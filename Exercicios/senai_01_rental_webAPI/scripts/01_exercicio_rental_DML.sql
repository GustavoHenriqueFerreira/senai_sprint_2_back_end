USE M_Rental;
GO

INSERT INTO EMPRESA(nomeEmpresa)
VALUES ('RENTAL');
GO

INSERT INTO MARCA(nomeMarca)
VALUES ('GM'), ('Ford');
GO

INSERT INTO CLIENTE(nomeCliente, sobrenomeCliente, CPF)
VALUES ('Gustavo', 'Henrique', '15620909834'), ('Kaik', 'Aquino', '11111111111');
GO

INSERT INTO MODELO(idMarca, nomeModelo, anoModelo)
VALUES (1, 'Onix', '2016'), (2, 'Ford Ka', '2015');
GO

INSERT INTO VEICULO(idEmpresa, idModelo, placa)
VALUES (1, 2, 'MMMMMMM'), (1, 1, 'ADFFFFF');
GO

INSERT INTO ALUGUEL(idVeiculo, idCliente, dataRetirada, dataDevolucao)
VALUES (2, 2, '14-07-2021', '18-07-2021'), (1, 1, '16-07-2021', '18-07-2021');
GO