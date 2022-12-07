CREATE TABLE [dbo].[UAResult]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Result] bit NOT NULL,
	[TestDate] DATETIME2 NOT NULL,
	[TenantId] INT NOT NULL, 
    CONSTRAINT [FK_UAResult_Tenant] FOREIGN KEY ([TenantId]) REFERENCES [Tenant]([Id])

)
