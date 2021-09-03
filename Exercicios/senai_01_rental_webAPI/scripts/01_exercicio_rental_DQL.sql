USE M_Rental;
GO

SELECT * FROM modelo

SELECT dataRetirada, dataDevolucao, nomeCliente, sobrenomeCliente, nomeModelo
FROM ALUGUEL
LEFT JOIN CLIENTE
ON ALUGUEL.idCliente = CLIENTE.idCliente
LEFT JOIN VEICULO
ON ALUGUEL.idVeiculo = VEICULO.idVeiculo
LEFT JOIN MODELO
ON VEICULO.idModelo = MODELO.idModelo;
GO

SELECT dataRetirada, dataDevolucao, nomeCliente, sobrenomeCliente, nomeModelo
FROM ALUGUEL
LEFT JOIN CLIENTE
ON ALUGUEL.idCliente = CLIENTE.idCliente
LEFT JOIN VEICULO
ON ALUGUEL.idVeiculo = VEICULO.idVeiculo
LEFT JOIN MODELO
ON VEICULO.idModelo = MODELO.idModelo
WHERE idAluguel = 1;
GO

SELECT nomeCliente, sobrenomeCliente, dataRetirada, dataDevolucao, nomeModelo
FROM ALUGUEL
LEFT JOIN CLIENTE
ON ALUGUEL.idCliente = CLIENTE.idCliente
LEFT JOIN VEICULO
ON ALUGUEL.idVeiculo = VEICULO.idVeiculo
LEFT JOIN MODELO
ON VEICULO.idModelo = Modelo.idModelo
WHERE nomeCliente = 'Gustavo';
GO


SELECT idVeiculo, placa, nomeMarca, nomeModelo, anoModelo
FROM VEICULO
INNER JOIN MODELO
ON VEICULO.idModelo = MODELO.idModelo
INNER JOIN MARCA
ON MARCA.idMarca = MODELO.idMarca;
GO

SELECT idVeiculo, placa, nomeMarca, nomeModelo, anoModelo, nomeEmpresa
FROM VEICULO
LEFT JOIN MODELO
ON VEICULO.idEmpresa = MODELO.idModelo
LEFT JOIN MARCA
ON MARCA.idMarca = MODELO.idMarca
LEFT JOIN EMPRESA
ON VEICULO.idEmpresa = EMPRESA.idEmpresa
WHERE idVeiculo = 1;
GO


UPDATE VEICULO SET idModelo = 1, idEmpresa = 1, placa = 11111 WHERE idVeiculo = 1;
GO




