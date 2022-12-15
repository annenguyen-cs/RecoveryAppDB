CREATE PROCEDURE [dbo].[sp_PaymentHistoryUpdate]
	@AmountPaid decimal(18,0),
	@TransactionDate datetime2(7),
	@PaymentType nvarchar(50),
	@TenantId int,
	@Id int output

AS

BEGIN

	SET NOCOUNT ON;
	
	UPDATE dbo.[PaymentHistory]
	SET AmountPaid = @AmountPaid,
		TransactionDate = @TransactionDate,
		PaymentType = @PaymentType,
		TenantId = @TenantId
	WHERE Id = @Id;

END

