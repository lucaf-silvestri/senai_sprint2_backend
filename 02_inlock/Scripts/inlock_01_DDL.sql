CREATE DATABASE _INLOCK_GAMES_MANHA;
GO

USE _INLOCK_GAMES_MANHA;
GO

CREATE TABLE ESTUDIO(
   idEstudio smallint PRIMARY KEY IDENTITY(1,1),
   nomeEstudio varchar(100),
);
go

CREATE TABLE JOGO(
idJogo smallint PRIMARY KEY IDENTITY(1,1),
nomeJogo varchar(200),
descricao varchar (1000),
dataLancamento DATE,
valor MONEY,
idEstudio smallint FOREIGN KEY REFERENCES ESTUDIO(idEstudio)
);
go

CREATE TABLE TIPOUSUARIO(
idTipoUsuario smallint PRIMARY KEY IDENTITY(1,1),
titulo varchar(50)
);
go

CREATE TABLE USUARIO(
idUsuario smallint PRIMARY KEY IDENTITY(1,1),
email char(200),
senha char(45),
idTipoUsuario smallint FOREIGN KEY REFERENCES TIPOUSUARIO(idTipoUsuario)

);
go