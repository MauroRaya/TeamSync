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

            string query = "SELECT * FROM usuario";

            cmd = new SqlCommand(query, conn);
            reader = cmd.ExecuteReader();

            if (reader == null)
            {
                Erro.setMsgErro("Erro ao consultar tabela do usuario. ");
                return false;
            }

            while (reader.Read())
            {
                String nomeUsuarioDB = reader.GetString(1);
                String senhaDB = reader.GetString(2);

                return nomeUsuarioDB == usuario.getNome() && senhaDB == usuario.getSenha();
            }

            return false;
        }
    }
}
