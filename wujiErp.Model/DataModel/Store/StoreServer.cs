using Furion.DatabaseAccessor;
using System.Linq;
using wujiErp.Model.DataModel.Store.Models;

namespace wujiErp.Model.DataModel.Store
{
	public class StoreServer : IStoreOperate
	{
		public IRepository<Order> OrderRepository { get; set; }
		public IQueryable<Order> Orders => OrderRepository.Entities;
	}
}