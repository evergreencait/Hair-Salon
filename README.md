# _Hair Salon_

#### _Hair Salon Website, Epicodus C# Week 3 Code Review, 2.24.17_

#### By _**Caitlin Hines**_

## Description

_This application will allow employees of a hair salon to: see a list of stylists at the salon, select a stylist and see their details and a list of their clients, add a new stylist to the system when then are hired, add new clients to a specific stylist, also update and delete clients in the system._

## Specifications

#### The GetAll method will return an empty list if the list of stylists is empty in the beginning
* Input: nothing/null
* Output : empty string


#### The Equals method will return true if there two stylists that are the same.
* Input: Henry, Henry
* Output : true


#### The GetAll method will return a stylist if the stylist was saved in the database.
* Input: "Henry"
* Output : "Henry"


#### The Save method will assign a new id to a new instance of the stylist class.
* Input: Henry, 0
* Output : Henry, non zero

#### The GetAll method will return a list of of all stylists.
* Input: Henry, Sally, Bob, Joan
* Output : Henry, Sally, Bob, Joan

#### The Find method will return the stylist in the database.
* Input: Henry
* Output : Henry

#### The GetAll method will return an empty list if the list of clients is empty in the beginning.
* Input: Nothing/null
* Output : empty string

#### The Equals method will return true if there are two clients that are the same.
* Input: Gwen, Gwen
* Output : true

#### The Save and Getall method will return true if the client was saved in the database.
* Input: Gwen
* Output : true

#### The GetAll method will return true if the id for the first restaurant has an id of 1.
* Input: Gwen
* Output : 1

#### The GetAll method will return a list of clients.
* Input: Gwen, Bill, Jane
* Output : Gwen, Bill, Jane

#### When a user updates a client, the Update method will return the updated info.
* Input: Gwen S replacing Gwen
* Output : Gwen S

#### When a user deletes a client, the Delete method will return an updated list without the deleted client.
* Input: DELETE Gwen S
* Output : Bill, Jane

## Support and contact details

_Contact: Caitlin Hines- caitlinhines@me.com_

## Technologies Used

## Setup/Installation Requirements

* SQLCMD:
* CREATE DATABASE hair_salon;
* GO
* USE hair_salon;
* GO
* CREATE TABLE stylists (id INT IDENTITY(1,1), name VARCHAR(255));
* CREATE TABLE clients (id INT IDENTITY(1,1), description VARCHAR(255));
* GO
* _Clone github repository:https://github.com/Hair-Salon
* _run dnu restore in terminal.
* _reset server with "gnx kestrel"_
* _Open webpage on localhost:5004_

_HTML, CSS, Nancy, Razor, C#, SQL_

### License

*MIT*

Copyright (c) 2017 **_Caitlin Hines_**
