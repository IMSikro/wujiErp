using System;

namespace wujiErp.Model.DataModel.Store.Models;

/// <summary>
/// 产品
/// </summary>
public class Produce
{
    public long Id { get; set; }

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
    /// 创建时间
    /// </summary>
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