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
            String dataNascimento = dtpDataNascimento.Value.ToString();
            char genero;
            String telefone = tbTelefone.Text;
            String cargo = tbCargo.Text;
            String salario = tbSalario.Text;

            if (rbMasculino.Checked)
            {
                genero = 'M';
            }
            else
            {
                genero = 'F';
            }

            funcionario.setNome(nome);
            funcionario.setDataNascimento(dataNascimento);
            funcionario.setGenero(genero);
            funcionario.setTelefone(telefone);
            funcionario.setCargo(cargo);
            funcionario.setSalario(salario);

            dgvFuncionario.Rows.Add(
                funcionario.getNome(),
                funcionario.getDataNascimento(),
                funcionario.getGenero(),
                funcionario.getTelefone(),
                funcionario.getCargo(),
                funcionario.getSalario()
            );
        }
    }
}
