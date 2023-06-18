using System;
using Furion.DatabaseAccessor;

namespace wujiErp.Model.DataModel.Store.Models;

/// <summary>
/// 产品
/// </summary>
public class Produce : Entity<long>
{
    /// <summary>
    /// 是否逻辑删除
    /// </summary>
    public bool IsDeleted { get; set; }

    /// <summary>
    /// 构造函数
    /// </summary>
    public Produce()
    {
        CreatedTime = DateTime.Now;
        IsDeleted = false;
    }

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

}