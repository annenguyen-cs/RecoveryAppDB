CREATE PROCEDURE [dbo].[sp_OrganizationDelete]
	@Id int
AS


BEGIN

	SET NOCOUNT ON;

	DELETE from dbo.Organization
	WHERE Id = @Id;

END

