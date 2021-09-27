using senai_rental_webAPI.Domains;
using senai_rental_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_rental_webAPI.Repositories
{
    public class AluguelRepository : IAluguelRepository
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

        public void Atualizar(AluguelDomain AluguelAtualizado)
        {

        }

//_____________________________________________________________________________________________________________________________________________


        public AluguelDomain BuscarPorId(int idAluguel)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT idAluguel, aluguel.idCliente, aluguel.idVeiculo, valorAluguel, dataRetirada, dataDevolucao FROM ALUGUEL";

                con.Open();
                SqlDataReader reader;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idAluguel", idAluguel);
                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        AluguelDomain AluguelBuscado = new AluguelDomain
                        {
                            idAluguel = Convert.ToInt32(reader["idAluguel"]),
                            idVeiculo = Convert.ToInt32(reader["idVeiculo"]),
                            idCliente = Convert.ToInt32(reader["idCliente"]),
                            valorAluguel = Convert.ToDecimal(reader["valorAluguel"]),
                            dataRetirada = Convert.ToDateTime(reader["dataRetirada"]),
                            dataDevolucao = Convert.ToDateTime(reader["dataDevolucao"]),
                        };

                        return AluguelBuscado;
                    }

                    return null;
                }
            }
        }

//_____________________________________________________________________________________________________________________________________________

        public void Cadastrar(AluguelDomain aluguel)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO (aluguel, idCliente, idVeiculo, valorAluguel, dataRetirada, dataDevolucao) VALUES (@idCliente, @idVeiculo, @valorAluguel, @dataRetirada, @dataDevolucao);";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@idCliente", aluguel.idCliente);
                    cmd.Parameters.AddWithValue("@idVeiculo", aluguel.idVeiculo);
                    cmd.Parameters.AddWithValue("@valorAluguel", aluguel.valorAluguel);
                    cmd.Parameters.AddWithValue("@dataRetirada", aluguel.dataRetirada);
                    cmd.Parameters.AddWithValue("@dataDevolucao", aluguel.dataDevolucao);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

//_____________________________________________________________________________________________________________________________________________

        public void Deletar(int idAluguel)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM ALUGUEL WHERE idAluguel = @idAluguel";
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@idAluguel", idAluguel);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //_____________________________________________________________________________________________________________________________________________

        public List<AluguelDomain> ListarTodos()
        {
            List<AluguelDomain> listaAlugueis = new List<AluguelDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT idAluguel, aluguel.idCliente, aluguel.idVeiculo, valorAluguel, dataRetirada, dataDevolucao FROM ALUGUEL";
                SqlDataReader rdr;
                con.Open();

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {

                        AluguelDomain aluguel = new AluguelDomain()
                        {
                            idAluguel = Convert.ToInt32(rdr[0]),
                            idCliente = Convert.ToInt32(rdr[1]),
                            idVeiculo = Convert.ToInt32(rdr[2]),
                            valorAluguel = Convert.ToDecimal(rdr[3]),
                            dataRetirada = Convert.ToDateTime(rdr[4]),
                            dataDevolucao = Convert.ToDateTime(rdr[5]),
                        };

                        listaAlugueis.Add(aluguel);
                    }
                }
                return listaAlugueis;
            }
        }
    }
}