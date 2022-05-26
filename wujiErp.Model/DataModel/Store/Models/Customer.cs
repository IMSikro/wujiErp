using System;
using FreeSql.DataAnnotations;

namespace wujiErp.Model.DataModel.Store.Models
{
    /// <summary>
    /// 客户
    /// </summary>
    //[Table(Name = "Customer_{yyyy}", AsTable = "CreatedTime=2022-1-1(1 year)")]
    public class Customer
    {
        [Column(IsPrimary = true, IsIdentity = true)]
        public long Id { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        [Column(StringLength = 50, IsNullable = false)]
        public string Name { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        [Column(StringLength = 20, IsNullable = false)]
        public string Phone { get; set; }

        /// <summary>
        /// 地址
        /// </summary>

        [Column(DbType = "nvarchar(max)", IsNullable = false)]
        public string Addr { get; set; }

        /// <summary>
        /// 来源
        /// </summary>
        [Column(StringLength = 50)]
        public string WhereFrom { get; set; }

        /// <summary>
        /// 微信号
        /// </summary>
        [Column(StringLength = 50)]
        public string WechatCode { get; set; }

        /// <summary>
        /// 喜好
        /// </summary>
        [Column(StringLength = 50)]
        public string Love { get; set; }

        /// <summary>
        /// 最后下单时间
        /// </summary>
        public DateTime? LastOrderTime { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Column(IsNullable = false)]
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? UpdatedTime { get; set; }

        public Customer()
        {
            CreatedTime = DateTime.Now;
        }
    }
}