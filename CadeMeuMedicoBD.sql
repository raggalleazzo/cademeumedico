CREATE DATABASE CadeMeuMedicoBD
GO

USE CadeMeuMedicoBD
GO

CREATE TABLE Usuario
(
	IDUsuario BIGINT IDENTITY(1,1) NOT NULL,
	Nome VARCHAR(80) NOT NULL,
	Login VARCHAR(30) NOT NULL,
	Senha VARCHAR(100) NOT NULL,
	Email VARCHAR(100) NOT NULL,

	PRIMARY KEY (IDUsuario)
);
GO

CREATE TABLE Medico
(
	IDMedico BIGINT IDENTITY(1,1) NOT NULL,
	CRM VARCHAR(30) NOT NULL,
	Nome VARCHAR(80) NOT NULL,
	Endereco VARCHAR(100) NOT NULL,
	Bairro VARCHAR(60) NOT NULL,
	Email VARCHAR(100) NOT NULL,
	AtendePorConvenio BIT NOT NULL,
	TemClinica BIT NOT NULL,
	WebsiteBlog VARCHAR(80) NULL,
	IDCidade INT NOT NULL,
	IDEspecialidade INT NOT NULL,

	PRIMARY KEY(IDMedico)
);
GO

CREATE TABLE Especialidade
(
	IDEspecialidade INT IDENTITY(1,1) NOT NULL,
	Nome VARCHAR(80) NOT NULL,

	PRIMARY KEY(IDEspecialidade)
);
GO

CREATE TABLE Cidade
(
	IDCidade INT IDENTITY(1,1) NOT NULL,
	Nome VARCHAR(100) NOT NULL,

	PRIMARY KEY(IDCidade)
);
GO

ALTER TABLE Medico
ADD CONSTRAINT fk_medico_cidade
FOREIGN KEY(IDCidade)
REFERENCES Cidade(IDCidade)
GO

ALTER TABLE Medico
ADD CONSTRAINT fk_medico_especialidade
FOREIGN KEY(IDEspecialidade)
REFERENCES Especialidade(IDEspecialidade)
GO

INSERT INTO Cidade (Nome) VALUES ('Recife')
INSERT INTO Cidade (Nome) VALUES ('Olinda')
GO

INSERT INTO Especialidade (Nome) VALUES ('Cardiologista')
INSERT INTO Especialidade (Nome) VALUES ('Neurologista')
GO

INSERT INTO Usuario (Nome, Login, Senha, Email) VALUES ('Administrador',
														 'admin',
														 '40BD001563085FC35165329EA1FF5C5ECBDBBEEF',
														 'admin@cdmm.com')
GO

CREATE TABLE BannerPublicitario
(
	IDBanner BIGINT IDENTITY NOT NULL,
	TituloCampanha VARCHAR(60) NOT NULL,
	BannerCampanha VARCHAR(200) NOT NULL,
	LinkBanner VARCHAR(200) NOT NULL,

	PRIMARY KEY(IDBanner)
);
GO

INSERT INTO BannerPublicitario (TituloCampanha, BannerCampanha, LinkBanner) VALUES ('Campanha Conio', 'logo-conio-cademeumedico.png', 'http://conio.com.br')
INSERT INTO BannerPublicitario (TituloCampanha, BannerCampanha, LinkBanner) VALUES ('Campanha Casa do Código', 'banner-cdc-cademeumedico.png', 'http://casadocodigo.com.br')