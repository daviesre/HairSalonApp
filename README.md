# _Hair Salon Database with C#, SQL, Nancy, and Razor_

#### _A site for storing information about stylists and their clients_

#### By _**Russ Davies**_

## Description

This site will allow the user to add new stylists to a list and view their clients. You may also delete and edit stylists.

## Setup

 1. Clone this repository
 2. Run "DNU restore" on PowerShell in the cloned repository.
 3. Put the following into SQL Studio:
 * CREATE DATABASE hair_salon;
 * GO
 * USE hair_salon;
 * GO
 * CREATE TABLE stylists (id INT IDENTITY(1,1), name VARCHAR(255), stylist_id INT);
 * CREATE TABLE clients (id INT IDENTITY(1,1), description VARCHAR(255));
 * GO
 4. Then type in "DNX Kestrel" and enter.
 5. Go to your web browser and type in "LocalHost:5004" to view the homepage.

## Known Bugs
No known bugs

## Support and contact details
Please contact Russ Davies at russdavies392@gmail.com if you have any questions.

## Technologies Used
* C#
* Nancy
* Razor
* SQL

### License
Copyright (c) 2016 Russ Davies

This software is licensed under the MIT license.
