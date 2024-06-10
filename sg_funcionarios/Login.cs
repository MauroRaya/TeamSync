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

        public Login()
        {
            InitializeComponent();
            Load += Form_Load;
            FormClosed += Form_Closed;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            if (BLL.getConexao() == null)
            {
                BLL.conectar();
            }
        }
        private void Form_Closed(object sender, EventArgs e)
        {
            if (BLL.getConexao() != null)
            {
                BLL.desconectar();
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            String nomeUsuario = tbNomeUsuario.Text;
            String senha = tbSenha.Text;

            Usuario usuario = new Usuario(nomeUsuario, senha);

            LoginBLL.validarLogin(usuario);

            if (Erro.getErro())
            {
                MessageBox.Show(Erro.getMsgErro());
                return;
            }

            if (!LoginBLL.usuarioExiste(usuario))
            {
                MessageBox.Show("Usuario inválido. Crie uma conta ou tente novamente.");
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