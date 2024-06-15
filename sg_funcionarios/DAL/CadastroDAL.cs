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
    static class CadastroDAL
    {
        public static void criarUsuario(Usuario usuario)
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

                String query = "INSERT INTO Usuario " +
                               "VALUES (@nome, @senha)";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nome",  usuario.getNome());
                    cmd.Parameters.AddWithValue("@senha", usuario.getSenha());

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        Erro.setMsgErro("Erro ao tentar inserir o usuario no banco de dados. " + ex.Message);
                        return;
                    }
                    catch (Exception ex)
                    {
                        Erro.setMsgErro("Um erro inesperado aconteceu ao tentar inserir o usuario no banco de dados. " + ex.Message);
                        return;
                    }
                }
            }
        }
    }
}
