CREATE PROCEDURE [dbo].[sp_OrganiztionTempDelete]
	@Id int
AS
--CHECK if TEMP DELETE IS 0  Else Skip
	IF EXISTS (SELECT Id FROM dbo.Organization WHERE Id = @Id AND TempDelete = 0)
BEGIN

	--SET TEMP DELETE to 1
	--SET TempDeleteDate 
	UPDATE dbo.Organization
	SET TempDelete = 1,
		TempDeleteDate = GETDATE()
	WHERE Id = @Id;
	
END
