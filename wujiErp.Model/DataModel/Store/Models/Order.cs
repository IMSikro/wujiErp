using System;
using FreeSql.DataAnnotations;

namespace wujiErp.Model.DataModel.Store.Models
{
    /// <summary>
    /// 订单
    /// </summary>
    //[Table(Name = "Order_{yyyy}",AsTable = "CreatedTime=2022-1-1(1 year)")]
    public class Order
    {
        [Column(IsPrimary = true, IsIdentity = true)]
        public long Id { get; set; }
        /// <summary>
        /// 商品外键
        /// </summary>
        [Column(IsNullable = false)]
        public long ProductId { get; set; }

        [Navigate(nameof(ProductId))]
        public virtual Produce Produce { get; set; }

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
        /// 购买数量
        /// </summary>

        [Column(IsNullable = false)]
        public double Num { get; set; }

        /// <summary>
        /// 总价
        /// </summary>

        [Column(DbType = "decimal(18,4)", IsNullable = false)]
        public double TotalPrice { get; set; }

        /// <summary>
        /// 客户外键
        /// </summary>

        [Column(IsNullable = false)]
        public long CustomerId { get; set; }

        [Navigate(nameof(CustomerId))]
        public virtual Customer Customer { get; set; }

        /// <summary>
        /// 非常用地址
        /// </summary>
        [Column(DbType = "nvarchar(max)")]
        public string OtherAddr { get; set; }

        /// <summary>
        /// 快递单号
        /// </summary>
        [Column(StringLength = 50)]
        public string OrderCode { get; set; }

        /// <summary>
        /// 是否售后
        /// </summary>
        public bool IsAftersale { get; set; } = false;

        /// <summary>
        /// 售后价格
        /// </summary>
        [Column(DbType = "decimal(18,4)")]
        public double AftersalePrice { get; set; } = 0D;

        /// <summary>
        /// 利润
        /// </summary>
        public virtual double Profit
        {
            get
            {
                var money = Price - CostPrice;
                if (IsAftersale && AftersalePrice > 0D)
                    money += AftersalePrice;
                return money;
            }
        }

        /// <summary>
        /// 订单来源
        /// </summary>

        [Column(StringLength = 50, IsNullable = false)]
        public string OrderFrom { get; set; }

        /// <summary>
        /// 订单状态
        /// 0 => 进行中
        /// 1 => 已完成
        /// </summary>
        public int OrderStatus { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Column(DbType = "nvarchar(max)")]
        public string Remark { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Column(IsNullable = false)]
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? UpdatedTime { get; set; }

        public Order()
        {
            CreatedTime = DateTime.Now;
        }
    }
}