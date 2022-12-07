CREATE PROCEDURE [dbo].[sp_ManagerAll]

AS

BEGIN

	SET NOCOUNT ON;

	SELECT [Id], [FirstName], [LastName], [Email], [Phone], [OrganizationId], [TempDelete], [TempDeleteDate] 
	FROM dbo.Manager;

END