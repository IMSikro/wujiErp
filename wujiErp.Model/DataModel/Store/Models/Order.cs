using System;
using System.ComponentModel.DataAnnotations;
using Furion.DatabaseAccessor;

namespace wujiErp.Model.DataModel.Store.Models
{
	public class Order : Entity<int>
	{
		/// <summary>
		/// 订单号
		/// </summary>
		[Required]
		public string OrderCode { get; set; }

		/// <summary>
		/// 商品名
		/// </summary>
		[Required]
		public string Name { get; set; }

		/// <summary>
		/// 数量
		/// </summary>
		[Required,Range(0.00D, double.MaxValue)]
		public double Num { get; set; }
	}
}