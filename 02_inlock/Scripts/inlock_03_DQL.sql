USE _INLOCK_GAMES_MANHA;
GO

-- Listar todos os usu�rios:
SELECT * FROM USUARIO;
GO

-- Listar todos os est�dios:
SELECT * FROM ESTUDIO;
GO

-- Listar todos os jogos:
SELECT * FROM JOGO;
GO

-- Listar todos os jogos e seus respectivos est�dios:
SELECT nomeJogo AS 'Jogo', nomeEstudio AS 'Est�dio' FROM JOGO
LEFT JOIN ESTUDIO
ON ESTUDIO.idEstudio = JOGO.idEstudio
GO

-- Buscar e trazer na lista todos os est�dios com os respectivos jogos:
SELECT nomeEstudio AS 'Est�dio', nomeJogo AS 'Jogo' FROM ESTUDIO
LEFT JOIN JOGO
ON JOGO.idEstudio = ESTUDIO.idEstudio
GO

-- Buscar um usu�rio por e-mail e senha (login):
SELECT idUsuario as 'Id', email as 'Email',  idTipoUsuario as 'Id do Tipo de Usu�rio' FROM USUARIO
WHERE email = 'admin@admin.com' and senha = 'admin'
GO

-- Buscar um jogo por idJogo:
SELECT idJogo as 'Id', nomeJogo as 'Nome',  descricao as 'Descri��o', dataLancamento as 'Data de Lan�amento', valor as 'Valor', idEstudio as 'Id do Est�dio' FROM JOGO
WHERE idJogo = 2
GO

-- Buscar um est�dio por idEstudio:
SELECT idEstudio as 'Id', nomeEstudio as 'Nome' FROM ESTUDIO
WHERE idEstudio = 2
GO