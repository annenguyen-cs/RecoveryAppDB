CREATE TABLE [dbo].[TenantDetails]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[DepositPaid] bit NOT NULL,
	[IntakeDate] DATETIME2 NOT NULL,
	[RentalStatus] bit NOT NULL,
	[RentAmount] decimal NOT NULL,
	[FinesBalance] decimal NOT NULL,
	[TenantId] INT NOT NULL, 
    CONSTRAINT [FK_TenantDetails_Tenant] FOREIGN KEY ([TenantId]) REFERENCES [Tenant]([Id])

)
