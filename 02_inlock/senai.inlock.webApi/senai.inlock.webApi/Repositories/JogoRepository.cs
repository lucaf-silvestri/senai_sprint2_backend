using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        /// <summary>
        /// String de conexão com o banco de dados que recebe os parâmetros
        /// Data Source = Nome do Servidor
        /// inital catalog = Nome do banco de dados
        /// user id= sa; pwd= Senai@132 = Faz a autenticação com o SQL SERVER passando Login e Senha
        /// integrated security = Faz a autenticação com o usuário do sistema.
        /// </summary>
        //private string stringConexao = "Data Source=DESKTOP-U20H53U; initial catalog=catalogo_manha; user id=sa; pwd=Senai@132";
        private string stringConexao = @"Data Source=DESKTOP-0R6MFG3\SQLEXPRESS; initial catalog=INLOCK_GAMES_MANHA; integrated security=true";

        //_____________________________________________________________________________________________________________________________________________

        public void Atualizar(int idJogo, JogoDomain JogoAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateUrl = "UPDATE JOGO SET nomeJogo = @nomeJogo, descricao = @descricao, dataLancamento = @dataLancamento, valor = @valor, idEstudio = @idEstudio WHERE idJogo = @id";

                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    cmd.Parameters.AddWithValue("@id", idJogo);
                    cmd.Parameters.AddWithValue("@nomeJogo", JogoAtualizado.nomeJogo);
                    cmd.Parameters.AddWithValue("@descricao", JogoAtualizado.descricao);
                    cmd.Parameters.AddWithValue("@dataLancamento", JogoAtualizado.dataLancamento);
                    cmd.Parameters.AddWithValue("@valor", JogoAtualizado.valor);
                    cmd.Parameters.AddWithValue("@idEstudio", JogoAtualizado.idEstudio);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //_____________________________________________________________________________________________________________________________________________

        public JogoDomain BuscarPorId(int idJogo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT nomeJogo, descricao, dataLancamento, valor, idEstudio FROM Jogo WHERE idJogo = @idJogo";
                con.Open();
                SqlDataReader reader;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idJogo", idJogo);
                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        JogoDomain JogoBuscado = new JogoDomain
                        {
                            nomeJogo = reader["nomeJogo"].ToString(),
                            descricao = reader["descricao"].ToString(),
                            valor = Convert.ToDecimal(reader["valor"]),
                            dataLancamento = Convert.ToDateTime(reader["dataLancamento"]),
                            idEstudio = Convert.ToInt32(reader["idEstudio"])
                        };

                        return JogoBuscado;
                    }

                    return null;
                }
            }
        }

        //_____________________________________________________________________________________________________________________________________________

        public void Cadastrar(JogoDomain Jogo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO JOGO (nomeJogo, descricao, dataLancamento, valor, idEstudio) VALUES (@nomeJogo, @descricao, @dataLancamento, @valor, @idEstudio);";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    con.Open();

                    cmd.Parameters.AddWithValue("@nomeJogo", Jogo.nomeJogo);
                    cmd.Parameters.AddWithValue("@descricao", Jogo.descricao);
                    cmd.Parameters.AddWithValue("@dataLancamento", Jogo.dataLancamento);
                    cmd.Parameters.AddWithValue("@valor", Jogo.valor);
                    cmd.Parameters.AddWithValue("@idEstudio", Jogo.idEstudio);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        //_____________________________________________________________________________________________________________________________________________

        public void Deletar(int idJogo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string queryDelete = "DELETE FROM Jogo WHERE idJogo = @idJogo";
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@idJogo", idJogo);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //_____________________________________________________________________________________________________________________________________________

        public List<JogoDomain> ListarTodos()
        {
            List<JogoDomain> listaJogo = new List<JogoDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectALL = "SELECT idJogo, nomeJogo, descricao, dataLancamento, valor, idEstudio FROM JOGO;";
                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectALL, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        JogoDomain Jogo = new JogoDomain()
                        {
                            idJogo = Convert.ToInt32(rdr[0]),
                            nomeJogo = rdr[1].ToString(),
                            descricao = rdr[2].ToString(),
                            dataLancamento = Convert.ToDateTime(rdr[3]),
                            valor = Convert.ToDecimal(rdr[4]),
                            idEstudio = Convert.ToInt32(rdr[5])
                        };

                        listaJogo.Add(Jogo);
                    }
                }
            }

            return listaJogo;
        }
    }
}