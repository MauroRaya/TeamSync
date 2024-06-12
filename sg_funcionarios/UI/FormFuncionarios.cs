using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sg_funcionarios
{
    public partial class FormFuncionarios : Form
    {
        Funcionario funcionario = new Funcionario();

        public FormFuncionarios()
        {
            InitializeComponent();

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Green;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            String nome = tbNome.Text;
            String dataNascimento = dtpDataNascimento.Value.ToString("dd/MM/yyyy");
            char genero = rbMasculino.Checked ? 'M' : 'F';
            String telefone = tbTelefone.Text;
            String cargo = tbCargo.Text;
            String salario = tbSalario.Text;

            funcionario.setNome(nome);
            funcionario.setDataNascimento(dataNascimento);
            funcionario.setGenero(genero);
            funcionario.setTelefone(telefone);
            funcionario.setCargo(cargo);
            funcionario.setSalario(salario);

            string imgEditarPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"imgs\img_editar.png");
            string imgRemoverPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"imgs\img_remover.png");

            Bitmap imgEditar = null;
            Bitmap imgRemover = null;

            using (Bitmap originalImage = new Bitmap(imgEditarPath))
            {
                imgEditar = new Bitmap(originalImage.GetThumbnailImage(22, 22, null, IntPtr.Zero));
            }

            using (Bitmap originalImage = new Bitmap(imgRemoverPath))
            {
                imgRemover = new Bitmap(originalImage.GetThumbnailImage(22, 22, null, IntPtr.Zero));
            }

            dataGridView1.Rows.Add(
                funcionario.getNome(),
                funcionario.getDataNascimento(),
                funcionario.getGenero(),
                funcionario.getTelefone(),
                funcionario.getCargo(),
                funcionario.getSalario(),
                imgEditar,
                imgRemover
            );
        }
    }
}
