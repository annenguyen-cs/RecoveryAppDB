CREATE PROCEDURE [dbo].[sp_IncidentReportInsert]
	@Summary nvarchar(255),
	@IncidentDate datetime2(7),
	@TenantId int,
	@Id int output
AS
	
BEGIN

	INSERT INTO dbo.IncidentReport (Summary, IncidentDate, TenantId)
	VALUES (@Summary, @IncidentDate, @TenantId)
	
	SET @Id = SCOPE_IDENTITY();
END
