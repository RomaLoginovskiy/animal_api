# Animal Pictures App

Get random animal pictures with custom sizes! Built with ASP.NET Core backend + Node.js frontend.

## What You Need

### Option 1: Run Locally
- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) - Check with `dotnet --version`
- [Node.js 18+](https://nodejs.org/) - Check with `node --version` and `npm --version`

### Option 2: Use Docker (Easier!)
- [Docker Desktop](https://www.docker.com/products/docker-desktop) - Check with `docker --version`

## Docker Way (Easiest)

```bash
# Just run this!
docker-compose up --build
```

Then visit:
- App: http://localhost:3000
- API: http://localhost:5076

```bash
# Other useful commands
docker-compose down        # Stop everything
docker-compose logs -f     # See what's happening
```

## Local Development

### Backend
```bash
cd Backend
dotnet restore
dotnet build
dotnet ef database update
dotnet run
```
Backend runs at: http://localhost:5076

### Frontend (new terminal)
```bash
cd Frontend
npm install
npm start
```
Frontend runs at: http://localhost:3000

## What's Inside

```
Backend/     # .NET API that fetches animal pics
Frontend/    # Simple HTML/JS interface
```

## Features

- Get random duck pictures (or add more animals!)
- Set custom image sizes
- Fetch multiple pics at once

## Troubleshooting

**Ports busy?** Change them in `docker-compose.yml`

**Database issues?** 
```bash
cd Backend
rm camunda_challenge_dev.db
dotnet ef database update
```

**Docker acting up?**
```bash
docker-compose down -v
docker system prune -f
```

That's it!
