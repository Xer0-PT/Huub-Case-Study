<img src="https://media-exp1.licdn.com/dms/image/C4E0BAQF3ukPgNlaIUw/company-logo_200_200/0/1637839417793?e=1654128000&v=beta&t=uEOS9Kts3nT2HCHwpHIqOWjTreEPuywlVC79_g4f2D4"
     style="height: 7rem;"/>

# Huub Case Study

Huub by Maersk's first code challenge.

## Description

This challenge goal was to develop an API that serves two contexts: orders and deliveries.

I was given two endpoints that return JSON payloads with information regarding orders and deliveries.

## Requirements

### Implement **two GET endpoints**

1. With brand as a query parameter, return a list of orders and its deliveries.
2. With an id or reference of order as a query parameter, return the quantity of each product of that order that has already been shipped.

## Built With

* .Net 6.0
* C#
* Docker
* Swagger

## Running the project

### You can clone this project or download a ZIP file

* Clone this project
> https://github.com/Xer0-PT/Huub-Case-Study.git


* Download ZIP file
> https://github.com/Xer0-PT/Huub-Case-Study/archive/refs/heads/master.zip


### After that, if you have Docker installed, in the root folder of the project run the following command:
```
docker-compose up huub.api
```

* Open your browser and go to
> http://localhost:8080

* This will open Swagger UI interface
* You can now test my API

### Or you can run it via Visual Studio

<br>

# Updates
* 01/03/2022 - Added in memory cache feature. This way the amount of requests to external server are reduced and the response time is increased.

<br><br>
## Author
<img src="https://avatars.githubusercontent.com/u/38245877?s=120&v=4">

**Joel Martins**

[<img src="https://img.shields.io/badge/LinkedIn-0077B5?style=for-the-badge&logo=linkedin&logoColor=white" />](https://www.linkedin.com/in/joelm-artins/)
[<img src="https://img.shields.io/badge/Gmail-D14836?style=for-the-badge&logo=gmail&logoColor=white" />](mailto:joelflm@gmail.com)
