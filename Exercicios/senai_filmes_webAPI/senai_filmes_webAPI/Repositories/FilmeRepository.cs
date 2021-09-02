using senai_filmes_webAPI.Domains;
using senai_filmes_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webAPI.Repositories
{
    public class FilmeRepository : IFilmeRepositorycs
    {
        /// <summary>
        /// String de conexão com um banco de dados que recebe parâmetros
        /// Data Source: 
        /// initial catalog:
        /// user id: ; pwd: 
        /// </summary>
        private string Conexao = "Data Source=DESKTOP-E81EO80\\SQLEXPRESS; initial catalog=CATALOGO; user id=sa; pwd=*CaChORrO_16*";
        public void AtualizarIdCorpo(Filme_Domain filme)
        {
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                string queryUptadeIdBody = "UPTADE tituloFilme FROM FILME SET = @novoNomeFilme WHERE idFilme = @idFilmeAtualizado";

                using (SqlCommand cmd = new SqlCommand(queryUptadeIdBody, con))
                {
                    cmd.Parameters.AddWithValue("@novoNomeGen", filme.tituloFilme);
                    cmd.Parameters.AddWithValue("@idGeneroAtualizado", filme.idFilme);

                    con.Open();
                }
            }
        }

        public void AtualizarIdUrl(int idFilme, Filme_Domain filme)
        {
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                string queryUptadeUrl = "UPTADE nomeFilme FROM FILME SET = @novoNomeFilme WHERE idFilme = @idFilmeAtualizado";

                using (SqlCommand cmd = new SqlCommand(queryUptadeUrl, con))
                {
                    cmd.Parameters.AddWithValue("@novoNomeGen", filme.tituloFilme);
                    cmd.Parameters.AddWithValue("@idGeneroAtualizado", idFilme);

                    con.Open();
                }
            }
        }

        public Filme_Domain BuscarPorId(int idFilme)
        {
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                string querySelecãoId = "SELECT idFilme, tituloFilme FROM GENERO WHERE idFilme = @idFilme";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelecãoId, con))
                {
                    cmd.Parameters.AddWithValue("@idFilme", idFilme);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        Filme_Domain FilmeProcurado = new Filme_Domain
                        {
                            idFilme = Convert.ToInt32(rdr["idFilme"]),
                            tituloFilme = rdr["tituloFilme"].ToString(),
                        };

                        return FilmeProcurado;
                    }

                    return null;
                }
            }
        }

        public void Cadastrar(Filme_Domain novoFilme)
        {
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                string queryInsert = "INSERT INTO GENERO (tituloFilme) VALUES ('" + novoFilme.tituloFilme + "')";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int idFilme)
        {
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                string queryDelete = "DELETE FROM FILME WHERE idFilme = @id";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@id", idFilme);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Filme_Domain> Listar()
        {
            List<Filme_Domain> listaFilme = new List<Filme_Domain>();
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                //Declara a instrução a ser executada
                string querySelectAll = "SELECT idFilme, tituloFilme FROM FILME;";

                //Abre a conexão com o banco de dados
                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    //Executa a query
                    rdr = cmd.ExecuteReader();

                    //Enquanto houver registros o laço se repete
                    while (rdr.Read())
                    {
                        Filme_Domain filme = new Filme_Domain()
                        {
                            idFilme = Convert.ToInt32(rdr[0]),
                            tituloFilme = rdr[1].ToString(),
                        };

                        listaFilme.Add(filme);
                    }
                }
            }

            return listaFilme;
        }
    }
}
