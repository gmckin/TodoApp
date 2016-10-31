create schema Todo;
go


--create the table by using the schema, and the table name followed by a dot
create table Todo.Todo
(
    TodoId int not null identity(1,1) primary key,    
    Description nvarchar(MAX) null,
    Completed bit not null
);
go