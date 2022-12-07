CREATE PROCEDURE [dbo].[sp_IncidentFollowUpInsert]
	@FollowUpSummary nvarchar(255),
	@FollowUpDate datetime2(7),
	@IncidentId int,
	@Id int output
AS
	
BEGIN

	SET NOCOUNT ON;

	INSERT INTO dbo.IncidentFollowUp (FollowUpSummary, FollowUpDate, IncidentId)
	VALUES (@FollowUpSummary, @FollowUpDate, @IncidentId)
	
	SET @Id = SCOPE_IDENTITY();
END
