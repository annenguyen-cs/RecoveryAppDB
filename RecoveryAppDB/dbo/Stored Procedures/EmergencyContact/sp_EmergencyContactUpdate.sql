CREATE PROCEDURE [dbo].[sp_EmergencyContactUpdate]
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@Relationship nvarchar(50),
	@Phone nvarchar(10),
	@Email nvarchar(100),
	@TenantId int,
	@Id int

AS

IF NOT EXISTS (SELECT Id FROM dbo.Tenant WHERE Id = @TenantId AND TempDelete = 1)
BEGIN 

	SET NOCOUNT ON;

	UPDATE dbo.EmergencyContact
	SET FirstName = @FirstName,
		LastName = @LastName,
		Email = @Email,
		Phone = @Phone,
		Relationship = @Relationship
	WHERE Id = @Id

END
