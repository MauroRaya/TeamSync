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

            CadastroDAL.criarUsuario(usuario);
        }
    }
}
