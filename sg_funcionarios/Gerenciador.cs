using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sg_funcionarios
{
    public partial class Gerenciador : Form
    {
        Funcionario funcionario = new Funcionario();
        LinhaFuncionario linhaFuncionario;

        public Gerenciador()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            String nome = tbNome.Text;
            String dataNascimento = dtpDataNascimento.Value.ToString("dd/MM/yyyy");
            char genero = rbMasculino.Checked ? 'M' : 'F';
            String telefone = tbTelefone.Text;
            String cargo = tbCargo.Text;
            String salario = tbSalario.Text;

            funcionario.setNome(nome);
            funcionario.setDataNascimento(dataNascimento);
            funcionario.setGenero(genero);
            funcionario.setTelefone(telefone);
            funcionario.setCargo(cargo);
            funcionario.setSalario(salario);

            LinhaFuncionario linhaFuncionario = new LinhaFuncionario();
            linhaFuncionario.setFuncionario(funcionario);

            linhaFuncionario.Location = new Point(280, 135 + (linhaFuncionario.Height * (this.Controls.OfType<LinhaFuncionario>().Count())));
            this.Controls.Add(linhaFuncionario);
        }
    }
}
