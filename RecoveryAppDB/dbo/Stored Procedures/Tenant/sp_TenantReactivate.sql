CREATE PROCEDURE [dbo].[sp_TenantReactivate]
	@Id int
AS

BEGIN

	--CHECK if TEMP DELETE IS 0  Else Skip
	IF EXISTS (SELECT Id FROM dbo.Tenant WHERE Id = @Id AND TempDelete = 1)
	
	--SET TEMP DELETE to 1
	--SET TempDeleteDate 
	UPDATE dbo.Tenant
	SET TempDelete = 0,
		TempDeleteDate = NULL
	WHERE Id = @Id;
	
END