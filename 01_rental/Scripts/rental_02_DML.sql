USE RENTAL;
GO

ALTER TABLE ALUGUEL DROP COLUMN dataAluguel;
GO

ALTER TABLE ALUGUEL ADD dataRetirada DATE, dataDevolucao DATE;
GO

INSERT INTO VEICULO (anoVeiculo, placaVeiculo)
VALUES (1966, 'FRK-2861'), (2004, 'THM-6188'), (1986, 'YZV-1561');
GO

INSERT INTO CLIENTE (nomeCliente, sobrenomeCliente)
VALUES ('Cláudio','Claudiney'), ('Saulo','Saulinho'), ('Odirlei','Ordilevs');
GO

INSERT INTO ALUGUEL (idVeiculo, idCliente, valorAluguel, dataRetirada, dataDevolucao) VALUES 
(2,	1,	169, '10/07/2021', '10/08/2021'), 
(2,	3,	210, '09/05/2021', '09/06/2021'), 
(3,	2,	199, '04/07/2021', '04/08/2021');
GO