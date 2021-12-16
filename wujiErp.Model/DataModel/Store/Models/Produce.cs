using System;
using System.ComponentModel.DataAnnotations;
using Furion.DatabaseAccessor;

namespace wujiErp.Model.DataModel.Store.Models
{
	/// <summary>
	/// 产品
	/// </summary>
	public class Produce : Entity<long>
	{
		/// <summary>
		/// 商品名
		/// </summary>
		[Required]
		public string Name { get; set; }

		/// <summary>
		/// 规格
		/// </summary>
		[Required]
		public string Norm { get; set; }

		/// <summary>
		/// 快递
		/// </summary>
		public string Delivery { get; set; }

		/// <summary>
		/// 产地
		/// </summary>
		public string Source { get; set; }

		/// <summary>
		/// 零售价
		/// </summary>
		[Required]
		public double Price { get; set; }

		/// <summary>
		/// 成本价
		/// </summary>
		[Required]
		public double CostPrice { get; set; }

		/// <summary>
		/// 最近成交价
		/// </summary>
		public double LastPrice { get; set; }

		/// <summary>
		/// 备注
		/// </summary>
		public string Remark { get; set; }

		public Produce()
		{
			CreatedTime = DateTimeOffset.Now;
			UpdatedTime = DateTimeOffset.Now;
		}
	}
}