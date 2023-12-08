# BasicWebApiNikolaDimeski

# Overview

This is simple Web Api made in ASP.NET Core Web Api Template that works on local database running on SQL Management Studio. 
The idea of this API is to be able to fetch and create data from and into 3 Database tables called: Country, Company and Contact.
Because the API is created with local database, it might have some problems running on different machines, because this is just a sample project to display my skills and knowledge.

# Getting Started

You need to open the API in Visual Studio 2022, since the template that this project is using is only supported by .NET 8.0 .
After opening the project, with a simple RUN to the code, you will be redirected to a web page that runs on localhost, and has all the API functionalities implemented using swagger.

# Models Structure

Company:
- CompanyId(int)
- CompanyName(varchar/string)
  
Contact:
- ContactId(int)
- ContactName(varchar/string)
- CompanyId(int)
- CountryId(int)
  
Country:
- CountryId(int)
- CountryName(varchar/string)

# Endpoints

Company:
- GET /api/Company/id: Get a specific company by ID.
- PUT /api/Company/id: Update an existing company.
- DELETE /api/Company/id: Delete a company by ID.
- POST /api/Company: Create a new company.
- GET /api/Company: Get all companies.

Contact:
- GET /api/Contact/id: Get a specific contact by ID.
- PUT /api/Contact/id: Update an existing contact.
- DELETE /api/Contact/id: Delete a contact by ID.
- POST /api/Contact: Create a new contact.
- GET /api/Companies: Get all contacts.
- GET /api/Contact/WithCompanyAndCountry: Get all contacts with the names of their country and company.
- GET /api/Contact/FilterContact: Get all contact by CountryId or/and CompanyId.

Country:
- GET /api/Country/id: Get a specific country by ID.
- PUT /api/Country/id: Update an existing country.
- DELETE /api/Country/id: Delete a country by ID.
- POST /api/Country: Create a new country.
- GET /api/Country: Get all countries.

# License

This API can be used from everyone, since is open-source project and is made for different purposes.
