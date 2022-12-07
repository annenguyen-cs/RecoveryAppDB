CREATE PROCEDURE [dbo].[sp_OrganizationAll]


AS

BEGIN

	SET NOCOUNT ON;

	SELECT [Id], [Title], [Street], [City], [ZipCode], [TempDelete], [TempDeleteDate] 
	FROM dbo.Organization;


END
