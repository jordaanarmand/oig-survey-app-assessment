# oig-survey-app-assessment
Test assessmment for oig-survey app

### 1. Run a local PostgreSQl instance

cd into the root directory.

open a terminal and run

```
docker-compose -f docker-compose-database.yml up -d
```

This will create a local postgres image on port 5433. 
To connect to the instance you can find the local credentials in the .env file.
Harcoding the connection string for now as there are ToDo's to implement azure appconfig and managed identities. Just don't have the time for this iteration.

### 2. Setup Application secrets

// TODO: Setup azure appconfigurtion and document dotnet user-secrets setup

### 3. 
