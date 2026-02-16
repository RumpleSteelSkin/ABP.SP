FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src
COPY ["src/ABP.SP.Web.Host/ABP.SP.Web.Host.csproj", "src/ABP.SP.Web.Host/"]
COPY ["src/ABP.SP.Web.Core/ABP.SP.Web.Core.csproj", "src/ABP.SP.Web.Core/"]
COPY ["src/ABP.SP.Application/ABP.SP.Application.csproj", "src/ABP.SP.Application/"]
COPY ["src/ABP.SP.Core/ABP.SP.Core.csproj", "src/ABP.SP.Core/"]
COPY ["src/ABP.SP.EntityFrameworkCore/ABP.SP.EntityFrameworkCore.csproj", "src/ABP.SP.EntityFrameworkCore/"]
WORKDIR "/src/src/ABP.SP.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/ABP.SP.Web.Host", "src/ABP.SP.Web.Host"]
COPY ["src/ABP.SP.Web.Core", "src/ABP.SP.Web.Core"]
COPY ["src/ABP.SP.Application", "src/ABP.SP.Application"]
COPY ["src/ABP.SP.Core", "src/ABP.SP.Core"]
COPY ["src/ABP.SP.EntityFrameworkCore", "src/ABP.SP.EntityFrameworkCore"]
WORKDIR "/src/src/ABP.SP.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "ABP.SP.Web.Host.dll"]
