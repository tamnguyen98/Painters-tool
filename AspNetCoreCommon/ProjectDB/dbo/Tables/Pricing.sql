CREATE TABLE [dbo].[Pricing]
(
	[Id] int NOT NULL PRIMARY KEY IDENTITY,
	[Name] nvarchar(59) NOT NULL UNIQUE,
	[Price] money NOT NULL

)
