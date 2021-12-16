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
	[ApiDescriptionSettings(Tag = "产品")]
	[Route("WJ/[controller]")]
	public class ProduceController : ControllerBase
	{
		private readonly ILogger<ProduceController> _logger;
		public IRepository<Produce> ProduceRepository { get; set; } = Db.GetRepository<Produce>();

		public ProduceController(ILogger<ProduceController> logger)
		{
			_logger = logger;
		}

		/// <summary>
		/// 获取所有产品
		/// </summary>
		/// <param name="Name">姓名</param>
		/// <returns></returns>
		public IEnumerable<Produce> GetList(string Name)
		{
			var result = ProduceRepository.Entities.AsQueryable();
			if (!Name.IsNullOrWhiteSpace())
				result = result.Where(wa => wa.Name.Contains(Name));
			UnifyContext.Fill(result.Count());
			return result;
		}

		/// <summary>
		/// 添加产品
		/// </summary>
		/// <param name="Produce">产品</param>
		/// <returns>产品Id</returns>
		public async Task<long> ProduceAdd(Produce Produce)
		{
			var result = await ProduceRepository.InsertNowAsync(Produce);
			return result.Entity.Id;
		}

		/// <summary>
		/// 修改产品信息
		/// </summary>
		/// <param name="Produce">产品</param>
		/// <returns>产品Id</returns>
		public async Task<long> ProduceUpdate(Produce Produce)
		{
			Produce.UpdatedTime = DateTime.Now;
			var result = await ProduceRepository.UpdateNowAsync(Produce);
			return result.Entity.Id;
		}
		
	}
}
