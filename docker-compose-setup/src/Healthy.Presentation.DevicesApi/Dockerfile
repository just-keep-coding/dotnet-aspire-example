FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Healthy.Presentation.DevicesApi/Healthy.Presentation.DevicesApi.csproj", "src/Healthy.Presentation.DevicesApi/"]
COPY ["src/Healthy.CrossCuttingConcerns/Healthy.CrossCuttingConcerns.csproj", "src/Healthy.CrossCuttingConcerns/"]
COPY ["src/Healthy.Core.Application/Healthy.Core.Application.csproj", "src/Healthy.Core.Application/"]
COPY ["src/Healthy.Core.Domain/Healthy.Core.Domain.csproj", "src/Healthy.Core.Domain/"]
RUN dotnet restore "src/Healthy.Presentation.DevicesApi/Healthy.Presentation.DevicesApi.csproj"
COPY . .
WORKDIR "/src/src/Healthy.Presentation.DevicesApi"
RUN dotnet build "Healthy.Presentation.DevicesApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Healthy.Presentation.DevicesApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Healthy.Presentation.DevicesApi.dll"]
