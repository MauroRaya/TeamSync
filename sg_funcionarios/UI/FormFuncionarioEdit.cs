using sg_funcionarios.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sg_funcionarios.UI
{
    public partial class FormFuncionarioEdit : Form
    {
        Thread th;
        Funcionario funcAdd = new Funcionario();

        public FormFuncionarioEdit()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();

            th = new Thread(abrirFormFuncionarios);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void abrirFormFuncionarios(object obj)
        {
            Application.Run(new FormFuncionarios());
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            String nome = tbNome.Text;
            String dataNascimento = dtpDataNascimento.Value.ToString("dd/MM/yyyy");
            char genero = rbMasculino.Checked ? 'M' : 'F';
            String telefone = tbTelefone.Text;
            String cargo = tbCargo.Text;
            String salario = tbSalario.Text;

            funcAdd.setNome(nome);
            funcAdd.setDataNascimento(dataNascimento);
            funcAdd.setGenero(genero);
            funcAdd.setTelefone(telefone);
            funcAdd.setCargo(cargo);
            funcAdd.setSalario(salario);

            FuncionarioAddBLL.validarCampos(funcAdd);

            if (Erro.getErro())
            {
                MessageBox.Show(Erro.getMsgErro());
                return;
            }


        }
    }
}
