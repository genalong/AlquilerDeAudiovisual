USE [AlquilerAudiovisual]
GO

CREATE TABLE [dbo].[Contratacion](
	[id] [int] NOT NULL,
	[solicitudId] [int] NOT NULL,
	[clienteId] [int] NOT NULL,
	[fechaInicio] [date] NOT NULL,
	[fechaFin] [date] NOT NULL,
	[ubicacion] [varchar](150) NOT NULL,
	[importeTotal] [float] NOT NULL,
	[estado] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Contratacion] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Contratacion]  WITH CHECK ADD  CONSTRAINT [FK_Contratacion_Solicitud] FOREIGN KEY([solicitudId])
REFERENCES [dbo].[SolicitudAlquiler] ([id])
GO

ALTER TABLE [dbo].[Contratacion]  WITH CHECK ADD  CONSTRAINT [FK_Contratacion_Cliente] FOREIGN KEY([clienteId])
REFERENCES [dbo].[Cliente] ([id])
GO