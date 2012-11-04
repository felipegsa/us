using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using Npgsql;
using NpgsqlTypes;

namespace DAL
{
    public class Questao_dao
    {
        public Questao_dao() { }

        public int salvar(Questao questao)
        {
            int novo_id = 0;
            string comandoSql = "SELECT inserir_questao(@DS_QUESTAO, @ID_CURSO)";
            try
            {
                using (NpgsqlConnection conexao = ConnectionFactory.createConnection())
                {
                    NpgsqlCommand cmd = new NpgsqlCommand(comandoSql, conexao);
                    NpgsqlParameter[] parametros = new NpgsqlParameter[2];

                    parametros[0] = new NpgsqlParameter();
                    parametros[0].ParameterName = "@DS_QUESTAO";
                    parametros[0].NpgsqlDbType = NpgsqlDbType.Varchar;

                    if (questao.Ds_questao == "")
                    {
                        parametros[0].Value = DBNull.Value;
                    }
                    else
                    {
                        parametros[0].Value = questao.Ds_questao;
                    }
                    cmd.Parameters.Add(parametros[0]);

                    parametros[1] = new NpgsqlParameter();
                    parametros[1].ParameterName = "@ID_CURSO";
                    parametros[1].NpgsqlDbType = NpgsqlDbType.Integer;

                    if (questao.Curso_obj.Id_curso == 0)
                    {
                        parametros[1].Value = DBNull.Value;
                    }
                    else
                    {
                        parametros[1].Value = questao.Curso_obj.Id_curso;
                    }
                    cmd.Parameters.Add(parametros[1]);

                    using (NpgsqlDataReader data_reader = cmd.ExecuteReader())
                    {
                        if (data_reader.Read())
                        {
                            novo_id = data_reader.IsDBNull(0) ? 0 : data_reader.GetInt32(0);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return 0;
            }

            return novo_id;
        }

        public Questao obter(int id_questao)
        {
            Questao questao = null;
            string comandoSql = "SELECT * FROM QUESTAO WHERE ID_QUESTAO = @ID_QUESTAO;";
            try
            {
                using (NpgsqlConnection conexao = ConnectionFactory.createConnection())
                {
                    NpgsqlCommand cmd = new NpgsqlCommand(comandoSql, conexao);
                    NpgsqlParameter[] parametros = new NpgsqlParameter[1];

                    parametros[0] = new NpgsqlParameter();
                    parametros[0].ParameterName = "@ID_QUESTAO";
                    parametros[0].NpgsqlDbType = NpgsqlDbType.Integer;
                    parametros[0].Value = id_questao;
                    cmd.Parameters.Add(parametros[0]);

                    using (NpgsqlDataReader data_reader = cmd.ExecuteReader())
                    {
                        if (data_reader.Read())
                        {
                            questao = carregar(data_reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }

            return questao;
        }

        public List<Questao> obterPorCurso(int id_curso)
        {
            List<Questao> lista = new List<Questao>();
            string comandoSql = "SELECT * FROM QUESTAO WHERE ID_CURSO = @ID_CURSO;";
            try
            {
                using (NpgsqlConnection conexao = ConnectionFactory.createConnection())
                {
                    NpgsqlCommand cmd = new NpgsqlCommand(comandoSql, conexao);
                    NpgsqlParameter[] parametros = new NpgsqlParameter[1];

                    parametros[0] = new NpgsqlParameter();
                    parametros[0].ParameterName = "@ID_CURSO";
                    parametros[0].NpgsqlDbType = NpgsqlDbType.Integer;
                    parametros[0].Value = id_curso;
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
                return lista;
            }

            return lista;
        }

        public int alterarDescricao(int id_questao, string descricao)
        {
            int linha_afetadas = 0;
            string comandoSql = "UPDATE QUESTAO SET DS_QUESTAO = @DS_QUESTAO WHERE ID_QUESTAO = @ID_QUESTAO;";
            try
            {
                using (NpgsqlConnection conexao = ConnectionFactory.createConnection())
                {
                    NpgsqlCommand cmd = new NpgsqlCommand(comandoSql, conexao);
                    NpgsqlParameter[] parametros = new NpgsqlParameter[2];

                    parametros[0] = new NpgsqlParameter();
                    parametros[0].ParameterName = "@ID_QUESTAO";
                    parametros[0].NpgsqlDbType = NpgsqlDbType.Integer;
                    parametros[0].Value = id_questao;
                    cmd.Parameters.Add(parametros[0]);
                    
                    parametros[1] = new NpgsqlParameter();
                    parametros[1].ParameterName = "@DS_QUESTAO";
                    parametros[1].NpgsqlDbType = NpgsqlDbType.Varchar;
                    parametros[1].Value = descricao;
                    cmd.Parameters.Add(parametros[1]);

                    linha_afetadas = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                return 0;
            }

            return linha_afetadas;
        }

        public int alterarCurso(int id_questao, int id_curso)
        {
            int linha_afetadas = 0;
            string comandoSql = "UPDATE QUESTAO SET ID_CURSO = @ID_CURSO WHERE ID_QUESTAO = @ID_QUESTAO;";
            try
            {
                using (NpgsqlConnection conexao = ConnectionFactory.createConnection())
                {
                    NpgsqlCommand cmd = new NpgsqlCommand(comandoSql, conexao);
                    NpgsqlParameter[] parametros = new NpgsqlParameter[2];

                    parametros[0] = new NpgsqlParameter();
                    parametros[0].ParameterName = "@ID_QUESTAO";
                    parametros[0].NpgsqlDbType = NpgsqlDbType.Integer;
                    parametros[0].Value = id_questao;
                    cmd.Parameters.Add(parametros[0]);

                    parametros[1] = new NpgsqlParameter();
                    parametros[1].ParameterName = "@ID_CURSO";
                    parametros[1].NpgsqlDbType = NpgsqlDbType.Integer;
                    parametros[1].Value = id_curso;
                    cmd.Parameters.Add(parametros[1]);

                    linha_afetadas = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                return 0;
            }

            return linha_afetadas;
        }

        private Questao carregar(NpgsqlDataReader data_reader)
        {
            Questao questao = new Questao();
            questao.Id_questao = data_reader.IsDBNull(data_reader.GetOrdinal("ID_QUESTAO")) ? 0 : data_reader.GetInt32(data_reader.GetOrdinal("ID_QUESTAO"));
            questao.Ds_questao = data_reader.IsDBNull(data_reader.GetOrdinal("DS_QUESTAO")) ? "" : data_reader.GetString(data_reader.GetOrdinal("DS_QUESTAO"));
            questao.Curso_obj.Id_curso = data_reader.IsDBNull(data_reader.GetOrdinal("ID_CURSO")) ? 0 : data_reader.GetInt32(data_reader.GetOrdinal("ID_CURSO"));
            questao.Dt_cadastro = data_reader.IsDBNull(data_reader.GetOrdinal("DT_CADASTRO")) ? DateTime.MinValue : data_reader.GetDateTime(data_reader.GetOrdinal("DT_CADASTRO"));
            return questao;
        }
    }
}
