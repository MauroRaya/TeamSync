using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sg_funcionarios
{
    static class Erro
    {
        private static String msgErro;
        private static bool erro;

        public static String getMsgErro()
        {
            return msgErro;
        }
        public static bool getErro()
        {
            return erro;        
        }

        public static void setMsgErro(String _msg)
        {
            msgErro = _msg;
            erro = true;
        }
        public static void setErro(bool _erro)
        {
            erro = _erro;
        }
    }
}
