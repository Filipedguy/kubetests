FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY SystemDataAPI.Application/SystemDataAPI.Application.csproj SystemDataAPI.Application/
RUN dotnet restore SystemDataAPI.Application/SystemDataAPI.Application.csproj
COPY . .
WORKDIR /src/SystemDataAPI.Application
RUN dotnet build SystemDataAPI.Application.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish SystemDataAPI.Application.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SystemDataAPI.Application.dll"]
