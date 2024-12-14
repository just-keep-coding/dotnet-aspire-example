FROM mcr.microsoft.com/dotnet/runtime:9.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Healthy.Presentation.Worker/Healthy.Presentation.Worker.csproj", "src/Healthy.Presentation.Worker/"]
COPY ["src/Healthy.CrossCuttingConcerns/Healthy.CrossCuttingConcerns.csproj", "src/Healthy.CrossCuttingConcerns/"]
COPY ["src/Healthy.Infrastructure.Database/Healthy.Infrastructure.Database.csproj", "src/Healthy.Infrastructure.Database/"]
COPY ["src/Healthy.Core.Domain/Healthy.Core.Domain.csproj", "src/Healthy.Core.Domain/"]
COPY ["src/Healthy.Core.Application/Healthy.Core.Application.csproj", "src/Healthy.Core.Application/"]
RUN dotnet restore "src/Healthy.Presentation.Worker/Healthy.Presentation.Worker.csproj"
COPY . .
WORKDIR "/src/src/Healthy.Presentation.Worker"
RUN dotnet build "Healthy.Presentation.Worker.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Healthy.Presentation.Worker.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Healthy.Presentation.Worker.dll"]
