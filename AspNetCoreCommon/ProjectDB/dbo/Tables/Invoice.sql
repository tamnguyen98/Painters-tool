CREATE TABLE [dbo].[Invoice]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [ClientID] INT NOT NULL,
	[PricingID] INT NOT NULL,
	[Name] nvarchar(50) NOT NULL,
	[Quantity] int NOT NULL DEFAULT 0,
	[Total] money NOT NULL DEFAULT 0, 
    CONSTRAINT [FK_Invoice_ToClient] FOREIGN KEY ([ClientID]) REFERENCES [Client]([Id]), 
    CONSTRAINT [FK_Invoice_ToPricing] FOREIGN KEY ([PricingID]) REFERENCES [Pricing]([Id]) 
)
