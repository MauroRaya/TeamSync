using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sg_funcionarios.ViewModels
{
    class Cadastro
    {
        private String nome;
        private String senha;
        private String confSenha;

        public String getNome() { return nome; }
        public String getSenha() { return senha; }
        public String getConfSenha() { return confSenha; }

        public void setNome(String _nome) { nome = _nome; }
        public void setSenha(String _senha) { senha = _senha; }
        public void setConfSenha(String _confSenha) { confSenha = _confSenha; }
    }
}
