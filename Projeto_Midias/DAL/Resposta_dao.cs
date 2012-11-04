using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using Npgsql;
using NpgsqlTypes;

namespace DAL
{
    public class Resposta_dao
    {
        public Resposta_dao() { }

        public int salvar(Resposta nova_resposta)
        {
            int novo_id = 0;
            string comandoSql = "SELECT inserir_resposta(@DS_RESPOSTA, @ID_QUESTAO, @FL_CORRETA)";
            try
            {
                using (NpgsqlConnection conexao = ConnectionFactory.createConnection())
                {
                    NpgsqlCommand cmd = new NpgsqlCommand(comandoSql, conexao);
                    NpgsqlParameter[] parametros = new NpgsqlParameter[3];

                    parametros[0] = new NpgsqlParameter();
                    parametros[0].ParameterName = "@DS_RESPOSTA";
                    parametros[0].NpgsqlDbType = NpgsqlDbType.Varchar;

                    if (nova_resposta.Ds_resposta == "")
                    {
                        parametros[0].Value = DBNull.Value;
                    }
                    else
                    {
                        parametros[0].Value = nova_resposta.Ds_resposta;
                    }
                    cmd.Parameters.Add(parametros[0]);

                    parametros[1] = new NpgsqlParameter();
                    parametros[1].ParameterName = "@FL_CORRETA";
                    parametros[1].NpgsqlDbType = NpgsqlDbType.Boolean;
                    parametros[1].Value = nova_resposta.FL_correta;
                    cmd.Parameters.Add(parametros[1]);

                    parametros[2] = new NpgsqlParameter();
                    parametros[2].ParameterName = "@ID_QUESTAO";
                    parametros[2].NpgsqlDbType = NpgsqlDbType.Integer;

                    if (nova_resposta.Questao_obj.Id_questao == 0)
                    {
                        parametros[2].Value = DBNull.Value;
                    }
                    else
                    {
                        parametros[2].Value = nova_resposta.Questao_obj.Id_questao;
                    }
                    cmd.Parameters.Add(parametros[0]);

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

        public Resposta obter(int id_resposta)
        {
            Resposta resposta = null;
            string comandoSql = "SELECT * FROM RESPOSTA WHERE ID_RESPOSTA = @ID_RESPOSTA;";
            try
            {
                using (NpgsqlConnection conexao = ConnectionFactory.createConnection())
                {
                    NpgsqlCommand cmd = new NpgsqlCommand(comandoSql, conexao);
                    NpgsqlParameter[] parametros = new NpgsqlParameter[1];

                    parametros[0] = new NpgsqlParameter();
                    parametros[0].ParameterName = "@ID_RESPOSTA";
                    parametros[0].NpgsqlDbType = NpgsqlDbType.Integer;
                    parametros[0].Value = id_resposta;
                    cmd.Parameters.Add(parametros[0]);

                    using (NpgsqlDataReader data_reader = cmd.ExecuteReader())
                    {
                        if (data_reader.Read())
                        {
                            resposta = carregar(data_reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }

            return resposta;
        }

        public List<Resposta> obterPorQuestao(int id_questao)
        {
            List<Resposta> lista = new List<Resposta>();
            string comandoSql = "SELECT * FROM RESPOSTA WHERE ID_QUESTAO = @ID_QUESTAO;";
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
                        while (data_reader.Read())
                        {
                            lista.Add(carregar(data_reader));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return lista; ;
            }

            return lista;
        }

        public int alterarDescricao(int id_resposta, string descricao)
        {
            int linha_afetadas = 0;
            string comandoSql = "UPDATE RESPOSTA SET DS_RESPOSTA = @DS_RESPOSTA WHERE ID_RESPOSTA = @ID_RESPOSTA;";
            try
            {
                using (NpgsqlConnection conexao = ConnectionFactory.createConnection())
                {
                    NpgsqlCommand cmd = new NpgsqlCommand(comandoSql, conexao);
                    NpgsqlParameter[] parametros = new NpgsqlParameter[2];

                    parametros[0] = new NpgsqlParameter();
                    parametros[0].ParameterName = "@ID_RESPOSTA";
                    parametros[0].NpgsqlDbType = NpgsqlDbType.Integer;
                    parametros[0].Value = id_resposta;
                    cmd.Parameters.Add(parametros[0]);

                    parametros[1] = new NpgsqlParameter();
                    parametros[1].ParameterName = "@DS_RESPOSTA";
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

        public int alterarQuestao(int id_resposta, int id_questao)
        {
            int linha_afetadas = 0;
            string comandoSql = "UPDATE RESPOSTA SET ID_QUESTAO = @ID_QUESTAO WHERE ID_RESPOSTA = @ID_RESPOSTA;";
            try
            {
                using (NpgsqlConnection conexao = ConnectionFactory.createConnection())
                {
                    NpgsqlCommand cmd = new NpgsqlCommand(comandoSql, conexao);
                    NpgsqlParameter[] parametros = new NpgsqlParameter[2];

                    parametros[0] = new NpgsqlParameter();
                    parametros[0].ParameterName = "@ID_RESPOSTA";
                    parametros[0].NpgsqlDbType = NpgsqlDbType.Integer;
                    parametros[0].Value = id_resposta;
                    cmd.Parameters.Add(parametros[0]);

                    parametros[1] = new NpgsqlParameter();
                    parametros[1].ParameterName = "@ID_QUESTAO";
                    parametros[1].NpgsqlDbType = NpgsqlDbType.Integer;
                    parametros[1].Value = id_questao;
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

        public int alterarCorreta(int id_resposta, bool correta)
        {
            int linha_afetadas = 0;
            string comandoSql = "UPDATE RESPOSTA SET FL_CORRETA = @FL_CORRETA WHERE ID_RESPOSTA = @ID_RESPOSTA;";
            try
            {
                using (NpgsqlConnection conexao = ConnectionFactory.createConnection())
                {
                    NpgsqlCommand cmd = new NpgsqlCommand(comandoSql, conexao);
                    NpgsqlParameter[] parametros = new NpgsqlParameter[2];

                    parametros[0] = new NpgsqlParameter();
                    parametros[0].ParameterName = "@ID_RESPOSTA";
                    parametros[0].NpgsqlDbType = NpgsqlDbType.Integer;
                    parametros[0].Value = id_resposta;
                    cmd.Parameters.Add(parametros[0]);

                    parametros[1] = new NpgsqlParameter();
                    parametros[1].ParameterName = "@FL_CORRETA";
                    parametros[1].NpgsqlDbType = NpgsqlDbType.Boolean;
                    parametros[1].Value = correta;
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

        private Resposta carregar(NpgsqlDataReader data_reader)
        {
            Resposta resposta = new Resposta();
            resposta.id_resposta = data_reader.IsDBNull(data_reader.GetOrdinal("ID_RESPOSTA")) ? 0 : data_reader.GetInt32(data_reader.GetOrdinal("ID_RESPOSTA"));
            resposta.Ds_resposta = data_reader.IsDBNull(data_reader.GetOrdinal("DS_RESPOSTA")) ? "" : data_reader.GetString(data_reader.GetOrdinal("DS_RESPOSTA"));
            resposta.FL_correta = data_reader.IsDBNull(data_reader.GetOrdinal("FL_CORRETA")) ? false : data_reader.GetBoolean(data_reader.GetOrdinal("FL_CORRETA"));
            resposta.Questao_obj.Id_questao = data_reader.IsDBNull(data_reader.GetOrdinal("ID_QUESTAO")) ? 0 : data_reader.GetInt32(data_reader.GetOrdinal("ID_QUESTAO"));
            resposta.Dt_cadastro = data_reader.IsDBNull(data_reader.GetOrdinal("DT_CADASTRO")) ? DateTime.MinValue : data_reader.GetDateTime(data_reader.GetOrdinal("DT_CADASTRO"));
            return resposta;
        }
    }
}
