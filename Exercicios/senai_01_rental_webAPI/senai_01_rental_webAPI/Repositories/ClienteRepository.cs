using senai_01_rental_webAPI.Domains;
using senai_01_rental_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_01_rental_webAPI.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private string Conexao = "Data Source=DESKTOP-E81EO80\\SQLEXPRESS; initial catalog=M_Rental; user id=sa; pwd=*CaChORrO_16*";

        public void AtualizarIdUrl(int idCliente, ClienteDomain clienteAtualizado)
        {
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                string queryUptadeUrl = "UPDATE CLIENTE SET nomeCliente = @nomeCliente, sobrenomeCliente = @sobrenomeCliente, CPF = @CPF WHERE idCliente = @idCliente;";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryUptadeUrl, con))
                {
                    cmd.Parameters.AddWithValue("@nomeCliente", clienteAtualizado.nomeCliente);
                    cmd.Parameters.AddWithValue("@sobrenomeCliente", clienteAtualizado.sobrenomeCliente);
                    cmd.Parameters.AddWithValue("@CPF", clienteAtualizado.CPF);
                    cmd.Parameters.AddWithValue("@idCliente", idCliente);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public ClienteDomain BuscarPorId(int idCliente)
        {
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                string querySelecãoId = "SELECT idCliente, nomeCliente, sobrenomeCliente, CPF FROM CLIENTE WHERE idCliente = @idCliente;";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelecãoId, con))
                {
                    cmd.Parameters.AddWithValue("@idCliente", idCliente);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        ClienteDomain clienteProcurado = new ClienteDomain
                        {
                            idCliente = Convert.ToInt32(rdr[0]),
                            nomeCliente = rdr[1].ToString(),
                            sobrenomeCliente = rdr[2].ToString(),
                            CPF = rdr[3].ToString(),
                        };

                        return clienteProcurado;
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
            
                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@nomeCliente", novoCliente.nomeCliente);
                    cmd.Parameters.AddWithValue("@sobrenomeCliente", novoCliente.sobrenomeCliente);
                    cmd.Parameters.AddWithValue("@CPF", novoCliente.CPF);
                    
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int idCliente)
        {
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                string queryDelete = "DELETE FROM CLIENTE WHERE idCliente = @idCliente";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@idCliente", idCliente);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<ClienteDomain> Listar()
        {
            List<ClienteDomain> listaClientes = new List<ClienteDomain>();
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                string querySelectAll = "SELECT idCliente, nomeCliente, sobrenomeCliente, CPF FROM CLIENTE;";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        ClienteDomain cliente = new ClienteDomain()
                        {
                            idCliente = Convert.ToInt32(rdr[0]),
                            nomeCliente = rdr[1].ToString(),
                            sobrenomeCliente = rdr[2].ToString(),
                            CPF = rdr[3].ToString(),
                        };

                        listaClientes.Add(cliente);
                    }
                }
            }

            return listaClientes;
        }
    }
}
