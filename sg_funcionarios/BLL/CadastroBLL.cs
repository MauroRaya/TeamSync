using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sg_funcionarios
{
    static class CadastroBLL
    {
        public static void validarCampos(Usuario usuario, String confSenha)
        {
            Erro.setErro(false);

            if (String.IsNullOrEmpty(usuario.getNome()))
            {
                Erro.setMsgErro("Nome de usuario é de preenchimento obrigatório. ");
                return;
            }
            if (usuario.getNome().Length > 15)
            {
                Erro.setMsgErro("Nome de usuário não pode ultrapassar 15 caracteres. ");
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

            if (usuario.getSenha() != confSenha)
            {
                Erro.setMsgErro("Senhas precisam ter o mesmo valor. ");
                return;
            }

            CadastroDAL.criarUsuario(usuario);
        }
    }
}
