ARG IMAGE
ARG BUILD_ID

FROM ${IMAGE}:build-${BUILD_ID}
ARG BUILD_CONFIGURATION
RUN dotnet publish --no-build ./Notificator.Api/*.csproj -c ${BUILD_CONFIGURATION} -o /app/publish /p:UseAppHost=false