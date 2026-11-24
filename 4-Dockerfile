FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY . .
RUN rm -rf Company.DAL/Migrations \
 && mv Company.PL/Views/Shared/_Authlayout.cshtml Company.PL/Views/Shared/_AuthLayout.cshtml \
 && dotnet publish Company.PL/Company.PL.csproj -c Release -o /app
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app .
ENV ASPNETCORE_URLS=http://0.0.0.0:8080
CMD ["sh","-c","ASPNETCORE_URLS=http://0.0.0.0:${PORT:-8080} dotnet Company.PL.dll"]
