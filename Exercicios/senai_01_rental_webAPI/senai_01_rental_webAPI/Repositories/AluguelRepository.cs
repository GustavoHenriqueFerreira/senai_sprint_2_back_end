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
        private string Conexao = "Data Source=DESKTOP-E81EO80\\SQLEXPRESS; initial catalog=CATALOGO; user id=sa; pwd=*CaChORrO_16*";

    public void AtualizarIdUrl(int idAluguel, AluguelDomain aluguelAtualizado)
    {
        using (SqlConnection con = new SqlConnection(Conexao))
        {
            string queryUptadeUrl = "UPTADE dataDevolucao FROM ALUGUEL SET = @novaDevolucao WHERE idAluguel = @idAluguel;";

            using (SqlCommand cmd = new SqlCommand(queryUptadeUrl, con))
            {
                cmd.Parameters.AddWithValue("@novaDevolucao", aluguelAtualizado.dataDevolucao);
                cmd.Parameters.AddWithValue("@idAluguel", idAluguel);

                con.Open();
            }
        }
    }

    public AluguelDomain BuscarPorId(int idAluguel)
    {
        using (SqlConnection con = new SqlConnection(Conexao))
        {
            string querySelecãoId = @"SELECT idAluguel, nomeCliente, sobrenomeCliente, dataRetirada, dataDevolucao, placa, nomeModelo
FROM ALUGUEL
LEFT JOIN CLIENTE
ON ALUGUEL.idCliente = CLIENTE.idCliente
LEFT JOIN VEICULO
ON ALUGUEL.idVeiculo = VEICULO.idVeiculo
LEFT JOIN MODELO
ON VEICULO.idModelo = Modelo.idModelo 
WHERE idAluguel = @idAluguel;";

            con.Open();

            SqlDataReader rdr;

            using (SqlCommand cmd = new SqlCommand(querySelecãoId, con))
            {
                cmd.Parameters.AddWithValue("@idAluguel", idAluguel);

                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                        AluguelDomain aluguelProcurado = new AluguelDomain
                        {
                            idAluguel = Convert.ToInt32(rdr[0]),
                            dataRetirada = Convert.ToDateTime(rdr[3]),
                            dataDevolucao = Convert.ToDateTime(rdr[4]),

                            cliente = new ClienteDomain()
                            {
                            nomeCliente = rdr[1].ToString(),
                            sobrenomeCliente = rdr[2].ToString()
                            },

                            veiculo = new VeiculoDomain()
                            {
                                placa = rdr[5].ToString(),
                                modelo  = new ModeloDomain()
                                {
                                    nomeModelo = rdr[6].ToString(),
                                }
                            }
                        };

                    return aluguelProcurado;
                }

                return null;
            }
        }
    }

        public void Cadastrar(ClienteDomain novoCliente)
        {
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                string queryInsert = "INSERT INTO CLIENTE (nomeCliente, sobrenomeCliente, CPF) VALUES (@nomeCliente, @sobrenomeCliente, @CPF)";


                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@nomeCliente", novoCliente.nomeCliente);
                    cmd.Parameters.AddWithValue("@sobrenomeCliente", novoCliente.sobrenomeCliente);
                    cmd.Parameters.AddWithValue("@CPF", novoCliente.CPF);

                    con.Open();

                    cmd.ExecuteNonQuery();
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
                cmd.ExecuteNonQuery();
            }
        }
    }

    public void Deletar(int idAluguel)
    {
        using (SqlConnection con = new SqlConnection(Conexao))
        {
            string queryDelete = "DELETE FROM ALUGUEL WHERE idAluguel = @idAluguel;";

            using (SqlCommand cmd = new SqlCommand(queryDelete, con))
            {
                cmd.Parameters.AddWithValue("@idAluguel", idAluguel);

                con.Open();

                cmd.ExecuteNonQuery();
            }
        }
    }

        public List<AluguelDomain> Listar()
    {
        List<AluguelDomain> listaAlugueis = new List<AluguelDomain>();
        using (SqlConnection con = new SqlConnection(Conexao))
        {
            string querySelectAll = @"SELECT idAluguel, nomeCliente, sobrenomeCliente, dataRetirada, dataDevolucao, placa, nomeModelo
FROM ALUGUEL
LEFT JOIN CLIENTE
ON ALUGUEL.idCliente = CLIENTE.idCliente
LEFT JOIN VEICULO
ON ALUGUEL.idVeiculo = VEICULO.idVeiculo
LEFT JOIN MODELO
ON VEICULO.idModelo = Modelo.idModelo;";

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
                        dataRetirada = Convert.ToDateTime(rdr[3]),
                        dataDevolucao = Convert.ToDateTime(rdr[4]),

                        cliente = new ClienteDomain()
                        {
                            nomeCliente = rdr[1].ToString(),
                            sobrenomeCliente = rdr[2].ToString()
                        },

                        veiculo = new VeiculoDomain()
                        {
                            placa = rdr[5].ToString(),
                            modelo = new ModeloDomain()
                            {
                                nomeModelo = rdr[6].ToString(),
                            }
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