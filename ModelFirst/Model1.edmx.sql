
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/05/2018 13:47:34
-- Generated from EDMX file: C:\Users\Антон\source\repos\lab3\ModelFirst\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Casino];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Card_typeSet'
CREATE TABLE [dbo].[Card_typeSet] (
    [Card_type_code] int IDENTITY(1,1) NOT NULL,
    [Card_type_name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ClientSet'
CREATE TABLE [dbo].[ClientSet] (
    [Card_number] int IDENTITY(1,1) NOT NULL,
    [FIO] nvarchar(max)  NOT NULL,
    [Phone] nvarchar(max)  NOT NULL,
    [Passport] nvarchar(max)  NOT NULL,
    [Balance] int  NOT NULL,
    [Card_type_code] int  NOT NULL,
    [Card_type_Card_type_code] int  NOT NULL
);
GO

-- Creating table 'RecordSet'
CREATE TABLE [dbo].[RecordSet] (
    [Record_number] int IDENTITY(1,1) NOT NULL,
    [Date] datetime  NOT NULL,
    [Bottom_line] float  NOT NULL,
    [Game_code] int  NOT NULL,
    [Card_number] int  NOT NULL,
    [Client_Card_number] int  NOT NULL,
    [Game_type_Game_code] int  NOT NULL
);
GO

-- Creating table 'Game_typeSet'
CREATE TABLE [dbo].[Game_typeSet] (
    [Game_code] int IDENTITY(1,1) NOT NULL,
    [Game_name] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Card_type_code] in table 'Card_typeSet'
ALTER TABLE [dbo].[Card_typeSet]
ADD CONSTRAINT [PK_Card_typeSet]
    PRIMARY KEY CLUSTERED ([Card_type_code] ASC);
GO

-- Creating primary key on [Card_number] in table 'ClientSet'
ALTER TABLE [dbo].[ClientSet]
ADD CONSTRAINT [PK_ClientSet]
    PRIMARY KEY CLUSTERED ([Card_number] ASC);
GO

-- Creating primary key on [Record_number] in table 'RecordSet'
ALTER TABLE [dbo].[RecordSet]
ADD CONSTRAINT [PK_RecordSet]
    PRIMARY KEY CLUSTERED ([Record_number] ASC);
GO

-- Creating primary key on [Game_code] in table 'Game_typeSet'
ALTER TABLE [dbo].[Game_typeSet]
ADD CONSTRAINT [PK_Game_typeSet]
    PRIMARY KEY CLUSTERED ([Game_code] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Card_type_Card_type_code] in table 'ClientSet'
ALTER TABLE [dbo].[ClientSet]
ADD CONSTRAINT [FK_Card_typeClient]
    FOREIGN KEY ([Card_type_Card_type_code])
    REFERENCES [dbo].[Card_typeSet]
        ([Card_type_code])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Card_typeClient'
CREATE INDEX [IX_FK_Card_typeClient]
ON [dbo].[ClientSet]
    ([Card_type_Card_type_code]);
GO

-- Creating foreign key on [Client_Card_number] in table 'RecordSet'
ALTER TABLE [dbo].[RecordSet]
ADD CONSTRAINT [FK_ClientRecord]
    FOREIGN KEY ([Client_Card_number])
    REFERENCES [dbo].[ClientSet]
        ([Card_number])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClientRecord'
CREATE INDEX [IX_FK_ClientRecord]
ON [dbo].[RecordSet]
    ([Client_Card_number]);
GO

-- Creating foreign key on [Game_type_Game_code] in table 'RecordSet'
ALTER TABLE [dbo].[RecordSet]
ADD CONSTRAINT [FK_Game_typeRecord]
    FOREIGN KEY ([Game_type_Game_code])
    REFERENCES [dbo].[Game_typeSet]
        ([Game_code])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Game_typeRecord'
CREATE INDEX [IX_FK_Game_typeRecord]
ON [dbo].[RecordSet]
    ([Game_type_Game_code]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------