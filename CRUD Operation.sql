Create Database EmployeeDB

Use EmployeeDB

Create Table tblEmployee(EmployeeId int IDENTITY(1,1) Primary KEY,
Name varchar(20) NOT NULL,
City varchar(20) NULL,
Department varchar(20) NULL,
Gender varchar(6) NULL)

Create Procedure spAddEmployee
(
	@Name Varchar(20),
	@City Varchar(20),
	@Departmant Varchar(20),
	@Gender Varchar(6)
)
as
 Begin
	Insert INTO tblEmployee (Name,City,Department,Gender)
	values (@Name,@City,@Departmant,@Gender)
 End

Create Procedure spUpdateEmployee
(
	@EmpId INTEGER,
	@Name Varchar(20),
	@City Varchar(20),
	@Departmant Varchar(20),
	@Gender Varchar(6)
)
as 
 Begin
	Update tblEmployee set Name = @Name, City = @City, Department = @Departmant, Gender = @Gender
	Where EmployeeId = @EmpId
 END

 Create Procedure spDeleteEmployee
 (
	@EmpId Integer
 )
 as
  Begin
	Delete From tblEmployee
	Where EmployeeId = @EmpId
  End

Create Procedure spGetAllEmployee
as
 Begin
	Select * From tblEmployee
 End

 Create Procedure spGetEmployeeById
 (
	@EmpId Integer
 )
 as
  Begin
	Select * from tblEmployee 
	Where EmployeeId = @EmpId
  End