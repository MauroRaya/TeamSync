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
    static class DAL
    {
        private static string diretorioBase = AppDomain.CurrentDomain.BaseDirectory;
        private static string pathArquivoDb = Path.Combine(diretorioBase, "EmpregadosDB.mdf");
        private static string strConexao = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={pathArquivoDb};Integrated Security=True;Connect Timeout=30";
        private static SqlConnection conn;

        public static void conectar()
        {
            try
            {
                conn = new SqlConnection(strConexao);
                conn.Open();
            }
            catch (Exception e)
            {
                Erro.setMsgErro("Erro ao tentar conectar ao banco de dados. " + e);
            }
        }

        public static void desconectar()
        {
            try
            {
                conn.Close();
            }
            catch (Exception e)
            {
                Erro.setMsgErro("Erro ao tentar desconectar o banco de dados. " + e);
            }
        }

        public static SqlConnection getConexao()
        {
            if (conn == null)
            {
                conectar();
            }

            return conn;
        }
    }
}
