# Family Games

This is designed to be a self-hosted set of games for playing with friends and family in your household and/or with access to your network (Cloudflare Tunnels, etc). 

## Games

- Tic-Tac-Toe
- Memory
- Connect Four / Four in a Row
  - Based off of @csharpfritz repository found at https://github.com/csharpfritz/BlazorConnectFour

## Installation Instructions

1) Install Docker - https://docs.docker.com/get-docker/
2) Run: 

```
docker pull knight0323/family-games:latest
docker run --name family-games -p 6001:8080 knight0323/family-games --restart=unless-stopped
```

NOTE: You may want to pull a specific version `1.0.1` instead of `latest`.

## Developer Instructions

### Publish

Change `ContainerImageTags` to latest version on publish.

```powershell
docker login
dotnet publish --os linux --arch x64 -c Release -p:PublishProfile=DefaultContainer -p:ContainerImageTags='"1.0.1;latest"' -p:ContainerRegistry=docker.io
```
