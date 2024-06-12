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
    static class CadastroDAL
    {
        public static void criarUsuario(Cadastro cadastro)
        {
            String strConexao = ConfigurationManager.ConnectionStrings["strConexao"].ConnectionString;

            using (var conn = new SqlConnection(strConexao))
            {
                if (conn == null)
                {
                    Erro.setMsgErro("Conexão não foi definida ou está com problema. ");
                    return;
                }

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

                String query = "INSERT INTO Usuario (nm_usuario, ds_senha) VALUES (@nome, @senha)";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nome", cadastro.getNome());
                    cmd.Parameters.AddWithValue("@senha", cadastro.getSenha());

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
