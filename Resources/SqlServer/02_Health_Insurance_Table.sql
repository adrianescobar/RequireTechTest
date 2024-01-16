CREATE TABLE Health_Insurance (
	Id int IDENTITY(1,1) NOT NULL,
	Name nvarchar(255) NOT  NULL,
	Description nvarchar(4000) NOT NULL,
	CONSTRAINT PK_Health_Insurance PRIMARY KEY (Id)
);
