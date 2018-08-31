FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80
COPY SystemDataAPI.Application/publish/* ./
ENTRYPOINT ["dotnet", "SystemDataAPI.Application.dll"]
