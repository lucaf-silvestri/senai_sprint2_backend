USE HROADS_MANHA;
GO

SELECT * FROM ClasseHabilidade;
GO

--Selecionar todos os personagens:
SELECT * FROM personagem;
GO

--Selecionar todas as classes:
SELECT * FROM classe;
GO

--Selecionar somente o nome das classes:
SELECT nomeClasse FROM classe;
GO

--Selecionar todas as habilidades:
SELECT * FROM habilidade;
GO

--Realizar a contagem de quantas habilidades estão cadastradas:
SELECT COUNT (nomeHabilidade)
FROM habilidade; 
GO

--Selecionar somente os id’s das habilidades classificando-os por ordem crescente:
SELECT idHabilidade FROM habilidade

ORDER BY idHabilidade ASC;
GO

--Selecionar todos os tipos de habilidades:
SELECT * FROM tipoHabilidade;
GO

--Selecionar todas as habilidades e a quais tipos de habilidades elas fazem parte:
SELECT nomeHabilidade, nomeTipoHab FROM habilidade 
INNER JOIN tipoHabilidade 
ON tipoHabilidade.idTipoHab = habilidade.idTipoHab;
GO

--Selecionar todos os personagens e suas respectivas classes:
SELECT idPersonagem, nome, nomeClasse Classe, maxVida Vida, maxMana Mana, dataAtualizacao [Atualização], dataCriacao [Criação] FROM personagem
LEFT JOIN classe
ON classe.idClasse = personagem.idClasse
GO

--Selecionar todos os personagens e as classes (mesmo que elas não tenham correspondência em personagens):
SELECT idPersonagem, nome, nomeClasse Classe, maxVida Vida, maxMana Mana, dataAtualizacao [Atualização], dataCriacao [Criação] FROM personagem
RIGHT JOIN classe
ON classe.idClasse = personagem.idClasse
GO

--Selecionar todas as classes e suas respectivas habilidades:
SELECT nomeClasse Classe, nomeHabilidade Habilidade FROM classeHabilidade
LEFT JOIN classe 
ON classeHabilidade.idClasse = classe.idClasse
LEFT JOIN habilidade
ON classeHabilidade.idHabilidade = habilidade.idHabilidade;
GO

--Selecionar todas as habilidades e suas classes (somente as que possuem correspondência):
SELECT nomeClasse AS Classe, nomeHabilidade AS Habilidade FROM classeHabilidade
INNER JOIN classe 
ON classeHabilidade.idClasse = classe.idClasse
INNER JOIN habilidade
ON classeHabilidade.idHabilidade = habilidade.idHabilidade;
GO

--Selecionar todas as habilidades e suas classes (mesmo que elas não tenham correspondência).
SELECT nomeHabilidade Habilidade, nomeClasse Classe FROM habilidade
LEFT JOIN classeHabilidade
ON classeHabilidade.idHabilidade = habilidade.idHabilidade
FULL OUTER JOIN classe 
ON classeHabilidade.idClasse = classe.idClasse;
GO