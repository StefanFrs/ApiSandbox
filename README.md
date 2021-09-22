# Stefan sandbox project for BE

name | value
--- | ---
language | C#
database | postgress
deployed | https://api-book-app.herokuapp.com/


## How to run in Docker from the commandline

Navigate to [ApiSandbox](ApiSandbox) directory

## Build in container
```
docker build -t web_stefan .
```

to run

```
docker run -d -p 8081:80 --name web_container_stefanV2 web_stefan
```

to stop container
```
docker stop web_container_stefanV2
```

to remove container
```
docker rm web_container_stefanV2
```

## Deploy to heroku

1. Create heroku account
2. Create application
3. Make sure application works locally in Docker


Login to heroku
```
heroku login
heroku container:login
```

Push container
```
heroku container:push -a api-book-app web
```

Release the container
```
heroku container:release -a api-book-app web
```

# Swagger interface

![GitHub Logo](/Assets/swagger-screenshot.png)

# Books interface

![GitHub Logo](/Assets/books-screenshot.png)
