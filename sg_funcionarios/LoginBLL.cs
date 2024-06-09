using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sg_funcionarios
{
    static class LoginBLL
    {
        public static void validarLogin(Usuario usuario)
        {
            Erro.setErro(false);

            if (usuario.getNome().Equals("") || usuario.getNome() == null)
            {
                Erro.setMsgErro("Nome de usuario é de preenchimento obrigatório. ");
                return;
            }

            if (usuario.getSenha().Equals("") || usuario.getSenha() == null)
            {
                Erro.setMsgErro("Senha é de preenchimento obrigatório. ");
                return;
            }
        }

        public static bool usuarioExiste(Usuario usuario)
        {
            return LoginDAL.usuarioExiste(usuario);
        }
    }
}
