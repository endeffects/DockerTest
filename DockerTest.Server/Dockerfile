FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app

EXPOSE 56800

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src

COPY ["DockerTest.Server/DockerTest.Server.csproj", "DockerTest.Server/"]
COPY ["DockerTest.Client/DockerTest.Client.csproj", "DockerTest.Client/"]

RUN dotnet restore "DockerTest.Server/DockerTest.Server.csproj"
COPY . .

WORKDIR "/src/DockerTest.Server"
RUN dotnet build "DockerTest.Server.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "DockerTest.Server.csproj" -c Release -o /app
#RUN dotnet publish "DockerTest.Server.csproj" -c Release -o /app/release

FROM base AS final
WORKDIR /app

COPY --from=publish /app .
#COPY --from=publish /app/release .

ENTRYPOINT ["dotnet", "DockerTest.Server.dll"]