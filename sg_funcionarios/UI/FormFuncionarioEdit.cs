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
    public partial class FormFuncionarioEdit : Form
    {
        Funcionario funcionario = new Funcionario();

        public FormFuncionarioEdit()
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
            String codigo         = tbCodigo.Text;
            String nome           = tbNome.Text;
            String dataNascimento = dtpDataNascimento.Value.ToString("dd/MM/yyyy");
            String genero         = rbMasculino.Checked ? "M" : "F";
            String telefone       = tbTelefone.Text;
            String cargo          = tbCargo.Text;
            String salario        = tbSalario.Text;

            funcionario.setCodigo(codigo);
            funcionario.setNome(nome);
            funcionario.setDataNascimento(dataNascimento);
            funcionario.setGenero(genero);
            funcionario.setTelefone(telefone);
            funcionario.setCargo(cargo);
            funcionario.setSalario(salario);

            FuncionarioEditBLL.validarCampos(funcionario); //se validar já edita/update no banco

            if (Erro.getErro())
            {
                MessageBox.Show(Erro.getMsgErro());
                return;
            }

            btnSair_Click(this, EventArgs.Empty); //voltar para form funcionarios se bem sucedido
        }
    }
}
