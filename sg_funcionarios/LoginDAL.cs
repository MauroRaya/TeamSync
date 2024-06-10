using System;
using System.Collections.Generic;
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
        private static SqlCommand cmd;
        private static SqlDataReader reader;

        public static bool usuarioExiste(Usuario usuario)
        {
            SqlConnection conn = DAL.getConexao();

            if (conn == null)
            {
                Erro.setMsgErro("Conexão não foi definida ou está com problema. ");
                return false;
            }

            string query = "SELECT nm_usuario, ds_senha FROM Usuario WHERE nm_usuario = @nome AND ds_senha = @senha";

            cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@nome", usuario.getNome());
            cmd.Parameters.AddWithValue("@senha", usuario.getSenha());

            object result = null;

            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }

                result = cmd.ExecuteScalar();
            }
            catch (Exception e)
            {
                Erro.setMsgErro("Erro ao tentar consultar e autenticar usuario. ");
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            return result != null;
        }
    }
}
