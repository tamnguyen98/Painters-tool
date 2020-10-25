CREATE PROCEDURE [dbo].[spTask_AddTask]
	@ClientID int,
	@Task nchar(25),
	@Description nchar(200) = NULL,
	@Complete bit = 0,
	@ETA int = NULL,
	@Id int output
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO dbo.[Task]( ClientID, Task, [Description],Complete, ETA)
	VALUES ( @ClientID, @Task, @Description, @Complete, @ETA);

	set @Id = SCOPE_IDENTITY();
END
