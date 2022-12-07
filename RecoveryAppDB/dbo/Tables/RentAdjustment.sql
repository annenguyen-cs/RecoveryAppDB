CREATE TABLE [dbo].[RentAdjustment]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[RentAmount] DECIMAL(18,0) NOT NULL,
	[AdjustmentDate] DATETIME2 NOT NULL,
	[TenantId] INT NOT NULL, 
    CONSTRAINT [FK_RentAdjustment_Tenant] FOREIGN KEY ([TenantId]) REFERENCES [Tenant]([Id])
)
