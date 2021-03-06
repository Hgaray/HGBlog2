CREATE TABLE [dbo].[tbPosts]
(
	[Id] INT NOT NULL PRIMARY KEY identity, 
    [CreationDate] DATETIME2 NULL, 
    [TitlePost] VARCHAR(500) NULL,
    [PostText] VARCHAR(MAX) NOT NULL, 
    [UserId] INT NOT NULL, 
    [StateId] INT NOT NULL,

    Constraint [FK_Posts_Users] Foreign Key (UserId) References [tbUsers](Id),
    Constraint [FK_Posts_States] Foreign Key ([StateId]) References [stbStates](Id)
)
