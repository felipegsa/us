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
    public class Aula_dal
    {
        public Aula_dal() { }

        // cadastra o nova aula e retorna o ID_AULA que acabou de ser cadastrado
        public int salvar(Aula nova_aula)
        {
            int novo_id = 0;
            string comandoSql = "SELECT inserir_aula(@TL_AULA, @DS_AULA, @ID_CURSO, @LINK_AULA)";

            try
            {
                using (NpgsqlConnection conexao = ConnectionFactory.createConnection())
                {
                    NpgsqlCommand cmd = new NpgsqlCommand(comandoSql, conexao);
                    NpgsqlParameter[] parametros = new NpgsqlParameter[4];

                    // título
                    parametros[0].ParameterName = "@TL_AULA";
                    parametros[0].NpgsqlDbType = NpgsqlDbType.Varchar;

                    if (nova_aula.Tl_aula == "")
                    {
                        parametros[0].Value = DBNull.Value;
                    }
                    else
                    {
                        parametros[0].Value = nova_aula.Tl_aula;
                    }

                    cmd.Parameters.Add(parametros[0]);

                    // descrição
                    parametros[1].ParameterName = "@DS_AULA";
                    parametros[1].NpgsqlDbType = NpgsqlDbType.Varchar;

                    if (nova_aula.Ds_aula == "")
                    {
                        parametros[1].Value = DBNull.Value;
                    }
                    else
                    {
                        parametros[1].Value = nova_aula.Ds_aula;
                    }
                    cmd.Parameters.Add(parametros[1]);

                    // curso no qual a aula pertence
                    parametros[2].ParameterName = "@ID_CURSO";
                    parametros[2].NpgsqlDbType = NpgsqlDbType.Integer;

                    if (nova_aula.Curso_obj.Id_curso == 0)
                    {
                        parametros[2].Value = DBNull.Value;
                    }
                    else
                    {
                        parametros[2].Value = nova_aula.Curso_obj.Id_curso;
                    }
                    cmd.Parameters.Add(parametros[2]);

                    // link da aula (link onde o vídeo da aula está)
                    parametros[3].ParameterName = "@LINK_AULA";
                    parametros[3].NpgsqlDbType = NpgsqlDbType.Varchar;

                    if (nova_aula.Link_aula == "")
                    {
                        parametros[3].Value = DBNull.Value;
                    }
                    else
                    {
                        parametros[3].Value = nova_aula.Link_aula;
                    }
                    cmd.Parameters.Add(parametros[3]);

                    using (NpgsqlDataReader data_reader = cmd.ExecuteReader())
                    {
                        if (data_reader.Read())
                        {
                            // retorna o ID_AULA que acabou de ser cadastrado
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

        public Aula obter(int id_aula)
        {
            Aula aula = null;
            string comandoSql = "SELECT * FROM AULA WHERE ID_AULA = @ID_AULA;";

            try
            {
                using (NpgsqlConnection conexao = ConnectionFactory.createConnection())
                {
                    NpgsqlCommand cmd = new NpgsqlCommand(comandoSql, conexao);
                    NpgsqlParameter[] parametros = new NpgsqlParameter[1];

                    parametros[0].ParameterName = "@ID_AULA";
                    parametros[0].NpgsqlDbType = NpgsqlDbType.Integer;
                    parametros[0].Value = id_aula;
                    cmd.Parameters.Add(parametros[0]);

                    using (NpgsqlDataReader data_reader = cmd.ExecuteReader())
                    {
                        if (data_reader.Read())
                        {
                            aula = carregar(data_reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // neste ponto poderia ser gerado um log...
                return null;
            }

            return aula;
        }

        public List<Aula> obter(Curso id_curso)
        {
            List<Aula> lista = new List<Aula>();
            string comandoSql = "SELECT * FROM AULA WHERE ID_CURSO = @ID_CURSO;";

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

        public List<Aula> obter(Usuario id_usuario)
        {
            List<Aula> lista = new List<Aula>();
            string comandoSql = "SELECT A.ID_AULA AS ID_AULA, A.TL_AULA AD TL_AULA, A.DS_AULA AS DS_AULA, A.ID_CURSO AS ID_CURSO, A.LINK_AULA AS LINK_AULA, A.DT_CADASTRO AS DT_CADASTRO FROM AULA A ";
            comandoSql += "INNER JOIN AULA_USUARIO AU ON AU.ID_AULA = A.ID_AULA ";
            comandoSql += "WHERE AU.ID_USUARIO = @ID_USUARIO;";

            try
            {
                using (NpgsqlConnection conexao = ConnectionFactory.createConnection())
                {
                    NpgsqlCommand cmd = new NpgsqlCommand(comandoSql, conexao);
                    NpgsqlParameter[] parametros = new NpgsqlParameter[1];

                    parametros[0].ParameterName = "@ID_USUARIO";
                    parametros[0].NpgsqlDbType = NpgsqlDbType.Integer;
                    parametros[0].Value = id_usuario.Id_usuario;
                    cmd.Parameters.Add(parametros[0]);

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

        public int alterar(Aula aula)
        {
            int linhas_afetadas = 0;
            string comandoSql = "UPDATE AULA SET TL_AULA = @TL_AULA, DS_AULA = @DS_AULA, ID_CURSO = @ID_CURSO, LINK_AULA = @LINK_AULA ";
            comandoSql += "WHERE ID_AULA = @ID_AULA;";

            try
            {
                using (NpgsqlConnection conexao = ConnectionFactory.createConnection())
                {
                    NpgsqlCommand cmd = new NpgsqlCommand(comandoSql, conexao);
                    NpgsqlParameter[] parametros = new NpgsqlParameter[5];

                    // título
                    parametros[0].ParameterName = "@TL_AULA";
                    parametros[0].NpgsqlDbType = NpgsqlDbType.Varchar;

                    if (aula.Tl_aula == "")
                    {
                        parametros[0].Value = DBNull.Value;
                    }
                    else
                    {
                        parametros[0].Value = aula.Tl_aula;
                    }
                    cmd.Parameters.Add(parametros[0]);

                    // descrição
                    parametros[1].ParameterName = "@DS_AULA";
                    parametros[1].NpgsqlDbType = NpgsqlDbType.Varchar;

                    if (aula.Ds_aula == "")
                    {
                        parametros[1].Value = DBNull.Value;
                    }
                    else
                    {
                        parametros[1].Value = aula.Ds_aula;
                    }
                    cmd.Parameters.Add(parametros[1]);

                    // curso
                    parametros[2].ParameterName = "@ID_CURSO";
                    parametros[2].NpgsqlDbType = NpgsqlDbType.Integer;

                    if (aula.Curso_obj.Id_curso == 0)
                    {
                        parametros[2].Value = DBNull.Value;
                    }
                    else
                    {
                        parametros[2].Value = aula.Curso_obj.Id_curso;
                    }
                    cmd.Parameters.Add(parametros[2]);

                    // link da aula
                    parametros[3].ParameterName = "@LINK_AULA";
                    parametros[3].NpgsqlDbType = NpgsqlDbType.Varchar;

                    if (aula.Link_aula == "")
                    {
                        parametros[3].Value = DBNull.Value;
                    }
                    else
                    {
                        parametros[3].Value = aula.Link_aula;
                    }
                    cmd.Parameters.Add(parametros[3]);

                    // ID_USUARIO
                    parametros[4].ParameterName = "@ID_AULA";
                    parametros[4].NpgsqlDbType = NpgsqlDbType.Integer;
                    parametros[4].Value = aula.Id_aula;
                    cmd.Parameters.Add(parametros[4]);

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

        // DROP CASCADED
        public int excluir(int id_aula)
        {
            int linhas_afetadas = 0;
            string comandoSql = "DELETE FROM AULA_USUARIO WHERE ID_AULA = @ID_AULA; ";
            comandoSql += "DELETE FROM AULA WHERE ID_AULA = @ID_AULA;";

            try
            {
                using (NpgsqlConnection conexao = ConnectionFactory.createConnection())
                {
                    NpgsqlCommand cmd = new NpgsqlCommand(comandoSql, conexao);
                    NpgsqlParameter[] parametros = new NpgsqlParameter[1];

                    // título
                    parametros[0].ParameterName = "@ID_AULA";
                    parametros[0].NpgsqlDbType = NpgsqlDbType.Integer;
                    parametros[0].Value = id_aula;
                    cmd.Parameters.Add(parametros[0]);
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

        Aula carregar(NpgsqlDataReader data_reader)
        {
            Aula aula = new Aula();
            aula.Id_aula = data_reader.IsDBNull(data_reader.GetOrdinal("ID_AULA")) ? 0 : data_reader.GetInt32(data_reader.GetOrdinal("ID_AULA"));
            aula.Tl_aula = data_reader.IsDBNull(data_reader.GetOrdinal("TL_AULA")) ? "" : data_reader.GetString(data_reader.GetOrdinal("TL_AULA"));
            aula.Ds_aula = data_reader.IsDBNull(data_reader.GetOrdinal("DS_AULA")) ? "" : data_reader.GetString(data_reader.GetOrdinal("DS_AULA"));
            aula.Curso_obj.Id_curso = data_reader.IsDBNull(data_reader.GetOrdinal("ID_CURSO")) ? 0 : data_reader.GetInt32(data_reader.GetOrdinal("ID_CURSO"));
            aula.Link_aula = data_reader.IsDBNull(data_reader.GetOrdinal("LINK_AULA")) ? "" : data_reader.GetString(data_reader.GetOrdinal("LINK_AULA"));
            aula.Dt_cadastro = data_reader.IsDBNull(data_reader.GetOrdinal("DT_CADASTRO")) ? DateTime.MinValue : data_reader.GetDateTime(data_reader.GetOrdinal("DT_CADASTRO"));
            return aula;
        }
    }
}