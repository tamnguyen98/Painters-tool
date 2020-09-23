CREATE PROCEDURE [dbo].[spTask_Delete]
	@Id int
AS
BEGIN
	DELETE
	FROM dbo.[Task]
	WHERE Id = @Id;
END
