using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using NpgsqlTypes;
using Model;
using Model.Enum;

namespace DAL
{
    public class Usuario_dal
    {
        public Usuario_dal() { }

        // cadastra o novo usuario e retorna o ID_USUARIO que acabou de ser cadastrado
        public int salvar(Usuario novo_usuario)
        {
            int novo_id = 0;
            string comandoSql = "SELECT inserir_usuario(@ID_TIPO_USUARIO, @NM_USUARIO, @EMAIL_USUARIO, @SENHA_USUARIO, @LINK_IMAGEM_USUARIO)";

            try
            {
                using (NpgsqlConnection conexao = ConnectionFactory.createConnection())
                {
                    NpgsqlCommand cmd = new NpgsqlCommand(comandoSql, conexao);
                    NpgsqlParameter[] parametros = new NpgsqlParameter[5];

                    // tipo de usuário
                    parametros[0] = new NpgsqlParameter();
                    parametros[0].ParameterName = "@ID_TIPO_USUARIO";
                    parametros[0].NpgsqlDbType = NpgsqlDbType.Integer;

                    if (novo_usuario.Tipo == Tipo_usuario.NONE)
                    {
                        parametros[0].Value = DBNull.Value;
                    }
                    else
                    {
                        parametros[0].Value = (int)novo_usuario.Tipo;
                    }
                    
                    cmd.Parameters.Add(parametros[0]);

                    // nome
                    parametros[1] = new NpgsqlParameter();
                    parametros[1].ParameterName = "@NM_USUARIO";
                    parametros[1].NpgsqlDbType = NpgsqlDbType.Varchar;

                    if (novo_usuario.Nm_usuario == "")
                    {
                        parametros[1].Value = DBNull.Value;
                    }
                    else
                    {
                        parametros[1].Value = novo_usuario.Nm_usuario;
                    }
                    cmd.Parameters.Add(parametros[1]);

                    // email
                    parametros[2] = new NpgsqlParameter();
                    parametros[2].ParameterName = "@EMAIL_USUARIO";
                    parametros[2].NpgsqlDbType = NpgsqlDbType.Varchar;

                    if (novo_usuario.Email_usuario == "")
                    {
                        parametros[2].Value = DBNull.Value;
                    }
                    else
                    {
                        parametros[2].Value = novo_usuario.Email_usuario;
                    }
                    cmd.Parameters.Add(parametros[2]);

                    // senha
                    parametros[3] = new NpgsqlParameter();
                    parametros[3].ParameterName = "@SENHA_USUARIO";
                    parametros[3].NpgsqlDbType = NpgsqlDbType.Varchar;

                    if (novo_usuario.Senha_usuario == "")
                    {
                        parametros[3].Value = DBNull.Value;
                    }
                    else
                    {
                        parametros[3].Value = novo_usuario.Senha_usuario;
                    }
                    cmd.Parameters.Add(parametros[3]);

                    // link da imagem
                    parametros[4] = new NpgsqlParameter();
                    parametros[4].ParameterName = "@LINK_IMAGEM_USUARIO";
                    parametros[4].NpgsqlDbType = NpgsqlDbType.Varchar;

                    if (novo_usuario.Link_imagem_usuario == "")
                    {
                        parametros[4].Value = DBNull.Value;
                    }
                    else
                    {
                        parametros[4].Value = novo_usuario.Link_imagem_usuario;
                    }
                    cmd.Parameters.Add(parametros[4]);

                    using (NpgsqlDataReader data_reader = cmd.ExecuteReader())
                    {
                        if (data_reader.Read())
                        {
                            // retorna o ID_USUARIO que acabou de ser cadastrado
                            novo_id = data_reader.IsDBNull(0) ? 0 : data_reader.GetInt32(0);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // neste ponto poderia ser gerado um log...
                return 0;
            }

            return novo_id;
        }

        public List<Usuario> obter()
        {
            List<Usuario> lista = new List<Usuario>();
            string comandoSql = "SELECT * FROM USUARIO;";

            try
            {
                using (NpgsqlConnection conexao = ConnectionFactory.createConnection())
                {
                    NpgsqlCommand cmd = new NpgsqlCommand(comandoSql, conexao);

                    using (NpgsqlDataReader data_reader = cmd.ExecuteReader())
                    {
                        while (data_reader.Read())
                        {
                            lista.Add(carregar(data_reader));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // neste ponto poderia ser gerado um log...
                return lista;
            }

            return lista;
        }

        public Usuario obter(int id_usuario)
        {
            Usuario usuario = null;
            string comandoSql = "SELECT * FROM USUARIO WHERE ID_USUARIO = @ID_USUARIO;";

            try
            {
                using (NpgsqlConnection conexao = ConnectionFactory.createConnection())
                {
                    NpgsqlCommand cmd = new NpgsqlCommand(comandoSql, conexao);
                    NpgsqlParameter[] parametros = new NpgsqlParameter[1];

                    parametros[0] = new NpgsqlParameter();
                    parametros[0].ParameterName = "@ID_USUARIO";
                    parametros[0].NpgsqlDbType = NpgsqlDbType.Integer;
                    parametros[0].Value = id_usuario;
                    cmd.Parameters.Add(parametros[0]);

                    using (NpgsqlDataReader data_reader = cmd.ExecuteReader())
                    {
                        if (data_reader.Read())
                        {
                            usuario = carregar(data_reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // neste ponto poderia ser gerado um log...
                return null;
            }

            return usuario;
        }

        public Usuario obter(string email_usuario)
        {
            Usuario usuario = null;
            string comandoSql = "SELECT * FROM USUARIO WHERE EMAIL_USUARIO = @EMAIL_USUARIO;";

            try
            {
                using (NpgsqlConnection conexao = ConnectionFactory.createConnection())
                {
                    NpgsqlCommand cmd = new NpgsqlCommand(comandoSql, conexao);
                    NpgsqlParameter[] parametros = new NpgsqlParameter[1];

                    parametros[0] = new NpgsqlParameter();
                    parametros[0].ParameterName = "@EMAIL_USUARIO";
                    parametros[0].NpgsqlDbType = NpgsqlDbType.Varchar;
                    parametros[0].Value = email_usuario;
                    cmd.Parameters.Add(parametros[0]);

                    using (NpgsqlDataReader data_reader = cmd.ExecuteReader())
                    {
                        if (data_reader.Read())
                        {
                            usuario = carregar(data_reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // neste ponto poderia ser gerado um log...
                return null;
            }

            return usuario;
        }

        public Usuario obter(string email_usuario, string senha)
        {
            Usuario usuario = null;
            string comandoSql = "SELECT * FROM USUARIO WHERE EMAIL_USUARIO = @EMAIL_USUARIO AND ";
            comandoSql += "SENHA_USUARIO = @SENHA_USUARIO;";

            try
            {
                using (NpgsqlConnection conexao = ConnectionFactory.createConnection())
                {
                    NpgsqlCommand cmd = new NpgsqlCommand(comandoSql, conexao);
                    NpgsqlParameter[] parametros = new NpgsqlParameter[2];

                    parametros[0] = new NpgsqlParameter();
                    parametros[0].ParameterName = "@EMAIL_USUARIO";
                    parametros[0].NpgsqlDbType = NpgsqlDbType.Varchar;
                    parametros[0].Value = email_usuario;
                    cmd.Parameters.Add(parametros[0]);

                    parametros[1] = new NpgsqlParameter();
                    parametros[1].ParameterName = "@SENHA_USUARIO";
                    parametros[1].NpgsqlDbType = NpgsqlDbType.Varchar;
                    parametros[1].Value = senha;
                    cmd.Parameters.Add(parametros[1]);

                    using (NpgsqlDataReader data_reader = cmd.ExecuteReader())
                    {
                        if (data_reader.Read())
                        {
                            usuario = carregar(data_reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // neste ponto poderia ser gerado um log...
                return null;
            }

            return usuario;
        }

        // alterar todos os campos do usuario. O parâmetro ID_USUARIO é obrigatório
        public int alterar(Usuario usuario)
        {
            int linhas_afetadas = 0;
            string comandoSql = "UPDATE USUARIO SET ID_TIPO_USUARIO = @ID_TIPO_USUARIO, NM_USUARIO = @NM_USUARIO, EMAIL_USUARIO = @EMAIL_USUARIO, SENHA_USUARIo = @SENHA_USUARIO, LINK_IMAGEM_USUARIO = @LINK_IMAGEM_USUARIO ";
            comandoSql += "WHERE ID_USUARIO = @ID_USUARIO;";

            try
            {
                using (NpgsqlConnection conexao = ConnectionFactory.createConnection())
                {
                    NpgsqlCommand cmd = new NpgsqlCommand(comandoSql, conexao);
                    NpgsqlParameter[] parametros = new NpgsqlParameter[6];

                    // tipo de usuário
                    parametros[0] = new NpgsqlParameter();
                    parametros[0].ParameterName = "@ID_TIPO_USUARIO";
                    parametros[0].NpgsqlDbType = NpgsqlDbType.Integer;

                    if (usuario.Tipo == Tipo_usuario.NONE)
                    {
                        parametros[0].Value = DBNull.Value;
                    }
                    else
                    {
                        parametros[0].Value = (int)usuario.Tipo;
                    }

                    cmd.Parameters.Add(parametros[0]);

                    // nome
                    parametros[1] = new NpgsqlParameter();
                    parametros[1].ParameterName = "@NM_USUARIO";
                    parametros[1].NpgsqlDbType = NpgsqlDbType.Varchar;

                    if (usuario.Nm_usuario == "")
                    {
                        parametros[1].Value = DBNull.Value;
                    }
                    else
                    {
                        parametros[1].Value = usuario.Nm_usuario;
                    }
                    cmd.Parameters.Add(parametros[1]);

                    // email
                    parametros[2] = new NpgsqlParameter();
                    parametros[2].ParameterName = "@EMAIL_USUARIO";
                    parametros[2].NpgsqlDbType = NpgsqlDbType.Varchar;

                    if (usuario.Email_usuario == "")
                    {
                        parametros[2].Value = DBNull.Value;
                    }
                    else
                    {
                        parametros[2].Value = usuario.Email_usuario;
                    }
                    cmd.Parameters.Add(parametros[2]);

                    // senha
                    parametros[3] = new NpgsqlParameter();
                    parametros[3].ParameterName = "@SENHA_USUARIO";
                    parametros[3].NpgsqlDbType = NpgsqlDbType.Varchar;

                    if (usuario.Senha_usuario == "")
                    {
                        parametros[3].Value = DBNull.Value;
                    }
                    else
                    {
                        parametros[3].Value = usuario.Senha_usuario;
                    }
                    cmd.Parameters.Add(parametros[3]);

                    // link da imagem
                    parametros[4] = new NpgsqlParameter();
                    parametros[4].ParameterName = "@LINK_IMAGEM_USUARIO";
                    parametros[4].NpgsqlDbType = NpgsqlDbType.Varchar;

                    if (usuario.Link_imagem_usuario == "")
                    {
                        parametros[4].Value = DBNull.Value;
                    }
                    else
                    {
                        parametros[4].Value = usuario.Link_imagem_usuario;
                    }
                    cmd.Parameters.Add(parametros[4]);

                    // ID_USUARIO
                    parametros[5] = new NpgsqlParameter();
                    parametros[5].ParameterName = "@ID_USUARIO";
                    parametros[5].NpgsqlDbType = NpgsqlDbType.Integer;
                    parametros[5].Value = usuario.Id_usuario;
                    cmd.Parameters.Add(parametros[5]);

                    // executa o update
                    linhas_afetadas = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // neste ponto poderia ser gerado um log...
                return 0;
            }

            return linhas_afetadas;
        }

        public int excluir(int id_usuario)
        {
            int linhas_afetadas = 0;

            // DROP CASCADED
            string comandoSql = "DELETE FROM USUARIO_CURSO WHERE ID_USUARIO = @ID_USUARIO; ";
            comandoSql += "DELETE FROM USUARIO_AULA WHEE ID_USUARIO = @ID_USUARIO; ";
            comandoSql += "DELETE FROM USUARIO WHERE ID_USUARIO = @ID_USUARIO;";

            try
            {
                using (NpgsqlConnection conexao = ConnectionFactory.createConnection())
                {
                    NpgsqlCommand cmd = new NpgsqlCommand(comandoSql, conexao);
                    NpgsqlParameter[] parametros = new NpgsqlParameter[1];

                    parametros[0] = new NpgsqlParameter();
                    parametros[0].ParameterName = "@ID_USUARIO";
                    parametros[0].NpgsqlDbType = NpgsqlDbType.Integer;
                    parametros[0].Value = id_usuario;
                    cmd.Parameters.Add(parametros[0]);

                    // executa o update
                    linhas_afetadas = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // neste ponto poderia ser gerado um log...
                return 0;
            }

            return linhas_afetadas;
        }

        public Usuario carregar(NpgsqlDataReader data_reader)
        {
            Usuario consulta = new Usuario();
            consulta.Id_usuario = data_reader.IsDBNull(data_reader.GetOrdinal("ID_USUARIO")) ? 0 : data_reader.GetInt32(data_reader.GetOrdinal("ID_USUARIO"));
            int id_tipo_usuario = consulta.Id_usuario = data_reader.IsDBNull(data_reader.GetOrdinal("ID_TIPO_USUARIO")) ? 0 : data_reader.GetInt32(data_reader.GetOrdinal("ID_TIPO_USUARIO"));

            if (id_tipo_usuario == (int)Tipo_usuario.ADMINISTRADOR)
            {
                consulta.Tipo = Tipo_usuario.ADMINISTRADOR;
            }
            else if (id_tipo_usuario == (int)Tipo_usuario.ALUNO)
            {
                consulta.Tipo = Tipo_usuario.ALUNO;
            }
            else
            {
                consulta.Tipo = Tipo_usuario.NONE;
            }

            consulta.Nm_usuario = data_reader.IsDBNull(data_reader.GetOrdinal("NM_USUARIO")) ? "" : data_reader.GetString(data_reader.GetOrdinal("NM_USUARIO"));
            consulta.Email_usuario = data_reader.IsDBNull(data_reader.GetOrdinal("EMAIL_USUARIO")) ? "" : data_reader.GetString(data_reader.GetOrdinal("EMAIL_USUARIO"));
            consulta.Senha_usuario = data_reader.IsDBNull(data_reader.GetOrdinal("SENHA_USUARIO")) ? "" : data_reader.GetString(data_reader.GetOrdinal("SENHA_USUARIO"));
            consulta.Link_imagem_usuario = data_reader.IsDBNull(data_reader.GetOrdinal("LINK_IMAGEM_USUARIO")) ? "" : data_reader.GetString(data_reader.GetOrdinal("LINK_IMAGEM_USUARIO"));
            consulta.Dt_cadastro = data_reader.IsDBNull(data_reader.GetOrdinal("DT_CADASTRO")) ? DateTime.MinValue : data_reader.GetDateTime(data_reader.GetOrdinal("DT_CADASTRO"));
            return consulta;
        }
    }
}