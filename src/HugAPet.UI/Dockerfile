FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/HugAPet.UI/HugAPet.UI.csproj", "src/HugAPet.UI/"]
RUN dotnet restore "src/HugAPet.UI/HugAPet.UI.csproj"
COPY . .
WORKDIR "/src/src/HugAPet.UI"
RUN dotnet build "HugAPet.UI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HugAPet.UI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HugAPet.UI.dll"]
