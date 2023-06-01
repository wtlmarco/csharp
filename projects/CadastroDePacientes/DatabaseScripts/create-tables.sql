USE [CadastroDePacientes]
GO

/****** Object:  Table [dbo].[Convenios]    Script Date: 29/05/2023 07:43:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Convenios](
	[ID] [uniqueidentifier] NOT NULL,
	[Nome] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_Convenio] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO



USE [CadastroDePacientes]
GO

/****** Object:  Table [dbo].[Pacientes]    Script Date: 29/05/2023 07:48:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Pacientes](
	[ID] [uniqueidentifier] NOT NULL,
	[Nome] [nvarchar](50) NOT NULL,
	[Sobrenome] [nvarchar](100) NOT NULL,
	[DataDeNascimento] [date] NOT NULL,
	[Genero] [nvarchar](50) NOT NULL,
	[CPF] [char](11) NULL,
	[RG] [varchar](20) NOT NULL,
	[UFDoRG] [char](2) NOT NULL,
	[Email] [nvarchar](256) NOT NULL,
	[Celular] [varchar](15) NULL,
	[TelefoneFixo] [varchar](15) NULL,
	[ConvenioID] [uniqueidentifier] NULL,
	[CarteirinhaDoConvenio] [varchar](50) NULL,
	[ValidadeDaCarteirinha] [date] NULL,
 CONSTRAINT [PK_Paciente] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Pacientes]  WITH CHECK ADD  CONSTRAINT [FK_Pacientes_Convenios_ConvenioID] FOREIGN KEY([ConvenioID])
REFERENCES [dbo].[Convenios] ([ID])
GO

ALTER TABLE [dbo].[Pacientes] CHECK CONSTRAINT [FK_Pacientes_Convenios_ConvenioID]
GO

ALTER TABLE [dbo].[Pacientes]  WITH CHECK ADD  CONSTRAINT [CK_UmTelefoneInformado] CHECK  (([Celular] IS NULL AND [TelefoneFixo] IS NOT NULL OR [Celular] IS NOT NULL AND [TelefoneFixo] IS NULL OR [Celular] IS NOT NULL AND [TelefoneFixo] IS NOT NULL))
GO

ALTER TABLE [dbo].[Pacientes] CHECK CONSTRAINT [CK_UmTelefoneInformado]
GO


