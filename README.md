# oig-survey-app-assessment
Test assessmment for oig-survey app

## Prerequisites
- Docker

### 1. Run a local PostgreSQl instance

cd into the root directory.

open a terminal and run

```
docker-compose -f docker-compose-database.yml up -d
```

This will create a local postgres image on port 5433. 
To connect to the instance you can find the local credentials in the .env file.

*Note: Harcoding the connection string for now as there are TODO to implement azure appconfig and managed identities.
This will be a local demo for now, aim is to have all Azure config in TerraForm instead of manually managing in Azure UI.

### 2. Setup Application secrets

// TODO: Setup azure appconfigurtion and document dotnet user-secrets setup

### About the application architecture

- The application is build as a .NET 6 ASP.NET MVC project with the aim to refactor out to microservices post MVP phase. (see draw.io diagrams)
- The packages directory is to show how to start separating out nuget packages. Future sate would be to add a test project for each in their own repo & release pipeline. This can be achieved eiether through Azure DevOps artifacts or Github nuget feed.
- Tha application uses CQRS and MediatR to facilitate the communication between the App & domain. Reference hexagonal architecture aka ports and adapters for clear separation of concerns between layers. 
Also opens up the ease to add an API or different integration layer based on REST,Graphql or gRPC
- Both the App & domain tier utilizes Automapper to facilitate mappings between the various DTOs.
- Fluentvalidation have been set up for App and domain
- The domain follow CQRS patter grouped by [DomainConcern]/[Action]
- The ValidationPipelineBehaviour is a class to just show what it would take to wire up the domain validation as part of the execution model so that when calling one handler from another that its DTO being passed
- adheres to its validator.
- I have offloaded the background processing to hangfire. Granted this implementation is just a demonstration and for an MVP the program.cs implementation would be moved into Extensions and possibly a nuget package
for other services to use. Also important to note the interface wireups on line 29 & 30 of the Program.cs is a short cut and that can be refactored to a generic extension implementation which can setup the IOC for you.
There is also a way to bridge Hangfire and MediatR thus giving you consistency.
 
Note:
- This project is very much a POC and certain code snippets would not pass a code review. the intent of the project is to get a survey app up and running as fast as possible so taht one can iterate on it.
- Hence there are iterations as part of the diagram.
- I did not get are around to implement the grid search functionality however this can easily be achieved with a linq expression with a contains on the Questionnaire name. It would be good enough however as the app grows
something like elastic search or solr would be able to facilitate a more intuitive search on multiple data points with large scale data sets. 
= For pagination we have a choice between cursor based or paged based each have their own pro's and con's and would need ot be decided on at a team level.
