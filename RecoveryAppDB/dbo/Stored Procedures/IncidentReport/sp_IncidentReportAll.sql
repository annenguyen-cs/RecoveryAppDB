CREATE PROCEDURE [dbo].[sp_IncidentReportAll]
	
AS

BEGIN 
	SET NOCOUNT ON;

	SELECT ir.TenantId, ir.Summary, ir.IncidentDate, ir.Id as Ir_Id
	FROM IncidentReport ir
	LEFT JOIN Tenant t
	ON ir.TenantId = t.Id
	WHERE t.TempDelete = 0
	ORDER BY ir.TenantId, ir.IncidentDate DESC

END
