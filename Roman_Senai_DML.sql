USE Roman_Senai
GO

INSERT INTO Usuario(Email, Senha)
VALUES				('professorTeste@gmail.com', '123Roman')
GO

INSERT INTO Tema(nomeTema)
VALUES				('Gest�o'),
					('HQs')
GO

INSERT INTO Projeto(idTema, nomeProjeto, nomeProfessor,descricaoProjeto)
VALUES				(1, 'RomanTeste', 'Jorge Lopez','Projeto usado como teste para a aplica��o'),
					(1, 'Controle de Estoque','Jorge Lopez' ,'Projeto usado como teste para a aplica��o'),
					(2, 'Listagem de Personagens', 'Val�ria Gallen','Projeto usado como teste para a aplica��o')
GO

