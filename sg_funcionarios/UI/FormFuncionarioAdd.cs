using sg_funcionarios.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sg_funcionarios.UI
{
    public partial class FormFuncionarioAdd : Form
    {
        Funcionario funcionario = new Funcionario();

        public FormFuncionarioAdd()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            FormFuncionario formFuncionario = new FormFuncionario();
            formFuncionario.Show();
            this.Hide();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            String nome           = tbNome.Text;
            String dataNascimento = dtpDataNascimento.Value.ToString("dd/MM/yyyy");
            String genero         = rbMasculino.Checked ? "M" : "F";
            String telefone       = tbTelefone.Text;
            String cargo          = tbCargo.Text;
            String salario        = tbSalario.Text;

            funcionario.setNome(nome);
            funcionario.setDataNascimento(dataNascimento);
            funcionario.setGenero(genero);
            funcionario.setTelefone(telefone);
            funcionario.setCargo(cargo);
            funcionario.setSalario(salario);

            FuncionarioAddBLL.validarCampos(funcionario); //se validar já cria no banco

            if (Erro.getErro())
            {
                MessageBox.Show(Erro.getMsgErro(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Funcionário adicionado com sucesso.",
                            "Adicionar funcionário",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

            btnSair_Click(this, EventArgs.Empty); //voltar para form funcionarios se bem sucedido
        }
    }
}
