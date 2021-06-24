using Roman_Senai.Domains;
using Roman_Senai.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Roman_Senai.Repository
{
    public class ProjetoRepository : IProjetoRepository
    {
        private string stringConexao = "Data Source=DESKTOP-EEVEMF2\\SQLEXPRESS; initial catalog=Roman_Senai; user Id=sa; pwd=";

        public void Atualizar(int id, ProjetoDomain projetoAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string queryUpdateIdUrl = "UPDATE Projeto SET  idTema = @idTema, nomeProfessor = @nomeProfessor, nomeProjeto = @nomeProjeto, descricaoProjeto = @descricao WHERE idProjeto = @ID";

                using (SqlCommand cmd = new SqlCommand(queryUpdateIdUrl, con))
                {

                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@idTema", projetoAtualizado.tema.idTema);
                    cmd.Parameters.AddWithValue("@nomeProfessor", projetoAtualizado.nomeProfessor);
                    cmd.Parameters.AddWithValue("@nomeProjeto", projetoAtualizado.nomeProjeto);
                    cmd.Parameters.AddWithValue("@descricao", projetoAtualizado.descricao);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public ProjetoDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT nomeProjeto AS 'Nome do projeto', nomeTema AS 'Nome do Tema', nomeProfessor AS 'Nome do Professor'  FROM Projeto P INNER JOIN Tema T ON P.idTema = T.idTema WHERE idProjeto = @ID";

                con.Open();

                SqlDataReader rdr;
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        ProjetoDomain projetoBuscada = new ProjetoDomain()
                        {
                            nomeProjeto = rdr[0].ToString(),
                            tema = new TemaDomain
                            {
                                nomeTema = rdr[1].ToString()
                            },
                            nomeProfessor = rdr[2].ToString(),
                        };

                        return projetoBuscada;
                    }

                    return null;
                }
            }
        }

        public void Cadastrar(ProjetoDomain novoProjeto)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Projeto(idTema, nomeProfessor, nomeProjeto, descricaoProjeto) VALUES ('" + novoProjeto.tema.idTema + "', '" + novoProjeto.nomeProfessor + "', '" + novoProjeto.nomeProjeto + "', " + novoProjeto.descricao + ")";
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM Projeto WHERE idProjeto = @ID";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<ProjetoDomain> ListarTodos()
        {
            List<ProjetoDomain> listaProjetos = new List<ProjetoDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT nomeProjeto AS 'Nome do projeto', nomeTema AS 'Nome do Tema', nomeProfessor AS 'Nome do Professor'  FROM Projeto P INNER JOIN Tema T ON P.idTema = T.idTema";
                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        ProjetoDomain projeto = new ProjetoDomain()
                        {
                            nomeProjeto = rdr[0].ToString(),
                            tema = new TemaDomain
                            {
                                nomeTema = rdr[1].ToString()
                            },
                            nomeProfessor = rdr[2].ToString(),
                        };

                        listaProjetos.Add(projeto);
                    }
                }
            }

            return listaProjetos;
        }
    }
}
