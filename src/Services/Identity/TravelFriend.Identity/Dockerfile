#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Services/Identity/TravelFriend.Identity/TravelFriend.Identity.csproj", "Services/Identity/TravelFriend.Identity/"]
RUN dotnet restore "Services/Identity/TravelFriend.Identity/TravelFriend.Identity.csproj"
COPY . .
WORKDIR "/src/Services/Identity/TravelFriend.Identity"
RUN dotnet build "TravelFriend.Identity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TravelFriend.Identity.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TravelFriend.Identity.dll"]