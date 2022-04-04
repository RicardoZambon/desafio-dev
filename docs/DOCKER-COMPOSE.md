# ByCoders - Coding Challenge

## Docker Compose

If you need, you can execute the docker-compose that will automatically set the environment and run the database, back-end and fron-end.

First, update the ```docker-compose.yaml``` file with the database password and JWT key.

```
...
services:
  db:
    ...
    environment:
      ...
      SA_PASSWORD: [Database password]
    ...
   
  api:
    ...
    environment:
      "ConnectionStrings:DefaultConnection": Server=sql;Initial Catalog=ByCodersImporter;User Id=sa;Password=[Database password]
      "JWT:Key": [JWT key]
    ...
	
  ...
```

Open a Command prompt from the ```docker-compose.yaml``` file folder and run:

```
C:\...\desafio-dev>docker-compose up
```

Wait for the docker finish generating the images and setting up the containers.

**Default configuration:** *(HTTP only)*
- Back-end: http://localhost:8081/swagger
- Front-end: http://localhost:8080/