# 无忌ERP

## 介绍
> 无忌ERP

---
## 软件架构

    软件架构说明
    后端: .NET6(ASP.NET Core)
    前端: 暂时使用 React + Semi Design UI(抖音UI框架)

---
## 安装教程

> 已修改为docker镜像发布 `sikro/wujierp:latest`

```
cd /var/docker/files && \
mkdir -p wujiErp && \
cd wujiErp && \
curl -O https://gh.sikro.cf/https://raw.githubusercontent.com/IMSikro/wujiErp/master/docker-compose.yml && \
docker-compose pull && docker-compose build && \
docker-compose up -d && \
docker system prune --all --force --volumes
```
