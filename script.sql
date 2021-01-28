USE [db_standBy]
GO

CREATE TABLE [dbo].[__EFMigrationsHistory] (
    [MigrationId]    NVARCHAR (150) NOT NULL,
    [ProductVersion] NVARCHAR (32)  NOT NULL
);

GO
CREATE TABLE [dbo].[Cliente] (
    [ClienteId]      INT             IDENTITY (1, 1) NOT NULL,
    [razao_social]   VARCHAR (MAX)   NOT NULL,
    [data_fundacao]  DATETIME2 (7)   NOT NULL,
    [cnpj]           VARCHAR (MAX)   NULL,
    [capital]        DECIMAL (18, 2) NOT NULL,
    [quarentena]     BIT             NOT NULL,
    [status_cliente] BIT             NOT NULL,
    [classificacao]  CHAR (1)        NOT NULL
);

GO
ALTER TABLE [dbo].[__EFMigrationsHistory]
    ADD CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED ([MigrationId] ASC);

GO
ALTER TABLE [dbo].[Cliente]
    ADD CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED ([ClienteId] ASC);

GO
