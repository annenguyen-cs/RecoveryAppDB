CREATE PROCEDURE [dbo].[sp_FinesHistoryUpdate]
	@Amount decimal(18,0),
	@TransactionDate datetime2(7),
	@FromBalance bit,
	@TenantId int,
	@Id int

AS
BEGIN
	SET NOCOUNT ON;

	UPDATE FinesHistory
	SET Amount = @Amount,
		TransactionDate = @TransactionDate,
		FromBalance = @FromBalance,
		TenantId = TenantId
	WHERE Id = @Id

END
