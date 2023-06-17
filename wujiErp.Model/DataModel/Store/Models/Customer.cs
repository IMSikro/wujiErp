﻿using System;

namespace wujiErp.Model.DataModel.Store.Models;

/// <summary>
/// 客户
/// </summary>
public class Customer
{
    public long Id { get; set; }
    /// <summary>
    /// 姓名
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 电话
    /// </summary>
    public string Phone { get; set; }

    /// <summary>
    /// 地址
    /// </summary>
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
    /// 最后下单时间
    /// </summary>
    public DateTime? LastOrderTime { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
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
