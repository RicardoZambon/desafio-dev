# ByCoders - Coding Challenge

This solution is using the following technologies:

- C# with .NET 6
- Entity Framework with SQL Server
- Swagger
- xUnit
- Angular 13 with RxJS
- SCSS
- Bootstrap and Font Awesome

Divided into the following projects:

- **Core:** C#, .NET 6, Entity Framework Core, and SQL Server<br />
Provides connection with database and repositories for common components rather than WebApi.

- **Web Api:** C#, .NET 6, WebApi, and Swagger<br />
Provides services, controllers and receives requests and send responses from/to web.

- **Front end:** Angular 13, RxJS, SCSS, Bootstrap, and FontAwesome<br />
The user front end application, send and receives data from the web api.


# Project Setup

After cloning repository, to setup the development environment and run the projects you must follow:

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

# API
### Authentication
* **[POST] Authentication / SiginIn** (model)<br />
Validate the user credentials against the users in database, expects to receive the model with username and password as plain text (password is encrypted in backend).

Returns an object with the JWT access token (expiration in 600 minutes) and the refresh token (expiration in 10 days).

* **[POST] Authentication / RefreshToken** (moel)<br />
Validate the refresh token and updates the expired JWT token used to access the API, expects to receive the model with the username and refresh token.


### Catalogs
* **[GET] Catalogs / TransactionTypes** ()<br />
Return a catalog (ID & Description) of the transaction types availables.


### FileManagement
* **[POST] FileManagement / Upload** ()<br />
Upload a text file with the transactions list, expects to receive the file in the request form.

### Transactions
* **[POST] Transactions / List** (parameters)<br />
Return a list of the transactions, expects to receive a parameter with the start and end range, filters and sort options.

* **[POST] Transactions / Summary** (parameters)<br />
Return the transactions summary information, expects to receive a parameter with filters.
