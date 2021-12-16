using System;
using System.ComponentModel.DataAnnotations;
using Furion.DatabaseAccessor;

namespace wujiErp.Model.DataModel.Store.Models
{
	/// <summary>
	/// 客户
	/// </summary>
	public class Customer : Entity<long>
	{
		/// <summary>
		/// 姓名
		/// </summary>
		[Required]
		public string Name { get; set; }

		/// <summary>
		/// 电话
		/// </summary>
		[Required]
		public string Phone { get; set; }

		/// <summary>
		/// 地址
		/// </summary>
		[Required]
		public string Addr { get; set; }

		/// <summary>
		/// 来源
		/// </summary>
		public string WhereFrom { get; set; }

		/// <summary>
		/// 微信号
		/// </summary>
		public string WechatCode { get; set; }

		/// <summary>
		/// 喜好
		/// </summary>
		public string Love { get; set; }

		/// <summary>
		/// 喜好
		/// </summary>
		public DateTimeOffset? LastOrderTime { get; set; }

		public Customer()
		{
			CreatedTime = DateTimeOffset.Now;
			UpdatedTime = DateTimeOffset.Now;
		}
	}
}