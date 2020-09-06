CREATE PROCEDURE [dbo].[spClient_GetByHouse]
	@HouseNum int,
	@Street nvarchar(50) = null
AS
IF @Street IS NULL
BEGIN
	SELECT *
	FROM dbo.Client
	WHERE HouseNum = @HouseNum;
END
ELSE
BEGIN
	SELECT *
	FROM dbo.Client
	WHERE HouseNum = @HouseNum AND Street = @Street;
END