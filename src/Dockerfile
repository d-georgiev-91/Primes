FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["Primes.Services/Primes.Services.csproj", "Primes.Services/"]
COPY ["Primes.Web/Primes.Web.csproj", "Primes.Web/"]
RUN dotnet restore "Primes.Web/Primes.Web.csproj"
COPY . .
WORKDIR "/src/Primes.Web"
RUN dotnet build "Primes.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Primes.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Primes.Web.dll"]
