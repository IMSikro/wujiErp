using Furion.DatabaseAccessor;
using Furion.UnifyResult;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StackExchange.Profiling.Internal;
using wujiErp.Model.DataModel.Store.Models;

namespace wujiErp.Web.Controllers
{
    [ApiDescriptionSettings(Tag = "订单")]
    [Route("WJ/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        public IRepository<Order> OrderRepository { get; set; }
        public IRepository<Customer> CustomerRepository { get; set; }

        public OrderController(ILogger<OrderController> logger, IRepository<Order> orderRepository, IRepository<Customer> customerRepository)
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
            var result = OrderRepository.Include(wa => wa.Customer).Include(wa => wa.Produce).AsQueryable();
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
        [UnitOfWork]
        public async Task<long> OrderAdd(Order order)
        {
            var result = await OrderRepository.InsertAsync(order);
            var customer = CustomerRepository.Where(wa => wa.Id == order.CustomerId).First();
            if (customer != null)
            {
                customer.LastOrderTime = order.CreatedTime;
                await CustomerRepository.UpdateAsync(customer);
            }
            return result.State == EntityState.Added ? order.Id : 0;
        }

        /// <summary>
        /// 修改订单
        /// </summary>
        /// <param name="order">订单</param>
        /// <returns>订单Id</returns>
        [UnitOfWork]
        public async Task<long> OrderUpdate(Order order)
        {
            var result = await OrderRepository.UpdateAsync(order);
            return result.State == EntityState.Modified ? order.Id : 0;
        }

        /// <summary>
        /// 订单详情
        /// </summary>
        /// <param name="Id">订单编号</param>
        /// <returns></returns>
        public Order OrderDetail(int? Id)
        {
            if (!Id.HasValue) return null;
            var result = OrderRepository.FirstOrDefault(wa => wa.Id == Id);
            return result;
        }

    }
}
