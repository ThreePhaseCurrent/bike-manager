# bike-manager
One of the test tasks. Implemented a CRUD of bicycles and made a frontend on the angular according to a given template.

# How start it
You must have MS SQL Server 2017 installed(for DB). For client application after cloning the repository, you need to run the command `npm install`. First run the WebAPI application. After that, you can run client app with the command `ng serve`. When the server starts, the database will be automatically created and configured. 

# troubleshooting
The server (API) must start from port 5001. If this is not the case, then you need to correct the port number to yours in the file `BikeManagerClient/src/app/shared/baseURL.ts` and rebuild the client application.
