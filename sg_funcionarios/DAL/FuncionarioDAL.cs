using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sg_funcionarios.DAL
{
    static class FuncionarioDAL
    {
        public static List<Funcionario> getFuncionarios()
        {
            String strConexao = ConfigurationManager.ConnectionStrings["strConexao"].ConnectionString;
            List<Funcionario> listaFuncionarios = new List<Funcionario>();
            Funcionario funcionario;

            using (var conn = new SqlConnection(strConexao))
            {
                try
                {
                    conn.Open();
                }
                catch (SqlException ex)
                {
                    Erro.setMsgErro("Erro ao abrir porta de conexão. " + ex.Message);
                    return null;
                }
                catch (Exception ex)
                {
                    Erro.setMsgErro("Um erro inesperado aconteceu ao tentar abrir a porta de conexão. " + ex.Message);
                    return null;
                }

                String query = "SELECT * FROM Funcionario WHERE cd_usuario = @cd_usuario";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@cd_usuario", Usuario.codigo);

                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                funcionario = new Funcionario();

                                funcionario.setCodigo(reader["cd_funcionario"].ToString());
                                funcionario.setNome(reader["nm_funcionario"].ToString());
                                funcionario.setDataNascimento(reader["dt_nascimento"].ToString());
                                funcionario.setGenero(reader["sg_genero"].ToString());
                                funcionario.setTelefone(reader["ds_telefone"].ToString());
                                funcionario.setCargo(reader["nm_cargo"].ToString());
                                funcionario.setSalario(reader["vl_salario"].ToString());

                                listaFuncionarios.Add(funcionario);
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        Erro.setMsgErro("Erro ao tentar consultar o funcionário no banco de dados. " + ex.Message);
                        return null;
                    }
                    catch (Exception ex)
                    {
                        Erro.setMsgErro("Um erro inesperado aconteceu ao tentar consultar o funcionário no banco de dados. " + ex.Message);
                        return null;
                    }
                }
            }
            return listaFuncionarios;
        }
    }
}
