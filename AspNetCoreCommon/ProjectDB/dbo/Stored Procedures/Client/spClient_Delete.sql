CREATE PROCEDURE [dbo].[spClient_Delete]
	@Id int
AS
BEGIN
	set nocount on;

	delete
	from dbo.Client
	where Id = @Id;
END
