using FreeSql;
using Microsoft.AspNetCore.Builder;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Data;
using System.IO;
using System.Reflection;

namespace wujiErp.Model
{
    public static class FreeSqlSetup
    {

        /// <summary>
        /// 添加FreeSql引用
        /// (StartUp调用方法)
        /// </summary>
        public static void AddFreeSqlSetup(this IServiceCollection services, IConfiguration configuration, Assembly assembly, string dbName = "WujiSqlServerConnString")
        {
            var freeSql = new FreeSqlBuilder()
                .UseConnectionString(DataType.SqlServer, configuration.GetConnectionString(dbName))
                .CreateDatabaseIfNotExists()
                .UseAutoSyncStructure(true).Build();
            services.AddSingleton(freeSql); // 这边是FreeSqlBuilder用AddSingleton
            services.AddFreeRepository(
                    assemblies: assembly
                );
        }

        /// <summary>
        /// 添加FreeSql引用
        /// (.Net6 Program调用方法)
        /// </summary>
        public static WebApplicationBuilder AddFreeSqlSetup(this WebApplicationBuilder builder, Assembly assembly, string dbName = "WujiSqlServerConnString")
        {
            var services = builder.Services;
            var freeSql = new FreeSqlBuilder()
                .UseConnectionString(DataType.SqlServer, builder.Configuration.GetConnectionString(dbName))
                .CreateDatabaseIfNotExists()
                .UseAutoSyncStructure(true).Build();
            services.AddSingleton(freeSql); // 这边是FreeSqlBuilder用AddSingleton
            services.AddFreeRepository(
                    assemblies: assembly
                );
            return builder;
        }

        /// <summary>
        /// 请在UseConnectionString配置后调用此方法
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static FreeSqlBuilder CreateDatabaseIfNotExists(this FreeSqlBuilder @this)
        {
            FieldInfo dataTypeFieldInfo = @this.GetType().GetField("_dataType", BindingFlags.NonPublic | BindingFlags.Instance);

            if (dataTypeFieldInfo is null)
            {
                throw new ArgumentException("_dataType is null");
            }

            string connectionString = GetConnectionString(@this);
            DataType dbType = (DataType)dataTypeFieldInfo.GetValue(@this);

            switch (dbType)
            {
                case DataType.MySql:
                    break;
                case DataType.SqlServer:
                    return @this.CreateDatabaseIfNotExistsSqlServer(connectionString);
                case DataType.PostgreSQL:
                    break;
                case DataType.Oracle:
                    break;
                case DataType.Sqlite:
                    return @this;
                case DataType.OdbcOracle:
                    break;
                case DataType.OdbcSqlServer:
                    break;
                case DataType.OdbcMySql:
                    break;
                case DataType.OdbcPostgreSQL:
                    break;
                case DataType.Odbc:
                    break;
                case DataType.OdbcDameng:
                    break;
                case DataType.MsAccess:
                    break;
                case DataType.Dameng:
                    break;
                case DataType.OdbcKingbaseES:
                    break;
                case DataType.ShenTong:
                    break;
                case DataType.KingbaseES:
                    break;
                case DataType.Firebird:
                    break;
                default:
                    break;
            }
            //Log.Error($"不支持创建数据库");
            return @this;
        }

        private static string GetConnectionString(FreeSqlBuilder @this)
        {
            Type type = @this.GetType();
            FieldInfo fieldInfo = type.GetField("_masterConnectionString", BindingFlags.NonPublic | BindingFlags.Instance);
            if (fieldInfo is null)
            {
                throw new ArgumentException("_masterConnectionString is null");
            }
            return fieldInfo.GetValue(@this).ToString();
        }

        #region SqlServer
        public static FreeSqlBuilder CreateDatabaseIfNotExistsSqlServer(this FreeSqlBuilder @this, string connectionString = "")
        {
            if (connectionString == "")
            {
                connectionString = GetConnectionString(@this);
            }
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectionString);
            string createDatabaseSql;
            if (!string.IsNullOrEmpty(builder.AttachDBFilename))
            {
                string fileName = ExpandFileName(builder.AttachDBFilename);
                string name = Path.GetFileNameWithoutExtension(fileName);
                string logFileName = Path.ChangeExtension(fileName, ".ldf");
                createDatabaseSql = @$"CREATE DATABASE {builder.InitialCatalog}   on  primary   
                (
                    name = '{name}',
                    filename = '{fileName}'
                )
                log on
                (
                    name= '{name}_log',
                    filename = '{logFileName}'
                )";
            }
            else
            {
                createDatabaseSql = @$"CREATE DATABASE {builder.InitialCatalog}";
            }

            using SqlConnection cnn = new SqlConnection($"Data Source={builder.DataSource};User ID={builder.UserID};Password={builder.Password};Initial Catalog=master;Pooling=true;Min Pool Size=1");
            cnn.Open();
            using SqlCommand cmd = cnn.CreateCommand();
            cmd.CommandText = $"select * from sysdatabases where name = '{builder.InitialCatalog}'";

            SqlDataAdapter apter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            apter.Fill(ds);

            if (ds.Tables[0].Rows.Count == 0)
            {
                cmd.CommandText = createDatabaseSql;
                cmd.ExecuteNonQuery();
            }

            return @this;
        }

        private static string ExpandFileName(string fileName)
        {
            if (fileName.StartsWith("|DataDirectory|", StringComparison.OrdinalIgnoreCase))
            {
                var dataDirectory = AppDomain.CurrentDomain.GetData("DataDirectory") as string;
                if (string.IsNullOrEmpty(dataDirectory))
                {
                    dataDirectory = AppDomain.CurrentDomain.BaseDirectory;
                }
                string name = fileName.Replace("\\", "").Replace("/", "").Substring("|DataDirectory|".Length);
                fileName = Path.Combine(dataDirectory, name);
            }
            if (!Directory.Exists(Path.GetDirectoryName(fileName)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(fileName));
            }
            return Path.GetFullPath(fileName);
        }

        #endregion
    }

}
