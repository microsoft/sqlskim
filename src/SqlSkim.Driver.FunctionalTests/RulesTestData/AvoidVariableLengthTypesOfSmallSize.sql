 CREATE TABLE [dbo].[TableWithWarning]
( 
[ID] INT NOT NULL IDENTITY(0, 1), 
[c1] INT NOT NULL PRIMARY KEY, 
[c2] INT,
[c3] INT,
[SmallBinary] VARBINARY(1),
[SmallUnicodeString] NVARCHAR (1),
[SmallString] VARCHAR(2)
)
ON [PRIMARY]

CREATE TABLE [dbo].[FixedTable]
( 
[ID] INT NOT NULL IDENTITY(0, 1), 
[c1] INT NOT NULL PRIMARY KEY, 
[c2] INT,
[c3] INT,
[SmallBinary] VARBINARY(10),
[SmallUnicodeString] NVARCHAR (3),
[SmallString] VARCHAR(41))
ON [PRIMARY]