CREATE PROCEDURE [dbo].[spTask_CompleteTask]
	@Id int,
	@Complete bit
AS
BEGIN
	UPDATE dbo.Task
	SET Complete = @Complete
	WHERE Id = @Id;
END