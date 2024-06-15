using sg_funcionarios.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sg_funcionarios.BLL
{
    static class FuncionarioBLL
    {
        public static List<Funcionario> getFuncionarios()
        {
            return FuncionarioDAL.getFuncionarios();
        }
    }
}
