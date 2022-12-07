﻿CREATE TABLE [dbo].[Organization]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Title] NVARCHAR(100) NOT NULL,
	[Street] NVARCHAR(100) NOT NULL,
	[City] NVARCHAR(25) NOT NULL,
	[ZipCode] NVARCHAR(5) NOT NULL, 
    [TempDelete] BIT NULL, 
    [TempDeleteDate] DATETIME2 NULL
)
