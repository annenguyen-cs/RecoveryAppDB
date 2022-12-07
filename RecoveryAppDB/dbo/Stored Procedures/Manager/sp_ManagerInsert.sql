CREATE PROCEDURE [dbo].[sp_ManagerInsert]
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@Email nvarchar(100),
	@Phone nvarchar(10),
	@OrganizationId int,
	@Id int output
AS
	
BEGIN

	SET NOCOUNT ON;

	INSERT INTO dbo.Manager (FirstName, LastName, Email, Phone, OrganizationId)
	VALUES (@FirstName, @LastName, @Email, @Phone, @OrganizationId)
	
	SET @Id = SCOPE_IDENTITY();
END
