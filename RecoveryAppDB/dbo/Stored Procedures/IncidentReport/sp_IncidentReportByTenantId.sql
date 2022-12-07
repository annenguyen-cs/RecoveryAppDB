CREATE PROCEDURE [dbo].[sp_IncidentReportByTenantId]
	@Id int
AS


--CHECK if TEMP DELETE IS 1  Else Skip
	IF EXISTS (SELECT Id FROM dbo.Tenant WHERE Id = @Id AND TempDelete = 1)
BEGIN 

	SET NOCOUNT ON;

	SELECT ir.TenantId, ir.Summary, ir.IncidentDate, ir.Id as Ir_Id
	FROM IncidentReport ir
	WHERE ir.TenantId = @Id
	ORDER BY ir.IncidentDate DESC

END

