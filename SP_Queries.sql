
--	UC3 Using SP for Insertion into Table .
Go
create procedure spAddEmployeeDetails
@Name varchar(200),
@Salary float ,
@StartDate date,
@Gender char(1),
@empPhone int,
@Address varchar(255),
@Department varchar(255),
@Deductions float,
@Taxable_Pay float,
@Income_Tax float,
@Net_Pay float
as
begin
Insert into EmployeePayRoll  
values ( @Name,@Salary,@StartDate,@Gender,@empPhone,@Address,@Department,@Deductions,@Taxable_Pay,@Income_Tax,@Net_Pay)
end

--UC4 Update Employee Details from the existing Records .
Go
CREATE PROCEDURE spUpdateEmployeeDetails
@Name varchar (200),
@Id int,
@Salary float 
As
begin
update EmployeePayRoll set salary=@Salary where Name=@Name and Id=@Id 
end



--TX SQL (Crating 2 tables cz implementing foreign key concept)

--creating table Employee
create table Employee
(
Id int identity(1,1) primary key,
Name varchar(100),
Address varchar(100)
)

--creating table Salary
create table Salary
(
SalaryId int identity(1,1) primary key,
Salary float,
EmpId int foreign key references Employee(EmployeeId)
)


--creating sp to add employee and returning ID.
Go
create procedure spAddEmployeeReturnId
@Name varchar(200),
@Address varchar(200),
@Id int Output
As
insert into Employee values(@Name,@Address)
set @Id=Scope_Identity()
return @Id

--Checking results from the both the table post aome insetions.
select * from Employee
select * from Salary