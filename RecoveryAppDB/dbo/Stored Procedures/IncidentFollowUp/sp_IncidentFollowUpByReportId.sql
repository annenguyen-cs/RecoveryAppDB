CREATE PROCEDURE [dbo].[sp_IncidentFollowUpByReportId]
	@Id int

AS

BEGIN
		
		SET NOCOUNT ON;
	
		SELECT [Id], [FollowUpSummary], [FollowUpDate], [IncidentId]
		FROM IncidentFollowUp
		WHERE IncidentId = @Id
		ORDER BY FollowUpDate 
END
