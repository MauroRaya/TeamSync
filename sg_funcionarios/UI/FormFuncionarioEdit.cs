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
        public Funcionario camposFuncionario { get; set; }
        Funcionario funcionario = new Funcionario();

        public FormFuncionarioEdit()
        {
            InitializeComponent();
            Load += loadCamposFuncionario;

            camposFuncionario = new Funcionario();
        }

        private void loadCamposFuncionario(object sender, EventArgs e)
        {
            tbNome.Text             = camposFuncionario.getNome();
            dtpDataNascimento.Value = Convert.ToDateTime(camposFuncionario.getDataNascimento());
            tbTelefone.Text         = camposFuncionario.getTelefone();
            tbCargo.Text            = camposFuncionario.getCargo();
            tbSalario.Text          = camposFuncionario.getSalario();
            
            if (camposFuncionario.getGenero() == "M")
            {
                rbMasculino.Checked = true;
            }
            else
            {
                rbFeminino.Checked = true;
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            FormFuncionario formFuncionario = new FormFuncionario();
            formFuncionario.Show();
            this.Hide();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            String codigo         = camposFuncionario.getCodigo();
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
                MessageBox.Show(Erro.getMsgErro(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Informações do funcionário foram editadas com sucesso.", 
                            "Editar funcionário",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);


            btnSair_Click(this, EventArgs.Empty); //voltar para form funcionarios se bem sucedido
        }
    }
}
