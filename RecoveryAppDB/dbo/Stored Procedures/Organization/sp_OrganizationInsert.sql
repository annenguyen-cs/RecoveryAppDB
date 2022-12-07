CREATE PROCEDURE [dbo].[sp_OrganizationInsert]
	@Title nvarchar(100),
	@Street nvarchar(100),
	@City nvarchar(25),
	@ZipCode nvarchar(5),
	@Id int output
AS

BEGIN 
	
	SET NOCOUNT ON;

	INSERT INTO  dbo.Organization( [Title], [Street], [City], [ZipCode]) 
	VALUES (@Title, @Street, @City, @ZipCode);
	
	-- Scope Idenity: get the value of lastest identity value created in this scope (this stored procedure)
	SET @Id = SCOPE_IDENTITY();

END
