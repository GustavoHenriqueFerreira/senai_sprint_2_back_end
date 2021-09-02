using senai_01_rental_webAPI.Domains;
using senai_01_rental_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_01_rental_webAPI.Repositories
{
    public class VeiculoRepository : IVeiculoRepository
    {
        private string Conexao = "Data Source=DESKTOP-E81EO80\\SQLEXPRESS; initial catalog=M_Rental; user id=sa; pwd=*CaChORrO_16*";
        public void AtualizarIdUrl(int idVeiculo, VeiculoDomain veiculoAtualizado)
        {
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                string queryUptadeIdBody = "UPDATE VEICULO SET idEmpresa = @idEmpresa, idModelo = @idModelo, placa = @placa WHERE idVeiculo = @idVeiculoAtualizado";

                using (SqlCommand cmd = new SqlCommand(queryUptadeIdBody, con))
                {
                    cmd.Parameters.AddWithValue("@idEmpresa", veiculoAtualizado.idModelo);
                    cmd.Parameters.AddWithValue("@idModelo", veiculoAtualizado.idEmpresa);
                    cmd.Parameters.AddWithValue("@placa", veiculoAtualizado.placa);
                    cmd.Parameters.AddWithValue("@idVeiculo", idVeiculo);

                    con.Open();
                }
            }
        }

        public VeiculoDomain BuscarPorId(int idVeiculo)
        {
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                string querySelecãoId = @"SELECT idVeiculo, placa, nomeMarca, nomeModelo, anoModelo, nomeEmpresa
FROM VEICULO
LEFT JOIN MODELO
ON VEICULO.idModelo = MODELO.idModelo
LEFT JOIN MARCA
ON MARCA.idMarca = MODELO.idMarca
LEFT JOIN EMPRESA
ON VEICULO.idEmpresa = EMPRESA.idEmpresa
WHERE idVeiculo = @idVeiculo;";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelecãoId, con))
                {
                    cmd.Parameters.AddWithValue("@idVeiculo", idVeiculo);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        VeiculoDomain veiculoProcurado = new VeiculoDomain
                        {
                            idVeiculo = Convert.ToInt32(rdr[0]),
                            placa = rdr[1].ToString(),

                            modelo = new ModeloDomain()
                            {
                                nomeModelo = rdr[3].ToString(),
                                anoModelo = Convert.ToDateTime(rdr[4]),
                                marca = new MarcaDomain()
                                {
                                    nomeMarca = rdr[2].ToString(),
                                },
                            },

                            empresa = new EmpresaDomain()
                            {
                                nomeEmpresa = rdr[5].ToString()
                            }
                        };

                        return veiculoProcurado;
                    }

                    return null;
                }
            }
        }

        //Concluir Cadastrar
        public void Cadastrar(VeiculoDomain novoVeiculo)
        {
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                string queryInsert = "INSERT INTO Veiculo (idEmpresa, idModelo, placa,) VALUES (@idEmpresa, @idModelo, @placa,)";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int idVeiculo)
        {
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                string queryDelete = "DELETE FROM VEICULO WHERE idVeiculo = @idVeiculo;";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@idVeiculo", idVeiculo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<VeiculoDomain> Listar()
        {
            List<VeiculoDomain> listaVeiculos = new List<VeiculoDomain>();
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                string querySelectAll = @"SELECT idVeiculo, placa, nomeMarca, nomeModelo, anoModelo, nomeEmpresa
FROM VEICULO
LEFT JOIN MODELO
ON VEICULO.idModelo = MODELO.idModelo
LEFT JOIN MARCA
ON MARCA.idMarca = MODELO.idMarca
LEFT JOIN EMPRESA
ON VEICULO.idEmpresa = EMPRESA.idEmpresa";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        VeiculoDomain veiculo = new VeiculoDomain()
                        {
                            idVeiculo = Convert.ToInt32(rdr[0]),
                            placa = rdr[1].ToString(),

                            modelo = new ModeloDomain()
                            {
                                nomeModelo = rdr[3].ToString(),
                                anoModelo = Convert.ToDateTime(rdr[4]),
                                marca = new MarcaDomain()
                                {
                                    nomeMarca = rdr[2].ToString(),
                                },
                            },

                            empresa = new EmpresaDomain()
                            {
                                nomeEmpresa = rdr[5].ToString()
                            }
                        };

                        listaVeiculos.Add(veiculo);
                    }
                }
            }

            return listaVeiculos;
        }
    }
}
