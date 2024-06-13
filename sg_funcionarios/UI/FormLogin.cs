using sg_funcionarios.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sg_funcionarios
{
    public partial class FormLogin : Form
    {
        Thread th;
        Login login = new Login();

        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            String nomeUsuario = tbNomeUsuario.Text;
            String senha = tbSenha.Text;

            login.setNome(nomeUsuario);
            login.setSenha(senha);

            LoginBLL.validarCampos(login);

            if (Erro.getErro())
            {
                MessageBox.Show(Erro.getMsgErro());
                return;
            }

            if (!LoginBLL.usuarioExiste(login))
            {
                MessageBox.Show("Usuario inválido. Tente novamente ou crie uma conta.");
                return;
            }

            int codigoUsuario = LoginBLL.getCodigoUsuario(login);

            if (codigoUsuario == -1)
            {
                MessageBox.Show(Erro.getMsgErro());
                return;
            }

            Usuario.setCodigo(codigoUsuario);
            Usuario.setNome(login.getNome());
            Usuario.setSenha(login.getSenha());

            MessageBox.Show("Usuario autenticado com sucesso!");

            irFuncionarios(this, EventArgs.Empty);
        }

        private void btnIrCadastro_Click(object sender, EventArgs e)
        {
            this.Close();

            th = new Thread(abrirFormCadastro);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void abrirFormCadastro(object obj)
        {
            Application.Run(new FormCadastro());
        }

        private void irFuncionarios(object sender, EventArgs e)
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
    }
}