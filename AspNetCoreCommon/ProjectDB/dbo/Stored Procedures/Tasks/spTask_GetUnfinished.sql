CREATE PROCEDURE [dbo].[spTask_GetUnfinished]
	@ProjectID int
AS
BEGIN
	SELECT *
	FROM dbo.Task
	WHERE ClientID = @ProjectID AND Complete = 0;
END