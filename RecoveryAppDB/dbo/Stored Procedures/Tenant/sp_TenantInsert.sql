CREATE PROCEDURE [dbo].[sp_TenantInsert]
	@FirstName nvarchar(50), 
	@LastName nvarchar(50), 
	@Phone nvarchar(10),
	@Email nvarchar(100), 
	@ManagerId int,
	@Id int output
AS

BEGIN
	SET NOCOUNT ON;
	
	INSERT INTO dbo.Tenant ([FirstName], [LastName], [Phone], [Email], [ManagerId])
	VALUES (@FirstName, @LastName, @Phone, @Email, @ManagerId)

	-- Scope Idenity: get the value of lastest identity value created in this scope (this stored procedure)
	SET @Id = SCOPE_IDENTITY();


END