CREATE PROCEDURE [dbo].[sp_UAResultInsert]
	@Result bit,
	@TestDate datetime2(7),
	@TenantId int,
	@Id int output

AS
BEGIN
	SET NOCOUNT ON;


	INSERT INTO dbo.UAResult (Result, TestDate, TenantId)
	VALUES (@Result, @TestDate, @TenantId)
	
	SET @Id = SCOPE_IDENTITY();

END