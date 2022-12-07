CREATE PROCEDURE [dbo].[sp_RentAdjustmentAll]
	
AS
BEGIN
	SET NOCOUNT ON;

	SELECT [Id], [RentAmount], [AdjustmentDate], [TenantId] 
	FROM RentAdjustment
	ORDER BY TenantId, AdjustmentDate DESC

END
