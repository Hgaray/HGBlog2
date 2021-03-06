CREATE TABLE [dbo].[tbComments]
(
	[Id] INT NOT NULL PRIMARY KEY identity, 
    [Detail] VARCHAR(MAX) NULL, 
    [PostId] INT NOT NULL,

    Constraint [FK_Comment_Post] Foreign Key (PostId) References [tbPosts](Id),

)
