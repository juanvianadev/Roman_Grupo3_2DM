USE Roman_Senai
GO

INSERT INTO Usuario(Email, Senha)
VALUES				('professorTeste@gmail.com', '123Roman')
GO

INSERT INTO Tema(nomeTema)
VALUES				('Gestão'),
					('HQs')
GO

INSERT INTO Projeto(idTema, nomeProjeto, nomeProfessor,descricaoProjeto)
VALUES				(1, 'RomanTeste', 'Jorge Lopez','Projeto usado como teste para a aplicação'),
					(1, 'Controle de Estoque','Jorge Lopez' ,'Projeto usado como teste para a aplicação'),
					(2, 'Listagem de Personagens', 'Valéria Gallen','Projeto usado como teste para a aplicação')
GO

