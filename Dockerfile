FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["HangmanGame/HangmanGame.HttpApi.csproj", "HangmanGame/"]
COPY ["Game/Game.csproj", "Game/"]
RUN dotnet restore "HangmanGame/HangmanGame.HttpApi.csproj"
COPY ./HangmanGame ./HangmanGame
COPY ./Game ./Game
WORKDIR "/src/HangmanGame"
RUN dotnet build "HangmanGame.HttpApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HangmanGame.HttpApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
#
#RUN useradd -m myappuser
#USER myappuser
#
CMD ASPNETCORE_URLS="http://*:$PORT" dotnet HangmanGame.dll