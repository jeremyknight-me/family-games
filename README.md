# Family Games

This is designed to be a self-hosted set of games for playing with friends and family in your household and/or with access to your network (Cloudflare Tunnels, etc). 

Games
- Tic-Tac-Toe
- Memory
- Connect Four / Four in a Row
  - Based off of @csharpfritz repository found at https://github.com/csharpfritz/BlazorConnectFour

Publish Instructions

```powershell
docker login
dotnet publish --os linux --arch x64 -c Release -p:PublishProfile=DefaultContainer -p:ContainerImageTags='"1.0.1;latest"'
```
