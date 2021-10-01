using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
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

        public void Atualizar(int idTipoUsuario, TipoUsuarioDomain TipoUsuarioAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateUrl = "UPDATE TIPOUSUARIO SET titulo = @titulo WHERE idTipoUsuario = @id";

                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    cmd.Parameters.AddWithValue("@id", idTipoUsuario);
                    cmd.Parameters.AddWithValue("@titulo", TipoUsuarioAtualizado.titulo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        //_____________________________________________________________________________________________________________________________________________

        public TipoUsuarioDomain BuscarPorId(int idTipoUsuario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT idTipoUsuario, titulo FROM TIPOUSUARIO WHERE idTipoUsuario = @idTipoUsuario";

                con.Open();
                SqlDataReader reader;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idTipoUsuario", idTipoUsuario);
                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        TipoUsuarioDomain TipoUsuarioBuscado = new TipoUsuarioDomain
                        {
                            idTipoUsuario = Convert.ToInt32(reader["idTipoUsuario"]),
                            titulo = reader["titulo"].ToString()
                        };

                        return TipoUsuarioBuscado;
                    }

                    return null;
                }
            }
        }

        //_____________________________________________________________________________________________________________________________________________

        public void Cadastrar(TipoUsuarioDomain TipoUsuario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO TIPOUSUARIO (titulo) VALUES (@titulo);";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@titulo", TipoUsuario.titulo);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //_____________________________________________________________________________________________________________________________________________

        public void Deletar(int idTipoUsuario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string queryDelete = "DELETE FROM TipoUsuario WHERE idTipoUsuario = @idTipoUsuario";
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@idTipoUsuario", idTipoUsuario);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //_____________________________________________________________________________________________________________________________________________

        public List<TipoUsuarioDomain> ListarTodos()
        {
            List<TipoUsuarioDomain> listaTipoUsuario = new List<TipoUsuarioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectALL = "SELECT idTipoUsuario, titulo FROM TIPOUSUARIO;";
                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectALL, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        TipoUsuarioDomain TipoUsuario = new TipoUsuarioDomain()
                        {
                            idTipoUsuario = Convert.ToInt32(rdr[0]),
                            titulo = rdr[1].ToString()
                        };

                        listaTipoUsuario.Add(TipoUsuario);
                    }
                }
            }

            return listaTipoUsuario;
        }

        //_____________________________________________________________________________________________________________________________________________
    }
}