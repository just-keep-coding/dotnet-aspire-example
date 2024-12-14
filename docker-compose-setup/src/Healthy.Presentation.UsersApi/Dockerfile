FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Healthy.Presentation.UsersApi/Healthy.Presentation.UsersApi.csproj", "src/Healthy.Presentation.UsersApi/"]
COPY ["src/Healthy.Core.Application/Healthy.Core.Application.csproj", "src/Healthy.Core.Application/"]
COPY ["src/Healthy.CrossCuttingConcerns/Healthy.CrossCuttingConcerns.csproj", "src/Healthy.CrossCuttingConcerns/"]
COPY ["src/Healthy.Core.Domain/Healthy.Core.Domain.csproj", "src/Healthy.Core.Domain/"]
COPY ["src/Healthy.Infrastructure.Database/Healthy.Infrastructure.Database.csproj", "src/Healthy.Infrastructure.Database/"]
RUN dotnet restore "src/Healthy.Presentation.UsersApi/Healthy.Presentation.UsersApi.csproj"
COPY . .
WORKDIR "/src/src/Healthy.Presentation.UsersApi"
RUN dotnet build "Healthy.Presentation.UsersApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Healthy.Presentation.UsersApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Healthy.Presentation.UsersApi.dll"]
