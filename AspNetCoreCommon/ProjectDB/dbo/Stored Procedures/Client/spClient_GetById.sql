CREATE PROCEDURE [dbo].[spClient_GetById]
	@Id int
AS
begin
	set nocount on;

	select [Id], [HouseNum], [Street], [State], [City], [Cost], [Status], [ETA], [StartDate], [CompleteDate]
	from dbo.Client
	where Id = @Id;

end
