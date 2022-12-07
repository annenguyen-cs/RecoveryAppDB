CREATE PROCEDURE [dbo].[sp_PaymentHistoryAll]


AS

BEGIN 
	SET NOCOUNT ON;
	
	SELECT [Id], [AmountPaid], [TransactionDate], [PaymentType], [TenantId]
	FROM PaymentHistory

END