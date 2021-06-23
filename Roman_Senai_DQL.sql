USE Roman_Senai;
GO

SELECT * FROM Usuario
SELECT * FROM Tema
SELECT * FROM Projeto

SELECT nomeProjeto AS 'Nome do projeto', nomeTema AS 'Nome do Tema', nomeProfessor AS 'Nome do Professor' 
FROM Projeto P
INNER JOIN Tema T
ON P.idTema = T.idTema