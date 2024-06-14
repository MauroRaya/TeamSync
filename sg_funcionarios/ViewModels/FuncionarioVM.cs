using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sg_funcionarios.ViewModels
{
    class FuncionarioVM
    {
        private String nome;
        private String dataNascimento;
        private char genero;
        private String telefone;
        private String cargo;
        private String salario;
        private int codigoUsuario;

        public String getNome() { return nome; }
        public String getDataNascimento() { return dataNascimento; }
        public char getGenero() { return genero; }
        public String getTelefone() { return telefone; }
        public String getCargo() { return cargo; }
        public String getSalario() { return salario; }
        public int getCodigoUsuario() { return codigoUsuario; }

        public void setNome(String _nome) { nome = _nome; }
        public void setDataNascimento(String _dataNascimento) { dataNascimento = _dataNascimento; }
        public void setGenero(char _genero) { genero = _genero; }
        public void setTelefone(String _telefone) { telefone = _telefone; }
        public void setCargo(String _cargo) { cargo = _cargo; }
        public void setSalario(String _salario) { salario = _salario; }
        public void setCodigoUsuario(int _codigoUsuario) { codigoUsuario = _codigoUsuario; }
    }
}
