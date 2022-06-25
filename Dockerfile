FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY . .

WORKDIR /src/DrivingLicenseExam.API
RUN dotnet publish DrivingLicenseExam.API.csproj -c Release -o /app/publish

FROM build AS tests
WORKDIR /src/DrivingLicenseExam.Tests
RUN dotnet test

FROM build AS update-database
WORKDIR /src
RUN dotnet tool install --global dotnet-ef
ENV PATH $PATH:/root/.dotnet/tools
RUN dotnet ef database update --project DrivingLicenseExam.Infrastructure --startup-project DrivingLicenseExam.API

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app
COPY --from=update-database /src/DrivingLicenseExam.API/dbo.DrivingLicenseExam.db .
COPY --from=update-database /app/publish .
ENTRYPOINT ["dotnet", "DrivingLicenseExam.API.dll"]