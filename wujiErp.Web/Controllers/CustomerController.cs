using FreeSql;
using Furion.UnifyResult;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Profiling.Internal;
using wujiErp.Model.DataModel.Store.Models;

namespace wujiErp.Web.Controllers
{
    [ApiDescriptionSettings(Tag = "客户")]
    [Route("WJ/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        public IBaseRepository<Customer> CustomerRepository { get; set; }

        public CustomerController(ILogger<CustomerController> logger, IBaseRepository<Customer> customerRepository)
        {
            _logger = logger;
            CustomerRepository = customerRepository;
        }

        /// <summary>
        /// 获取所有客户
        /// </summary>
        /// <param name="CustomerStr">姓名或手机号</param>
        /// <returns>客户列表</returns>
        public IEnumerable<Customer> GetList(string CustomerStr)
        {
            var result = CustomerRepository.Select;
            if (!CustomerStr.IsNullOrWhiteSpace())
                result = result.Where(wa => wa.Name.Contains(CustomerStr) || wa.Phone.Contains(CustomerStr));
            UnifyContext.Fill(result.Count());
            return result.ToList();
        }

        /// <summary>
        /// 添加客户
        /// </summary>
        /// <param name="customer">客户</param>
        /// <returns>客户Id</returns>
        public async Task<long> CustomerAdd(Customer customer)
        {
            var tran = CustomerRepository.UnitOfWork.GetOrBeginTransaction();
            var result = await CustomerRepository.InsertAsync(customer);
            tran.Commit();
            return result.Id;
        }

        /// <summary>
        /// 修改客户信息
        /// </summary>
        /// <param name="customer">客户</param>
        /// <returns>客户Id</returns>
        public async Task<long> CustomerUpdate(Customer customer)
        {
            var tran = CustomerRepository.UnitOfWork.GetOrBeginTransaction();
            customer.UpdatedTime = DateTime.Now;
            var result = await CustomerRepository.UpdateAsync(customer);
            tran.Commit();
            return result > 0 ? customer.Id : 0;
        }

    }
}
