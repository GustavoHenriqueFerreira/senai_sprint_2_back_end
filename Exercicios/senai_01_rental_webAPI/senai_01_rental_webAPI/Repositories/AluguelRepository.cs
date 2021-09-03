using senai_01_rental_webAPI.Domains;
using senai_01_rental_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_01_rental_webAPI.Repositories
{
    public class AluguelRepository : IAluguelRepository
    {
        private string Conexao = "Data Source=DESKTOP-E81EO80\\SQLEXPRESS; initial catalog=M_Rental; user id=sa; pwd=*CaChORrO_16*";

        public void AtualizarIdUrl(int idAluguel, AluguelDomain aluguelAtualizado)
        {
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                string queryUptadeBody = "UPDATE ALUGUEL SET idVeiculo = @idVeiculo, idCliente = @idCliente, dataRetirada = @dataRetirada, dataDevolucao = @dataDevolucao WHERE idAluguel = @idAluAtualizado";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryUptadeBody, con))
                {
                    cmd.Parameters.AddWithValue("@idVeiculo", aluguelAtualizado.idVeiculo);
                    cmd.Parameters.AddWithValue("@idCliente", aluguelAtualizado.idCliente);
                    cmd.Parameters.AddWithValue("@dataRetirada", aluguelAtualizado.dataRetirada);
                    cmd.Parameters.AddWithValue("@dataDevolucao", aluguelAtualizado.dataDevolucao);
                    cmd.Parameters.AddWithValue("@idAluguel", idAluguel);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public AluguelDomain BuscarPorId(int idAluguel)
        {
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                string querySelecãoId = @"SELECT * FROM ALUGUEL WHERE idAluguel = @idAluguel";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelecãoId, con))
                {
                    cmd.Parameters.AddWithValue("@idAluguel", idAluguel);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        AluguelDomain aluguelProcurado = new AluguelDomain()
                        {
                            idAluguel = Convert.ToInt32(rdr[0]),
                            idVeiculo = Convert.ToInt32(rdr[2]),
                            idCliente = Convert.ToInt32(rdr[1]),
                            dataRetirada = Convert.ToDateTime(rdr[3]),
                            dataDevolucao = Convert.ToDateTime(rdr[4]),

                            cliente = new ClienteDomain()
                            {
                                idCliente = Convert.ToInt32(rdr[1]),
                            },

                            veiculo = new VeiculoDomain()
                            {
                                idVeiculo = Convert.ToInt32(rdr[2]),
                            }
                        };

                        return aluguelProcurado;
                    }

                    return null;
                }
            }
        }



        public void Cadastrar(AluguelDomain novoAluguel)
        {
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                string queryInsert = @"INSERT INTO ALUGUEL(idVeiculo, idCliente, dataRetirada, dataDevolucao) VALUES(@idVeiculo, @idCliente, @dataRetirada, @dataDevolucao);";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@idVeiculo", novoAluguel.idVeiculo);
                    cmd.Parameters.AddWithValue("@idCliente", novoAluguel.idCliente);
                    cmd.Parameters.AddWithValue("@dataRetirada", novoAluguel.dataRetirada);
                    cmd.Parameters.AddWithValue("@dataDevolucao", novoAluguel.dataDevolucao);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int idAluguel)
        {
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                string queryDelete = "DELETE FROM ALUGUEL WHERE idAluguel = @idAluguel;";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@idAluguel", idAluguel);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<AluguelDomain> Listar()
        {
            List<AluguelDomain> listaAlugueis = new List<AluguelDomain>();
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                string querySelectAll = @"SELECT * FROM ALUGUEL";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        AluguelDomain aluguel = new AluguelDomain()
                        {
                            idAluguel = Convert.ToInt32(rdr[0]),
                            idVeiculo = Convert.ToInt32(rdr[2]),
                            idCliente = Convert.ToInt32(rdr[1]),
                            dataRetirada = Convert.ToDateTime(rdr[3]),
                            dataDevolucao = Convert.ToDateTime(rdr[4]),

                            cliente = new ClienteDomain()
                            {
                                idCliente = Convert.ToInt32(rdr[1]),
                            },

                            veiculo = new VeiculoDomain()
                            {
                                idVeiculo = Convert.ToInt32(rdr[2]),
                            }
                        };
                        listaAlugueis.Add(aluguel);
                    }
                }
            }
            return listaAlugueis;
        }
    }
}