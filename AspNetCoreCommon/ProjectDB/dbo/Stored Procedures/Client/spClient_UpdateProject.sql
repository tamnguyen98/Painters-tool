CREATE PROCEDURE [dbo].[spClient_UpdateProject]
	@Id int,
	@FirstName nchar(50),
	@LastName nchar(60),
	@Email nchar(60),
	@PhoneNumber nchar(15),
	@Cost money,
	@HouseNum nchar(10),
	@Street nchar(40),
	@City nchar(50),
	@State nchar(28)
AS
BEGIN
	set nocount on;

	update dbo.Client
	set FirstName = @FirstName, LastName = @LastName, PhoneNumber = @PhoneNumber, Cost = @Cost, @HouseNum = @HouseNum, @Street = @Street, City = @City, [State] = @State
	where Id = @Id;
END