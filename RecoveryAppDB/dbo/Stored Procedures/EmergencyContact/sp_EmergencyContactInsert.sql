CREATE PROCEDURE [dbo].[sp_EmergencyContactInsert]
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@Relationship nvarchar(50),
	@Phone nvarchar(10),
	@Email nvarchar(100),
	@TenantId int,
	@Id int output
AS

--ensure no dups
IF NOT EXISTS (SELECT Id FROM dbo.EmergencyContact WHERE TenantId = @TenantId)

BEGIN

	SET NOCOUNT ON;

	Select [Id], [FirstName], [LastName], [Relationship], [Phone], [Email], [TenantId]
	From EmergencyContact
	
	INSERT INTO dbo.EmergencyContact([FirstName], [LastName], [Relationship], [Phone], [Email], [TenantId])
	VALUES (@FirstName, @LastName, @Relationship, @Phone, @Email,  @TenantId)

	-- Scope Idenity: get the value of lastest identity value created in this scope (this stored procedure)
	SET @Id = SCOPE_IDENTITY();
	
END