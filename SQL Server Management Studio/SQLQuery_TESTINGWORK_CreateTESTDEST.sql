

--USE [TESTS_DEST]
--USE [TESTS_SOURCE]
--GO


---Удаление Test_DEST

USE [TESTS_SOURCE]
DROP DATABASE [TESTS_DEST]
GO

----******

-----Создание Test_DEST

--USE [TESTS_SOURCE]
CREATE DATABASE [TESTS_DEST]
 ON  PRIMARY 
( NAME = N'TESTS_DEST', FILENAME = N'F:\Soft\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\TESTS_DESTS.mdf' , SIZE = 1024KB , MAXSIZE = 1GB, FILEGROWTH = 1%)
 LOG ON 
( NAME = N'TESTS_DEST_log', FILENAME = N'F:\Soft\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\TESTS_DESTS.ldf' , SIZE = 1024KB , MAXSIZE = 1GB, FILEGROWTH = 1%)
GO


USE [TESTS_DEST]
GO
-- [TESTS_DEST].[AccessGroups]

CREATE TABLE [dbo].[AccessGroups](
	[PK] [int] IDENTITY(1000,50) NOT NULL,
	[Guid] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[TypeID] [int] NOT NULL,
	[Temporary] [int] NOT NULL,
	[SystemType] [int] NOT NULL,
 CONSTRAINT [PK_AccessGroups] PRIMARY KEY CLUSTERED 
(
	[PK] ASC
) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[AccessGroups] ADD  CONSTRAINT [DF_AccessGroups_Guid]  DEFAULT (newid()) FOR [Guid]
ALTER TABLE [dbo].[AccessGroups] ADD  CONSTRAINT [DF_AccessGroups_Name]  DEFAULT ('') FOR [Name]
ALTER TABLE [dbo].[AccessGroups] ADD  CONSTRAINT [DF_AccessGroups_TypeID]  DEFAULT ((0)) FOR [TypeID]
ALTER TABLE [dbo].[AccessGroups] ADD  CONSTRAINT [DF_AccessGroups_Temporary]  DEFAULT ((0)) FOR [Temporary]
ALTER TABLE [dbo].[AccessGroups] ADD  CONSTRAINT [DF_AccessGroups_SystemType]  DEFAULT ((0)) FOR [SystemType]

CREATE NONCLUSTERED INDEX [IX_AccessGroups_TypeID] ON [dbo].[AccessGroups](
	[TypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

CREATE UNIQUE NONCLUSTERED INDEX [UK_AccessGroups_Guid] ON [dbo].[AccessGroups](
	[Guid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

-- [TESTS_DEST].[AccessGroupCommands]

USE [TESTS_DEST]
GO

CREATE TABLE [dbo].[AccessGroupCommands](
	[CommandID] [int] NOT NULL,
	[GroupID] [int] NOT NULL,
	[Enable] [int] NOT NULL,
 CONSTRAINT [PK_AccessGroupCommands] PRIMARY KEY CLUSTERED 
(
	[CommandID] ASC,
	[GroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_AccGroupCommands_CommandID] ON [dbo].[AccessGroupCommands](
	[CommandID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

CREATE NONCLUSTERED INDEX [IX_AccGroupCommands_GroupID] ON [dbo].[AccessGroupCommands](
	[GroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

CREATE NONCLUSTERED INDEX [IX_AccGroupCommands_Optimize1] ON [dbo].[AccessGroupCommands](
	[CommandID] ASC,
	[GroupID] ASC,
	[Enable] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

ALTER TABLE [dbo].[AccessGroupCommands] ADD  CONSTRAINT [DF_AccGrpCommands_CommandID]  DEFAULT ((0)) FOR [CommandID]
ALTER TABLE [dbo].[AccessGroupCommands] ADD  CONSTRAINT [DF_AccGrpCommands_GroupID]  DEFAULT ((0)) FOR [GroupID]
ALTER TABLE [dbo].[AccessGroupCommands] ADD  CONSTRAINT [DF_AccGrpCommands_Enable]  DEFAULT ((0)) FOR [Enable]
ALTER TABLE [dbo].[AccessGroupCommands]  WITH CHECK ADD  CONSTRAINT [FK_AccGrpCommands_AccGroups] FOREIGN KEY([GroupID]) REFERENCES [dbo].[AccessGroups] ([PK]) ON DELETE CASCADE
ALTER TABLE [dbo].[AccessGroupCommands] CHECK CONSTRAINT [FK_AccGrpCommands_AccGroups]
GO

-- [TESTS_DEST].[Objects]

USE [TESTS_DEST]
GO

CREATE TABLE [dbo].[Objects](
	[PK] [int] IDENTITY(1,1) NOT NULL,
	[ObjectID] [int] NOT NULL,
	[AccessGroupID] [int] NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Guid] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Objects] PRIMARY KEY CLUSTERED 
(
	[PK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Objects] ADD  DEFAULT ((0)) FOR [ObjectID]
ALTER TABLE [dbo].[Objects] ADD  DEFAULT ((0)) FOR [AccessGroupID]
ALTER TABLE [dbo].[Objects] ADD  DEFAULT (N'') FOR [Name]
ALTER TABLE [dbo].[Objects] ADD  CONSTRAINT [DF_Objects_Guid]  DEFAULT (newid()) FOR [Guid]
ALTER TABLE [dbo].[Objects]  WITH CHECK ADD  CONSTRAINT [FK_Objects_AccGroups] FOREIGN KEY([AccessGroupID]) REFERENCES [dbo].[AccessGroups] ([PK]) ON DELETE SET DEFAULT ON UPDATE CASCADE
ALTER TABLE [dbo].[Objects] CHECK CONSTRAINT [FK_Objects_AccGroups]
GO

------*********** УДАЛИТЬ ПОТОМ, заполнение TESTS_DEST значениями из SOURCE_TABLE, Для удобства.



/*********************************ЗАДАНИЕ 1**********************************/

/*	скопировать информацию о группах прав доступа и их командах, сохранив содержимое групп,
	а также содержимое таблицы Objects, также сохраняя права доступа.*/

 BEGIN TRANSACTION
--1: Копируем данные из таблицы AccessGroup в новую, с измененным PK (1000+50)
INSERT INTO [AccessGroups] ([Guid], [Name],[TypeID],[Temporary],[SystemType])
     SELECT [Guid], [Name],[TypeID],[Temporary],[SystemType] 
       FROM [TESTS_SOURCE].[dbo].[AccessGroups]; 
GO


--2: Копируем данные из таблицы AccessGroupCommand в новую, с учетом изменного GroupID 
INSERT INTO [AccessGroupCommands] ([CommandID], [GroupID], [Enable])
SELECT   AGC.[CommandID], nAG.[PK], AGC.[Enable]
FROM [TESTS_SOURCE].[dbo].[AccessGroups] as oAG, [AccessGroups] as nAG, [TESTS_SOURCE].[dbo].[AccessGroupCommands] as AGC
WHERE oAG.[Guid] LIKE nAG.[Guid]
AND oAG.[PK] LIKE AGC.[GroupID] 
ORDER BY AGC.[CommandID]
GO

--3: Копируем данные из таблицы Objects в новую, с учетом изменного AccessGroupID
INSERT INTO [Objects] ([ObjectID], [AccessGroupID],[Name],[Guid])
SELECT    oBJ.[ObjectID] as ObjectID, nAG.[PK] as AccessGroupID, oBJ.[Name] as Name, obj.[Guid] as Guid
FROM [TESTS_SOURCE].[dbo].[AccessGroups] as oAG, [AccessGroups] as nAG, [TESTS_SOURCE].[dbo].[Objects] as oBJ 
WHERE oAG.[Guid] LIKE nAG.[Guid]
AND oAG.[PK] LIKE oBJ.[AccessGroupID] 
ORDER BY oBJ.[PK] 
GO

COMMIT TRANSACTION
