
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/10/2018 13:34:00
-- Generated from EDMX file: E:\F\lab3\ModFirst\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [bank_mf];
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

-- Creating table 'VkladSet'
CREATE TABLE [dbo].[VkladSet] (
    [Vklad_id] int IDENTITY(1,1) NOT NULL,
    [Balance] int  NOT NULL,
    [DateOpen] datetime  NOT NULL,
    [ProgProg_id] int  NOT NULL,
    [ClientClient_id] int  NOT NULL
);
GO

-- Creating table 'ProgSet'
CREATE TABLE [dbo].[ProgSet] (
    [Prog_id] int IDENTITY(1,1) NOT NULL,
    [Percent] int  NOT NULL,
    [Prog_name] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'ClientSet'
CREATE TABLE [dbo].[ClientSet] (
    [Client_id] int IDENTITY(1,1) NOT NULL,
    [FIO] nvarchar(50)  NOT NULL,
    [Passport] int  NOT NULL,
    [Phone] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Vklad_id] in table 'VkladSet'
ALTER TABLE [dbo].[VkladSet]
ADD CONSTRAINT [PK_VkladSet]
    PRIMARY KEY CLUSTERED ([Vklad_id] ASC);
GO

-- Creating primary key on [Prog_id] in table 'ProgSet'
ALTER TABLE [dbo].[ProgSet]
ADD CONSTRAINT [PK_ProgSet]
    PRIMARY KEY CLUSTERED ([Prog_id] ASC);
GO

-- Creating primary key on [Client_id] in table 'ClientSet'
ALTER TABLE [dbo].[ClientSet]
ADD CONSTRAINT [PK_ClientSet]
    PRIMARY KEY CLUSTERED ([Client_id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ProgProg_id] in table 'VkladSet'
ALTER TABLE [dbo].[VkladSet]
ADD CONSTRAINT [FK_ProgVklad]
    FOREIGN KEY ([ProgProg_id])
    REFERENCES [dbo].[ProgSet]
        ([Prog_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProgVklad'
CREATE INDEX [IX_FK_ProgVklad]
ON [dbo].[VkladSet]
    ([ProgProg_id]);
GO

-- Creating foreign key on [ClientClient_id] in table 'VkladSet'
ALTER TABLE [dbo].[VkladSet]
ADD CONSTRAINT [FK_ClientVklad]
    FOREIGN KEY ([ClientClient_id])
    REFERENCES [dbo].[ClientSet]
        ([Client_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClientVklad'
CREATE INDEX [IX_FK_ClientVklad]
ON [dbo].[VkladSet]
    ([ClientClient_id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------