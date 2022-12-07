CREATE TABLE [dbo].[IncidentReport]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Summary] NVARCHAR(255) NOT NULL,
	[IncidentDate] DATETIME2 NOT NULL,
	[TenantId] INT NOT NULL, 
    CONSTRAINT [FK_IncidentReport_Tenant] FOREIGN KEY ([TenantId]) REFERENCES [Tenant]([Id])

)
