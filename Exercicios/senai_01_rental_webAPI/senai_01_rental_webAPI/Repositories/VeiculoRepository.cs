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
                string queryUptadeIdBody = "UPDATE VEICULO SET idEmpresa = @idEmpresa, idModelo = @idModelo, placa = @placa WHERE idVeiculo = @idVeiculo";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryUptadeIdBody, con))
                {
                    cmd.Parameters.AddWithValue("@idEmpresa", veiculoAtualizado.idEmpresa);
                    cmd.Parameters.AddWithValue("@idModelo", veiculoAtualizado.idModelo);
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
                string querySearchById = @"SELECT idVeiculo, V.idEmpresa, nomeEmpresa, V.idModelo, M.idMarca, nomeMarca, nomeModelo, anoModelo, placa FROM VEICULO V INNER JOIN EMPRESA E ON V.idEmpresa = E.idEmpresa INNER JOIN MODELO M ON V.idModelo = M.idModelo INNER JOIN MARCA MA ON M.idMarca = MA.idMarca WHERE idVeiculo = @idVeiculo";

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
                            idVeiculo = Convert.ToInt32(rdr["idVeiculo"]),
                            idEmpresa = Convert.ToInt32(rdr["idEmpresa"]),
                            idModelo = Convert.ToInt32(rdr["idModelo"]),
                            placa = rdr["placa"].ToString(),
                            empresa = new EmpresaDomain()
                            {
                                idEmpresa = Convert.ToInt32(rdr["idEmpresa"]),
                                nomeEmpresa = rdr["nomeEmpresa"].ToString()
                            },
                            modelo = new ModeloDomain()
                            {
                                idModelo = Convert.ToInt32(rdr["idModelo"]),
                                idMarca = Convert.ToInt32(rdr["idMarca"]),
                                nomeModelo = rdr["nomeModelo"].ToString(),
                                anoModelo = Convert.ToDateTime(rdr["anoModelo"]),
                                marca = new MarcaDomain()
                                {
                                    idMarca = Convert.ToInt32(rdr["idMarca"]),
                                    nomeMarca = rdr["nomeMarca"].ToString()
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
                string queryInsert = "INSERT INTO VEICULO (idEmpresa, idModelo, placa) VALUES(@idEmpresa, @idModelo, @placa)";

                con.Open();
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@idEmpresa", novoVeiculo.idEmpresa);
                    cmd.Parameters.AddWithValue("@idModelo", novoVeiculo.idModelo);
                    cmd.Parameters.AddWithValue("@placa", novoVeiculo.placa);

                    cmd.ExecuteNonQuery();
                }
            }
        }


        public void Deletar(int idVeiculo)
        {
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                string queryDelete = "DELETE FROM VEICULO WHERE idVEICULO = @idVeiculo";

                con.Open();
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@idVeiculo", idVeiculo);
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
                            idVeiculo = Convert.ToInt32(rdr["idVeiculo"]),
                            idEmpresa = Convert.ToInt32(rdr["idEmpresa"]),
                            idModelo = Convert.ToInt32(rdr["idModelo"]),
                            placa = rdr["placa"].ToString(),
                            empresa = new EmpresaDomain()
                            {
                                idEmpresa = Convert.ToInt32(rdr["idEmpresa"]),
                                nomeEmpresa = rdr["nomeEmpresa"].ToString()
                            },
                            modelo = new ModeloDomain()
                            {
                                idModelo = Convert.ToInt32(rdr["idModelo"]),
                                idMarca = Convert.ToInt32(rdr["idMarca"]),
                                nomeModelo = rdr["nomeModelo"].ToString(),
                                anoModelo = Convert.ToDateTime(rdr["anoModelo"]),
                                marca = new MarcaDomain()
                                {
                                    idMarca = Convert.ToInt32(rdr["idMarca"]),
                                    nomeMarca = rdr["nomeMarca"].ToString()
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
