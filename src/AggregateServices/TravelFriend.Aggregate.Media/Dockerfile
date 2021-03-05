#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["AggregateServices/TravelFriend.Aggregate.Media/TravelFriend.Aggregate.Media.csproj", "AggregateServices/TravelFriend.Aggregate.Media/"]
RUN dotnet restore "AggregateServices/TravelFriend.Aggregate.Media/TravelFriend.Aggregate.Media.csproj"
COPY . .
WORKDIR "/src/AggregateServices/TravelFriend.Aggregate.Media"
RUN dotnet build "TravelFriend.Aggregate.Media.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TravelFriend.Aggregate.Media.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TravelFriend.Aggregate.Media.dll"]