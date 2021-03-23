FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["MyShop.csproj", "./"]
RUN dotnet restore "MyShop.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "MyShop.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyShop.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet MyShop.dll
