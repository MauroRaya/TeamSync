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
        Usuario usuario = new Usuario();

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
            String senha       = tbSenha.Text;
            String confSenha   = tbConfSenha.Text;

            usuario.setNome(nomeUsuario);

            CadastroBLL.validarCampos(usuario, senha, confSenha); //caso validação bem sucedida, já cria no banco

            if (Erro.getErro())
            {
                MessageBox.Show(Erro.getMsgErro(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Usuario criado com sucesso. ");

            btnIrLogin_Click(this, EventArgs.Empty);
        }

        private void btnIrLogin_Click(object sender, EventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            formLogin.Show();
            this.Hide();
        }
    }
}
