using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sg_funcionarios.DAL
{
    static class FuncionarioEditDAL
    {
        public static void editarFuncionario(Funcionario funcionario)
        {
            String strConexao = ConfigurationManager.ConnectionStrings["strConexao"].ConnectionString;

            using (var conn = new SqlConnection(strConexao))
            {
                try
                {
                    conn.Open();
                }
                catch (SqlException ex)
                {
                    Erro.setMsgErro("Erro ao abrir porta de conexão. " + ex.Message);
                    return;
                }
                catch (Exception ex)
                {
                    Erro.setMsgErro("Um erro inesperado aconteceu ao tentar abrir a porta de conexão. " + ex.Message);
                    return;
                }

                String query = "UPDATE Funcionario SET " +
                    "nm_funcionario = @nome, " +
                    "dt_nascimento = @dataNasc, " +
                    "sg_genero = @genero, " +
                    "ds_telefone = @telefone, " +
                    "nm_cargo = @cargo, " +
                    "vl_salario = @salario " +
                    "WHERE cd_funcionario = @cd_funcionario";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nome",           funcionario.getNome());
                    cmd.Parameters.AddWithValue("@dataNasc",       Convert.ToDateTime(funcionario.getDataNascimento()).ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@genero",         funcionario.getGenero());
                    cmd.Parameters.AddWithValue("@telefone",       funcionario.getTelefone());
                    cmd.Parameters.AddWithValue("@cargo",          funcionario.getCargo());
                    cmd.Parameters.AddWithValue("@salario",        Convert.ToDecimal(funcionario.getSalario()));
                    cmd.Parameters.AddWithValue("@cd_funcionario", funcionario.getCodigo());

                    try
                    {
                        int linhasAfetadas = cmd.ExecuteNonQuery();

                        if (linhasAfetadas == 0)
                        {
                            Erro.setMsgErro("Usuário com código digitado não existe. ");
                            return;
                        }
                    }
                    catch (SqlException ex)
                    {
                        Erro.setMsgErro("Erro ao tentar editar o funcionário no banco de dados. " + ex.Message);
                        return;
                    }
                    catch (Exception ex)
                    {
                        Erro.setMsgErro("Um erro inesperado aconteceu ao tentar editar o funcionário no banco de dados. " + ex.Message);
                        return;
                    }
                }
            }
        }
    }
}
