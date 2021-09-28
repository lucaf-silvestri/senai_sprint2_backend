using senai_rental_webAPI.Domains;
using senai_rental_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_rental_webAPI.Repositories
{
    public class VeiculoRepository : IVeiculoRepository
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

        public void Atualizar(int idVeiculo, VeiculoDomain VeiculoAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateUrl = "UPDATE Veiculo SET anoVeiculo = @anoVeiculo, placaVeiculo = @placaVeiculo WHERE idVeiculo = @id";

                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    cmd.Parameters.AddWithValue("@id", idVeiculo);
                    cmd.Parameters.AddWithValue("@anoVeiculo", VeiculoAtualizado.anoVeiculo);
                    cmd.Parameters.AddWithValue("@placaVeiculo", VeiculoAtualizado.placaVeiculo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        //_____________________________________________________________________________________________________________________________________________

        public VeiculoDomain BuscarPorId(int idVeiculo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT idVeiculo, anoVeiculo, placaVeiculo FROM VEICULO WHERE idVeiculo = @idVeiculo";

                con.Open();
                SqlDataReader reader;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idVeiculo", idVeiculo);
                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        VeiculoDomain VeiculoBuscado = new VeiculoDomain
                        {
                            idVeiculo = Convert.ToInt32(reader["idVeiculo"]),
                            anoVeiculo = Convert.ToInt32(reader["anoVeiculo"]),
                            placaVeiculo = reader["placaVeiculo"].ToString()
                        };

                        return VeiculoBuscado;
                    }

                    return null;
                }
            }
        }

//_____________________________________________________________________________________________________________________________________________

        public void Cadastrar(VeiculoDomain veiculo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO VEICULO (anoVeiculo, placaVeiculo) VALUES (@anoVeiculo, @placaVeiculo);";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@anoVeiculo", veiculo.anoVeiculo);
                    cmd.Parameters.AddWithValue("@placaVeiculo", veiculo.placaVeiculo);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

//_____________________________________________________________________________________________________________________________________________

        public void Deletar(int idVeiculo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM VEICULO WHERE idVeiculo = @idVeiculo";
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@idVeiculo", idVeiculo);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

//_____________________________________________________________________________________________________________________________________________

        public List<VeiculoDomain> ListarTodos()
        {
            List<VeiculoDomain> listaVeiculo = new List<VeiculoDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectALL = "SELECT idVeiculo, anoVeiculo, placaVeiculo FROM VEICULO;";
                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectALL, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        VeiculoDomain veiculo = new VeiculoDomain()
                        {
                            idVeiculo = Convert.ToInt32(rdr[0]),
                            anoVeiculo = Convert.ToInt32(rdr[1]),
                            placaVeiculo = rdr[2].ToString(),
                        };

                        listaVeiculo.Add(veiculo);
                    }
                }
            }

            return listaVeiculo;
        }
    }
}