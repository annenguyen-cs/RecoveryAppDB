CREATE PROCEDURE [dbo].[sp_UAFollowUpUpdate]
	@Summary nvarchar(255),
	@FollowUpDate datetime2(7),
	@UAId int,
	@Id int
AS

BEGIN 
	SET NOCOUNT ON;

	UPDATE dbo.UAFollowUp
	SET Summary = @Summary,
		FollowUpDate = @FollowUpDate,
		UAId = @UAId
	WHERE Id = @Id

END