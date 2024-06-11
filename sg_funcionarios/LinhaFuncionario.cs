using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sg_funcionarios
{
    public partial class LinhaFuncionario : UserControl
    {
        public LinhaFuncionario()
        {
            InitializeComponent();
        }

        public void setFuncionario(Funcionario funcionario)
        {
            lbNome.Text = funcionario.getNome();
            lbDataNascimento.Text = funcionario.getDataNascimento();
            lbGenero.Text = funcionario.getGenero().ToString();
            lbTelefone.Text = funcionario.getTelefone();
            lbCargo.Text = funcionario.getCargo();
            lbSalario.Text = funcionario.getSalario();
        }
    }
}
