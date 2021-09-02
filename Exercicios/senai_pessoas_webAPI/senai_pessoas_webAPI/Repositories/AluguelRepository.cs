using senai_pessoas_webAPI.Domains;
using senai_pessoas_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_pessoas_webAPI.Repositories
{
    public class AluguelRepository : IAluguelRepository
    {
        private string Conexao = "Data Source=DESKTOP-E81EO80\\SQLEXPRESS; initial catalog=CATALOGO; user id=sa; pwd=*CaChORrO_16*";

        public void AtualizarIdUrl(int idAluguel, Aluguel_Domain aluguel)
        {
            throw new NotImplementedException();
        }

        public Aluguel_Domain BuscarPorId(int idAluguel)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Aluguel_Domain novoAluguel)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int idAluguel)
        {
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                string queryDelete = "DELETE FROM ALUGUEL WHERE idAluguel = @id";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@id", idAluguel);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Aluguel_Domain> Listar()
        {
            List<Aluguel_Domain> listaAluguel = new List<Aluguel_Domain>();
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                //Declara a instrução a ser executada
                string querySelectAll = "SELECT idAluguel, nomeAluguel FROM ALUGUEL;";

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
                        Aluguel_Domain aluguel = new Aluguel_Domain()
                        {
                            idAluguel = Convert.ToInt32(rdr[0]),
                            Preco = Convert.ToDouble(rdr[1]),
                            Data = Convert.ToDateTime(rdr[2]),
                        };

                        listaAluguel.Add(aluguel);
                    }
                }
            }

            return listaAluguel;
        }
    }
}
