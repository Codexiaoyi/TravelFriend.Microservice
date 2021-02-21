#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Apigateways/TravelFriend.Gateway.Web/TravelFriend.Gateway.Web.csproj", "Apigateways/TravelFriend.Gateway.Web/"]
RUN dotnet restore "Apigateways/TravelFriend.Gateway.Web/TravelFriend.Gateway.Web.csproj"
COPY . .
WORKDIR "/src/Apigateways/TravelFriend.Gateway.Web"
RUN dotnet build "TravelFriend.Gateway.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TravelFriend.Gateway.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TravelFriend.Gateway.Web.dll"]