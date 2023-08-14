# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/aspnet:7.0.10-alpine3.18 AS base

FROM --platform=amd64 mcr.microsoft.com/dotnet/sdk:7.0.400-bullseye-slim AS build
WORKDIR /wuji
COPY ["wujiErp.Model/","wujiErp.Model/"]
COPY ["wujiErp.ModelMigragions/","wujiErp.ModelMigragions/"]
COPY ["wujiErp.Web/","wujiErp.Web/"]
WORKDIR "/wuji/wujiErp.Web"
# RUN dotnet publish "wujiErp.Web.csproj" -c Release -o /wuji/publish
RUN dotnet publish "wujiErp.Web.csproj" -r linux-x64 --sc false -c Release -o /wuji/publish/amd64; dotnet publish "wujiErp.Web.csproj" -r linux-arm --sc false -c Release -o /wuji/publish/arm; dotnet publish "wujiErp.Web.csproj" -r linux-arm64 --sc false -c Release -o /wuji/publish/arm64

FROM --platform=amd64 node:16.17.0-bullseye as react
WORKDIR /wuji
COPY wujiErp.React/package.json ./package.json
RUN yarn 
COPY wujiErp.React/ .
RUN yarn build

FROM base AS final
ARG TARGETPLATFORM
# RUN echo "$TARGETPLATFORM"
WORKDIR /wuji
COPY --from=build /wuji/publish/ /publish/
COPY docker_copyfile.sh /cpfile/
RUN chmod +x /cpfile/docker_copyfile.sh
SHELL [ "/bin/ash" ]
RUN /cpfile/docker_copyfile.sh
COPY --from=react /wuji/build/ ./wwwroot/

ENV ASPNETCORE_URLS=http://0.0.0.0:5210
ENV TZ=Asia/Shanghai

SHELL [ "/bin/ash", "-c" ]
RUN rm -rf /cpfile
# RUN tree /wuji
RUN chmod +x /wuji/wujiErp.Web
# alpine镜像添加上海时区
RUN apk add --no-cache tzdata; \
    cp /usr/share/zoneinfo/${TZ} /etc/localtime; \
    echo "${TZ}" > /etc/timezone; \
    apk del tzdata;

EXPOSE 5210

ENTRYPOINT ["dotnet", "wujiErp.Web.dll"]
