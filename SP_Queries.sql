
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