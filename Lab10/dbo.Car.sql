CREATE TABLE [dbo].[Car]
(
    [Registration_Number] NCHAR(10) NOT NULL, 
    [Color] NCHAR(10) NULL, 
    [Brand] NCHAR(10) NULL, 
    [Owner] INT NULL, 
    PRIMARY KEY ([Registration_Number]), 
    CONSTRAINT [FK_Car_ToPerson] FOREIGN KEY ([Owner]) REFERENCES [Person]([Id])
)
