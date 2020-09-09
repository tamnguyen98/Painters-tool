CREATE TABLE [dbo].[Client]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [FirstName] nchar(50) NOT NULL,
    [LastName] nchar(60) NOT NULL,
    [PhoneNumber] nchar(15) NOT NULL,
    [Email] nchar(60),
    [HouseNum] NCHAR(10) NOT NULL, 
    [Street] NCHAR(40) NOT NULL, 
    [City] NCHAR(50) NULL, 
    [State] NCHAR(28) NULL, 
    [Cost] MONEY NULL, 
    [Status] VARCHAR(13) NOT NULL, 
    [ETA] INT NULL, 
    [StartDate] DATE NULL, 
    [CompleteDate] DATE NULL,
    [ContractorID] INT NOT NULL
)
