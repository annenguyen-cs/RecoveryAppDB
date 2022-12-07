CREATE PROCEDURE [dbo].[sp_UAFollowUpInsert]
	@Summary nvarchar(255),
	@FollowUpDate datetime2(7),
	@UAId int,
	@Id int output
AS

BEGIN 
	SET NOCOUNT ON;

	INSERT INTO dbo.UAFollowUp (Summary, FollowUpDate, UAId)
	VALUES (@Summary, @FollowUpDate, @UAId)
	
	SET @Id = SCOPE_IDENTITY();

END