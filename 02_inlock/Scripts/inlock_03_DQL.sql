USE _INLOCK_GAMES_MANHA;
GO

-- Listar todos os usuários:
SELECT * FROM USUARIO;
GO

-- Listar todos os estúdios:
SELECT * FROM ESTUDIO;
GO

-- Listar todos os jogos:
SELECT * FROM JOGO;
GO

-- Listar todos os jogos e seus respectivos estúdios:
SELECT nomeJogo AS 'Jogo', nomeEstudio AS 'Estúdio' FROM JOGO
LEFT JOIN ESTUDIO
ON ESTUDIO.idEstudio = JOGO.idEstudio
GO

-- Buscar e trazer na lista todos os estúdios com os respectivos jogos:
SELECT nomeEstudio AS 'Estúdio', nomeJogo AS 'Jogo' FROM ESTUDIO
LEFT JOIN JOGO
ON JOGO.idEstudio = ESTUDIO.idEstudio
GO

-- Buscar um usuário por e-mail e senha (login):
SELECT idUsuario as 'Id', email as 'Email',  idTipoUsuario as 'Id do Tipo de Usuário' FROM USUARIO
WHERE email = 'admin@admin.com' and senha = 'admin'
GO

-- Buscar um jogo por idJogo:
SELECT idJogo as 'Id', nomeJogo as 'Nome',  descricao as 'Descrição', dataLancamento as 'Data de Lançamento', valor as 'Valor', idEstudio as 'Id do Estúdio' FROM JOGO
WHERE idJogo = 2
GO

-- Buscar um estúdio por idEstudio:
SELECT idEstudio as 'Id', nomeEstudio as 'Nome' FROM ESTUDIO
WHERE idEstudio = 2
GO