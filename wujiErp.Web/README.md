# 无忌ERP

### 数据库迁移命令

```
add-migration [Name]		#创建迁移

update-database [Name]		#应用迁移

script-migration [Name]		#生成迁移脚本

enable-migrations –EnableAutomaticMigration:$true #配置自动迁移
```


### docker-compose.yml
```
version: '3'
services:
    wujiErp:
        image: mcr.microsoft.com/dotnet/aspnet:6.0
        container_name: wujiErp
        restart: always
        ports:
            - 5210:5210   #自定义
        environment:
            ASPNETCORE_URLS: 'http://0.0.0.0:5210'   #自定义
        working_dir: '/wujiErp' #自定义
        volumes:
            - ./linux:/wujiErp  #自定义
        entrypoint: ["dotnet", "wujiErp.Web.dll"]
```