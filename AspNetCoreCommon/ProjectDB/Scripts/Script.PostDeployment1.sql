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
    insert into dbo.Client(HouseNum, Street, City, [State], Cost, [Status])
    values (2902, 'NE 145th Ave.', 'Vancouver', 'WA', 10,000.00, 'Not Started'),
    (1212, 'Downtown', 'Vancouver', 'WA', 12,000.00, 'Started');
end
