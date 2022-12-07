CREATE PROCEDURE [dbo].[sp_TenantDetailsUpdate]
	@DepositPaid decimal, 
	@IntakeDate DateTime2, 
	@RentalStatus bit, 
	@RentAmount decimal, 
	@FinesBalance decimal, 
	@TenantId int 
AS

BEGIN

	SET NOCOUNT ON; 
	
	UPDATE dbo.TenantDetails
	SET DepositPaid = @DepositPaid,
		RentalStatus = @RentalStatus,
		RentAmount = @RentAmount,
		FinesBalance = @FinesBalance
	WHERE TenantId = @TenantId;
	

END