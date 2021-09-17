## Description
This is a demo APIs for adding, updating, deleting, and getting all agents with paging.

## Used Technologies & Tools
* ASP.NET Core 5.0 - _a cross-platform software framework._
* C# 9.0 _programming language_
* MongoDB.Driver/2.11.6 - _official .NET driver for MongoDB._
* AutoMapper/10.1.1 - _a convention-based object-object mapper._
* MediatR/9.0.0 - _simple, unambitious mediator implementation in .NET._

### Requirements
* Installed .NET 5.0 SDK on your machine

* Running MongoDB server. Optionally you can run it as a container on Docker (using Command Line):

  `docker run -d --rm --name mongo -p 27017:27017 -v mongodbdata:/data/db mongo`

* Open `https://localhost:5001/swagger/index.html` on your browser to launch a **Swagger UI** and visually render documentation for the application.