CREATE PROCEDURE [dbo].[sp_FinesHistoryInsert]
	@Amount decimal(18,0),
	@TransactionDate datetime2(7),
	@FromBalance bit,
	@TenantId int,
	@Id int

AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO FinesHistory(Amount, TransactionDate, FromBalance, TenantId)
	VALUES (@Amount, @TransactionDate, @FromBalance, @TenantId)

	SET @Id = SCOPE_IDENTITY();
END
