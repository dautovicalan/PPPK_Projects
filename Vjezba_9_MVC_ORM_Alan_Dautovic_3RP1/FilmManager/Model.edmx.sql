
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/30/2022 20:55:13
-- Generated from EDMX file: E:\Prog\School_Projects\3_Godina\FilmManager\FilmManager\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MovieManager];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_MovieMovieUploadedFile]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MovieUploadedFiles] DROP CONSTRAINT [FK_MovieMovieUploadedFile];
GO
IF OBJECT_ID(N'[dbo].[FK_MovieActor_Movie]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MovieActor] DROP CONSTRAINT [FK_MovieActor_Movie];
GO
IF OBJECT_ID(N'[dbo].[FK_MovieActor_Actor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MovieActor] DROP CONSTRAINT [FK_MovieActor_Actor];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Movies]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Movies];
GO
IF OBJECT_ID(N'[dbo].[MovieUploadedFiles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MovieUploadedFiles];
GO
IF OBJECT_ID(N'[dbo].[Actors]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Actors];
GO
IF OBJECT_ID(N'[dbo].[Directors]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Directors];
GO
IF OBJECT_ID(N'[dbo].[MovieActor]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MovieActor];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Movies'
CREATE TABLE [dbo].[Movies] (
    [IDMovie] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Duration] int  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Genre] nvarchar(30)  NOT NULL,
    [ReleaseDate] datetime  NOT NULL,
    [DirectorIDDirector] int  NOT NULL
);
GO

-- Creating table 'MovieUploadedFiles'
CREATE TABLE [dbo].[MovieUploadedFiles] (
    [IDUploadedFile] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [ContentType] nvarchar(20)  NOT NULL,
    [Content] varbinary(max)  NOT NULL,
    [MovieIDMovie] int  NOT NULL
);
GO

-- Creating table 'Actors'
CREATE TABLE [dbo].[Actors] (
    [IDActor] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(50)  NOT NULL,
    [LastName] nvarchar(50)  NOT NULL,
    [Age] int  NOT NULL
);
GO

-- Creating table 'Directors'
CREATE TABLE [dbo].[Directors] (
    [IDDirector] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(50)  NOT NULL,
    [LastName] nvarchar(50)  NOT NULL,
    [Age] int  NOT NULL
);
GO

-- Creating table 'MovieActor'
CREATE TABLE [dbo].[MovieActor] (
    [Movies_IDMovie] int  NOT NULL,
    [Actors_IDActor] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IDMovie] in table 'Movies'
ALTER TABLE [dbo].[Movies]
ADD CONSTRAINT [PK_Movies]
    PRIMARY KEY CLUSTERED ([IDMovie] ASC);
GO

-- Creating primary key on [IDUploadedFile] in table 'MovieUploadedFiles'
ALTER TABLE [dbo].[MovieUploadedFiles]
ADD CONSTRAINT [PK_MovieUploadedFiles]
    PRIMARY KEY CLUSTERED ([IDUploadedFile] ASC);
GO

-- Creating primary key on [IDActor] in table 'Actors'
ALTER TABLE [dbo].[Actors]
ADD CONSTRAINT [PK_Actors]
    PRIMARY KEY CLUSTERED ([IDActor] ASC);
GO

-- Creating primary key on [IDDirector] in table 'Directors'
ALTER TABLE [dbo].[Directors]
ADD CONSTRAINT [PK_Directors]
    PRIMARY KEY CLUSTERED ([IDDirector] ASC);
GO

-- Creating primary key on [Movies_IDMovie], [Actors_IDActor] in table 'MovieActor'
ALTER TABLE [dbo].[MovieActor]
ADD CONSTRAINT [PK_MovieActor]
    PRIMARY KEY CLUSTERED ([Movies_IDMovie], [Actors_IDActor] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [MovieIDMovie] in table 'MovieUploadedFiles'
ALTER TABLE [dbo].[MovieUploadedFiles]
ADD CONSTRAINT [FK_MovieMovieUploadedFile]
    FOREIGN KEY ([MovieIDMovie])
    REFERENCES [dbo].[Movies]
        ([IDMovie])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MovieMovieUploadedFile'
CREATE INDEX [IX_FK_MovieMovieUploadedFile]
ON [dbo].[MovieUploadedFiles]
    ([MovieIDMovie]);
GO

-- Creating foreign key on [Movies_IDMovie] in table 'MovieActor'
ALTER TABLE [dbo].[MovieActor]
ADD CONSTRAINT [FK_MovieActor_Movie]
    FOREIGN KEY ([Movies_IDMovie])
    REFERENCES [dbo].[Movies]
        ([IDMovie])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Actors_IDActor] in table 'MovieActor'
ALTER TABLE [dbo].[MovieActor]
ADD CONSTRAINT [FK_MovieActor_Actor]
    FOREIGN KEY ([Actors_IDActor])
    REFERENCES [dbo].[Actors]
        ([IDActor])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MovieActor_Actor'
CREATE INDEX [IX_FK_MovieActor_Actor]
ON [dbo].[MovieActor]
    ([Actors_IDActor]);
GO

-- Creating foreign key on [DirectorIDDirector] in table 'Movies'
ALTER TABLE [dbo].[Movies]
ADD CONSTRAINT [FK_DirectorMovie]
    FOREIGN KEY ([DirectorIDDirector])
    REFERENCES [dbo].[Directors]
        ([IDDirector])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DirectorMovie'
CREATE INDEX [IX_FK_DirectorMovie]
ON [dbo].[Movies]
    ([DirectorIDDirector]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------