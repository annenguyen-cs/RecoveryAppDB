CREATE PROCEDURE [dbo].[sp_UAResultByDate]
	@Date datetime2(7)
AS
BEGIN 

	SET NOCOUNT ON;

	SELECT [Id], [Result], [TestDate], [TenantId] 
	FROM UAResult
	WHERE TestDate = @Date
	ORDER BY TenantId, TestDate DESC;

END
