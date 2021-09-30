using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
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

        public void Atualizar(int idUsuario, UsuarioDomain UsuarioAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateUrl = "UPDATE Usuario SET email = @email, senha = @senha, TIPOUSUARIO.idTipoUsuario = @idTipoUsuario WHERE idUsuario = @id";

                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    cmd.Parameters.AddWithValue("@id", idUsuario);
                    cmd.Parameters.AddWithValue("@email", UsuarioAtualizado.email);
                    cmd.Parameters.AddWithValue("@senha", UsuarioAtualizado.senha);
                    cmd.Parameters.AddWithValue("@idTipoUsuario", UsuarioAtualizado.idTipoUsuario);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        //_____________________________________________________________________________________________________________________________________________

        public UsuarioDomain BuscarPorId(int idUsuario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT idUsuario, email, senha, idTipoUsuario FROM Usuario WHERE idUsuario = @idUsuario";

                con.Open();
                SqlDataReader reader;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        UsuarioDomain UsuarioBuscado = new UsuarioDomain
                        {
                            idUsuario = Convert.ToInt32(reader["idUsuario"]),
                            email = reader["email"].ToString(),
                            senha = reader["senha"].ToString(),
                            idTipoUsuario = Convert.ToInt32(reader["idTipoUsuario"])
                        };

                        return UsuarioBuscado;
                    }

                    return null;
                }
            }
        }

        //_____________________________________________________________________________________________________________________________________________

        public void Cadastrar(UsuarioDomain Usuario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Usuario (email, senha, idTipoUsuario) VALUES (@email, @senha, @idTipoUsuario);";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    con.Open();

                    cmd.Parameters.AddWithValue("@email", Usuario.email);
                    cmd.Parameters.AddWithValue("@senha", Usuario.senha);
                    cmd.Parameters.AddWithValue("@idTipoUsuario", Usuario.idTipoUsuario);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        //_____________________________________________________________________________________________________________________________________________

        public void Deletar(int idUsuario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string queryDelete = "DELETE FROM Usuario WHERE idUsuario = @idUsuario";
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //_____________________________________________________________________________________________________________________________________________

        public List<UsuarioDomain> ListarTodos()
        {
            List<UsuarioDomain> listaUsuario = new List<UsuarioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectALL = "SELECT idUsuario, email, senha, idTipoUsuario FROM Usuario;";
                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectALL, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        UsuarioDomain Usuario = new UsuarioDomain()
                        {
                            idUsuario = Convert.ToInt32(rdr[0]),
                            email = rdr[1].ToString(),
                            senha = rdr[2].ToString(),
                            idTipoUsuario = Convert.ToInt32(rdr[3])
                        };

                        listaUsuario.Add(Usuario);
                    }
                }
            }

            return listaUsuario;
        }

        //_____________________________________________________________________________________________________________________________________________

        public UsuarioDomain BuscarPorEmailSenha(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelect = @"SELECT idUsuario, email, senha, idTipoUsuario FROM USUARIO WHERE email = @email and senha = @senha";


                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@senha", senha);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        UsuarioDomain UsuarioBuscado = new UsuarioDomain
                        {
                            idUsuario = Convert.ToInt32(rdr["idUsuario"]),
                            email = rdr["email"].ToString(),
                            senha = rdr["senha"].ToString(),
                            idTipoUsuario = Convert.ToInt32(rdr["idTipoUsuario"])
                        };

                        return UsuarioBuscado;
                    }

                    return null;
                }
            }
        }
    }
}
