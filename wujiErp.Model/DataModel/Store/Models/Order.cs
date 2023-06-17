using System;

namespace wujiErp.Model.DataModel.Store.Models;

/// <summary>
/// 订单
/// </summary>
public class Order
{
    public long Id { get; set; }

    /// <summary>
    /// 商品外键
    /// </summary>
    public long ProductId { get; set; }

    public virtual Produce Produce { get; set; }

    /// <summary>
    /// 零售价
    /// </summary>
    public double Price { get; set; }

    /// <summary>
    /// 成本价
    /// </summary>
    public double CostPrice { get; set; }

    /// <summary>
    /// 购买数量
    /// </summary>
    public double Num { get; set; }

    /// <summary>
    /// 总价
    /// </summary>
    public double TotalPrice { get; set; }

    /// <summary>
    /// 客户外键
    /// </summary>
    public long CustomerId { get; set; }

    public virtual Customer Customer { get; set; }

    /// <summary>
    /// 非常用地址
    /// </summary>
    public string OtherAddr { get; set; }

    /// <summary>
    /// 快递单号
    /// </summary>
    public string OrderCode { get; set; }

    /// <summary>
    /// 是否售后
    /// </summary>
    public bool IsAftersale { get; set; } = false;

    /// <summary>
    /// 售后价格
    /// </summary>
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
    public string Remark { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
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
