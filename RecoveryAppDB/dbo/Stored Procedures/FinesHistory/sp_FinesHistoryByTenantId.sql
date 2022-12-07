CREATE PROCEDURE [dbo].[sp_FinesHistoryByTenantId]
	@Id int

AS

BEGIN 
	SET NOCOUNT ON;

	SELECT [Id], [Amount], [TransactionDate], [FromBalance], [TenantId] 
	FROM FinesHistory
	WHERE TenantId = @Id;

END
