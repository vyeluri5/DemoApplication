FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 5020

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["DemoApplication.Api/DemoApplication.Api.csproj", "DemoApplication.Api/"]
COPY ["DemoApplication.Interfaces/DemoApplication.Interfaces.csproj", "DemoApplication.Interfaces/"]
COPY ["DemoApplication.Domain/DemoApplication.Domain.csproj", "DemoApplication.Domain/"]
COPY ["DemoApplication.Application/DemoApplication.Application.csproj", "DemoApplication.Application/"]
COPY ["DemoApplication.WorkerTask/DemoApplication.WorkerTask.csproj", "DemoApplication.WorkerTask/"]
COPY ["DemoApplication.IoC/DemoApplication.IoC.csproj", "DemoApplication.IoC/"]
RUN dotnet restore "DemoApplication.WorkerTask/DemoApplication.WorkerTask.csproj"
RUN dotnet restore "DemoApplication.Domain/DemoApplication.Domain.csproj"
RUN dotnet restore "DemoApplication.Application/DemoApplication.Application.csproj"
RUN dotnet restore "DemoApplication.IoC/DemoApplication.IoC.csproj"
RUN dotnet restore "DemoApplication.Api/DemoApplication.Api.csproj"
RUN dotnet restore "DemoApplication.Interfaces/DemoApplication.Interfaces.csproj"
COPY . .
WORKDIR "/src/DemoApplication.Api"
RUN dotnet build "DemoApplication.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DemoApplication.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DemoApplication.Api.dll"]

