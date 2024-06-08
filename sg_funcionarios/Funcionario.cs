using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sg_funcionarios
{
    class Funcionario
    {
        private int codigo;
        private string nome;
        private DateTime dataNascimento;
        private string genero;
        private string telefone;
        private string cargo;
        private decimal salario;
        private int codigoUsuario;

        public int getCodigo()
        {
            return codigo;
        }
        public string getNome()
        {
            return nome;
        }
        public DateTime getDataNascimento()
        {
            return dataNascimento;
        }
        public string getGenero()
        {
            return genero;
        }
        public string getTelefone()
        {
            return telefone;
        }
        public string getCargo()
        {
            return cargo;
        }
        public decimal getSalario()
        {
            return salario;
        }
        public int getCodigoUsuario()
        {
            return codigoUsuario;
        }

        public void setCodigo(int _codigo)
        {
            codigo = _codigo;
        }
        public void setNome(string _nome)
        {
            nome = _nome;
        }
        public void setDataNascimento(DateTime _dataNascimento)
        {
            dataNascimento = _dataNascimento;
        }
        public void setGenero(string _genero)
        {
            genero = _genero;
        }
        public void setTelefone(string _telefone)
        {
            telefone = _telefone;
        }
        public void setCargo(string _cargo)
        {
            cargo = _cargo;
        }
        public void setSalario(decimal _salario)
        {
            salario = _salario;
        }
        public void setCodigoUsuario(int _codigoUsuario)
        {
            codigoUsuario = _codigoUsuario;
        }
    }
}
