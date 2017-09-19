FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS builder
WORKDIR /src
COPY *.sln ./
COPY ContosoAir.Site/ContosoAir.Site.csproj ContosoAir.Site/
COPY ContosoAir.Data/ContosoAir.Data.csproj ContosoAir.Data/
RUN dotnet restore
COPY . .
WORKDIR /src/ContosoAir.Site
RUN npm install -v
RUN npm run prod
RUN dotnet build -c Release -o /app

FROM builder AS publish
RUN dotnet publish -c Release -o /app

FROM base AS production
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ContosoAir.Site.dll"]
