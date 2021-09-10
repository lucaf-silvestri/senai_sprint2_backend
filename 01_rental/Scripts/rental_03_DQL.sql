USE RENTAL;
GO

SELECT * FROM EMPRESA;
GO

SELECT * FROM VEICULO;
GO

SELECT * FROM MODELO;
GO

SELECT * FROM MARCA;
GO

SELECT * FROM ALUGUEL;
GO

SELECT * FROM CLIENTE;
GO



SELECT nomeCliente, sobrenomeCliente, dataRetirada, dataDevolucao, nomeModelo FROM ALUGUEL
LEFT JOIN VEICULO
ON VEICULO.idVeiculo = ALUGUEL.idVeiculo
INNER JOIN MODELO
ON MODELO.idModelo = VEICULO.idModelo
LEFT JOIN CLIENTE
ON CLIENTE.idCliente = ALUGUEL.idCliente



SELECT nomeCliente, sobrenomeCliente, dataRetirada, dataDevolucao, nomeModelo FROM ALUGUEL
LEFT JOIN VEICULO
ON VEICULO.idVeiculo = ALUGUEL.idVeiculo
INNER JOIN MODELO
ON MODELO.idModelo = VEICULO.idModelo
LEFT JOIN CLIENTE
ON CLIENTE.idCliente = ALUGUEL.idCliente
WHERE nomeCliente = 'Odirlei'