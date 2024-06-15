using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sg_funcionarios.DAL
{
    static class FuncionarioAddDAL
    {
        public static void criarFuncionario(Funcionario funcionario)
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

                String query = "INSERT INTO Funcionario " +
                               "VALUES (@nome, @dataNasc, @genero, @telefone, @cargo, @salario, @cd_usuario)";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nome",       funcionario.getNome());
                    cmd.Parameters.AddWithValue("@dataNasc",   Convert.ToDateTime(funcionario.getDataNascimento()).ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@genero",     funcionario.getGenero());
                    cmd.Parameters.AddWithValue("@telefone",   funcionario.getTelefone());
                    cmd.Parameters.AddWithValue("@cargo",      funcionario.getCargo());
                    cmd.Parameters.AddWithValue("@salario",    Convert.ToDecimal(funcionario.getSalario()));
                    cmd.Parameters.AddWithValue("@cd_usuario", Usuario.codigo);

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        Erro.setMsgErro("Erro ao tentar inserir o funcionário no banco de dados. " + ex.Message);
                        return;
                    }
                    catch (Exception ex)
                    {
                        Erro.setMsgErro("Um erro inesperado aconteceu ao tentar inserir o funcionário no banco de dados. " + ex.Message);
                        return;
                    }
                }
            }
        }
    }
}
