# GraphQL + HotChocolate Demo Project
All instructions can be found in the GraphQL workshop:
https://github.com/ChilliCream/graphql-workshop

## Setup
To install Entity Framework global tool run in the command line:

~~~ 
dotnet new tool-manifest
dotnet tool install dotnet-ef --version 5.0.0 --local
~~~ 
 
 To create initial migrations run from console:

~~~ 
dotnet build GraphQL
dotnet ef migrations add Initial --project GraphQL
dotnet ef database update --project GraphQL
~~~ 

To drop the database run from the console:

~~~ 
dotnet ef database drop
~~~ 

To view the GraphQL schema and open Banana Cake Pop follow the following URL into the POST field:
https://localhost:5001/graphql/

To insert data into the DB run a mutation from Banana Cake Pop interface as per example below:

~~~ 
mutation AddSpeaker {
    addSpeaker(input: {
        name: "Speaker Name"
        bio: "Speaker Bio"
           webSite: "http://speaker.website" }) {
        speaker {
            id
        }
    }
}
~~~ 

To verify the data inserted run a query from Banana Cake Pop as per example below:

~~~ 
query GetSpeakerNames {
   speakers {
     name
   }
}
~~~ 

To add a subscription to an event run a subscription as per example below:

~~~
subscription {
  onSessionScheduled {
    title
    startTime
  }
}
~~~

To create Xunit test project and add it to solution run the following from the terminal:

~~~
dotnet new xunit -n <project_name>
dotnet sln add <project_name>
~~~

References required for the test project:
- Snapshooter.Xunit
- Microsoft.EntityFrameworkCore.InMemory

**NB! Make sure the Xunit version used is 2.4.1**