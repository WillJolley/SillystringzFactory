# _Dr. Sillystringz's Factory_

#### By _Will Jolley_

#### _A web app for managing a database of engineers and machines_

## Technologies Used

* C#
* ASP.NET core MVC
* Razor Pages


## Description

Dr. Sillystringz's Factory is a web app for a factory that allows the user to create and edit lists of the factory's engineers and machines.   

## Setup Instructions

- Note: An installation of the .NET SDK is required in order to run this application locally. [See Here](https://dotnet.microsoft.com/en-us/) for installation.
1. Clone this repo.
2. Open your shell (e.g., Terminal or GitBash) and navigate to this project's directory called "Factory/". 
3. Create a file named `appsettings.json`: `$ touch appsettings.json`
4. Within `appsettings.json` add the following code, replacing the `uid` and `pwd` values with your own username and password for MySQL.

    ```json
    {
      "ConnectionStrings": {
          "DefaultConnection": "Server=localhost;Port=3306;database=sillystringz_factory;uid=[YOUR-USERNAME];pwd=[YOUR-MYSQL-PASSWORD];"
      }
    }
    ```
5. Set up the Database. Follow the instructions in the LearnHowToProgram.com lesson ["Creating a Test Database: Exporting and Importing Databases with MySQL Workbench"](https://www.learnhowtoprogram.com/c-and-net/database-basics/creating-a-test-database-exporting-and-importing-databases-with-mysql-workbench) to use the `sillystringz_factory.sql` file located at the top level of this repo to create a new database in MySQL Workbench with the name `sillystringz_factory`.
6. Navigate to the project directory: `$ cd Factory`
7. Run `$ dotnet watch run` in the command line to start the project in development mode with a watcher.
8. Open the browser at: _https://localhost:5001_. If you cannot access localhost:5001 it is likely because you have not configured a .NET developer security certificate for HTTPS. To learn about this, review this lesson: [Redirecting to HTTPS and Issuing a Security Certificate](https://www.learnhowtoprogram.com/c-and-net/basic-web-applications/redirecting-to-https-and-issuing-a-security-certificate).

## License

e-mail me at yeswilljolley@gmail.com with any issues, questions, ideas, concerns.

MIT

Copyright (c) 2023 Will Jolley