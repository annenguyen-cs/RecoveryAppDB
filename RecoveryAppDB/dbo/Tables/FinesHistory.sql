CREATE TABLE [dbo].[FinesHistory]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Amount] decimal NOT NULL,
	[TransactionDate] DateTime2 NOT NULL,
	[FromBalance] bit NOT NULL,
	[TenantId] INT NOT NULL, 
    CONSTRAINT [FK_FinesHistory_Tenant] FOREIGN KEY ([TenantId]) REFERENCES [Tenant]([Id])

) 
