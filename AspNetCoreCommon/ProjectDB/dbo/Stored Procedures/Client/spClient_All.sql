CREATE PROCEDURE [dbo].[spClient_All]
AS
begin
	set nocount on;
	
	select [Id], [FirstName], [LastName], [PhoneNumber], [Email], [HouseNum], [Street], [City], [State], [Cost], [Status], [ETA], [StartDate], [CompleteDate], [ContractorID]
	from dbo.Client;
end
