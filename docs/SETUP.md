# ByCoders - Coding Challenge
## Project Setup

This project is divided into two applications (Back-end and Front-end), you will need to setup both projects to rum them in development.

**Default configuration:** *(HTTPS)*<br />
Back-end: https://localhost:44352/swagger<br />
Front-end: https://localhost:4200/<br />

After cloning the repository into your computer, follow the steps:

## Back-end (Web Api) https://localhost:44352/swagger

### 1. Set the local user secrets:
Replace the ```Server```, ```Initial Catalog```, ```User Id```, and ```Password``` from the connection string with the values from your environment and set your own ```JWT Key```.
- *You can use the https://passwordsgenerator.net/ to generate the JWT Key, set the legth to 29 and Exclude Ambiguous Characters*
```
secrets.json
{
  "ConnectionStrings:DefaultConnection": "Server=[Host]; Initial Catalog=[Database]; User Id=[User]; Password=[Password];",
  "JWT:Key": "[JWT Key]"
}
```

- :point_right: *In case you are not running the project from Visual Studio, you can edit the ```appsettings.Development.json``` adding the entries manually*
```
appsettings.Development.json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=[Host]; Initial Catalog=[Database]; User Id=[User]; Password=[Password];"
  },
  "JWT": {
    "Key": "[JWT Key]",
    ...
  },
  ...
}
```

### 2. Run the project

:red_circle: **Attention: This project is in .NET 6, if you try run the Back-end project from Visual Studio 2019 you will get an error!**

:yellow_heart: The back-end is configured to automatically try to connect with your SQL instance to create / update the database during the application startup, you don't need to manually run ```Database-Update``` to apply the migrations.

When executing for the first time, you will be asked to Trust ASP.NET Core SSL Certificate:

- Check the option Don't ask me again;
- Click **Yes**;
- And click **Yes** again.

## Front end (Angular) https://localhost:4200/

With the backend configured and running, you can set the front-end:

### 1. Trust HTTPS certificate

The front-end is also running in HTTPS, you need also add the development certificate as trusted.

- Open the file ```C:\...\desafio-dev\ByCoders.Importer.Angular\ssl\server.crt```;
- Click Install Certificate...;
- Click Next;
- Select **Place all certificates in the following store**;
- Browse for **Trusted Root Certification Authorities**;
- Click Next and Finish;
- Click Yes in the security warning message;
- You should have a confirmation the import was successfull;
- Click Ok and close the certificate properties.

### 2. Install the NPM packages 

From the front-end root folder, execute ```npm install``` to update the depencencies from NPM.

```
C:\...\desafio-dev\ByCoders.Importer.Angular>npm install
```

### 3. Run the project

With the NPM dependencies installed, execute ```npm run start``` to execute the project.

This command will compile and opens browser automatically once finished.

*You might be asked to share anonumous usage data about this project with Angular Team during the first execution*

```
C:\...\desafio-dev\ByCoders.Importer.Angular>npm run start
```

### 4. Access to the application

To access the application you can use the credentials:

```
Username: ricardo.zambon
Password: zambon
```
