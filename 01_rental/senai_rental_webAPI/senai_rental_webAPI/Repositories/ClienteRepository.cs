using senai_rental_webAPI.Domains;
using senai_rental_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_rental_webAPI.Repositories
{
    /// <summary>
    /// Classe responsável pelo repositório dos clientes
    /// </summary>
    public class ClienteRepository : IClienteRepository
    {
        /// <summary>
        /// String de conexão com o banco de dados que recebe os parâmetros
        /// Data Source = Nome do Servidor
        /// inital catalog = Nome do banco de dados
        /// user id= sa; pwd= Senai@132 = Faz a autenticação com o SQL SERVER passando Login e Senha
        /// integrated security = Faz a autenticação com o usuário do sistema.
        /// </summary>
        //private string stringConexao = "Data Source=DESKTOP-U20H53U; initial catalog=catalogo_manha; user id=sa; pwd=Senai@132";
        private string stringConexao = @"Data Source=DESKTOP-0R6MFG3\SQLEXPRESS; initial catalog=RENTAL; integrated security=true";

//_____________________________________________________________________________________________________________________________________________

        public void Atualizar(ClienteDomain clienteAtualizado)
        {

        }

        //_____________________________________________________________________________________________________________________________________________

        public ClienteDomain BuscarPorId(int idCliente)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT idCliente, nomeCliente, sobrenomeCliente FROM CLIENTE WHERE idCliente = @idCliente";

                con.Open();
                SqlDataReader reader;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idCliente", idCliente);
                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        ClienteDomain ClienteBuscado = new ClienteDomain
                        {
                            idCliente = Convert.ToInt32(reader["idCliente"]),
                            nomeCliente = reader["nomeCliente"].ToString(),
                            sobrenomeCliente = reader["sobrenomeCliente"].ToString()
                        };

                        return ClienteBuscado;
                    }

                    return null;
                }
            }
        }

        //_____________________________________________________________________________________________________________________________________________

        public void Cadastrar(ClienteDomain cliente)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO (nomeCliente, sobrenomeCliente) VALUES (@nomeCliente, @sobrenomeCliente);";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@nomeCliente", cliente.nomeCliente);
                    cmd.Parameters.AddWithValue("@sobrenomeCliente", cliente.sobrenomeCliente);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

//_____________________________________________________________________________________________________________________________________________

        public void Deletar(int idCliente)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM CLIENTE WHERE idCliente = @idCliente";
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@idCliente", idCliente);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

//_____________________________________________________________________________________________________________________________________________

        public List<ClienteDomain> ListarTodos()
        {
            List<ClienteDomain> listaCliente = new List<ClienteDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectALL = "SELECT idCliente, nomeCliente, sobrenomeCliente FROM CLIENTE;";
                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectALL, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        ClienteDomain cliente = new ClienteDomain()
                        {
                            idCliente = Convert.ToInt32(rdr[0]),
                            nomeCliente = rdr[1].ToString(),
                            sobrenomeCliente = rdr[2].ToString()
                        };

                        listaCliente.Add(cliente);
                    }
                }
            }

            return listaCliente;
        }
    }
}