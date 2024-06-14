using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sg_funcionarios.ViewModels
{
    class LoginVM
    {
        private String nome;
        private String senha;

        public String getNome() { return nome; }
        public String getSenha() { return senha; }

        public void setNome(String _nome) { nome = _nome; }
        public void setSenha(String _senha) { senha = _senha; }
    }
}
