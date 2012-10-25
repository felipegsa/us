using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using NpgsqlTypes;
using System.Data;
using System.IO;
using Model;

namespace DAL
{
    public class CursoDAL
    {
        public CursoDAL() { }

        public List<Curso> obter()
        {
            List<Curso> lista = new List<Curso>();
            string comandoSql = "SELECT * FROM CURSO;";

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

        public List<Curso> obter(Curso curso)
        {
            List<Curso> lista = new List<Curso>();
            string comandoSql = "SELECT * FROM CURSO WHERE ";

            try
            {
                using (NpgsqlConnection conexao = ConnectionFactory.createConnection())
                {
                    NpgsqlCommand cmd = new NpgsqlCommand(comandoSql, conexao);
                    NpgsqlParameter[] parametros = new NpgsqlParameter[2];
                    int total_parametros = 0;

                    if (curso.Id_curso != 0)
                    {
                        parametros[0] = new NpgsqlParameter();
                        parametros[0].ParameterName = "@ID_CURSO";
                        parametros[0].NpgsqlDbType = NpgsqlDbType.Integer;
                        parametros[0].Value = curso.Id_curso;
                        cmd.Parameters.Add(parametros[0]);
                        comandoSql += "ID_CURSO = @ID_CURSO AND ";
                        total_parametros++;
                    }

                    if (curso.Tl_curso != "")
                    {
                        comandoSql += "TL_CURSO LIKE '%" + curso.Tl_curso + "%' AND ";
                        total_parametros++;
                    }

                    if (total_parametros > 0)
                    {
                        comandoSql = comandoSql.Substring(0, (comandoSql.Length - 5));
                        comandoSql += " ORDER BY DS_CURSO;";
                    }
                    else
                    {
                        comandoSql = comandoSql.Substring(0, (comandoSql.Length - 7));
                        comandoSql += " ORDER BY DS_CURSO;";
                    }

                    cmd.CommandText = comandoSql;

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

        public List<Curso> ObterCursoXAluno(int pIdAluno) {
            List<Curso> vListCurso = new List<Curso>();
            Curso vCurso = null;
            string comandoSql = "SELECT  A.DS_CURSO, A.TL_CURSO , A.DUR_CURSO , B.DT_CADASTRO FROM CURSO A , USUARIO_CURSO B WHERE B.ID_USUARIO = @ID_USUARIO AND A.ID_CURSO = B.ID_CURSO;";
            try 
	        {	        
        	    using (NpgsqlConnection  conn = ConnectionFactory.createConnection())
                {
                    NpgsqlCommand cmd = new NpgsqlCommand(comandoSql,conn);
                    NpgsqlParameter[] parametros = new NpgsqlParameter[1];
                    parametros[0] = new NpgsqlParameter();
                    parametros[0].ParameterName = "@ID_USUARIO";
                    parametros[0].NpgsqlDbType = NpgsqlDbType.Integer;
                    parametros[0].Value = pIdAluno;
                    cmd.Parameters.Add(parametros[0]);

                    using (NpgsqlDataReader  dr = cmd.ExecuteReader())
                    {
                        
                       while (dr.Read())
	                    {
                            vCurso = carregarCursoXAluno(dr);
                            vListCurso.Add(vCurso);
	                    }
                    }
                }
	        }
	        catch (Exception ex)
	        {        		
		        throw new ExceptionDAL(ex.Message);
	        }
            return vListCurso;
        }       

        public Curso obter(int id_curso)
        {
            Curso curso = null;
            string comandoSql = "SELECT * FROM CURSO WHERE ID_CURSO = @ID_CURSO;";

            try
            {
                using (NpgsqlConnection conexao = ConnectionFactory.createConnection())
                {
                    NpgsqlCommand cmd = new NpgsqlCommand(comandoSql, conexao);
                    NpgsqlParameter[] parametros = new NpgsqlParameter[1];

                    parametros[0].ParameterName = "@ID_CURSO";
                    parametros[0].NpgsqlDbType = NpgsqlDbType.Integer;
                    parametros[0].Value = id_curso;
                    cmd.Parameters.Add(parametros[0]);

                    using (NpgsqlDataReader data_reader = cmd.ExecuteReader())
                    {
                        if (data_reader.Read())
                        {
                            curso = carregar(data_reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // neste ponto poderia ser gerado um log...
                return null;
            }

            return curso;
        }

        public int salvar(Curso novo_curso)
        {
            int novo_id = 0;
            string comandoSql = "SELECT inserir_curso(@TL_CURSO, @DS_CURSO, @OBJ_CURSO, @TOPICOS_CURSO, @PRE_REQ_CURSO, @DURACAO_CURSO)";

            try
            {
                using (NpgsqlConnection conexao = ConnectionFactory.createConnection())
                {
                    NpgsqlCommand cmd = new NpgsqlCommand(comandoSql, conexao);
                    NpgsqlParameter[] parametros = new NpgsqlParameter[6];

                    // título
                    parametros[0].ParameterName = "@TL_CURSO";
                    parametros[0].NpgsqlDbType = NpgsqlDbType.Varchar;

                    if (novo_curso.Tl_curso == "")
                    {
                        parametros[0].Value = DBNull.Value;
                    }
                    else
                    {
                        parametros[0].Value = novo_curso.Tl_curso;
                    }
                    cmd.Parameters.Add(parametros[0]);

                    // descrição
                    parametros[1].ParameterName = "@DS_CURSO";
                    parametros[1].NpgsqlDbType = NpgsqlDbType.Varchar;

                    if (novo_curso.Ds_curso == "")
                    {
                        parametros[1].Value = DBNull.Value;
                    }
                    else
                    {
                        parametros[1].Value = novo_curso.Ds_curso;
                    }
                    cmd.Parameters.Add(parametros[1]);

                    // objetivo
                    parametros[2].ParameterName = "@OBJ_CURSO";
                    parametros[2].NpgsqlDbType = NpgsqlDbType.Varchar;

                    if (novo_curso.Obj_curso == "")
                    {
                        parametros[2].Value = DBNull.Value;
                    }
                    else
                    {
                        parametros[2].Value = novo_curso.Obj_curso;
                    }
                    cmd.Parameters.Add(parametros[2]);

                    // Tópicos
                    parametros[3].ParameterName = "@TOPICOS_CURSO";
                    parametros[3].NpgsqlDbType = NpgsqlDbType.Varchar;

                    if (novo_curso.Topicos_curso == "")
                    {
                        parametros[3].Value = DBNull.Value;
                    }
                    else
                    {
                        parametros[3].Value = novo_curso.Topicos_curso;
                    }
                    cmd.Parameters.Add(parametros[3]);

                    // Pré-requisitos
                    parametros[4].ParameterName = "@PRE_REQ_CURSO";
                    parametros[4].NpgsqlDbType = NpgsqlDbType.Varchar;

                    if (novo_curso.Pre_req_curso == "")
                    {
                        parametros[4].Value = DBNull.Value;
                    }
                    else
                    {
                        parametros[4].Value = novo_curso.Pre_req_curso;
                    }
                    cmd.Parameters.Add(parametros[4]);

                    // Duração
                    parametros[5].ParameterName = "@DURACAO_CURSO";
                    parametros[5].NpgsqlDbType = NpgsqlDbType.Varchar;

                    if (novo_curso.Duracao_curso == "")
                    {
                        parametros[5].Value = DBNull.Value;
                    }
                    else
                    {
                        parametros[5].Value = novo_curso.Duracao_curso;
                    }
                    cmd.Parameters.Add(parametros[5]);
                    
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
                // neste ponto poderia ser gerado um log...
                return 0;
            }

            return novo_id;
        }

        // o update irá atualizar todos os campos do curso. O ID_CURSO é parâmetro obrigatório
        public int alterar(Curso curso)
        {
            int linhas_afetadas = 0;
            string comandoSql = "UPDATE CURSO SET TL_CURSO = @TL_CURSO, DS_CURSO = @DS_CURSO, OBJ_CURSO = @OBJ_CURSO, TOPICOS_CURSO = @TOPICOS_CURSO, PRE_REQ_CURSO = @PRE_REQ_CURSO, DURACAO_CURSO = @DURACAO_CURSO ";
            comandoSql += "WHERE ID_CURSO = @ID_CURSO;";

            try
            {
                using (NpgsqlConnection conexao = ConnectionFactory.createConnection())
                {
                    NpgsqlCommand cmd = new NpgsqlCommand(comandoSql, conexao);
                    NpgsqlParameter[] parametros = new NpgsqlParameter[7];

                    // título
                    parametros[0].ParameterName = "@TL_CURSO";
                    parametros[0].NpgsqlDbType = NpgsqlDbType.Varchar;

                    if (curso.Tl_curso == "")
                    {
                        parametros[0].Value = DBNull.Value;
                    }
                    else
                    {
                        parametros[0].Value = curso.Tl_curso;
                    }
                    cmd.Parameters.Add(parametros[0]);

                    // descrição
                    parametros[1].ParameterName = "@DS_CURSO";
                    parametros[1].NpgsqlDbType = NpgsqlDbType.Varchar;

                    if (curso.Ds_curso == "")
                    {
                        parametros[1].Value = DBNull.Value;
                    }
                    else
                    {
                        parametros[1].Value = curso.Ds_curso;
                    }
                    cmd.Parameters.Add(parametros[1]);

                    // objetivo
                    parametros[2].ParameterName = "@OBJ_CURSO";
                    parametros[2].NpgsqlDbType = NpgsqlDbType.Varchar;

                    if (curso.Obj_curso == "")
                    {
                        parametros[2].Value = DBNull.Value;
                    }
                    else
                    {
                        parametros[2].Value = curso.Obj_curso;
                    }
                    cmd.Parameters.Add(parametros[2]);

                    // Tópicos
                    parametros[3].ParameterName = "@TOPICOS_CURSO";
                    parametros[3].NpgsqlDbType = NpgsqlDbType.Varchar;

                    if (curso.Topicos_curso == "")
                    {
                        parametros[3].Value = DBNull.Value;
                    }
                    else
                    {
                        parametros[3].Value = curso.Topicos_curso;
                    }
                    cmd.Parameters.Add(parametros[3]);

                    // Pré-requisitos
                    parametros[4].ParameterName = "@PRE_REQ_CURSO";
                    parametros[4].NpgsqlDbType = NpgsqlDbType.Varchar;

                    if (curso.Pre_req_curso == "")
                    {
                        parametros[4].Value = DBNull.Value;
                    }
                    else
                    {
                        parametros[4].Value = curso.Pre_req_curso;
                    }
                    cmd.Parameters.Add(parametros[4]);

                    // Duração
                    parametros[5].ParameterName = "@DURACAO_CURSO";
                    parametros[5].NpgsqlDbType = NpgsqlDbType.Varchar;

                    if (curso.Duracao_curso == "")
                    {
                        parametros[5].Value = DBNull.Value;
                    }
                    else
                    {
                        parametros[5].Value = curso.Duracao_curso;
                    }
                    cmd.Parameters.Add(parametros[5]);

                    // para update id_curso é parâmetro obrigatório
                    parametros[6].ParameterName = "@ID_CURSO";
                    parametros[6].NpgsqlDbType = NpgsqlDbType.Integer;
                    parametros[6].Value = curso.Id_curso;
                    cmd.Parameters.Add(parametros[6]);

                    // executa a instrução SQL
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

        public int excluir(int id_curso)
        {
            int linhas_afetadas = 0;

            // DROP CASCADED
            string comandoSql = "DELETE FROM USUARIO_CURSO WHERE ID_CURSO = @ID_CURSO; ";
            comandoSql += "DELETE FROM AULA WHERE ID_CURSO = @ID_CURSO; ";
            comandoSql += "DELETE FROM QUESTAO WHERE ID_CURSO = @ID_CURSO; ";
            comandoSql += "DELETE FROM CURSO WHERE ID_CURSO = @ID_CURSO;";

            try
            {
                using (NpgsqlConnection conexao = ConnectionFactory.createConnection())
                {
                    NpgsqlCommand cmd = new NpgsqlCommand(comandoSql, conexao);
                    NpgsqlParameter[] parametros = new NpgsqlParameter[3];

                    parametros[0].ParameterName = "@ID_CURSO";
                    parametros[0].NpgsqlDbType = NpgsqlDbType.Integer;
                    parametros[0].Value = id_curso;
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

        public Curso carregar(NpgsqlDataReader data_reader)
        {
            Curso curso = new Curso();
            curso.Id_curso = data_reader.IsDBNull(data_reader.GetOrdinal("ID_CURSO")) ? 0 : data_reader.GetInt32(data_reader.GetOrdinal("ID_CURSO"));
            curso.Tl_curso = data_reader.IsDBNull(data_reader.GetOrdinal("TL_CURSO")) ? "" : data_reader.GetString(data_reader.GetOrdinal("TL_CURSO"));
            curso.Ds_curso = data_reader.IsDBNull(data_reader.GetOrdinal("DS_CURSO")) ? "" : data_reader.GetString(data_reader.GetOrdinal("DS_CURSO"));
            curso.Obj_curso = data_reader.IsDBNull(data_reader.GetOrdinal("OBJ_CURSO")) ? "" : data_reader.GetString(data_reader.GetOrdinal("OBJ_CURSO"));
            curso.Topicos_curso = data_reader.IsDBNull(data_reader.GetOrdinal("TOPICOS_CURSO")) ? "" : data_reader.GetString(data_reader.GetOrdinal("TOPICOS_CURSO"));
            curso.Pre_req_curso = data_reader.IsDBNull(data_reader.GetOrdinal("PRE_REQ_CURSO")) ? "" : data_reader.GetString(data_reader.GetOrdinal("PRE_REQ_CURSO"));
            curso.Duracao_curso = data_reader.IsDBNull(data_reader.GetOrdinal("DURACAO_CURSO")) ? "" : data_reader.GetString(data_reader.GetOrdinal("DURACAO_CURSO"));
            curso.Dt_cadastro = data_reader.IsDBNull(data_reader.GetOrdinal("DT_CADASTRO")) ? DateTime.MinValue : data_reader.GetDateTime(data_reader.GetOrdinal("DT_CADASTRO"));
            return curso;
        }
        public Curso carregarCursoXAluno(NpgsqlDataReader data_reader)
        {
            Curso curso = new Curso();
            curso.Tl_curso = data_reader.IsDBNull(data_reader.GetOrdinal("TL_CURSO")) ? "" : data_reader.GetString(data_reader.GetOrdinal("TL_CURSO"));
            curso.Ds_curso = data_reader.IsDBNull(data_reader.GetOrdinal("DS_CURSO")) ? "" : data_reader.GetString(data_reader.GetOrdinal("DS_CURSO"));
            curso.Duracao_curso = data_reader.IsDBNull(data_reader.GetOrdinal("DUR_CURSO")) ? "" : data_reader.GetString(data_reader.GetOrdinal("DUR_CURSO"));
            curso.Dt_cadastro = data_reader.IsDBNull(data_reader.GetOrdinal("DT_CADASTRO")) ? DateTime.MinValue : data_reader.GetDateTime(data_reader.GetOrdinal("DT_CADASTRO"));
            return curso;
        }
    }
}
