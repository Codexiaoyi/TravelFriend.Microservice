#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["AggregateServices/TravelFriend.Aggregate.Upload/TravelFriend.Aggregate.Upload.csproj", "AggregateServices/TravelFriend.Aggregate.Upload/"]
RUN dotnet restore "AggregateServices/TravelFriend.Aggregate.Upload/TravelFriend.Aggregate.Upload.csproj"
COPY . .
WORKDIR "/src/AggregateServices/TravelFriend.Aggregate.Upload"
RUN dotnet build "TravelFriend.Aggregate.Upload.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TravelFriend.Aggregate.Upload.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TravelFriend.Aggregate.Upload.dll"]