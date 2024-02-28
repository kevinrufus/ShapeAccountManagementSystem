# shape-account-management-system

This solution contains two applications.
  1- Backend Server(C#)
  2- Client Application(React)

To run and test the application you have to perform these steps:

  1- To run backend server you have to insure that sql server is installed in your system, docker container can also work.
  
  2- Connection string is in appsettings.json file, if your local system server name is different then change it.
  
  3- After this you have to run these commands in pacakage manager console:
    - EntityFrameworkCore\update-database (it will initialize and create the database using EF Core Code First approach)
  
  4- Now, you can start the project from cmd by executing this command: "dotnet run" or run using visual studio
  
  5- Now go to react application and run these commands:
    - yarn or npm install
    - yarn start or npm start
  
