CREATE PROCEDURE [dbo].[sp_UAFollowUpByResultId]
	@Id int

AS

BEGIN

	SET NOCOUNT ON;

	SELECT [Id], [Summary], [FollowUpDate], [UAId] 
	FROM UAFollowUp
	WHERE UAId = @Id;

END