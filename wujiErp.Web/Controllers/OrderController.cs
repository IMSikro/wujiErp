using System.Collections.Generic;
using System.Threading.Tasks;
using FreeSql;
using Furion.UnifyResult;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StackExchange.Profiling.Internal;
using wujiErp.Model.DataModel.Store.Models;

namespace wujiErp.Web.Controllers
{
    [ApiDescriptionSettings(Tag = "订单")]
    [Route("WJ/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        public IBaseRepository<Order> OrderRepository { get; set; }
        public IBaseRepository<Customer> CustomerRepository { get; set; }

        public OrderController(ILogger<OrderController> logger, IBaseRepository<Order> orderRepository, IBaseRepository<Customer> customerRepository)
        {
            _logger = logger;
            OrderRepository = orderRepository;
            CustomerRepository = customerRepository;
        }

        /// <summary>
        /// 获取所有订单
        /// </summary>
        /// <param name="OrderCode">快递单号</param>
        /// <param name="CustomerInfo">客户姓名或手机号</param>
        /// <param name="ProduceName">产品名称</param>
        /// <returns></returns>
        public IEnumerable<Order> GetList([FromQuery] string OrderCode, string CustomerInfo, string ProduceName)
        {
            var result = OrderRepository.Select.Include(wa => wa.Customer).Include(wa => wa.Produce);
            if (!OrderCode.IsNullOrWhiteSpace())
                result = result.Where(wa => wa.OrderCode.ToLower().Contains(OrderCode.ToLower()));
            if (!CustomerInfo.IsNullOrWhiteSpace())
                result = result.Where(wa => wa.Customer.Name.ToLower().Contains(CustomerInfo.ToLower()) || wa.Customer.Phone.ToLower().Contains(CustomerInfo.ToLower()));
            if (!ProduceName.IsNullOrWhiteSpace())
                result = result.Where(wa => wa.Produce.Name.ToLower().Contains(ProduceName.ToLower()));
            UnifyContext.Fill(result.Count());
            return result.ToList();
        }

        /// <summary>
        /// 添加订单
        /// </summary>
        /// <param name="order">订单</param>
        /// <returns>订单Id</returns>
        public async Task<long> OrderAdd(Order order)
        {
            var tran = OrderRepository.UnitOfWork.GetOrBeginTransaction();
            var result = await OrderRepository.InsertAsync(order);
            var customer = CustomerRepository.Where(wa => wa.Id == order.CustomerId).First();
            if (customer != null)
            {
                customer.LastOrderTime = order.CreatedTime;
                await CustomerRepository.UpdateAsync(customer);
            }
            tran.Commit();
            return result.Id;
        }

        /// <summary>
        /// 修改订单
        /// </summary>
        /// <param name="order">订单</param>
        /// <returns>订单Id</returns>
        public async Task<long> OrderUpdate(Order order)
        {
            var tran = OrderRepository.UnitOfWork.GetOrBeginTransaction();
            var result = await OrderRepository.UpdateAsync(order);
            tran.Commit();
            return result > 0 ? order.Id : 0;
        }

        /// <summary>
        /// 订单详情
        /// </summary>
        /// <param name="Id">订单编号</param>
        /// <returns></returns>
        public Order OrderDetail(int? Id)
        {
            if (!Id.HasValue) return null;
            var result = OrderRepository.Where(wa => wa.Id == Id).First();
            return result;
        }

    }
}
