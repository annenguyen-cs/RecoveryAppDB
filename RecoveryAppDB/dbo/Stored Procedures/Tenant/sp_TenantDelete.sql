CREATE PROCEDURE [dbo].[sp_TenantDelete]
	@FiveYearDays int = 1825
AS

BEGIN
	
	SET NOCOUNT ON;

	-- validate if data is old enough to delete 5 years from time of TempDelete
	WITH tempData ( Id, TempDelete, TempDeleteDate)
	AS (
		SELECT [Id],[TempDelete], [TempDeleteDate] 
		FROM dbo.Tenant 
		WHERE DATEDIFF(DAY,(SELECT TempDeleteDate FROM dbo.Tenant WHERE TempDelete = 1), GETDATE()) >= @FiveYearDays 
	), incidentReportData (Id) --retrieve list of incident report id to match and remove in incident follow up table
	AS (
		SELECT ir.Id FROM dbo.IncidentReport ir
		LEFT JOIN tempData td
		ON ir.TenantId = td.Id
		WHERE td.Id IS NOT NULL
	), uaResultData (Id)  --retrieve list of ua result id to match and remove in ua follow up table
	AS (
		SELECT ua.Id FROM dbo.UAResult ua
		LEFT JOIN tempData td
		ON ua.TenantId = td.Id
		WHERE td.Id IS NOT NULL
	)

	--Delete tenant records from all tables
	DELETE dbo.Tenant FROM dbo.Tenant t
	LEFT JOIN tempData td
	ON t.Id = td.Id
	WHERE td.Id IS NOT NULL

	DELETE dbo.TenantDetails FROM dbo.TenantDetails t
	LEFT JOIN tempData td
	ON t.TenantId = td.Id
	WHERE td.Id IS NOT NULL

	DELETE dbo.EmergencyContact FROM dbo.EmergencyContact e
	LEFT JOIN tempData td
	ON e.TenantId = td.Id
	WHERE td.Id IS NOT NULL

	DELETE dbo.FinesHistory FROM dbo.FinesHistory f
	LEFT JOIN tempData td
	ON f.TenantId = td.Id
	WHERE td.Id IS NOT NULL

	DELETE dbo.PreferredHospital FROM dbo.PreferredHospital pre
	LEFT JOIN tempData td
	ON pre.TenantId = td.Id
	WHERE td.Id IS NOT NULL

	
	DELETE dbo.PaymentHistory FROM dbo.PaymentHistory ph
	LEFT JOIN tempData td
	ON ph.TenantId = td.Id
	WHERE td.Id IS NOT NULL

	DELETE dbo.RentAdjustment FROM dbo.RentAdjustment ra
	LEFT JOIN tempData td
	ON ra.TenantId = td.Id
	WHERE td.Id IS NOT NULL



	--before removing from IncidentReport must create cte for list of Incident Reports Id's to match Incident details to delete also
	
	DELETE dbo.IncidentReport FROM dbo.IncidentReport ir
	LEFT JOIN tempData td
	ON ir.TenantId = td.Id
	WHERE td.Id IS NOT NULL

	DELETE dbo.IncidentFollowUp FROM dbo.IncidentFollowUp inc
	LEFT JOIN incidentReportData ird
	ON inc.IncidentId = ird.Id
	WHERE ird.Id IS NOT NULL

	--before removing from UAResult must create cte for list of UAResults Id's to match UA FollowUps to delete also

	DELETE dbo.UAResult FROM dbo.UAResult ua
	LEFT JOIN tempData td
	ON ua.TenantId = td.Id
	WHERE td.Id IS NOT NULL

	DELETE dbo.UAFollowUp FROM dbo.UAFollowUp uaf
	LEFT JOIN uaResultData uad
	ON uaf.UAId = uad.Id
	WHERE uad.Id IS NOT NULL


END
