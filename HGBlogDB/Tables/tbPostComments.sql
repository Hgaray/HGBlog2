CREATE TABLE [dbo].[tbPostComments]
(
	[Id] INT NOT NULL PRIMARY KEY identity, 
    [PostId] INT NOT NULL, 
    [CreationDate] DATETIME2 NULL, 
    [CommentText] VARCHAR(MAX) NULL, 
    [OwnerComment] NCHAR(100) NULL,

    Constraint [FK_PostComments_Post] Foreign Key ([PostId]) References [tbPosts](Id),
)
