CREATE PROCEDURE [dbo].[spClient_GetById]
	@Id int
AS
BEGIN
	SELECT *
	FROM dbo.Client
	WHERE Id = @Id;
END
