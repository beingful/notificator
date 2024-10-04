FROM mcr.microsoft.com/dotnet/sdk:8.0 as restore
WORKDIR /src
COPY ./*.sln .
COPY ./Notificator.Api/*.csproj ./Notificator.Api/
RUN dotnet restore