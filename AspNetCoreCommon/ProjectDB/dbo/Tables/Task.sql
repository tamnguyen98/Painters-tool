CREATE TABLE [dbo].[Task]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ClientID] INT NOT NULL, 
    [Task] NCHAR(25) NOT NULL, 
    [Description] NCHAR(200) NULL, 
    [Complete] BIT NOT NULL DEFAULT 0, 
    [ETA] INT NULL
)
