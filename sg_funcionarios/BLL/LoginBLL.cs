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
            if (usuario.getNome().Length > 15)
            {
                Erro.setMsgErro("Nome de usuario não pode ultrapassar 15 caracteres. ");
                return;
            }

            if (String.IsNullOrEmpty(usuario.getSenha()))
            {
                Erro.setMsgErro("Senha é de preenchimento obrigatório. ");
                return;
            }
            if (usuario.getSenha().Length > 15)
            {
                Erro.setMsgErro("Senha não pode ultrapassar 15 caracteres. ");
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
