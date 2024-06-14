# RoseBros
## Problem Solved
Rose Bros is your destination for high-quality bare root English roses. An online shop curated by world renowned Rosarians ..the Rose Bros.
At Rose Bros, we’re passionate about bringing the beauty of English roses to your garden. 
We understand the frustration of searching for premium roses, so we’ve curated a collection that combines elegance, fragrance, and hardiness. 
Search for your perfect rose by color, and habit, saving you time and effort. 
With Rose Bros, your garden will flourish, and your love for roses will bloom. 🌹


## Technologies Used
- ReactJS
- React-Strap
- EF Core 8.0
- PostgreSQL 16
- JavaScript
- HTML5
- CSS3
- Vite

## Installation and Setup Instructions
Clone this repository, and ensure you have the following installed on your machine:
- [node](https://github.com/nodejs/node)
- [npm](https://github.com/npm/cli)
- [.Net 8.0.101 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [PostgreSQL 16](https://www.enterprisedb.com/downloads/postgres-postgresql-downloads)

Then run the following command
```
dotnet tool install --global dotnet-ef --framework net8.0
```
#### Installation
Navigate to the cloned directory and run the following
```
dotnet user-secrets init
```
```
dotnet user-secrets set 'RoseBrosDbConnectionString' 'Host=localhost;Port=5432;Username=postgres;Password=<your_postgresql_password>;Database=RoseBros'
```
```
dotnet user-secrets set AdminPassword password
```
```
dotnet restore
```
```
dotnet ef migrations add InitialCreate
```
```
dotnet ef database update
```
Then navigate to the client directory and run the following
```
npm install
```
#### Run Database
Run the following command in the project root directory
```
dotnet watch run --launch-profile https
```
#### Run Website
Navigate to the client directory and run the following
```
npm run dev
```

## Essential Structure
RoseBros consists of several key features:
#### Browsing Available Roses
From the Home view you can view all of the available Roses, and click on a Rose of interest to see it's details.
#### Add a Rose to your Cart
While viewing the details of a Rose, you can enter the quantity of bareroots you would like to add to your order, and add them to your cart!
#### Place an Order
From the Cart View:
- Users can adjust the items in their cart by removing items or adjusting the quantity.
- Users can place their order. 
#### View Profile information and past orders 
From Profile View:
- Users can view their account details, and see all of their past orders and order status. 
#### Admins can facilitate inventory and order management
When an admin is logged in:
- They are able to see an Inventory link in the navbar, that allows them to add a rose to the system.
- They are able to see an Orders link in the navbar, with a list of orders that are unfulfilled, and mark them as fulfilled. 


## Wireframe
[Project Wireframe](https://miro.com/app/board/uXjVKAD2aF0=/)

## ER Diagram
[Entity Relationship Diagram](https://dbdiagram.io/d/RoseBros-ServerSide-Capstone-65cd1193ac844320ae27d869)


## Usage Notes:

#### User Registration and Login:

Ensure that you register a new user account before attempting to log in.
Admin access requires specific credentials, which can be configured in the backend.

#### Database Setup:

Make sure the PostgreSQL database is running and correctly configured.
The connection string should be set in the user-secrets as described in the installation instructions.

#### Running the Application:

Use dotnet watch run --launch-profile https to start the backend.
Use npm run dev to start the frontend.
Both servers need to be running simultaneously for full functionality.

#### Admin Features:

Admin users can add new roses to the inventory and manage orders.
Make sure to log in with an admin account to access these features.



## Reflection
In this capstone project, I developed a full-stack application using C# with .NET Core and Entity Framework Core (EF Core) for the backend, 
and React with React-Strap for the frontend. User authentication and authorization were key components; 
I implemented secure user access, and differentiated roles for regular users and administrators, allowing admins to manage inventory and orders.

Working on this project, I faced challenges such as setting up secure user authentication, managing state in the frontend, and ensuring data consistency 
between client and server. These experiences improved my technical skills and deepened my understanding of full-stack development. I look forward to getting 
more comfortable building these applications, and writing more detailed PRs, even when working by myself.


 
