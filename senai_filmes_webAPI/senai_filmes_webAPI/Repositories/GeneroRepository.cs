using senai_filmes_webAPI.Domains;
using senai_filmes_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webAPI.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {
        /// <summary>
        /// String de conexão com um banco de dados que recebe parâmetros
        /// Data Source: 
        /// initial catalog:
        /// user id: ; pwd: 
        /// </summary>
        private string Conexao = "Data Source=DESKTOP-E81EO80\\SQLEXPRESS; initial catalog=CATALOGO; user id=sa; pwd=*CaChORrO_16*";
        public void AtualizarIdCorpo(Genero_Domain genero)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdUrl(int idGenero, Genero_Domain genero)
        {
            throw new NotImplementedException();
        }

        public Genero_Domain BuscarPorId(int idGenero)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Genero_Domain novoGenero)
        {
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                string queryInsert = "INSERT INTO GENERO (nomeGenero) VALUES ('" + novoGenero.nomeGenero + "')";

                con.Open();

                using(SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int idGenero)
        {
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                string queryDelete = "DELETE FROM GENERO WHERE idGenero = @id";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@id", idGenero);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Genero_Domain> ListarTodos()
        {
            List<Genero_Domain> listaGenero = new List<Genero_Domain>();
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                //Declara a instrução a ser executada
                string querySelectAll = "SELECT idGenero, nomeGenero FROM GENERO;";

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
                        Genero_Domain genero = new Genero_Domain()
                        {
                            idGenero = Convert.ToInt32(rdr[0]),
                            nomeGenero = rdr[1].ToString(),
                        };

                        listaGenero.Add(genero);
                    }
                }
            }

            return listaGenero;
        }
    }
}
