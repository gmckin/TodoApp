﻿/*
 Pre-Deployment Script Template              
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be executed before the build script.  
 Use SQLCMD syntax to include a file in the pre-deployment script.      
 Example:      :r .\myfile.sql                
 Use SQLCMD syntax to reference a variable in the pre-deployment script.    
 Example:      :setvar TableName MyTable              
               SELECT * FROM [$(TableName)]          
--------------------------------------------------------------------------------------
*/
use master;
go

if(db_id(N'TodoDB') is not null)
begin
	drop database TodoDB;
end;

create database TodoDB;
go

use TodoDB;
go

if(SCHEMA_ID(N'Todo') is not null)
begin
	drop schema Todo;
end
go