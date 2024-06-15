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
        Usuario usuario = new Usuario();

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
            String senha       = tbSenha.Text;

            usuario.setNome(nomeUsuario);
            usuario.setSenha(senha);

            LoginBLL.validarCampos(usuario);

            if (Erro.getErro())
            {
                MessageBox.Show(Erro.getMsgErro());
                return;
            }

            if (!LoginBLL.usuarioExiste(usuario))
            {
                MessageBox.Show(Erro.getMsgErro());
                return;
            }

            int codigoUsuario = LoginBLL.getCodigoUsuario(usuario);

            if (codigoUsuario == -1)
            {
                MessageBox.Show(Erro.getMsgErro());
                return;
            }

            Usuario.codigo = codigoUsuario;

            MessageBox.Show("Usuario autenticado com sucesso!");

            irFuncionarios();
        }

        private void btnIrCadastro_Click(object sender, EventArgs e)
        {
            FormCadastro formCadastro = new FormCadastro();
            formCadastro.Show();
            this.Hide();
        }

        private void irFuncionarios()
        {
            FormFuncionario formFuncionario = new FormFuncionario();
            formFuncionario.Show();
            this.Hide();
        }

        private void cbMostrarSenha_CheckedChanged(object sender, EventArgs e)
        {
            tbSenha.PasswordChar = cbMostrarSenha.Checked ? '\0' : '*';
        }
    }
}