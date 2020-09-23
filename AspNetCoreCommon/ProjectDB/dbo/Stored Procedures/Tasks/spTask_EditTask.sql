CREATE PROCEDURE [dbo].[spTask_EditTask]
	@Id int,
	@Task nchar(25),
	@Description nchar(200) = NULL
AS
BEGIN
	UPDATE dbo.Task
	SET Task = @Task, [Description] = @Description
	WHERE Id = @Id;
END