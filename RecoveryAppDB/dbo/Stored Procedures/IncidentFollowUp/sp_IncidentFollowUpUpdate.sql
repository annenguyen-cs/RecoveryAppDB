CREATE PROCEDURE [dbo].[sp_IncidentFollowUpUpdate]
	@FollowUpSummary nvarchar(255),
	@FollowUpDate datetime2(7),
	@IncidentId int,
	@Id int  
AS

BEGIN
	
	SET NOCOUNT ON;

	UPDATE dbo.IncidentFollowUp 
	SET FollowUpSummary = @FollowUpSummary,
		FollowUpDate = @FollowUpDate,
		IncidentId = @IncidentId
	WHERE Id = @Id;

END