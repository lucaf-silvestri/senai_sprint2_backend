USE SP_MEDICAL_GROUP;
GO

SELECT * FROM tipoUsuario;
GO

SELECT * FROM usuario;
GO

SELECT * FROM cliente;
GO

SELECT * FROM especialidadeMedico;
GO

SELECT * FROM clinica;
GO

SELECT * FROM medico;
GO

SELECT * FROM situacao;
GO

SELECT * FROM consulta;
GO

--Seleciona alguns dados do m�dico e do cliente de todas consultas:
SELECT nomeCliente[Paciente], telefoneCliente[Telefone do Paciente], enderecoCliente[Endere�o do Paciente], nomeMedico[Nome do M�dico], nomeEspecialidade[Especialidade do M�dico] FROM consulta
LEFT JOIN cliente
ON cliente.idCliente = consulta.idCliente
LEFT JOIN medico
ON medico.idMedico = consulta.idMedico
LEFT JOIN especialidadeMedico
ON especialidadeMedico.idEspecialidadeMedico = medico.idEspecialidadeMedico
GO

--Seleciona alguns dados do m�dico e do cliente de todas consultas de um cliente espec�fico:
SELECT nomeCliente[Paciente], telefoneCliente[Telefone do Paciente], enderecoCliente[Endere�o do Paciente], nomeMedico[Nome do M�dico], nomeEspecialidade[Especialidade do M�dico] FROM consulta
LEFT JOIN cliente
ON cliente.idCliente = consulta.idCliente
LEFT JOIN medico
ON medico.idMedico = consulta.idMedico
LEFT JOIN especialidadeMedico
ON especialidadeMedico.idEspecialidadeMedico = medico.idEspecialidadeMedico
Where cliente.idCliente = 7
GO