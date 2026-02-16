FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

RUN dotnet tool install -g Microsoft.Web.LibraryManager.Cli
RUN ln -s ~/.dotnet/tools/libman /usr/local/bin/libman

WORKDIR /src
COPY ["src/ABP.SP.Web.Mvc/ABP.SP.Web.Mvc.csproj", "src/ABP.SP.Web.Mvc/"]
COPY ["src/ABP.SP.Web.Core/ABP.SP.Web.Core.csproj", "src/ABP.SP.Web.Core/"]
COPY ["src/ABP.SP.Application/ABP.SP.Application.csproj", "src/ABP.SP.Application/"]
COPY ["src/ABP.SP.Core/ABP.SP.Core.csproj", "src/ABP.SP.Core/"]
COPY ["src/ABP.SP.EntityFrameworkCore/ABP.SP.EntityFrameworkCore.csproj", "src/ABP.SP.EntityFrameworkCore/"]
WORKDIR "/src/src/ABP.SP.Web.Mvc"
RUN dotnet restore 

WORKDIR /src
COPY ["src/ABP.SP.Web.Mvc", "src/ABP.SP.Web.Mvc"]
COPY ["src/ABP.SP.Web.Core", "src/ABP.SP.Web.Core"]
COPY ["src/ABP.SP.Application", "src/ABP.SP.Application"]
COPY ["src/ABP.SP.Core", "src/ABP.SP.Core"]
COPY ["src/ABP.SP.EntityFrameworkCore", "src/ABP.SP.EntityFrameworkCore"]
WORKDIR "/src/src/ABP.SP.Web.Mvc"
RUN libman restore
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "ABP.SP.Web.Mvc.dll"]
