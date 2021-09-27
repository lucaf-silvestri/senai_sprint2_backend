CREATE DATABASE RENTAL;
GO

USE RENTAL;
GO

CREATE TABLE CLIENTE(
   idCliente smallint PRIMARY KEY IDENTITY(1,1),
   nomeCliente varchar(60),
   sobrenomeCliente varchar(60),
);
go

CREATE TABLE VEICULO(
   idVeiculo smallint PRIMARY KEY IDENTITY(1,1),
   anoVeiculo char(4),
   placaVeiculo CHAR(8),
);
go

CREATE TABLE ALUGUEL(
   idAluguel smallint PRIMARY KEY IDENTITY(1,1),
   idVeiculo smallint FOREIGN KEY REFERENCES VEICULO(idVeiculo),
   idCliente smallint FOREIGN KEY REFERENCES CLIENTE(idCliente),
   valorAluguel char(12),
   dataAluguel DATE,
);
go