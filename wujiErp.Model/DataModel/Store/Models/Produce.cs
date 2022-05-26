using System;
using FreeSql.DataAnnotations;

namespace wujiErp.Model.DataModel.Store.Models
{
    /// <summary>
    /// 产品
    /// </summary>
    //[Table(Name = "Produce_{yyyy}",AsTable = "CreatedTime=2022-1-1(1 year)")]
    public class Produce
    {
        [Column(IsPrimary = true, IsIdentity = true)]
        public long Id { get; set; }

        /// <summary>
        /// 商品名
        /// </summary>
        [Column(StringLength = 100, IsNullable = false)]
        public string Name { get; set; }

        /// <summary>
        /// 规格
        /// </summary>
        [Column(StringLength = 200, IsNullable = false)]
        public string Norm { get; set; }

        /// <summary>
        /// 快递
        /// </summary>
        [Column(StringLength = 50)]
        public string Delivery { get; set; }

        /// <summary>
        /// 产地
        /// </summary>
        [Column(StringLength = 100)]
        public string Source { get; set; }

        /// <summary>
        /// 零售价
        /// </summary>
        [Column(DbType = "decimal(18,4)", IsNullable = false)]
        public double Price { get; set; }

        /// <summary>
        /// 成本价
        /// </summary>
        [Column(DbType = "decimal(18,4)", IsNullable = false)]
        public double CostPrice { get; set; }

        /// <summary>
        /// 最近成交价
        /// </summary>
        [Column(DbType = "decimal(18,4)")]
        public double LastPrice { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Column(DbType = "nvarchar(max)")]
        public string Remark { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Column(IsNullable = false, CanUpdate = false, ServerTime = DateTimeKind.Local)]
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? UpdatedTime { get; set; }

        public Produce()
        {
            CreatedTime = DateTime.Now;
        }
    }
}