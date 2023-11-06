FROM mcr.microsoft.com/dotnet/aspnet:6.0 as base
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:8080

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
COPY . /src
WORKDIR /src
RUN ls
RUN dotnet build "books.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "books.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "books.dll"]