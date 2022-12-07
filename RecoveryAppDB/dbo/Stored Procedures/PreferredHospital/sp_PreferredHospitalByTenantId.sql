CREATE PROCEDURE [dbo].[sp_PreferredHospitalByTenantId]
	@Id int
AS


IF NOT EXISTS (SELECT Id FROM dbo.Tenant WHERE Id = @Id AND TempDelete = 1)

BEGIN
	
	SET NOCOUNT ON;

	SELECT [Id], [HospitalName], [Street], [City], [ZipCode], [Phone], [TenantId]
	FROM PreferredHospital
	WHERE TenantId = @Id

END