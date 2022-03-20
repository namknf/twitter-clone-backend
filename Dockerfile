FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app
COPY *.csproj ./
RUN dotnet restore Twitter-backend.csproj
COPY . ./
RUN dotnet publish Twitter-backend.csproj -c Release -o out
ENTRYPOINT [“dotnet”, “Twitter-backend.dll”]`