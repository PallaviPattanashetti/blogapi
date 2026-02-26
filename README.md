# Blog BackEnd API => Project Overview

# Project Goal

Create a backend for Blog Applications=>

-Support full CRUD operations

- All users to create account and login
- Deploy to Azure
  -Uses SCRUM workflow
- Introduces Azure DevOps practices

## Stack

- Back End will be in .Net 9, ASP.Net Core, EF Core, SQL Server.
  -Front End Will be done in Next JS with TypeScript and flowbite(tailwind). Deploy with (Vercel or Azure)

## Application Features =>

## User Capabilities =>

-create Account
-Login
-Delete

## Blog Features =>

-View all published blog posts
-Filter blog posts
-Create new posts
-Edit existing posts
-Delete posts
-Publish/Unpublish posts

## Pages (Frontend Connected to API) =>

-Create Account Page
-Blog view post page of published items
-Dashboard page (This is the profile page will edit, delete, and publish and unpublish our blog posts)

**Blog Page**
-Display all published blog items

**Dashboards**
-User profile page
-Create blog posts
-Edit blog posts
-Delete blog posts

## Project Folder Structure

=== Controllers =====

## Controllers

## UserController

Handle all user Interactions-
Endpoints:
-Login
-AddUser
-Update Users
-Delete User

## BlogController

Handles-
Endpoints:
-Create Blog Items(Create)
-Get All Blog Items(Read)
-Get Blog Items by Category(Read)
-Get Blog Items by Tags(Read)
-Get Blog Items by Date(Read)
-Get Publish by Items (Read)
-Update Blog Items(Update)
-Delete Blog Items(Delete)
-Get Blog Items by UserId

> Delete will be use for soft delete / Publish logic

====Models=====

## Models

## UserModel

````Csharp

int Id
string  Username
string  Salt
string  Hash

## BlogItemModel

int  Id
int  UserId
string PublisherName
string  Title
string  Image
string  Description
string  Date
string  Category
string  Tags
bool IsPublished
bool IsDeleted

## Items Saved to our DB
## We need a way to sign in with our user name and password

```Csharp

## LoginModel

string  Username
string  Password

## CreateAccountModel

int Id = 0
string Username
string Password

## PasswordModel

string Salt
string Hash

````

======Services=========

##Services
Context / Folder
-DataContext
-UserServices / file
-GetUserByUsername
-Login
-AddUser
-UpdateUser
-DeleteUser

## BlogItemService

-AddBlogItems
-GetAllBlogItems
-GetAllItemsByCategory
-GetBlogItemsByTags
-GetBlogItemsByDate
-GetPublishedBlogItems
-UpdateBlogItems
-DeleteBlogItems
-GetUserById

## PasswordServices

-Hash Password
-Very Hash Password
