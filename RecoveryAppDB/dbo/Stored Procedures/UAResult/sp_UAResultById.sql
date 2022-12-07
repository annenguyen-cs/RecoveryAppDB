CREATE PROCEDURE [dbo].[sp_UAResultById]
	@Id int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT [Id], [Result], [TestDate], [TenantId] 
	FROM UAResult
	WHERE Id = @Id;

END