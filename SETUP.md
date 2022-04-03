# ByCoders - Coding Challenge
## Project Setup

Since this project is divided into two applications, you will need to setup both of them to run.

After cloning repository, start by setting up the backend:

## Back end (Web Api)

### 1. Set the local the user secrets as the example:
Replace the Server, Initial Catalog, User Id, and Password from the connection string with the values from your environment and set your own JWT Key.
- *You can use the https://passwordsgenerator.net/ to generate the JWT Key, set the legth to 29 and Exclude Ambiguous Characters*
- :point_right: *In case you are not running the project from Visual Studio, edit the ```appsettings.Development.json``` andding manually the entries*

```
secrets.json
{
  "ConnectionStrings:DefaultConnection": "Server=[Host]; Initial Catalog=[Database]; User Id=[User]; Password=[Password];",
  "JWT:Key": "[JWT Key]"
}
```
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

:red_circle: **Attention: This project is in .NET 6, if you try run the solution from Visual Studio 2019 you will get an error!**

:yellow_heart: The web api will automatically try to connect with your database server to create / update the database during the application startup, you don't need to manually run ```Database-Update``` to apply the migrations.

When executing for the first time, will ask you to Trust ASP.NET Core SSL Certificate

- Check the option Don't ask me again;
- Click **Yes**;
- And click **Yes** again.

## Front end (Angular)

With the backend up and running, you can start setting up the front end:

### 1. Install the NPM packages 

From the front end root folder, execute ```npm install```.

```
C:\...\desafio-dev\ByCoders.Importer.Angular>npm install
```

### 2. Trust HTTPS certificate

The front end is also running in HTTPS, you need first add the development certificate as trusted.

- Open the file ```C:\...\desafio-dev\ByCoders.Importer.Angular\ssl\server.crt```;
- Click Install Certificate...;
- Click Next;
- Select **Place all certificates in the following store**;
- Browse for **Trusted Root Certification Authorities**;
- Click Next and Finish;
- Click Yes in the security warning message;
- You should have a confirmation the import was successfull;
- Click Ok and close the certificate.

### 3. Run the project

From the front end root folder again, execute ```npm run start``` to execute the project.

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
