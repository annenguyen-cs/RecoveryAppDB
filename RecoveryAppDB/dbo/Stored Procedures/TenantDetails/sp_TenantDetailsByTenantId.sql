CREATE PROCEDURE [dbo].[sp_TenantDetailsByTenantId]
	@Id int -- Id of tenant - not Id of the tenantDetail record

AS
-- Ensure tenant is not currently on tempDelete status
IF NOT EXISTS (SELECT Id FROM dbo.Tenant WHERE Id = @Id AND TempDelete = 1)
BEGIN

	SET NOCOUNT ON; 
	
	SELECT [Id], [DepositPaid], [IntakeDate], [RentalStatus], [RentAmount], [FinesBalance], [TenantId] 
	FROM dbo.TenantDetails
	WHERE TenantId = @Id
	
END