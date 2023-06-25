using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations;
using System;
using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace wujiErp.Model.DataModel.Store.Models;

/// <summary>
/// 客户
/// </summary>
public class Customer : BaseEntity, IEntitySeedData<Customer>
{
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

    // 配置种子数据
    public IEnumerable<Customer> HasData(DbContext dbContext, Type dbContextLocator)
    {
        return new List<Customer>
        {
            new Customer {
                Id = 1,
                Name = "张文静",
                Phone = "13952401683",
                Addr = "江苏省苏州市姑苏区东汇路187号 2-103",
                WhereFrom = "微信",
                WechatCode="violame",
                Love="水果",
                LastOrderTime = DateTime.UtcNow
            },
        };
    }
}
