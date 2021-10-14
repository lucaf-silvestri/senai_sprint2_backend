CREATE DATABASE HROADS_MANHA
GO

USE HROADS_MANHA;
GO

CREATE TABLE tipoHabilidade (
	idTipoHab INT PRIMARY KEY IDENTITY (1,1),
	nomeTipoHab VARCHAR(100) NOT NULL
);
GO

CREATE TABLE classe (
	idClasse INT PRIMARY KEY IDENTITY (1,1),
	nomeClasse VARCHAR(100) NOT NULL
);
GO

CREATE TABLE habilidade (
	idHabilidade INT PRIMARY KEY IDENTITY (1,1),
	idTipoHab INT FOREIGN KEY REFERENCES tipoHabilidade (idTipoHab),
	nomeHabilidade VARCHAR(100) NOT NULL
);
GO

CREATE TABLE classeHabilidade (
	idClasseHabilidade INT PRIMARY KEY IDENTITY (1,1),
	idHabilidade INT FOREIGN KEY REFERENCES habilidade (idHabilidade),
	idClasse INT FOREIGN KEY REFERENCES classe (idClasse)
);
GO

CREATE TABLE personagem (
	idPersonagem INT PRIMARY KEY IDENTITY (1,1),
	idClasse INT FOREIGN KEY REFERENCES classe (idClasse),
	nome VARCHAR(100) NOT NULL,
	maxVida SMALLINT UNIQUE NOT NULL,
	maxMana SMALLINT UNIQUE NOT NULL,
	dataAtualizacao DATE,
	dataCriacao DATE,
);
GO

CREATE TABLE tipoUsuario(
	idTipoUsuario INT PRIMARY KEY IDENTITY(1,1),
	nomeTipoUsuario VARCHAR(50) NOT NULL UNIQUE
);
GO

CREATE TABLE usuario(
	idUsuario INT PRIMARY KeY IdeNTITY(1,1),
	idTipoUsuario INT FOREIGN KEY REFERENCES tipoUsuario(idTipoUsuario),
	nome VARCHAR(50) NOT NULL,
	email VARCHAR(100) NOT NULL UNIQUE,
	senha VARCHAR(50) NOT NULL
);
GO