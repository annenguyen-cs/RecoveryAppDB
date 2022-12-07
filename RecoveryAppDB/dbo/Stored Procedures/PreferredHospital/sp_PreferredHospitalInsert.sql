CREATE PROCEDURE [dbo].[sp_PreferredHospitalInsert]
	@HospitalName nvarchar(100),
	@Street nvarchar(100),
	@City nvarchar(25),
	@ZipCode nvarchar(5),
	@Phone nvarchar(10),
	@TenantId int,
	@Id int output

AS
BEGIN 
	SET NOCOUNT ON;

	INSERT INTO dbo.PreferredHospital ([HospitalName], [Street], [City], [ZipCode], [Phone], [TenantId])
	VALUES (@HospitalName, @Street, @City, @ZipCode, @Phone, @TenantId)

	
	SET @Id = SCOPE_IDENTITY();

END
	
