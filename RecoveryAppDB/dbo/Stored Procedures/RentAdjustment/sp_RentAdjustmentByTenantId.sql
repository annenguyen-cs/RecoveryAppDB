CREATE PROCEDURE [dbo].[sp_RentAdjustmentByTenantId]
	@Id int

AS

BEGIN 
	SET NOCOUNT ON;

	SELECT [Id], [RentAmount], [AdjustmentDate], [TenantId] 
	FROM RentAdjustment
	WHERE TenantId = @Id

END