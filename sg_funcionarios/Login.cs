using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sg_funcionarios
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            Load += Form_Load;
            FormClosed += Form_Closed;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            DAL.conectar();
        }
        private void Form_Closed(object sender, EventArgs e)
        {
            DAL.desconectar();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

        }

        private void btnCadastro_Click(object sender, EventArgs e)
        {

        }
    }
}