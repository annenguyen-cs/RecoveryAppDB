CREATE PROCEDURE [dbo].[sp_ManagerUpdate]
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@Email nvarchar(100),
	@Phone nvarchar(10),
	@Id int
AS

IF NOT EXISTS (SELECT Id FROM dbo.Manager WHERE Id = @Id AND TempDelete = 1)
BEGIN
	
	SET NOCOUNT ON;

	UPDATE dbo.Manager 
	SET FirstName = @FirstName,
		LastName = @LastName,
		Email = @Email,
		Phone = @Phone
	WHERE Id = @Id;

END