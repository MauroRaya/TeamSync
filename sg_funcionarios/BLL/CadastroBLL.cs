using sg_funcionarios.ViewModels;
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
        public static void validarCampos(CadastroVM cadastro)
        {
            Erro.setErro(false);

            if (String.IsNullOrEmpty(cadastro.getNome()))
            {
                Erro.setMsgErro("Nome de usuario é de preenchimento obrigatório. ");
                return;
            }

            if (String.IsNullOrEmpty(cadastro.getSenha()))
            {
                Erro.setMsgErro("Senha é de preenchimento obrigatório. ");
                return;
            }

            if (cadastro.getSenha() != cadastro.getConfSenha())
            {
                Erro.setMsgErro("Senhas precisam ter o mesmo valor. ");
                return;
            }

            //desativo por enquanto, por questões de teste
            //CadastroDAL.criarUsuario(cadastro);
        }
    }
}
