CREATE PROCEDURE [dbo].[sp_EmergencyContactByTenantId]
	@Id int
AS

BEGIN

	SET NOCOUNT ON;
	
	SELECT [Id], [FirstName], [LastName], [Relationship], [Phone], [Email], [TenantId]
	FROM dbo.EmergencyContact
	WHERE TenantId = @Id;

END