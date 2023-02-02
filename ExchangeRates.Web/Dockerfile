FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ExchangeRates.Web/ExchangeRates.Web.csproj", "ExchangeRates.Web/"]
RUN dotnet restore "ExchangeRates.Web/ExchangeRates.Web.csproj"
COPY . .
WORKDIR "/src/ExchangeRates.Web"
RUN dotnet build "ExchangeRates.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ExchangeRates.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ExchangeRates.Web.dll"]
