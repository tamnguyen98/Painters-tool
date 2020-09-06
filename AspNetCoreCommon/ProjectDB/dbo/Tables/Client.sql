CREATE TABLE [dbo].[Client]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [HouseNum] INT NOT NULL, 
    [Street] NCHAR(40) NOT NULL, 
    [State] NCHAR(28) NULL, 
    [City] NCHAR(50) NULL, 
    [Cost] MONEY NOT NULL, 
    [Status] VARCHAR(13) NOT NULL, 
    [ETA] INT NULL, 
    [StartDate] DATE NULL, 
    [CompleteDate] DATE NULL

)
