1. Mentions
- .Net Core 2.1 was used
- Data is persited to postgress databse. As such the appsettings.json file contains username and password. This is done for simplicity.

2. How to run service locally
2.1 Load solution
2.2. Open Program.cs, comment //BuildWebHost(args).Run() and uncomment RunServiceAsAService(args);
2.3. Open a CMD nevigate to solution and execute: dotnet publish --configuration Release --runtime win7-x64
2.4. Copy the publish to the desired install location
2.5. In CMD navigate to the install location
2.6. Execute the following command: sc create "Dell.CustomerService" binPath="%~dp0\Dell.CustomerService.Web.Api.exe"
2.7. Execute the following comman: sc start Dell.CustomerService
2.8. Open browser navigate to http://localhost:5000/api/home or post a request (see below the request sample)

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



