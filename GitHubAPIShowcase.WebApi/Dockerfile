FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY GitHubAPIShowcase.Application/GitHubAPIShowcase.Application.csproj ./GitHubAPIShowcase.Application/
COPY GitHubAPIShowcase.Domain/GitHubAPIShowcase.Domain.csproj ./GitHubAPIShowcase.Domain/
COPY GitHubAPIShowcase.Infra/GitHubAPIShowcase.Infra.csproj ./GitHubAPIShowcase.Infra/
COPY GitHubAPIShowcase.WebApi/GitHubAPIShowcase.WebApi.csproj ./GitHubAPIShowcase.WebApi/

RUN dotnet restore GitHubAPIShowcase.WebApi/GitHubAPIShowcase.WebApi.csproj

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .
EXPOSE 80
ENTRYPOINT ["dotnet", "GitHubAPIShowcase.WebApi.dll"]
