using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Repositories
{
    public class EstudioRepository : IEstudioRepository
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

        /// <summary>
        /// Atualiza um Estudio existente passando o id pela URL da requisição
        /// </summary>
        /// <param name="idEstudio">id do Estudio que será atualizado</param>
        /// <param name="EstudioAtualizado">Objeto EstudioAtualizado com os novos dados</param>
        public void Atualizar(int idEstudio, EstudioDomain EstudioAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateUrl = "UPDATE ESTUDIO SET nomeEstudio = @nomeEstudio WHERE idEstudio = @id";

                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    cmd.Parameters.AddWithValue("@id", idEstudio);
                    cmd.Parameters.AddWithValue("@nomeEstudio", EstudioAtualizado.nomeEstudio);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //_____________________________________________________________________________________________________________________________________________

        /// <summary>
        /// Busca um Estudio através de seu ID
        /// </summary>
        /// <param name="idEstudio">ID do Estudio buscado</param>
        /// <returns>O Estudio buscado </returns>
        public EstudioDomain BuscarPorId(int idEstudio)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT idEstudio, nomeEstudio FROM ESTUDIO WHERE idEstudio = @idEstudio";
                con.Open();
                SqlDataReader reader;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idEstudio", idEstudio);
                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        EstudioDomain EstudioBuscado = new EstudioDomain
                        {
                            idEstudio = Convert.ToInt32(reader["idEstudio"]),
                            nomeEstudio = reader["nomeEstudio"].ToString()
                        };

                        return EstudioBuscado;
                    }

                    return null;
                }
            }
        }

        //_____________________________________________________________________________________________________________________________________________

        /// <summary>
        /// Cadastra um novo Estudio
        /// </summary>
        /// <param name="Estudio">Objeto novoEstudio com os novos dados</param>
        public void Cadastrar(EstudioDomain Estudio)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO ESTUDIO (nomeEstudio) VALUES (@nomeEstudio);";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    con.Open();

                    cmd.Parameters.AddWithValue("@idEstudio", Estudio.idEstudio);
                    cmd.Parameters.AddWithValue("@nomeEstudio", Estudio.nomeEstudio);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        //_____________________________________________________________________________________________________________________________________________

        /// <summary>
        /// Deleta um Estudio existente
        /// </summary>
        /// <param name="idEstudio">ID do Estudio deletado</param>
        public void Deletar(int idEstudio)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string queryDelete = "DELETE FROM ESTUDIO WHERE idEstudio = @idEstudio";
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@idEstudio", idEstudio);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //_____________________________________________________________________________________________________________________________________________

        /// <summary>
        /// Lista todos os Estudios
        /// </summary>
        /// <returns>Lista de Estudios</returns>
        public List<EstudioDomain> ListarTodos()
        {
            List<EstudioDomain> listaEstudio = new List<EstudioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectALL = "SELECT idEstudio, nomeEstudio FROM ESTUDIO;";
                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectALL, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        EstudioDomain Estudio = new EstudioDomain()
                        {
                            idEstudio = Convert.ToInt32(rdr[0]),
                            nomeEstudio = rdr[1].ToString()
                        };

                        listaEstudio.Add(Estudio);
                    }
                }
            }

            return listaEstudio;
        }

        //_____________________________________________________________________________________________________________________________________________

        /// <summary>
        /// Lista todos os Estudios com suas respectivas listas de jogos
        /// </summary>
        /// <returns>Uma lista de Estudios com seus jogos</returns>
        public List<EstudioDomain> ListarComJogos()
        {
            List<EstudioDomain> listaEstudios = new List<EstudioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectALL = "SELECT ESTUDIO.idEstudio, ESTUDIO.nomeEstudio FROM ESTUDIO";
                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectALL, con))
                {

                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        List<JogoDomain> jogoEstudio = new List<JogoDomain>();

                        EstudioDomain Estudio = new EstudioDomain()
                        {
                            idEstudio = Convert.ToInt32(rdr[0]),
                            nomeEstudio = rdr[1].ToString()
                        };

                        using (SqlConnection connection = new SqlConnection(stringConexao))
                        {
                            string query = "SELECT idJogo, nomeJogo, descricao, dataLancamento, valor FROM JOGO WHERE idEstudio = @idEstudio";

                            connection.Open();

                            SqlDataReader readerGames;

                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@idEstudio", Estudio.idEstudio);
                                readerGames = command.ExecuteReader();

                                while (readerGames.Read())
                                {
                                    JogoDomain Jogo = new JogoDomain()
                                    {
                                        idJogo = Convert.ToInt32(readerGames[0]),
                                        nomeJogo = readerGames[1].ToString(),
                                        descricao = readerGames[2].ToString(),
                                        dataLancamento = Convert.ToDateTime(readerGames[3]),
                                        valor = Convert.ToDecimal(readerGames[4])
                                    };

                                    jogoEstudio.Add(Jogo);
                                }
                            }
                        }
                        Estudio.listaJogos = jogoEstudio;

                        listaEstudios.Add(Estudio);
                    }
                }
            }
            return listaEstudios;
        }
    }
}