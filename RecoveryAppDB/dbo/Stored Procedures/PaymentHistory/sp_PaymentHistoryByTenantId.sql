CREATE PROCEDURE [dbo].[sp_PaymentHistoryByTenantId]
	@Id int

AS

BEGIN 
	SET NOCOUNT ON;
	
	SELECT [Id], [AmountPaid], [TransactionDate], [PaymentType], [TenantId]
	FROM PaymentHistory
	WHERE TenantId = @Id

END