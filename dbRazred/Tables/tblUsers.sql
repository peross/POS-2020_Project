CREATE TABLE [dbo].[tblUsers]
(
	[Username] NVARCHAR(32) NOT NULL PRIMARY KEY, 
    [Password] NVARCHAR(32) NOT NULL, 
    [RoleId] INT NOT NULL, 
    CONSTRAINT [FK_tblUsers_tblRole] FOREIGN KEY ([RoleId]) REFERENCES [tblRole]([RoleId])
)
