using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sg_funcionarios
{
    static class CadastroBLL
    {
        public static void validarCadastro(Usuario usuario)
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

            CadastroDAL.criarUsuario(usuario);
        }
    }
}
