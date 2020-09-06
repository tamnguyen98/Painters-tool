CREATE PROCEDURE [dbo].[spClient_All]
AS
begin
	set nocount on;
	
	select [Id], [HouseNum], [Street], [State], [City], [Cost], [Status], [ETA], [StartDate], [CompleteDate] 
	from dbo.Client;
end
