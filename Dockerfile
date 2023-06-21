FROM mcr.microsoft.com/dotnet/aspnet:7.0.7-alpine3.18 AS base

FROM mcr.microsoft.com/dotnet/sdk:7.0.304-alpine3.18 AS publish
WORKDIR /wuji

COPY ["wujiErp.Model/","wujiErp.Model/"]
COPY ["wujiErp.Web/","wujiErp.Web/"]
WORKDIR "/wuji/wujiErp.Web"
RUN dotnet publish "wujiErp.Web.csproj" -c Release -o /wuji/publish

FROM node:16.17.0-alpine as build
WORKDIR /wuji

COPY ["wujiErp.React/","wujiErp.React/"]
WORKDIR "/wuji/wujiErp.React"
RUN yarn && yarn build

FROM base AS final
WORKDIR /wuji
EXPOSE 5210

ENV ASPNETCORE_URLS=http://0.0.0.0:5210
ENV TZ=Asia/Shanghai

COPY --from=publish /wuji/publish .
COPY --from=build /wuji/wujiErp.React/build ./wwwroot/
RUN cp -rf /usr/share/zoneinfo/${TZ} /etc/localtime && echo "${TZ}" > /etc/timezone
ENTRYPOINT ["dotnet", "wujiErp.Web.dll"]
