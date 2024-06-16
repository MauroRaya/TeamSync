using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sg_funcionarios
{
    class Usuario
    {
        public static int codigo;
        private String nome;
        private String hash;
        private String salt;

        public int getCodigo() { return codigo; }
        public String getNome() { return nome; }
        public String getHash() { return hash; }
        public String getSalt() { return salt; }

        public void setCodigo(int _codigo) { codigo = _codigo; }
        public void setNome(String _nome) { nome = _nome; }
        public void setHash(String _hash) { hash = _hash; }
        public void setSalt(String _salt) { salt = _salt; }
    }
}
