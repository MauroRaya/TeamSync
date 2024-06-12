using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sg_funcionarios
{
    public class Usuario
    {
        private int codigo;
        private String nome;
        private String senha;

        public int getCodigo() { return codigo; }
        public String getNome() { return nome; }
        public String getSenha() { return senha; }

        public void setCodigo(int _codigo) { codigo = _codigo; }
        public void setNome(String _nome) { nome = _nome; }
        public void setSenha(String _senha) { senha = _senha; }
    }
}
