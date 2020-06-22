FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["TheMovie.Api/TheMovie.Api.csproj", "TheMovie.Api/"]
COPY ["TheMovie.Service/TheMovie.Service.csproj", "TheMovie.Service/"]
COPY ["TheMovie.Model/TheMovie.Model.csproj", "TheMovie.Model/"]
RUN dotnet restore "TheMovie.Api/TheMovie.Api.csproj"
COPY . .
WORKDIR "/src/TheMovie.Api"
RUN dotnet build "TheMovie.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TheMovie.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TheMovie.Api.dll"]