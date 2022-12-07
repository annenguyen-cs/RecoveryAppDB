CREATE PROCEDURE [dbo].[sp_OrganizationUpdateTitle]
	@Id int,
	@Title nvarchar(100)
AS

IF NOT EXISTS (SELECT Id FROM dbo.Organization WHERE Id = @Id AND TempDelete = 1)
BEGIN

	SET NOCOUNT ON;

	UPDATE dbo.[Organization]
	SET Title = @Title
	WHERE Id = @Id;
	
END

