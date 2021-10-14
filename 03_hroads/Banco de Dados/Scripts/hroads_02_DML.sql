USE HROADS_MANHA;
GO

INSERT INTO classe (nomeClasse) 
VALUES ('Bárbaro'),
	   ('Cruzado'),
	   ('Caçadora de demônios'),
	   ('Monge'),
	   ('Necromante'),
	   ('Feiticeiro'),
	   ('Arcanista');
GO

INSERT INTO tipoHabilidade (nomeTipoHab)
VALUES ('Ataque'),
	   ('Defesa'),
	   ('Cura'),
	   ('Magia');
GO

INSERT INTO habilidade (idTipoHab, nomeHabilidade)
VALUES (1, 'Lança Mortal'),
	   (2, 'Escudo Supremo'),
	   (3, 'Recuperar Vida');
GO

INSERT INTO classeHabilidade (idClasse, idHabilidade)
VALUES (1, 1),
	   (1, 2),
	   (2, 2),
	   (3, 1),
	   (4, 3),
	   (4, 2),
	   (5, NULL),
	   (6, 3),
	   (7,NULL);
GO

INSERT INTO personagem (idClasse, nome, maxVida, maxMana, dataCriacao, dataAtualizacao)
VALUES (1, 'DeuBug', 100, 80, '18/01/2019', '09/08/2021'),
	   (4, 'BitBug', 70, 100, '17/03/2016', '09/08/2021'),
	   (7, 'Fer8', 75, 60, '18/03/2018', '09/08/2021');
GO

UPDATE personagem SET nome = 'Fer7' WHERE idPersonagem = 3;
GO

UPDATE classe SET nomeClasse = 'Necromancer' WHERE idClasse = 5;
GO

INSERT INTO tipoUsuario
VALUES
('Administrador'),
('Jogador');
GO

INSERT INTO usuario
VALUES
(1, 'Admin', 'admin@admin.com', 'admin'),
(2, 'Jogador', 'jogador@jogador.com', 'jogador');
GO