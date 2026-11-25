USE [AlquilerAudiovisual]
GO

CREATE TABLE [dbo].[Cliente](
	[id] [int] NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[tipo] [varchar](50) NOT NULL,
	[documento] [varchar](50) NOT NULL,
	[email] [varchar](100) NOT NULL,
	[telefono] [varchar](50) NOT NULL,
	[direccion] [varchar](150) NOT NULL,
	[activo] [bit] NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO