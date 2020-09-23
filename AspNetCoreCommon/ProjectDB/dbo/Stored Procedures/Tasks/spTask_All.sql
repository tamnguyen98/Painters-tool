CREATE PROCEDURE [dbo].[spTask_All]
	@ProjectID int
AS
BEGIN
	SELECT *
	FROM dbo.Task
	WHERE ClientID = @ProjectID
END