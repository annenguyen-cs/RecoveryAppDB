CREATE PROCEDURE [dbo].[sp_OrganizationReactivate]
	@Id int
AS
--CHECK if TEMP DELETE IS 1  Else Skip
	IF EXISTS (SELECT Id FROM dbo.Organization WHERE Id = @Id AND TempDelete = 1)
BEGIN

	--SET TEMP DELETE to 0
	--SET TempDeleteDate 
	UPDATE dbo.Organization
	SET TempDelete = 0,
		TempDeleteDate = NULL
	WHERE Id = @Id;
	
END
