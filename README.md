# e-Sign Web API

### Description
e-Sign Web API is a powerful .Net Core 6 service that facilitates electronic signature management. Built with security and scalability in mind, this API allows you to create and manage electronic signatures efficiently using MongoDB as a backend database. JWT-based authentication ensures that your data remains secure throughout the process.

### Features
- User registration and authentication using JWT tokens.
- Create and manage electronic signature requests.
- Verify the authenticity of e-Signatures.
- Seamless integration with MongoDB for efficient data storage and retrieval.
- Token-based security for enhanced protection against unauthorized access.

### Installation and Setup
1. Clone this repository to your local machine.
2. Install the required dependencies using NuGet package manager.
3. Configure MongoDB connection string in the appsettings.json file.
4. Build the project using the .NET CLI or Visual Studio.
5. Run the API application.

### API Endpoints
###### The following endpoints are available in the API:

#### **Token (Without Auth)**

- **POST ~/api/Auth/LoginUser**

```javascript
{
	"email": "test@mail.com",
	"password": "pass123",
	"grant_type": "password"
}
```

#### **User (With Auth)**
##### **Authorize Header;**
```
Authorization - Bearer token
```
- **GET ~/api/User**
- **POST ~/api/User**
```javascript
{
	"name": "string",
	"surname": "string",
	"email": "string",
	"password": "encodedString",
	"phone": "string",
	"contacts": [
		"userID1",
		"userID2"
	],
	"package": "string",
	"signatures": [
		"signID1",
		"signID2"
	]
}
```
- **GET ~/api/User/{id}**
- **GET ~/api/User/GetUserByEmail/{email}**
- **PUT ~/api/User/{id}**
```javascript
{
	"name": "string",
	"surname": "string",
	"email": "string",
	"password": "encodedString",
	"phone": "string",
	"contacts": [
		"userID1",
		"userID2"
	],
	"package": "string",
	"signatures": [
		"signID1",
		"signID2"
	]
}
```
- **DELETE ~/api/User/{id}**

#### **Signature (With Auth)**
##### **Authorize Header;**
```
Authorization - Bearer token
```
- **GET ~/api/Signature**
- **POST ~/api/Signature**
```javascript
{
	"status": "string",
	"title": "string",
	"startDate": "dateTime",
	"endDate": "dateTime",
	"reminder": "string",
	"files": [
		"Bindata()"
	],
	"users": [
		"userID1",
		"userID2"
	],
	"nextSigner": "userID1"
}
```
- **POST ~/api/Signature/GetWithIds**
```javascript
[
	"SignatureID1",
	"SignatureID2",
	"SignatureID3",
	"SignatureID4"
]
```
- **GET ~/api/Signature/{id}**
- **PUT ~/api/Signature/{id}**
```javascript
{
	"status": "string",
	"title": "string",
	"startDate": "dateTime",
	"endDate": "dateTime",
	"reminder": "string",
	"files": [
		"Bindata()"
	],
	"users": [
		"userID1",
		"userID2"
	],
	"nextSigner": "userID1"
}
```
- **DELETE ~/api/Signature/{id}**

### [Click for Postman collection.](https://github.com/dogukanzder/eSignWebAPI-AspNetCore6/blob/master/e-SignInnosaApi.postman_collection.json)

### What can be added?
- Email notifications for e-Signature requests and verifications.
- Granular access control and user roles.
- Integration with third-party e-Signature providers (DocuSign, Adobe Sign, etc.).

### Found an Issue or Need Help?
If you find any bugs or have questions, please open an issue [here](https://github.com/dogukanzder/eSignWebAPI-AspNetCore6/issues "here").

### Keywords
.Net Core 6, e-Signature, API, MongoDB, JWT, Authentication, Authorization, Postman Collection, Electronic Signature, Security

### License
This project is licensed under the GPL-3.0.
