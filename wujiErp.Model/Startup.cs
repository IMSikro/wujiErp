using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Furion;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using wujiErp.Model.DBContext;

namespace wujiErp.Model
{
	public class Startup : AppStartup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			TypeAdapterConfig.GlobalSettings.Default.PreserveReference(true)
				.AddDestinationTransform(DestinationTransform.EmptyCollectionIfNull);

			services.AddDatabaseAccessor(op =>
			{
				op.AddDbPool<WujiContext>();
			}, "wujiErp.Migrations");
		}
    }
}
