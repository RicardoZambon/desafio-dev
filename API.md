# ByCoders - Coding Challenge

## API Documentation

This file intends to explain the controllers and methods available in API, for a more detailed description, please, check that the Swagger is available with far more documented method and parameters.


### Authentication
* **[POST] Authentication / SiginIn** (model)<br />
Validate the user credentials against the users in database, expects to receive the model with username and password as plain text (password is encrypted in backend).

Returns an object with the JWT access token (expiration in 600 minutes) and the refresh token (expiration in 10 days).

* **[POST] Authentication / RefreshToken** (model)<br />
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