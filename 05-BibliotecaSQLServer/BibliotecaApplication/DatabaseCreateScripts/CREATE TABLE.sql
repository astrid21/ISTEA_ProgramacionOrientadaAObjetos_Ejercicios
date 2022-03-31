CREATE TABLE [dbo].[Lector] (
    [id_lector] INT          IDENTITY (1, 1) NOT NULL,
    [dni]       INT          NOT NULL,
    [apellido]  VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([id_lector] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Lector_Column]
    ON [dbo].[Lector]([dni] ASC);

GO
CREATE TABLE [dbo].[Libro] (
    [id_libro]                    INT           IDENTITY (1, 1) NOT NULL,
    [codigo_identificacion_unico] VARCHAR (10)  NOT NULL,
    [titulo]                      VARCHAR (MAX) NULL,
    [isbn]                        VARCHAR (MAX) NULL,
    [id_lector]                   INT           NULL,
    PRIMARY KEY CLUSTERED ([id_libro] ASC),
    CONSTRAINT [FK_Libro_To_Lector] FOREIGN KEY ([id_lector]) REFERENCES [dbo].[Lector] ([id_lector])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Table_Column]
    ON [dbo].[Libro]([codigo_identificacion_unico] ASC);