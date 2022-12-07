CREATE TABLE [dbo].[PreferredHospital]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[HospitalName] NVARCHAR(100) NOT NULL,
	[Street] NVARCHAR(100),
	[City] NVARCHAR(25) NOT NULL,
	[ZipCode] NVARCHAR(5),
	[Phone] NVARCHAR(10),
	[TenantId] INT NOT NULL, 
    CONSTRAINT [FK_PreferredHospital_Tenant] FOREIGN KEY ([TenantId]) REFERENCES [Tenant]([Id])

	
)
