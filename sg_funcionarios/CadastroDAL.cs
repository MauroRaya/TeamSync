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
    static class CadastroDAL
    {
        private static SqlCommand cmd;

        public static void criarUsuario(Usuario usuario)
        {
            SqlConnection conn = DAL.getConexao();

            if (conn == null)
            {
                Erro.setMsgErro("Conexão não foi definida ou está com problema. ");
                return;
            }

            string query = "INSERT INTO Usuario (nm_usuario, ds_senha) VALUES (@Nome, @Senha)";

            cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Nome", usuario.getNome());
            cmd.Parameters.AddWithValue("@Senha", usuario.getSenha());

            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }

                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Erro.setMsgErro("Erro ao tentar inserir o usuario no banco de dados. " + e);
                return;
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
    }
}
