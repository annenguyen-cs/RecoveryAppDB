CREATE PROCEDURE [dbo].[sp_UAResultByTenantId]
	@Id int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT [Id], [Result], [TestDate], [TenantId] 
	FROM UAResult
	WHERE TenantId = @Id;

END