FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim as base

WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster as build

WORKDIR /src

COPY . .

RUN dotnet restore "DevFreela.API/DevFreela.API.csproj"

WORKDIR "/src/DevFreela.API"

RUN ls

RUN dotnet build "DevFreela.API.csproj" -c Release -o /DevFreela.API

FROM build AS publish
RUN dotnet publish "DevFreela.API.csproj" -c Release -o /DevFreela.API

FROM base AS final

WORKDIR /DevFreela.API

COPY --from=publish /DevFreela.API .

ENTRYPOINT ["dotnet","DevFreela.API.dll"]