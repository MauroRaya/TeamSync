using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sg_funcionarios
{
    static class LoginBLL
    {
        public static void validarCampos(Usuario usuario)
        {
            Erro.setErro(false);

            if (String.IsNullOrEmpty(usuario.getNome()))
            {
                Erro.setMsgErro("Nome de usuario é de preenchimento obrigatório. ");
                return;
            }

            if (String.IsNullOrEmpty(usuario.getSenha()))
            {
                Erro.setMsgErro("Senha é de preenchimento obrigatório. ");
                return;
            }
        }

        public static bool usuarioExiste(Usuario usuario)
        {
            return LoginDAL.usuarioExiste(usuario);
        }

        public static int getCodigoUsuario(Usuario usuario)
        {
            return LoginDAL.getCodigoUsuario(usuario);
        }
    }
}
