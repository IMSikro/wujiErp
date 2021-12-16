# 无忌ERP

### 数据库迁移命令

```
add-migration Name			#创建迁移

update-database [Name]		#应用迁移


script-migration [Name]		#生成迁移脚本
```


### docker-compose.yml
```
version: '3'
services:
    wujiErp:
        image: mcr.microsoft.com/dotnet/aspnet:5.0
        container_name: wujiErp
        restart: always
        ports:
            - 520:520   #自定义
        environment:
            ASPNETCORE_URLS: 'http://0.0.0.0:520'   #自定义
        working_dir: '/app' #自定义
        volumes:
            - ./linux:/app  #自定义
        entrypoint: ["dotnet", "wujiErp.Web.dll"]
```