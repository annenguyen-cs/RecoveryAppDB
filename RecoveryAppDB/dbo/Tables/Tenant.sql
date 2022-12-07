CREATE TABLE [dbo].[Tenant]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(50) NOT NULL,
	[LastName] NVARCHAR(50) NOT NULL,
	[Phone] NVARCHAR(10) NOT NULL,
	[Email] NVARCHAR(100),
	[ManagerId] INT NOT NULL, 
    [TempDelete] BIT NULL, 
    [TempDeleteDate] DATETIME2 NULL, 
    CONSTRAINT [FK_Tenant_Manager] FOREIGN KEY ([ManagerId]) REFERENCES [Manager]([Id])

)
