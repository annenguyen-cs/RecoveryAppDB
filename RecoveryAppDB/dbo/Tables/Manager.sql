CREATE TABLE [dbo].[Manager]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(50) NOT NULL,
	[LastName] NVARCHAR(50) NOT NULL,
	[Email] NVARCHAR(100) NOT NULL,
	[Phone] NVARCHAR(10) NOT NULL,
	[OrganizationId] INT NOT NULL,
    [TempDelete] BIT NULL, 
    [TempDeleteDate] DATETIME2 NULL, 
    CONSTRAINT [FK_Manager_Organization] FOREIGN KEY (OrganizationId) REFERENCES [Organization]([Id]) 


)
