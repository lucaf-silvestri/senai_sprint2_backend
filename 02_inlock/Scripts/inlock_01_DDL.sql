CREATE DATABASE INLOCK_GAMES_MANHA;
GO

USE INLOCK_GAMES_MANHA;
GO

CREATE TABLE ESTUDIO(
   idEstudio smallint PRIMARY KEY IDENTITY(1,1),
   nomeEstudio varchar(100) UNIQUE NOT NULL,
);
go

CREATE TABLE JOGO(
idJogo smallint PRIMARY KEY IDENTITY(1,1),
nomeJogo varchar(200) UNIQUE NOT NULL,
descricao varchar (1000) NOT NULL,
dataLancamento DATE NOT NULL,
valor DECIMAL NOT NULL,
idEstudio smallint FOREIGN KEY REFERENCES ESTUDIO(idEstudio)
);
go

CREATE TABLE TIPOUSUARIO(
idTipoUsuario smallint PRIMARY KEY IDENTITY(1,1),
titulo varchar(50) UNIQUE NOT NULL);
go

CREATE TABLE USUARIO(
idUsuario smallint PRIMARY KEY IDENTITY(1,1),
email varchar(50) UNIQUE NOT NULL,
senha varchar(45) NOT NULL,
idTipoUsuario smallint FOREIGN KEY REFERENCES TIPOUSUARIO(idTipoUsuario)

);
go