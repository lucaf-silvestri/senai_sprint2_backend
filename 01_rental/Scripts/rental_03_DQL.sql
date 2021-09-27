USE RENTAL;
GO

SELECT * FROM VEICULO;
GO

SELECT * FROM ALUGUEL;
GO

SELECT * FROM CLIENTE;
GO

SELECT nomeCliente AS 'Nome do Cliente', sobrenomeCliente AS 'Sobrenome do Cliente', anoVeiculo AS 'Ano do Ve�culo Alugado', placaVeiculo AS 'Placa do Ve�culo Alugado', valorAluguel AS 'Valor do Aluguel', CONVERT (CHAR, dataRetirada, 103) AS 'Data de Retirada', CONVERT (CHAR, dataDevolucao, 103) AS 'Data de Devolucao' FROM ALUGUEL
LEFT JOIN VEICULO
ON VEICULO.idVeiculo = ALUGUEL.idVeiculo
LEFT JOIN CLIENTE
ON CLIENTE.idCliente = ALUGUEL.idCliente
GO