using sg_funcionarios.ViewModels;
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

namespace sg_funcionarios
{
    public partial class FormCadastro : Form
    {
        Thread th;
        Cadastro cadastro = new Cadastro();

        public FormCadastro()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCriarConta_Click(object sender, EventArgs e)
        {
            String nomeUsuario = tbNomeUsuario.Text;
            String senha = tbSenha.Text;
            String confSenha = tbConfSenha.Text;

            cadastro.setNome(nomeUsuario);
            cadastro.setSenha(senha);

            CadastroBLL.validarCampos(cadastro); //caso validação bem sucedida, já cria no banco

            if (Erro.getErro())
            {
                MessageBox.Show(Erro.getMsgErro());
                return;
            }

            MessageBox.Show("Usuario criado com sucesso. ");
        }

        private void btnIrLogin_Click(object sender, EventArgs e)
        {
            this.Close();

            th = new Thread(abrirFormLogin);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void abrirFormLogin(object obj)
        {
            Application.Run(new FormLogin());
        }
    }
}
