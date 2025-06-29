# Family Games

This is designed to be a self-hosted set of games for playing with friends and family in your household and/or with access to your network (Cloudflare Tunnels, etc). 

![Docker Image Version](https://img.shields.io/docker/v/knight0323/family-games) [![buy me a coffee button](https://img.shields.io/badge/buy%20me%20a%20coffee-donate-yellowgreen)](https://ko-fi.com/jeremyknight) ![GitHub last commit](https://img.shields.io/github/last-commit/jeremyknight-me/family-games?color=red) [![Contributor Covenant](https://img.shields.io/badge/Contributor%20Covenant-2.1-4baaaa.svg)](CODE_OF_CONDUCT.md)

## Games

- Tic-Tac-Toe
- Memory
- Connect Four / Four in a Row
  - Based off of @csharpfritz repository found at https://github.com/csharpfritz/BlazorConnectFour
- Flashcards

## Installation Instructions

Install Docker (https://docs.docker.com/get-docker/) and then run:

```
docker run --name family-games -p 6000:8080 -e ASPNETCORE_ENVIRONMENT=Production -e ASPNETCORE_URLS=http://+:8080 knight0323/family-games:latest --restart=unless-stopped
```

Using the above example, you should be able to navigate to the site using: `http://localhost:6000`

NOTE: You may want to pull a specific version `1.0.1` instead of `latest`.

### Docker Compose

You can also use Docker Compose to run the application. 
Create a `docker-compose.yml` file in your project directory with the following content:

```yaml
services:
  family-games:
    container_name: family-games
    image: knight0323/family-games:latest
    environment:
      - ASPNETCORE_URLS=http://+:8080
      - ASPNETCORE_ENVIRONMENT=Production
    ports:
      - 6080:8080
    restart: unless-stopped
```

## Developer Instructions

For all commands below. replace `1.2.3` with the version you are working on.

### Build

To build the docker image, run the following command in the root of the repository:

```powershell
docker build -f src\FamilyGames\Dockerfile -t knight0323/family-games:1.2.3 .
```

### Publish

To publish the docker image, run the following:

```powershell
docker login
docker push knight0323/family-games:1.2.3
docker tag knight0323/family-games:1.2.3 knight0323/family-games:latest
docker push knight0323/family-games:latest
```
