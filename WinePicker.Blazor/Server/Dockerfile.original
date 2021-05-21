#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["WinePicker.Blazor/Server/WinePicker.Blazor.Server.csproj", "WinePicker.Blazor/Server/"]
COPY ["WinePicker.Blazor/Client/WinePicker.Blazor.Client.csproj", "WinePicker.Blazor/Client/"]
COPY ["WinePicker.Blazor/Shared/WinePicker.Blazor.Shared.csproj", "WinePicker.Blazor/Shared/"]
RUN dotnet restore "WinePicker.Blazor/Server/WinePicker.Blazor.Server.csproj"
COPY . .
WORKDIR "/src/WinePicker.Blazor/Server"
RUN dotnet build "WinePicker.Blazor.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WinePicker.Blazor.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WinePicker.Blazor.Server.dll"]