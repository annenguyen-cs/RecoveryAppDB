CREATE PROCEDURE [dbo].[sp_FinesHistoryAll]


AS
BEGIN
	SET NOCOUNT ON;

	SELECT [Id], [Amount], [TransactionDate], [FromBalance], [TenantId] 
	FROM FinesHistory

END