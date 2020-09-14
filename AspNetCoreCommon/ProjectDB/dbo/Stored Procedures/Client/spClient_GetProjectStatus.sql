CREATE PROCEDURE [dbo].[spClient_GetProjectStatus]
	@Id int
AS
BEGIN
	SELECT [Status], ETA, StartDate, CompleteDate
	FROM dbo.Client
	WHERE Id = @Id;
END
