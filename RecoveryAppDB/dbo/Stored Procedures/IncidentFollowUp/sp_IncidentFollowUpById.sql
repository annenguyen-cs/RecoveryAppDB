CREATE PROCEDURE [dbo].[sp_IncidentFollowUpById]
	@Id int

AS

BEGIN 

	SET NOCOUNT ON;

	SELECT [Id], [Summary], [IncidentDate], [TenantId] 
	FROM IncidentReport
	WHERE Id = @Id;

END 