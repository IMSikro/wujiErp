using Furion.DatabaseAccessor;
using Furion.UnifyResult;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StackExchange.Profiling.Internal;
using wujiErp.Model.DataModel.Store.Models;

namespace wujiErp.Web.Controllers
{
    [ApiDescriptionSettings(Tag = "产品")]
    [Route("WJ/[controller]")]
    public class ProduceController : ControllerBase
    {
        private readonly ILogger<ProduceController> _logger;
        public IRepository<Produce> ProduceRepository { get; set; }

        public ProduceController(ILogger<ProduceController> logger, IRepository<Produce> produceRepository)
        {
            _logger = logger;
            ProduceRepository = produceRepository;
        }

        /// <summary>
        /// 获取所有产品
        /// </summary>
        /// <param name="Name">姓名</param>
        /// <returns></returns>
        public IEnumerable<Produce> GetList(string Name)
        {
            var result = ProduceRepository.AsQueryable();
            if (!Name.IsNullOrWhiteSpace())
                result = result.Where(wa => wa.Name.Contains(Name));
            UnifyContext.Fill(result.Count());
            return result.ToList();
        }

        /// <summary>
        /// 添加产品
        /// </summary>
        /// <param name="Produce">产品</param>
        /// <returns>产品Id</returns>
        [UnitOfWork]
        public async Task<long> ProduceAdd(Produce Produce)
        {
            var result = await ProduceRepository.InsertAsync(Produce);
            return result.State == EntityState.Added ? Produce.Id : 0;

        }

        /// <summary>
        /// 修改产品信息
        /// </summary>
        /// <param name="Produce">产品</param>
        /// <returns>产品Id</returns>
        [UnitOfWork]
        public async Task<long> ProduceUpdate(Produce Produce)
        {
            Produce.UpdatedTime = DateTime.Now;
            var result = await ProduceRepository.UpdateAsync(Produce);
            return result.State == EntityState.Modified ? Produce.Id : 0;
        }

        /// <summary>
        /// 产品详情
        /// </summary>
        /// <param name="Id">产品Id</param>
        /// <returns></returns>
        public Produce ProduceDetail(int? Id)
        {
            if (!Id.HasValue) return null;
            var result = ProduceRepository.FirstOrDefault(wa => wa.Id == Id);
            return result;
        }

        /// <summary>
        /// 删除产品
        /// </summary>
        /// <param name="Id">产品Id</param>
        /// <returns></returns>
        [UnitOfWork]
        public async Task<int> ProduceDelete(int? Id)
        {
            if (!Id.HasValue) return 0;
            await ProduceRepository.DeleteNowAsync(Id);
            return Id.Value;
        }


    }
}
