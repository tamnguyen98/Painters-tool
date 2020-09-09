CREATE PROCEDURE [dbo].[spClient_New]
	@FirstName nchar(50),
	@LastName nchar(60),
	@PhoneNumber nchar(15),
	@Email nchar(60),
	@HouseNum nchar(10),
	@Street nchar(40),
	@State nchar(28) = null,
	@City nchar(50) = null,
	@Cost money,
	@Status varchar(13),
	@ETA int = null,
	@StartDate date = null,
	@CompleteDate date = null,
	@ContractorID int,
	@Id int output
AS
BEGIN
	set nocount on;
	insert into dbo.[Client](FirstName, LastName, PhoneNumber, Email, HouseNum, Street, [State], City, Cost, [Status], ETA, StartDate, CompleteDate, ContractorID)
	values (@FirstName, @LastName, @PhoneNumber, @Email, @HouseNum, @Street, @State, @City, @Cost, @Status, @ETA, @StartDate, @CompleteDate, @ContractorID);

	set @Id = SCOPE_IDENTITY();
END
