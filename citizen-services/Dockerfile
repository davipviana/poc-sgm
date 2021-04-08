FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app

COPY CitizenServices/. ./CitizenServices/
COPY CitizenServices.Entities/. ./CitizenServices.Entities/
COPY CitizenServices.Messaging/. ./CitizenServices.Messaging/
COPY CitizenServices.Services/. ./CitizenServices.Services/

WORKDIR /app/CitizenServices
RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime

WORKDIR /app

COPY --from=build /app/CitizenServices/out ./

ENTRYPOINT ["dotnet", "CitizenServices.dll"]
