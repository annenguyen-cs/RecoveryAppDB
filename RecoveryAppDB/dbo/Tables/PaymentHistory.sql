CREATE TABLE [dbo].[PaymentHistory]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[AmountPaid] decimal NOT NULL,
	[TransactionDate] DATETIME2 NOT NULL,
	[PaymentType] NVARCHAR(50) NOT NULL,
	[TenantId] INT NOT NULL, 
    CONSTRAINT [FK_PaymentHistory_Tenant] FOREIGN KEY ([TenantId]) REFERENCES [Tenant]([Id])

)
