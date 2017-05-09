# CustomerModule

## Prerequisites:
1. Sql Server Express
2. Visual Studio 2015

## Installation instruction:

Clone this repo in to your machine, open it in VisualStudio and run/debug it. 

## App interaction:
You can interact with the CustomerModule trough web api using for example https://www.getpostman.com/ or Fiddler. Remember to use application/json content type.

### Creating customer:
Send POST request to http://localhost:51868/api/Customer. Use this example data as request body:
```json
{
  "Name": "Some",
  "Surname": "Guy",
  "TelephoneNumber": "123456789",
  "Address": {
    "StreetName": "Wrocławska",
    "City": "Gdańsk",
    "ZipCode": "00-001",
    "Country": "Polska"
  }
}
```

### Getting all customers:
Send GET request to http://localhost:51868/api/Customer/

### Getting customer trough id
Send GET requset to http://localhost:51868/api/Customer/{customerId}
For example: http://localhost:51868/api/Customer/1

### Updating existing customer
Send PUT request to http://localhost:51868/api/Customer/{customerId}
For example: http://localhost:51868/api/Customer/1 with this body:
```json
{
  "Name": "Some new name",
  "Surname": "Guy",
  "TelephoneNumber": "123456789",
  "Address": {
    "StreetName": "Wrocławska",
    "City": "Gdańsk",
    "ZipCode": "00-001",
    "Country": "Polska"
  }
}
```
