using sg_funcionarios.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sg_funcionarios
{
    static class LoginDAL
    {
        public static bool usuarioExiste(Login login)
        {
            String strConexao = ConfigurationManager.ConnectionStrings["strConexao"].ConnectionString;

            using (var conn = new SqlConnection(strConexao))
            {
                if (conn == null)
                {
                    Erro.setMsgErro("Conexão não foi definida ou está com problema. ");
                    return false;
                }

                try
                {
                    conn.Open();
                }
                catch (SqlException ex)
                {
                    Erro.setMsgErro("Erro ao abrir porta de conexão. " + ex.Message);
                    return false;
                }
                catch (Exception ex)
                {
                    Erro.setMsgErro("Um erro inesperado aconteceu ao tentar abrir a porta de conexão. " + ex.Message);
                    return false;
                }

                String query = "SELECT nm_usuario, ds_senha FROM Usuario WHERE nm_usuario = @nome AND ds_senha = @senha";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nome", login.getNome());
                    cmd.Parameters.AddWithValue("@senha", login.getSenha());

                    object result = null;

                    try
                    {
                        result = cmd.ExecuteScalar();
                    }
                    catch (SqlException ex)
                    {
                        Erro.setMsgErro("Erro ao tentar consultar o usuario no banco de dados. " + ex.Message);
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Erro.setMsgErro("Um erro inesperado aconteceu ao tentar consultar o usuario. " + ex.Message);
                        return false;
                    }

                    return result != null;
                }
            }
        }
    }
}
