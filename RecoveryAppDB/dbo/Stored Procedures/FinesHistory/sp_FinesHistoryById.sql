CREATE PROCEDURE [dbo].[sp_FinesHistoryById]
	@Id int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT [Id], [Amount], [TransactionDate], [FromBalance], [TenantId] 
	FROM FinesHistory
	WHERE Id = @Id

END