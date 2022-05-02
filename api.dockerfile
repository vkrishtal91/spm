FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build

COPY . /src
WORKDIR /src

RUN dotnet publish -c Release -o ./build Spm.Web.Api

FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine
COPY --from=build /src/build /app
WORKDIR /app

ENTRYPOINT ["dotnet", "Spm.Web.Api.dll"]