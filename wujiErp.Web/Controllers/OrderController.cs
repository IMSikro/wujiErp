using Furion.DatabaseAccessor;
using Furion.UnifyResult;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StackExchange.Profiling.Internal;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wujiErp.Model.DataModel.Store.Models;

namespace wujiErp.Web.Controllers
{
	[ApiDescriptionSettings(Tag = "订单")]
	[Route("WJ/[controller]")]
	public class OrderController : ControllerBase
	{
		private readonly ILogger<OrderController> _logger;
		public IRepository<Order> OrderRepository { get; set; } = Db.GetRepository<Order>();

		public OrderController(ILogger<OrderController> logger)
		{
			_logger = logger;
		}

		/// <summary>
		/// 获取所有订单
		/// </summary>
		/// <param name="OrderCode">快递单号</param>
		/// <param name="CustomerName">客户姓名</param>
		/// <param name="ProduceName">产品名称</param>
		/// <returns></returns>
		public IEnumerable<Order> GetList([FromQuery] string OrderCode,string CustomerName,string ProduceName)
		{
			var result = OrderRepository.Entities.Include(wa => wa.Produce).Include(wa => wa.Customer).AsQueryable();
			if (!OrderCode.IsNullOrWhiteSpace())
				result = result.Where(wa => wa.OrderCode.ToLower().Contains(OrderCode.ToLower()));
			if (!CustomerName.IsNullOrWhiteSpace())
				result = result.Where(wa => wa.Customer.Name.ToLower().Contains(CustomerName.ToLower()));
			if (!ProduceName.IsNullOrWhiteSpace())
				result = result.Where(wa => wa.Produce.Name.ToLower().Contains(ProduceName.ToLower()));
			UnifyContext.Fill(result.Count());
			return result;
		}
		
		/// <summary>
		/// 添加订单
		/// </summary>
		/// <param name="order">订单</param>
		/// <returns>订单Id</returns>
		public async Task<long> OrderAdd(Order order)
		{
			var result = await OrderRepository.InsertNowAsync(order);
			if (result.IsKeySet)
				return result.Entity.Id;
			return 0;
		}
		
	}
}
