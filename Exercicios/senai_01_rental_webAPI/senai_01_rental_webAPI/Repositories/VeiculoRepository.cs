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
                string queryUptadeIdBody = "UPDATE VEICULO SET idEmpresa = @idEmpresa, idModelo = @idModelo, placa = @placa" + "WHERE idVeiculo = @idVeiculoAtualizado";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryUptadeIdBody, con))
                {
                    cmd.Parameters.AddWithValue("@idEmpresa", veiculoAtualizado.idModelo);
                    cmd.Parameters.AddWithValue("@idModelo", veiculoAtualizado.idEmpresa);
                    cmd.Parameters.AddWithValue("@placa", veiculoAtualizado.placa);
                    cmd.Parameters.AddWithValue("@idVeiculo", idVeiculo);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public VeiculoDomain BuscarPorId(int idVeiculo)
        {
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                string querySearchById = "SELECT IdVeiculo, IdEmpresa, IdModelo, placa, nomeModelo, anoModelo, nomeEmpresa FROM VEICULO " +
                    "INNER JOIN EMPRESA " +
                    "ON EMPRESA.IdEmpresa = VEICULO.IdEmpresa" +
                    "INNER JOIN MODELO" +
                    "ON VEICULO.IdModelo = MODELO.IdModelo" +
                    "WHERE VEICULO.IdVeiculo = @Idveiculo";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySearchById, con))
                {
                    cmd.Parameters.AddWithValue("@idVeiculo", idVeiculo);
                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        VeiculoDomain veiculoProcurado = new VeiculoDomain()
                        {
                            idVeiculo = Convert.ToInt32(rdr[0]),
                            placa = rdr[3].ToString(),
                            empresa = new EmpresaDomain()
                            {
                                idEmpresa = Convert.ToInt32(rdr[1]),
                                nomeEmpresa = rdr[6].ToString()
                            },
                            modelo = new ModeloDomain()
                            {
                                idModelo = Convert.ToInt32(rdr[2]),
                                nomeModelo = rdr[4].ToString(),
                                anoModelo = Convert.ToDateTime(rdr[5]),
                                marca = new MarcaDomain()
                                {
                                    nomeMarca = rdr[3].ToString()
                                }
                            }
                        };
                        return veiculoProcurado;
                    }
                    return null;
                }
            }
        }

        public void Cadastrar(VeiculoDomain novoVeiculo)
        {
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                string queryInsert = "INSERT INTO veiculo (IdEmpresa, IdModelo, placaVeiculo) VALUES (@IdEmpresa, @IdModelo, @placaVeiculo);";

                con.Open();
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {

                    cmd.Parameters.AddWithValue("@IdEmpresa", novoVeiculo.idEmpresa);
                    cmd.Parameters.AddWithValue("@IdModelo", novoVeiculo.idModelo);
                    cmd.Parameters.AddWithValue("@placaVeiculo", novoVeiculo.placa);

                    cmd.ExecuteNonQuery();
                }
            }
        }


        public void Deletar(int idVeiculo)
        {
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                string queryDelete = "DELETE FROM veiculo WHERE IdVeiculo = @IdVeiculo";

                con.Open();
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@IdVeiculo", idVeiculo);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<VeiculoDomain> Listar()
        {
            List<VeiculoDomain> listaVeiculos = new List<VeiculoDomain>();
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                string querySelectAll = @"SELECT idVeiculo, V.idEmpresa, nomeEmpresa, V.idModelo, M.idMarca, nomeMarca, nomeModelo, anoModelo, placa FROM VEICULO V INNER JOIN EMPRESA E ON V.idEmpresa = E.idEmpresa INNER JOIN MODELO M ON V.idModelo = M.idModelo INNER JOIN MARCA MA ON M.idMarca = MA.idMarca";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        VeiculoDomain veiculo = new VeiculoDomain
                        {
                            idVeiculo = Convert.ToInt32(rdr[0]),
                            idEmpresa = Convert.ToInt32(rdr[1]),
                            idModelo = Convert.ToInt32(rdr[3]),
                            placa = rdr[8].ToString(),
                            empresa = new EmpresaDomain()
                            {
                                idEmpresa = Convert.ToInt32(rdr[1]),
                                nomeEmpresa = rdr[2].ToString()
                            },
                            modelo = new ModeloDomain()
                            {
                                idModelo = Convert.ToInt32(rdr[3]),
                                idMarca = Convert.ToInt32(rdr[4]),
                                nomeModelo = rdr[6].ToString(),
                                anoModelo = Convert.ToDateTime(rdr[7]),
                                marca = new MarcaDomain()
                                {
                                    idMarca = Convert.ToInt32(rdr[4]),
                                    nomeMarca = rdr[5].ToString()
                                }
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
