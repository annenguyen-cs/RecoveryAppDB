CREATE TABLE [dbo].[EmergencyContact]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(50) NOT NULL,
	[LastName] NVARCHAR(50),
	[Relationship] NVARCHAR(50),
	[Phone] NVARCHAR(10) NOT NULL,
	[Email] NVARCHAR(100),
	[TenantId] INT NOT NULL, 
    CONSTRAINT [FK_EmergencyContact_Tenant] FOREIGN KEY ([TenantId]) REFERENCES [Tenant]([Id])
)
