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
    static class FuncionarioRemoveDAL
    {
        public static void removerFuncionario(int codigoFuncionario)
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

                String query = "DELETE Funcionario " +
                               "WHERE cd_funcionario = @cd_funcionario";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@cd_funcionario", codigoFuncionario);

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        Erro.setMsgErro("Erro ao tentar remover o funcionário no banco de dados. " + ex.Message);
                        return;
                    }
                    catch (Exception ex)
                    {
                        Erro.setMsgErro("Um erro inesperado aconteceu ao tentar remover o funcionário no banco de dados. " + ex.Message);
                        return;
                    }
                }
            }
        }
    }
}
