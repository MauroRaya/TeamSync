using sg_funcionarios.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sg_funcionarios
{
    static class LoginBLL
    {
        public static void validarCampos(Login login)
        {
            Erro.setErro(false);

            if (String.IsNullOrEmpty(login.getNome()))
            {
                Erro.setMsgErro("Nome de usuario é de preenchimento obrigatório. ");
                return;
            }

            if (String.IsNullOrEmpty(login.getSenha()))
            {
                Erro.setMsgErro("Senha é de preenchimento obrigatório. ");
                return;
            }
        }

        public static bool usuarioExiste(Login login)
        {
            return LoginDAL.usuarioExiste(login);
        }

        public static int getCodigoUsuario(Login login)
        {
            return LoginDAL.getCodigoUsuario(login);
        }
    }
}
