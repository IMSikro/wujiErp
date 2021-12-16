using Furion.DatabaseAccessor;
using Furion.UnifyResult;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StackExchange.Profiling.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wujiErp.Model.DataModel.Store.Models;

namespace wujiErp.Web.Controllers
{
	[ApiDescriptionSettings(Tag = "客户")]
	[Route("WJ/[controller]")]
	public class CustomerController : ControllerBase
	{
		private readonly ILogger<CustomerController> _logger;
		public IRepository<Customer> CustomerRepository { get; set; } = Db.GetRepository<Customer>();

		public CustomerController(ILogger<CustomerController> logger)
		{
			_logger = logger;
		}

		/// <summary>
		/// 获取所有客户
		/// </summary>
		/// <param name="Name">姓名</param>
		/// <returns></returns>
		public IEnumerable<Customer> GetList(string Name)
		{
			var result = CustomerRepository.Entities.AsQueryable();
			if (!Name.IsNullOrWhiteSpace())
				result = result.Where(wa => wa.Name.Contains(Name));
			UnifyContext.Fill(result.Count());
			return result;
		}

		/// <summary>
		/// 添加客户
		/// </summary>
		/// <param name="customer">客户</param>
		/// <returns>客户Id</returns>
		public async Task<long> CustomerAdd(Customer customer)
		{
			var result = await CustomerRepository.InsertNowAsync(customer);
			return result.Entity.Id;
		}
		
		/// <summary>
		/// 修改客户信息
		/// </summary>
		/// <param name="customer">客户</param>
		/// <returns>客户Id</returns>
		public async Task<long> CustomerUpdate(Customer customer)
		{
			customer.UpdatedTime = DateTime.Now;
			var result = await CustomerRepository.UpdateNowAsync(customer);
			return result.Entity.Id;
		}
		
	}
}
