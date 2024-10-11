# Link zum Docker/Podman Tutorial

https://www.youtube.com/watch?v=3c-iBn73dDE&ab_channel=TechWorldwithNana

# Einfache docker/podman commands
## docker compose starten

```batch
podman compose -f docker-compose.yaml --project-name mongodb-services up -d
```

## docker compose entfernen

```batch
podman compose -f docker-compose.yaml --project-name mongodb-services down
```

## docker compose stoppen/restart

```batch
podman compose --project-name mongodb-services stop/restart
```
