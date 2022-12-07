CREATE PROCEDURE [dbo].[sp_ManagerDelete]
	@Id int
AS

BEGIN 

	SET NOCOUNT ON;

	DELETE FROM dbo.Manager
	WHERE Id = @Id;

END