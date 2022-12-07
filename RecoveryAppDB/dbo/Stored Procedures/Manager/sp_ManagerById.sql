CREATE PROCEDURE [dbo].[sp_ManagerById]
	@Id int
AS

-- Ensure tenant is not currently on tempDelete status
IF NOT EXISTS (SELECT Id FROM dbo.Manager WHERE Id = @Id AND TempDelete = 1)

BEGIN

	SET NOCOUNT ON;

	SELECT [Id], [FirstName], [LastName], [Email], [Phone], [OrganizationId] 
	FROM dbo.Manager
	WHERE Id = @Id;

END