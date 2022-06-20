FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DrivingLicenseExam.API/DrivingLicenseExam.API.csproj", "DrivingLicenseExam.API/"]
RUN dotnet restore "DrivingLicenseExam.API/DrivingLicenseExam.API.csproj"
COPY . .
WORKDIR "/src/DrivingLicenseExam.API"
RUN dotnet build "DrivingLicenseExam.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DrivingLicenseExam.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DrivingLicenseExam.API.dll"]
