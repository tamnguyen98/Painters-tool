CREATE PROCEDURE [dbo].[spClient_UpdateProject]
	@Id int,
	@FirstName nchar(50),
	@LastName nchar(60),
	@Email nchar(60) = null,
	@PhoneNumber nchar(15),
	@Cost money = null,
	@HouseNum nchar(10),
	@Street nchar(40),
	@City nchar(50) = null,
	@State nchar(28) = null,
	@Status varchar(30),
	@ETA int = null,
	@StartDate date = null,
	@CompleteDate date = null,
	@ContractorID int = null /* Empty field. Using so I can reuse the model */
AS
BEGIN
	set nocount on;

	update dbo.Client
	set FirstName = @FirstName, 
		LastName = @LastName, 
		Email = @Email,
		PhoneNumber = @PhoneNumber, 
		Cost = @Cost, 
		HouseNum = @HouseNum, 
		Street = @Street, 
		City = @City, 
		[State] = @State, 
		[Status] = @Status, 
		ETA = @ETA, 
		StartDate = @StartDate, 
		CompleteDate = @CompleteDate
	where Id = @Id;
END