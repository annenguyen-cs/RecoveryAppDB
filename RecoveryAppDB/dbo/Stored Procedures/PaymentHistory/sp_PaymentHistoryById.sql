CREATE PROCEDURE [dbo].[sp_PaymentHistoryById]
	@Id int

AS

BEGIN 
	SET NOCOUNT ON;
	
	SELECT [Id], [AmountPaid], [TransactionDate], [PaymentType], [TenantId]
	FROM PaymentHistory
	WHERE Id = @Id

END