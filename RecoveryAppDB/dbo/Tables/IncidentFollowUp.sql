CREATE TABLE [dbo].[IncidentFollowUp]
(
	[Id] INT NOT NULL PRIMARY KEY Identity,
	[FollowUpSummary] NVARChar(255) NOT NULL,
	[FollowUpDate] DATETIME2 NOT NULL,
	[IncidentId] INT NOT NULL, 
    CONSTRAINT [FK_IncidentFollowUp_IncidentReport] FOREIGN KEY ([IncidentId]) REFERENCES [IncidentReport]([Id])

)
