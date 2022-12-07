CREATE PROCEDURE [dbo].[sp_ManagerTempDelete]
	@Id int
AS

--CHECK if TEMP DELETE IS 0  Else Skip
	IF EXISTS (SELECT Id FROM dbo.Manager WHERE Id = @Id AND TempDelete = 0)

BEGIN

	--SET TEMP DELETE to 1
	--SET TempDeleteDate 
	UPDATE dbo.Manager
	SET TempDelete = 1,
		TempDeleteDate = GETDATE()
	WHERE Id = @Id;
	
END
