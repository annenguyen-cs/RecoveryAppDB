CREATE PROCEDURE [dbo].[sp_PreferredHospitalUpdate]
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

	UPDATE dbo.PreferredHospital
	SET HospitalName = @HospitalName,
		Street = @Street,
		City = @City,
		ZipCode = @ZipCode,
		Phone = @Phone,
		TenantId = @TenantId
	WHERE Id = @Id;

END