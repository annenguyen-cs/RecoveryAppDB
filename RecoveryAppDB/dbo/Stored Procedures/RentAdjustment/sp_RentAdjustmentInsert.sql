CREATE PROCEDURE [dbo].[sp_RentAdjustmentInsert]
	@RentAmount decimal(18,0),
	@AdjustmentDate datetime2(7),
	@TenantId int,
	@Id int output

AS

BEGIN 
	SET NOCOUNT ON;

	INSERT INTO RentAdjustment (RentAmount, AdjustmentDate, TenantId)
	VALUES (@RentAmount, @AdjustmentDate, @TenantId)

END 
