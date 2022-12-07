CREATE PROCEDURE [dbo].[sp_TenantDetailsInsert]
	@DepositPaid decimal, 
	@IntakeDate DateTime2, 
	@RentalStatus bit, 
	@RentAmount decimal, 
	@FinesBalance decimal, 
	@TenantId int,
	@Id int output
AS

BEGIN
	SET NOCOUNT ON;
	
	INSERT INTO dbo.TenantDetails (DepositPaid, IntakeDate, RentalStatus, RentAmount, FinesBalance, TenantId )
	VALUES (@DepositPaid, @IntakeDate, @RentalStatus, @RentAmount, @FinesBalance, @TenantId)

	-- Scope Idenity: get the value of lastest identity value created in this scope (this stored procedure)
	SET @Id = SCOPE_IDENTITY();


END 