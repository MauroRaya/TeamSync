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
    public partial class Login : Form
    {
        Thread th;
        Usuario usuario = new Usuario();

        public Login()
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

            usuario.setNome(nomeUsuario);
            usuario.setSenha(senha);

            LoginBLL.validarLogin(usuario);

            if (Erro.getErro())
            {
                MessageBox.Show(Erro.getMsgErro());
                return;
            }

            if (!LoginBLL.usuarioExiste(usuario))
            {
                MessageBox.Show("Usuario inválido. Tente novamente ou crie uma conta.");
                return;
            }

            MessageBox.Show("Usuario autenticado com sucesso!");
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
            Application.Run(new Cadastro());
        }

    }
}