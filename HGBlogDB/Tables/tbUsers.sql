CREATE TABLE [dbo].[tbUsers]
(
	[Id] INT NOT NULL PRIMARY KEY identity, 
    [UserGuid] UNIQUEIDENTIFIER NOT NULL, 
    [Name] NCHAR(100) NOT NULL, 
    [LastName] NCHAR(100) NOT NULL, 
    [UserName] NCHAR(100) NOT NULL, 
    [Password] NCHAR(100) NOT NULL, 
    [RolId] INT NOT NULL,

    Constraint [FK_Users_Roles] Foreign Key ([RolId]) References [stbRoles](Id)
	

)
