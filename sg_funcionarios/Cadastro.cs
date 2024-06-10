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
    public partial class Cadastro : Form
    {
        Thread th;
        Usuario usuario = new Usuario();

        public Cadastro()
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

        private void btnCriarConta_Click(object sender, EventArgs e)
        {
            String nomeUsuario = tbNomeUsuario.Text;
            String senha = tbSenha.Text;
            String confSenha = tbConfSenha.Text;

            if (senha != confSenha)
            {
                MessageBox.Show("Senhas precisam ter o mesmo valor. ");
                return;
            }

            usuario.setNome(nomeUsuario);
            usuario.setSenha(senha);

            CadastroBLL.validarCadastro(usuario);

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
            Application.Run(new Login());
        }
    }
}
