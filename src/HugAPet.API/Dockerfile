FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/HugAPet.API/HugAPet.API.csproj", "src/HugAPet.API/"]
RUN dotnet restore "src/HugAPet.API/HugAPet.API.csproj"
COPY . .
WORKDIR "/src/src/HugAPet.API"
RUN dotnet build "HugAPet.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HugAPet.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HugAPet.API.dll"]
