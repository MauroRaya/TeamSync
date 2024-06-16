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
        //public static bool usuarioExiste(Usuario usuario)
        //{
        //    String strConexao = ConfigurationManager.ConnectionStrings["strConexao"].ConnectionString;

        //    using (var conn = new SqlConnection(strConexao))
        //    {
        //        try
        //        {
        //            conn.Open();
        //        }
        //        catch (SqlException ex)
        //        {
        //            Erro.setMsgErro("Erro ao abrir porta de conexão. " + ex.Message);
        //            return false;
        //        }
        //        catch (Exception ex)
        //        {
        //            Erro.setMsgErro("Um erro inesperado aconteceu ao tentar abrir a porta de conexão. " + ex.Message);
        //            return false;
        //        }

        //        String query = "SELECT nm_usuario, ds_senha " +
        //                       "FROM Usuario " +
        //                       "WHERE nm_usuario = @nome";

        //        using (var cmd = new SqlCommand(query, conn))
        //        {
        //            cmd.Parameters.AddWithValue("@nome", usuario.getNome());

        //            object result = null;

        //            try
        //            {
        //                result = cmd.ExecuteScalar();
        //            }
        //            catch (SqlException ex)
        //            {
        //                Erro.setMsgErro("Erro ao tentar consultar o usuário no banco de dados. " + ex.Message);
        //                return false;
        //            }
        //            catch (Exception ex)
        //            {
        //                Erro.setMsgErro("Um erro inesperado aconteceu ao tentar consultar o usuário. " + ex.Message);
        //                return false;
        //            }

        //            if (result == null)
        //            {
        //                Erro.setMsgErro("Usuário não encontrado. ");
        //                return false;
        //            }

        //            return true;
        //        }
        //    }
        //}

        public static int getCodigoUsuario(Usuario usuario)
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
                    return -1;
                }
                catch (Exception ex)
                {
                    Erro.setMsgErro("Um erro inesperado aconteceu ao tentar abrir a porta de conexão. " + ex.Message);
                    return -1;
                }

                String query = "SELECT cd_usuario FROM Usuario WHERE nm_usuario COLLATE Latin1_General_BIN = @nome";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nome",  usuario.getNome());

                    try
                    {
                        object result = cmd.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int codigoUsuario))
                        {
                            return codigoUsuario;
                        }
                        else
                        {
                            Erro.setMsgErro("Usuário não foi encontrado. ");
                            return -1;
                        }
                    }
                    catch (SqlException ex)
                    {
                        Erro.setMsgErro("Erro ao tentar consultar o usuario no banco de dados. " + ex.Message);
                        return -1;
                    }
                    catch (Exception ex)
                    {
                        Erro.setMsgErro("Um erro inesperado aconteceu ao tentar consultar o usuario. " + ex.Message);
                        return -1;
                    }
                }
            }
        }

        public static String getHash()
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
                    return null;
                }
                catch (Exception ex)
                {
                    Erro.setMsgErro("Um erro inesperado aconteceu ao tentar abrir a porta de conexão. " + ex.Message);
                    return null;
                }

                String query = "SELECT ds_hash FROM Usuario WHERE cd_usuario = @codigoUsuario";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@codigoUsuario", Usuario.codigo);

                    try
                    {
                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            return result.ToString();
                        }
                        else
                        {
                            Erro.setMsgErro("Usuário não foi encontrado. ");
                            return null;
                        }
                    }
                    catch (SqlException ex)
                    {
                        Erro.setMsgErro("Erro ao tentar consultar o usuario no banco de dados. " + ex.Message);
                        return null;
                    }
                    catch (Exception ex)
                    {
                        Erro.setMsgErro("Um erro inesperado aconteceu ao tentar consultar o usuario. " + ex.Message);
                        return null;
                    }
                }
            }
        }

        public static String getSalt()
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
                    return null;
                }
                catch (Exception ex)
                {
                    Erro.setMsgErro("Um erro inesperado aconteceu ao tentar abrir a porta de conexão. " + ex.Message);
                    return null;
                }

                String query = "SELECT ds_salt FROM Usuario WHERE cd_usuario = @codigoUsuario";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@codigoUsuario", Usuario.codigo);

                    try
                    {
                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            return result.ToString();
                        }
                        else
                        {
                            Erro.setMsgErro("Usuário não foi encontrado. ");
                            return null;
                        }
                    }
                    catch (SqlException ex)
                    {
                        Erro.setMsgErro("Erro ao tentar consultar o usuario no banco de dados. " + ex.Message);
                        return null;
                    }
                    catch (Exception ex)
                    {
                        Erro.setMsgErro("Um erro inesperado aconteceu ao tentar consultar o usuario. " + ex.Message);
                        return null;
                    }
                }
            }
        }
    }
}
