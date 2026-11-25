USE [AlquilerAudiovisual]
GO

CREATE TABLE [dbo].[LineaContratacion](
	[id] [int] NOT NULL,
	[contratacionId] [int] NOT NULL,
	[equipamientoId] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
	[precioUnitario] [float] NOT NULL,
 CONSTRAINT [PK_LineaContratacion] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[LineaContratacion]  WITH CHECK ADD  CONSTRAINT [FK_LineaContratacion_Contratacion] FOREIGN KEY([contratacionId])
REFERENCES [dbo].[Contratacion] ([id])
GO

ALTER TABLE [dbo].[LineaContratacion]  WITH CHECK ADD  CONSTRAINT [FK_LineaContratacion_Equipo] FOREIGN KEY([equipamientoId])
REFERENCES [dbo].[Equipamiento] ([id])
GO