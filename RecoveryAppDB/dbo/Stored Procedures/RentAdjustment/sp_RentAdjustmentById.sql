CREATE PROCEDURE [dbo].[sp_RentAdjustmentById]
	@Id int

AS

BEGIN

	SET NOCOUNT ON;

	SELECT [Id], [RentAmount], [AdjustmentDate], [TenantId] 
	FROM RentAdjustment 
	WHERE Id = @Id;
END