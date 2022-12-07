CREATE PROCEDURE [dbo].[sp_UAResultUpdate]
	@Result bit,
	@TestDate datetime2(7),
	@TenantId int,
	@Id int

AS
BEGIN
	SET NOCOUNT ON;

	UPDATE dbo.UAResult
	SET Result = @Result,
		TestDate = @TestDate,
		TenantId = @TenantId
	WHERE Id = @Id;

END