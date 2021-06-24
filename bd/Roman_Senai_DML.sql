USE Roman_Senai
GO

INSERT INTO Usuario(Email, Senha)
VALUES				('professorTeste@gmail.com', '123Roman')
GO

INSERT INTO Tema(nomeTema)
VALUES				('Gestão'),
					('HQs')
GO

INSERT INTO Projeto(idTema, nomeProjeto, descricaoProjeto)
VALUES				(1, 'RomanTeste', 'Projeto usado como teste para a aplicação'),
					(1, 'Controle de Estoque', 'Projeto usado como teste para a aplicação'),
					(2, 'Listagem de Personagens', 'Projeto usado como teste para a aplicação')
GO

