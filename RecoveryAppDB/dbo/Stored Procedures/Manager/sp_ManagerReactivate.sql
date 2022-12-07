CREATE PROCEDURE [dbo].[sp_ManagerReactivate]
	@Id int
AS

--CHECK if TEMP DELETE IS 1  Else Skip
	IF EXISTS (SELECT Id FROM dbo.Manager WHERE Id = @Id AND TempDelete = 1)
BEGIN

	SET NOCOUNT ON;

	UPDATE dbo.Manager
	SET TempDelete = 0,
		TempDeleteDate = NULL
	WHERE Id = @Id;
	
END
