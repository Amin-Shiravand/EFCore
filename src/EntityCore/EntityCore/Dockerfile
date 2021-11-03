#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["EntityCore/EntityCore/EntityCore.csproj", "EntityCore/EntityCore/"]
COPY ["EntityCore/EntityCoreDataAceess/EntityCoreDataAceess.csproj", "EntityCore/EntityCoreDataAceess/"]
COPY ["EntityCore/EntityCoreModel/EntityCoreModel.csproj", "EntityCore/EntityCoreModel/"]
RUN dotnet restore "EntityCore/EntityCore/EntityCore.csproj"
COPY . .
WORKDIR "/src/EntityCore/EntityCore"
RUN dotnet build "EntityCore.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EntityCore.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EntityCore.dll"]
