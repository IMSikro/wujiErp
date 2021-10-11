using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Furion.DynamicApiController;
using Microsoft.Extensions.Logging;
using wujiErp.Web.Controllers;

namespace wujiErp.Web.Areas.Api.Controllers
{
	[ApiDescriptionSettings(Tag = "数值")]
	[DynamicApiController]
	[Route("WJ/[controller]")]
	public class ValuesController
	{

		private readonly ILogger<ValuesController> _logger;

		public ValuesController(ILogger<ValuesController> logger)
		{
			_logger = logger;
		}

		/// <summary>
		/// 给我一组随机数
		/// </summary>
		/// <returns></returns>
		public IEnumerable<int> GetIndex()
		{
			var r = new Random();
			return Enumerable.Range(1, 5).Select(i => r.Next(50));
		}

		/// <summary>
		/// 给我一组随机数
		/// </summary>
		/// <returns></returns>
		public IEnumerable<int> PostList()
		{
			var r = new Random();
			return Enumerable.Range(1, 5).Select(i => r.Next(50));
		}
	}
}
