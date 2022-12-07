CREATE PROCEDURE [dbo].[sp_UAResultByDate]
	@date datetime2(7)
AS
BEGIN 

	SET NOCOUNT ON;

	SELECT [Id], [Result], [TestDate], [TenantId] 
	FROM UAResult
	WHERE TestDate = @date
	ORDER BY TenantId, TestDate DESC;

END
