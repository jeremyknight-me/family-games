# Family Games

This is designed to be a self-hosted set of games for playing with friends and family in your household and/or with access to your network (Cloudflare Tunnels, etc). 

![Docker Image Version](https://img.shields.io/docker/v/knight0323/family-games) [![buy me a coffee button](https://img.shields.io/badge/buy%20me%20a%20coffee-donate-yellowgreen)](https://ko-fi.com/jeremyknight) ![GitHub last commit](https://img.shields.io/github/last-commit/jeremyknight-me/family-games?color=red) [![Contributor Covenant](https://img.shields.io/badge/Contributor%20Covenant-2.1-4baaaa.svg)](CODE_OF_CONDUCT.md)

## Games

- Tic-Tac-Toe
- Memory
- Connect Four / Four in a Row
  - Based off of @csharpfritz repository found at https://github.com/csharpfritz/BlazorConnectFour

## Installation Instructions

Install Docker (https://docs.docker.com/get-docker/) and then run:

```
docker run --name family-games -p 6000:8080 -e ASPNETCORE_ENVIRONMENT=Production -e ASPNETCORE_URLS=http://+:8080 knight0323/family-games:latest --restart=unless-stopped
```

Using the above example, you should be able to navigate to the site using: `http://localhost:6000`

NOTE: You may want to pull a specific version `1.0.1` instead of `latest`.

## Developer Instructions

### Publish

Change `ContainerImageTags` to latest version on publish.

```powershell
docker login
dotnet publish --os linux --arch x64 -c Release -p:PublishProfile=DefaultContainer -p:ContainerImageTags='"1.0.1;latest"' -p:ContainerRegistry=docker.io
```
