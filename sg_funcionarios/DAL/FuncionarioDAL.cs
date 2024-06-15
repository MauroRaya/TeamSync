using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sg_funcionarios.DAL
{
    static class FuncionarioDAL
    {
        public static void criarFuncionario(Funcionario funcionario)
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

                String query = "INSERT INTO Funcionario VALUES (@nome, @dataNasc, @genero, @telefone, @cargo, @salario, @cd_usuario)";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nome",       funcionario.getNome());
                    cmd.Parameters.AddWithValue("@dataNasc",   funcionario.getDataNascimento());
                    cmd.Parameters.AddWithValue("@genero",     funcionario.getGenero());
                    cmd.Parameters.AddWithValue("@telefone",   funcionario.getTelefone());
                    cmd.Parameters.AddWithValue("@cargo",      funcionario.getCargo());
                    cmd.Parameters.AddWithValue("@salario",    funcionario.getSalario());
                    cmd.Parameters.AddWithValue("@cd_usuario", Usuario.codigo);

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        Erro.setMsgErro("Erro ao tentar inserir o funcionário no banco de dados. " + ex.Message);
                        return;
                    }
                    catch (Exception ex)
                    {
                        Erro.setMsgErro("Um erro inesperado aconteceu ao tentar inserir o funcionário no banco de dados. " + ex.Message);
                        return;
                    }
                }
            }
        }

        public static List<Funcionario> getFuncionarios()
        {
            List<Funcionario> listaFuncionarios = new List<Funcionario>();
            Funcionario funcionario;
            String strConexao = ConfigurationManager.ConnectionStrings["strConexao"].ConnectionString;

            using (var conn = new SqlConnection(strConexao))
            {
                if (conn == null)
                {
                    Erro.setMsgErro("Conexão não foi definida ou está com problema. ");
                    return null;
                }

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

                String query = "SELECT nm_funcionario, dt_nascimento, sg_genero, ds_telefone, nm_cargo, vl_salario FROM Funcionario";

                using (var cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                funcionario = new Funcionario();

                                funcionario.setNome(reader["nm_funcionario"].ToString());
                                funcionario.setDataNascimento(reader["dt_nascimento"].ToString());
                                funcionario.setGenero(reader["sg_genero"].ToString()[0]);
                                funcionario.setTelefone(reader["ds_telefone"].ToString());
                                funcionario.setCargo(reader["nm_cargo"].ToString());
                                funcionario.setSalario(reader["vl_salario"].ToString());

                                listaFuncionarios.Add(funcionario);
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        Erro.setMsgErro("Erro ao tentar consultar o funcionário no banco de dados. " + ex.Message);
                        return null;
                    }
                    catch (Exception ex)
                    {
                        Erro.setMsgErro("Um erro inesperado aconteceu ao tentar consultar o funcionário no banco de dados. " + ex.Message);
                        return null;
                    }
                }
            }
            return listaFuncionarios;
        }

        public static void editarFuncionario(Funcionario funcionario)
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

                String query = "UPDATE Funcionario SET " +
                    "(nm_funcionario=@nome, " +
                    "dt_nascimento=@dataNasc, " +
                    "sg_genero=@genero, " +
                    "ds_telefone=@telefone, " +
                    "nm_cargo=@cargo, " +
                    "vl_salario=@salario, " +
                    "cd_usuario=@cd_usuario) " +
                    "WHERE cd_funcionario = @cd_funcionario";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nome", funcionario.getNome());
                    cmd.Parameters.AddWithValue("@dataNasc", Convert.ToDateTime(funcionario.getDataNascimento()));
                    cmd.Parameters.AddWithValue("@genero", funcionario.getGenero());
                    cmd.Parameters.AddWithValue("@telefone", funcionario.getTelefone());
                    cmd.Parameters.AddWithValue("@cargo", funcionario.getCargo());
                    cmd.Parameters.AddWithValue("@salario", funcionario.getSalario());
                    cmd.Parameters.AddWithValue("@cd_usuario", Usuario.codigo);
                    //cmd.Parameters.AddWithValue("@cd_usuario", funcionario.getCodigo());

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        Erro.setMsgErro("Erro ao tentar editar o funcionário no banco de dados. " + ex.Message);
                        return;
                    }
                    catch (Exception ex)
                    {
                        Erro.setMsgErro("Um erro inesperado aconteceu ao tentar editar o funcionário no banco de dados. " + ex.Message);
                        return;
                    }
                }
            }
        }
    }
}
