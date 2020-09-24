CREATE PROCEDURE [dbo].[spTask_UpdateTaskStatus]
	@Id int,
	@Complete bit
AS
BEGIN
	UPDATE dbo.Task
	SET Complete = @Complete
	WHERE Id = @Id;
END