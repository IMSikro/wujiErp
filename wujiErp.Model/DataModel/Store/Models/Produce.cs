using System;
using System.Collections.Generic;
using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;

namespace wujiErp.Model.DataModel.Store.Models;

/// <summary>
/// 产品
/// </summary>
public class Produce : BaseEntity, IEntitySeedData<Produce>
{
    /// <summary>
    /// 商品名
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 规格
    /// </summary>
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
    public double Price { get; set; }

    /// <summary>
    /// 成本价
    /// </summary>
    public double CostPrice { get; set; }

    /// <summary>
    /// 最近成交价
    /// </summary>
    public double LastPrice { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    public string Remark { get; set; }

    /// <summary>
    /// 构造函数
    /// </summary>
    public Produce()
    {
        CreatedTime = DateTime.UtcNow;
        IsDeleted = false;
    }


    // 配置种子数据
    public IEnumerable<Produce> HasData(DbContext dbContext, Type dbContextLocator)
    {
        return new List<Produce>
        {
            new Produce {
                Id = 1,
                Name = "昭通丑苹果",
                Norm = "5斤大果",
                Delivery = "德邦物流",
                Source = "云南昭通",
                Price = 50D,
                CostPrice = 15D,
                LastPrice = 50D,
                Remark = "又甜又脆很好吃"
            },
        };
    }
}