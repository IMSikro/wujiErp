using System;
using System.Collections.Generic;
using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;

namespace wujiErp.Model.DataModel.Store.Models;

/// <summary>
/// 订单
/// </summary>
public class Order : BaseEntity, IEntitySeedData<Order>
{

    /// <summary>
    /// 商品外键
    /// </summary>
    public int ProduceId { get; set; }

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
    public int CustomerId { get; set; }

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

    public Order()
    {
        CreatedTime = DateTime.UtcNow;
        IsDeleted = false;
    }


    // 配置种子数据
    public IEnumerable<Order> HasData(DbContext dbContext, Type dbContextLocator)
    {
        return new List<Order>
        {
            new Order {
                Id = 1,
                ProduceId = 1,
                Price = 50D,
                CostPrice = 15D,
                Num = 1,
                TotalPrice = 50D,
                CustomerId = 1,
                OtherAddr = "",
                OrderCode = "SF15645648951516554",
                IsAftersale = false,
                AftersalePrice = 0D,
                OrderFrom = "微信",
                OrderStatus = 1,
                Remark = "好评"
            },
        };
    }
}
