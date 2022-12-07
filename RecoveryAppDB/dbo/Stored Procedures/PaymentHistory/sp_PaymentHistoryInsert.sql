CREATE PROCEDURE [dbo].[sp_PaymentHistoryInsert]
	@AmountPaid decimal(18,0),
	@TransactionDate datetime2(7),
	@PaymentType nvarchar(50),
	@TenantId int,
	@Id int output

AS

BEGIN

	SET NOCOUNT ON;
	
	INSERT INTO PaymentHistory ([Id], [AmountPaid], [TransactionDate], [PaymentType], [TenantId])
	VALUES (@Id, @AmountPaid, @TransactionDate, @PaymentType, @TenantId)

	SET @Id = SCOPE_IDENTITY();

END
