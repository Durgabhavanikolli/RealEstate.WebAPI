#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["RealEstate.WebAPI/RealEstate.WebAPI.csproj", "RealEstate.WebAPI/"]
RUN dotnet restore "RealEstate.WebAPI/RealEstate.WebAPI.csproj"
COPY . .
WORKDIR "/src/RealEstate.WebAPI"
RUN dotnet build "RealEstate.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RealEstate.WebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RealEstate.WebAPI.dll"]