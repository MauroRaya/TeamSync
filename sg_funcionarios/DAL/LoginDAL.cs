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
        public static bool usuarioExiste(Usuario usuario)
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
                catch (Exception e)
                {
                    Erro.setMsgErro("Erro ao abrir porta de conexão. " + e.Message);
                    return false;
                }

                String query = "SELECT nm_usuario, ds_senha FROM Usuario WHERE nm_usuario = @nome AND ds_senha = @senha";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nome", usuario.getNome());
                    cmd.Parameters.AddWithValue("@senha", usuario.getSenha());

                    object result = null;

                    try
                    {
                        result = cmd.ExecuteScalar();
                    }
                    catch (Exception e)
                    {
                        Erro.setMsgErro("Erro ao tentar inserir o usuario no banco de dados. " + e);
                        return false;
                    }

                    return result != null;
                }
            }
        }
    }
}
