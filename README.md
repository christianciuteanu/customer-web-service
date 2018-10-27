1. Mentions
- .Net Core 2.1 was used
- Data is persited to postgress databse. As such the appsettings.json file contains username and password. This is done for simplicity.

2. How to run service locally
- Load solution
- Open Program.cs, comment //BuildWebHost(args).Run() and uncomment RunServiceAsAService(args);
- Open a CMD nevigate to solution and execute: dotnet publish --configuration Release --runtime win7-x64
- Copy the publish to the desired install location
- In CMD navigate to the install location
- Execute the following command: sc create "Dell.CustomerService" binPath="%~dp0\Dell.CustomerService.Web.Api.exe"
- Execute the following comman: sc start Dell.CustomerService
- Open browser navigate to http://localhost:5000/api/home or post a request (see below the request sample)

3. Sample of web service request

Url: https://customer-web-service.herokuapp.com/api/customers/addUpdateCustomer
Request Sample Json: 
{
		"name": "Customer 4",
		"email": "customer4@test.ro"
}

Response Sample Json: 
{
    "id": "152976e0-e3a1-4da0-b328-ee15aadfbe83",
    "email": "customer2@test.ro",
    "name": "Customer 2 Update"
}



