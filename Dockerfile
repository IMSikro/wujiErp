FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS publish
WORKDIR /publish

COPY ["wujiErp.Model/","wujiErp.Model/"]
COPY ["wujiErp.Web/","wujiErp.Web/"]
WORKDIR "/publish/wujiErp.Web"
RUN dotnet publish "wujiErp.Web.csproj" -c Release -o /publish/wuji

FROM node:lts-bullseye as build
WORKDIR /wuji

COPY ["wujiErp.React/","wujiErp.React/"]
WORKDIR "/wuji/wujiErp.React"
RUN yarn && yarn build

FROM base AS final
WORKDIR /wuji
EXPOSE 5210

ENV ASPNETCORE_URLS=http://0.0.0.0:5210
ENV TZ=Asia/Shanghai

COPY --from=publish /publish/wuji .
COPY --from=build /wuji/wujiErp.React/build ./wwwroot
RUN cp -rf /usr/share/zoneinfo/${TZ} /etc/localtime && echo "${TZ}" > /etc/timezone
ENTRYPOINT ["dotnet", "wujiErp.Web.dll"]
