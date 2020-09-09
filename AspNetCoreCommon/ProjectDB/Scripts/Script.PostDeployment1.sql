/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

if not exists (select * from dbo.Client)
begin
    insert into dbo.Client(FirstName, LastName, PhoneNumber, Email, HouseNum, Street, City, [State], Cost, [Status], ContractorID)
    values ('Tam', 'Nguyen', '3609779642', '123@yahoo.com', '2902', 'NE 145th Ave.', 'Vancouver', 'WA', 10000, 'Not Started', 1),
    ('Yajaira', 'Nguyen', '3603602334', 'qwe@yahoo.com', '1212', 'Downtown', 'Vancouver', 'WA', 12000, 'Started', 1);
end
