#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Services/UserService/TravelFriend.UserService.Api/TravelFriend.UserService.Api.csproj", "Services/UserService/TravelFriend.UserService.Api/"]
RUN dotnet restore "Services/UserService/TravelFriend.UserService.Api/TravelFriend.UserService.Api.csproj"
COPY . .
WORKDIR "/src/Services/UserService/TravelFriend.UserService.Api"
RUN dotnet build "TravelFriend.UserService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TravelFriend.UserService.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TravelFriend.UserService.Api.dll"]