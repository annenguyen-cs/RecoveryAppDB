CREATE PROCEDURE [dbo].[sp_RentAdjustmentUpdate]
	@RentAmount decimal(18,0),
	@AdjustmentDate datetime2(7),
	@TenantId int,
	@Id int output

AS

BEGIN 
	SET NOCOUNT ON;

	UPDATE RentAdjustment 
	SET RentAmount = @RentAmount,
		AdjustmentDate = @AdjustmentDate,
		TenantId = @TenantId
	WHERE Id = @Id
END 
