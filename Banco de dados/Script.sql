/****** Object:  Database [SAEC]    Script Date: 16/02/2018 22:21:45 ******/
CREATE DATABASE [SAEC]
 
CREATE TABLE [dbo].[Tb_Aluno](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](50) NOT NULL,
	[Cpf] [varchar](50) NOT NULL,
	[Sexo] [varchar](50) NOT NULL,
	[Telefone] [varchar](50) NOT NULL,
	[Cadastro] [datetime] NOT NULL,
	[CidadeId] [int] NOT NULL,
	[Rg] [varchar](50) NULL,
	[Nascimento] [datetime] NOT NULL,
	[Endereco] [varchar](200) NOT NULL,
	[Matricula] [varchar](50) NOT NULL,
	[Alterado] [datetime] NOT NULL,
	[UsuarioId] [int] NOT NULL,
 CONSTRAINT [PK_Tb_Aluno] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tb_Aluno_Responsavel]    Script Date: 16/02/2018 22:21:46 ******/
CREATE TABLE [dbo].[Tb_Aluno_Responsavel](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](50) NOT NULL,
	[Rg] [varchar](50) NULL,
	[Cpf] [varchar](50) NOT NULL,
	[Profissao] [varchar](50) NOT NULL,
	[Celular] [varchar](50) NOT NULL,
	[Cadastro] [datetime] NOT NULL,
	[AlunoId] [int] NOT NULL,
 CONSTRAINT [PK_Tb_Aluno_Responsavel] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tb_Cidade]    Script Date: 16/02/2018 22:21:46 ******/
CREATE TABLE [dbo].[Tb_Cidade](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Cadastro] [datetime] NOT NULL,
	[Estado] [varchar](100) NOT NULL,
	[Cep] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Tb_Cidade] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tb_Usuario]    Script Date: 16/02/2018 22:21:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tb_Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](50) NOT NULL,
	[Cpf] [varchar](50) NOT NULL,
	[Sexo] [varchar](50) NOT NULL,
	[Telefone] [varchar](50) NOT NULL,
	[Cadastro] [datetime] NOT NULL,
	[CidadeId] [int] NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Senha] [varchar](32) NOT NULL,
 CONSTRAINT [PK_Tb_Usuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Tb_Aluno]  WITH CHECK ADD  CONSTRAINT [FK_Tb_Aluno_Tb_Cidade] FOREIGN KEY([CidadeId])
REFERENCES [dbo].[Tb_Cidade] ([Id])
GO
ALTER TABLE [dbo].[Tb_Aluno] CHECK CONSTRAINT [FK_Tb_Aluno_Tb_Cidade]
GO
ALTER TABLE [dbo].[Tb_Aluno]  WITH CHECK ADD  CONSTRAINT [FK_Tb_Aluno_Tb_Usuario] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Tb_Usuario] ([Id])
GO
ALTER TABLE [dbo].[Tb_Aluno] CHECK CONSTRAINT [FK_Tb_Aluno_Tb_Usuario]
GO
ALTER TABLE [dbo].[Tb_Aluno_Responsavel]  WITH CHECK ADD  CONSTRAINT [FK_Tb_Aluno_Responsavel_Tb_Aluno] FOREIGN KEY([AlunoId])
REFERENCES [dbo].[Tb_Aluno] ([Id])
GO
ALTER TABLE [dbo].[Tb_Aluno_Responsavel] CHECK CONSTRAINT [FK_Tb_Aluno_Responsavel_Tb_Aluno]
GO
ALTER TABLE [dbo].[Tb_Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Tb_Usuario_Tb_Cidade] FOREIGN KEY([CidadeId])
REFERENCES [dbo].[Tb_Cidade] ([Id])
GO
ALTER TABLE [dbo].[Tb_Usuario] CHECK CONSTRAINT [FK_Tb_Usuario_Tb_Cidade]
GO
USE [master]
GO
ALTER DATABASE [SAEC] SET  READ_WRITE 
GO


