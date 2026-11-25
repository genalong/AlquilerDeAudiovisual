USE [AlquilerAudiovisual]
GO

CREATE TABLE [dbo].[Equipamiento](
	[id] [int] NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[marca] [varchar](50) NOT NULL,
	[modelo] [varchar](50) NOT NULL,
	[caracteristicas] [varchar](200) NULL,
	[depositoId] [int] NOT NULL,
	[precioBaseAlquiler] [float] NOT NULL,
	[codigo] [varchar](50) NOT NULL,
	[categoria] [varchar](50) NOT NULL,
	[estado] [varchar](50) NOT NULL,
	[stock] [int] NOT NULL,
	[activo] [bit] NOT NULL,
 CONSTRAINT [PK_Equipamiento] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Equipamiento]  WITH CHECK ADD  CONSTRAINT [FK_Equipamiento_Deposito] FOREIGN KEY([depositoId])
REFERENCES [dbo].[Deposito] ([id])
GO