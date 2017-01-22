# Bangazon TaskTracker (Backend)

### Specs:
> Create a backend WebAPI2 Interface for creating, modifying, updating and deleting a simple ToDo task list.

### Technologies Used:
1. [MS .NET Core 1.1] (https://www.microsoft.com/net/download/core#/current) 
2. Entity Framework with Db Migrations
3. SQL Server Express

### How to run:
#### Initial Setup
1. Clone or download this repo
2. In the repo dir, at the Package Manager Command Prompt type `dotnet restore`
3. Once the packages are installed, in the package manager:
    * Enable the initial migration of the Db:  
   `dotnet ef migrations add InitialCreate -c BangazonContext`  
    * Apply the migration to the Db:  
   `dotnet ef database update -c BangazonContext`  
4. On first run the Database will be seeded with two user tasks

#### API Access
The default domain/port of the package is - localhost:1479  

##### The "UserTask" format
When sending/receiving data from the API, it will be in the "UserTask" format:
```
{
	"id": 4,
	"name": "Go Shopping at JcPenny",
	"description": "Shop for a new pair of shoes",
	"status": 0,
	"completedOn": "2017-01-21T23:40:15.8460917"
}
``` 
1. Any task is required to have a name, description and status (see below for status options). The lack of any of these three fields will yield an error.
    * The 'status' is an int value of 0, 1 or 2: 0="ToDo", 1="InProgress", 2="Complete"

##### The API:
The API has six actions that all return info in Json "UserTask" format:
1. Return a full list of user tasks
GET: `/api/bangazon`

1. Return a list of a tasks of that status level (0="ToDo", 1="InProgress", 2="Complete")  
GET: `/api/bangazon/stat/{StatId}`  
[where {StatId} is an integer Id corresponding to one of the three "status"]  

1. Return a single user task based on it's Id  
GET: `/api/bangazon/{TaskId}`  
[where {TaskId} is an integer Id for a task]  

1. Sending a new UserTask (via the request Body) in "UserTask" format will add a new task to the list  
POST: `/api/bangazon`  

    * When adding a new task, the API will look for a UserTask with no Id or an Id value of 0.
    * Adding a task, if successful, will return that full, new task. 

1. Sending a prior "UserTask" (via the request Body) in "UserTask" format will update that task  
PUT: `/api/bangazon`  

    * When updating a task the Id of the updated task needs to be present
    * Updating a task, if successful, will return the updated, full task.

1. Deletes a single user task based on it's Id  
DELETE: `/api/bangazon/{TaskId}`  
(where {TaskId} is an integer Id for a task)  

### Specs By:
[Nashville Software School](https://github.com/nashville-software-school)  
[Steve Brownlee](https://github.com/chortlehoort)  
[Nathan Gonzalez](https://github.com/ncgonz)  

### Contributors:
[Bernie Anderson](https://github.com/bernardanderson)  


