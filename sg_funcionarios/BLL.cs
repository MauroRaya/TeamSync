using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sg_funcionarios
{
    static class BLL
    {
        public static void conectar()
        {
            DAL.conectar();
        }

        public static void desconectar()
        {
            DAL.desconectar();
        }

        public static SqlConnection getConexao()
        {
            return DAL.getConexao();
        }
    }
}
