#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["HCL.APIGateway/HCL.APIGateway.csproj", "HCL.APIGateway/"]
RUN dotnet restore "HCL.APIGateway/HCL.APIGateway.csproj"
COPY . .
WORKDIR "/src/HCL.APIGateway"
RUN dotnet build "HCL.APIGateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HCL.APIGateway.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HCL.APIGateway.dll"]