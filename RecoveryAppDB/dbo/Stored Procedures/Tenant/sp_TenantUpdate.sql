CREATE PROCEDURE [dbo].[sp_TenantUpdate]
	@Id int,
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@Phone nvarchar(10),
	@Email nvarchar(100)
AS
BEGIN

	SET NOCOUNT ON;

	UPDATE dbo.Tenant
	SET FirstName = @FirstName,
		LastName = @LastName,
		Phone = @Phone,
		Email = @Email
	WHERE Id = @Id


END 