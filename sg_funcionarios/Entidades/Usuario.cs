using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sg_funcionarios
{
    static class Usuario
    {
        private static int codigo;
        private static String nome;
        private static String senha;

        public static int getCodigo() { return codigo; }
        public static String getNome() { return nome; }
        public static String getSenha() { return senha; }

        public static void setCodigo(int _codigo) { codigo = _codigo; }
        public static void setNome(String _nome) { nome = _nome; }
        public static void setSenha(String _senha) { senha = _senha; }
    }
}