insert into Tb_Cidade values('São Paulo','2018-02-16 16:55:48.000' ,'SP', 11111111)
insert into Tb_Cidade values('Rio de Janeiro','2018-02-16 16:55:48.000' ,'RJ', 11111111)
insert into Tb_Cidade values('Belo Horizonte','2018-02-16 16:55:48.000' ,'BH', 11111111)
insert into Tb_Cidade values('Santa Catarina','2018-02-16 16:55:48.000' ,'SC', 11111111)

insert into Tb_Usuario values('Alan','11111111111','Masculino','55555555','2018-02-16 16:55:48.000',(select Id from Tb_Cidade where Estado like 'SP'),'alan@gmail.com','e10adc3949ba59abbe56e057f20f883e')

insert into Tb_Aluno values('Alan','11111111111','Masculino','55555555','2018-02-16 16:55:48.000',(select Id from Tb_Cidade where Estado like 'SP'),'111111111','1992-05-08','Rua Teste','1234','2018-02-16 16:55:48.000',(select Id from Tb_Usuario where Email like 'alan@gmail.com'))
insert into Tb_Aluno values('Gilson','11111111111','Masculino','55555555','2018-02-10 16:55:48.000',(select Id from Tb_Cidade where Estado like 'SP'),'111111111','1992-05-08','Rua Teste','1234','2018-02-16 16:55:48.000',(select Id from Tb_Usuario where Email like 'alan@gmail.com'))
insert into Tb_Aluno values('Jose','11111111111','Masculino','55555555','2018-02-12 15:55:48.000',(select Id from Tb_Cidade where Estado like 'SP'),'111111111','1992-05-08','Rua Teste','1234','2018-02-16 16:55:48.000',(select Id from Tb_Usuario where Email like 'alan@gmail.com'))
insert into Tb_Aluno values('Alfredo','11111111111','Masculino','55555555','2018-02-13 15:55:48.000',(select Id from Tb_Cidade where Estado like 'RJ'),'111111111','1992-05-08','Rua Teste','1234','2018-02-16 16:55:48.000',(select Id from Tb_Usuario where Email like 'alan@gmail.com'))
insert into Tb_Aluno values('Daniel','11111111111','Masculino','55555555','2018-02-16 15:55:48.000',(select Id from Tb_Cidade where Estado like 'SC'),'111111111','1992-05-08','Rua Teste','1234','2018-02-16 16:55:48.000',(select Id from Tb_Usuario where Email like 'alan@gmail.com'))
insert into Tb_Aluno values('Denis','11111111111','Masculino','55555555','2018-02-16 01:55:48.000',(select Id from Tb_Cidade where Estado like 'BH'),'111111111','1992-05-08','Rua Teste','1234','2018-02-16 16:55:48.000',(select Id from Tb_Usuario where Email like 'alan@gmail.com'))
insert into Tb_Aluno values('Amanda','11111111111','Feminino','55555555','2018-01-15 02:55:48.000',(select Id from Tb_Cidade where Estado like 'SP'),'111111111','1992-05-08','Rua Teste','1234','2018-02-16 16:55:48.000',(select Id from Tb_Usuario where Email like 'alan@gmail.com'))
insert into Tb_Aluno values('Catherine','11111111111','Feminino','55555555','2018-01-11 08:55:48.000',(select Id from Tb_Cidade where Estado like 'SP'),'111111111','1992-05-08','Rua Teste','1234','2018-02-16 16:55:48.000',(select Id from Tb_Usuario where Email like 'alan@gmail.com'))
insert into Tb_Aluno values('Eliani','11111111111','Feminino','55555555','2017-12-29 20:55:48.000',(select Id from Tb_Cidade where Estado like 'SP'),'111111111','1992-05-08','Rua Teste','1234','2018-02-16 16:55:48.000',(select Id from Tb_Usuario where Email like 'alan@gmail.com'))
insert into Tb_Aluno values('Alana','11111111111','Feminino','55555555','2018-02-16 16:55:48.000',(select Id from Tb_Cidade where Estado like 'BH'),'111111111','1992-05-08','Rua Teste','1234','2018-02-16 16:55:48.000',(select Id from Tb_Usuario where Email like 'alan@gmail.com'))
