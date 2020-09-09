CREATE PROCEDURE [dbo].[spClient_UpdateStatus]
	@Id int,
	@Status varchar(30),
	@ETA int = null,
	@StartDate date = null,
	@CompleteDate date = null
AS
BEGIN
	set nocount on;

	update dbo.Client
	set [Status] = @Status, ETA = @ETA, StartDate = @StartDate, CompleteDate = @CompleteDate
	where Id = @Id;
END