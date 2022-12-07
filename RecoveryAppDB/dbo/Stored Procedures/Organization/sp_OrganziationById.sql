CREATE PROCEDURE [dbo].[sp_OrganziationById]
	@Id int 
AS

-- Ensure tenant is not currently on tempDelete status
IF NOT EXISTS (SELECT Id FROM dbo.Organization WHERE Id = @Id AND TempDelete = 1)

BEGIN

	SET NOCOUNT ON;

	SELECT [Id], [Title], [Street], [City], [ZipCode], [TempDelete], [TempDeleteDate] 
	FROM dbo.Organization
	WHERE Id = @Id;

END
