#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["AuthDemoBlazor.WebUI/AuthDemoBlazor.WebUI/AuthDemoBlazor.WebUI.csproj", "AuthDemoBlazor.WebUI/AuthDemoBlazor.WebUI/"]
COPY ["AuthDemoBlazor.Infrastructure/AuthDemoBlazor.Infrastructure.csproj", "AuthDemoBlazor.Infrastructure/"]
COPY ["AuthDemoBlazor.Application/AuthDemoBlazor.Application.csproj", "AuthDemoBlazor.Application/"]
COPY ["AuthDemoBlazor.Domain/AuthDemoBlazor.Domain.csproj", "AuthDemoBlazor.Domain/"]
COPY ["AuthDemoBlazor.WebUI/AuthDemoBlazor.WebUI.Client/AuthDemoBlazor.WebUI.Client.csproj", "AuthDemoBlazor.WebUI/AuthDemoBlazor.WebUI.Client/"]
RUN dotnet restore "./AuthDemoBlazor.WebUI/AuthDemoBlazor.WebUI/AuthDemoBlazor.WebUI.csproj"
COPY . .
WORKDIR "/src/AuthDemoBlazor.WebUI/AuthDemoBlazor.WebUI"
RUN dotnet build "./AuthDemoBlazor.WebUI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./AuthDemoBlazor.WebUI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AuthDemoBlazor.WebUI.dll"]