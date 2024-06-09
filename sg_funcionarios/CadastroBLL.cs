using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sg_funcionarios
{
    static class CadastroBLL
    {
        public static void validarCadastro(String nomeUsuario, String senha, String confSenha)
        {
            Erro.setErro(false);

            if (nomeUsuario.Equals("") || nomeUsuario == null)
            {
                Erro.setMsgErro("Nome de usuario é de preenchimento obrigatório. ");
                return;
            }

            if (senha.Equals("") || senha == null)
            {
                Erro.setMsgErro("Senha é de preenchimento obrigatório. ");
                return;
            }

            if (confSenha.Equals("") || confSenha == null)
            {
                Erro.setMsgErro("Confirmar senha é de preenchimento obrigatório. ");
                return;
            }

            if (senha != confSenha)
            {
                Erro.setMsgErro("Senhas precisam ter o mesmo valor. ");
                return;
            }

            Usuario usuario = new Usuario();
            usuario.setNome(nomeUsuario);
            usuario.setSenha(senha);

            CadastroDAL.criarUsuario(usuario);
        }
    }
}
