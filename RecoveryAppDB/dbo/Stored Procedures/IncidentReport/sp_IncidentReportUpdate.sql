CREATE PROCEDURE [dbo].[sp_IncidentReportUpdate]
	@Id int,
	@Summary nvarchar(255),
	@IncidentDate datetime2(7),
	@TenantId int
AS

IF EXISTS (SELECT Id FROM dbo.IncidentReport WHERE Id = @Id)
BEGIN
	
	SET NOCOUNT ON;

	UPDATE dbo.IncidentReport 
	SET Summary = @Summary,
		IncidentDate = @IncidentDate,
		TenantId = @TenantId
	WHERE Id = @Id;

END