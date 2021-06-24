using Roman_Senai.Domains;
using Roman_Senai.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Roman_Senai.Repository
{
    public class TemaRepository : ITemaRepository
    {
        private string stringConexao = "Data Source=DESKTOP-EEVEMF2\\SQLEXPRESS; initial catalog=Roman_Senai; user Id=sa; pwd=";

        public void Atualizar(int id, TemaDomain temaAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string queryUpdateIdUrl = "UPDATE Tema SET nomeTema WHERE idTema = @ID";

                using (SqlCommand cmd = new SqlCommand(queryUpdateIdUrl, con))
                {

                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@idTema", temaAtualizado.nomeTema);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public TemaDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT nomeTema AS 'Nome do Tema' FROM Tema WHERE idProjeto = @ID";

                con.Open();

                SqlDataReader rdr;
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        TemaDomain temaBuscado = new TemaDomain()
                        {
                            nomeTema = rdr[0].ToString(),
                        };

                        return temaBuscado;
                    }

                    return null;
                }
            }
        }

        public void Cadastrar(TemaDomain novoTema)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Tema(nomeTema) VALUES ('" + novoTema.nomeTema + ")";
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
                string queryDelete = "DELETE FROM Tema WHERE idTema = @ID";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<TemaDomain> ListarTodos()
        {
            List<TemaDomain> listaTemas = new List<TemaDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT nomeTema AS 'Nome do Tema' FROM Tema";
                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        TemaDomain tema = new TemaDomain()
                        {
                            nomeTema = rdr[0].ToString(),
                        };

                        listaTemas.Add(tema);
                    }
                }
            }

            return listaTemas;
        }
    }
}
