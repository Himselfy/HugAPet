FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/HugAPet.UserManagement/HugAPet.UserManagement.csproj", "src/HugAPet.UserManagement/"]
RUN dotnet restore "src/HugAPet.UserManagement/HugAPet.UserManagement.csproj"
COPY . .
WORKDIR "/src/src/HugAPet.UserManagement"
RUN dotnet build "HugAPet.UserManagement.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HugAPet.UserManagement.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HugAPet.UserManagement.dll"]
