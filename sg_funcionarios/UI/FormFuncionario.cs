using sg_funcionarios.BLL;
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
    public partial class FormFuncionario : Form
    {
        Funcionario funcionario = new Funcionario();

        public FormFuncionario()
        {
            InitializeComponent();
            this.Load += load_Funcionarios;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colname = dataGridView1.Columns[e.ColumnIndex].Name;
            if (colname == "editar")
            {
                MessageBox.Show("Botão editar clicado na linha " + e.RowIndex);
            }
            else if (colname == "remover")
            {
                MessageBox.Show("Botão remover clicado na linha " + e.RowIndex);
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void load_Funcionarios(object sender, EventArgs e)
        {
            var funcionarios = FuncionarioBLL.getFuncionarios();

            if (funcionarios == null)
            {
                MessageBox.Show(Erro.getMsgErro());
                return;
            }

            string imgEditarPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"imgs\img_editar.png");
            string imgRemoverPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"imgs\img_remover.png");

            Bitmap imgEditar = GetThumbnailImage(imgEditarPath, 22, 22);
            Bitmap imgRemover = GetThumbnailImage(imgRemoverPath, 22, 22);

            foreach (var func in funcionarios)
            {
                dataGridView1.Rows.Add(
                    func.getNome(),
                    func.getDataNascimento(),
                    func.getGenero(),
                    func.getTelefone(),
                    func.getCargo(),
                    func.getSalario(),
                    imgEditar,
                    imgRemover
                );
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            string nome = tbNome.Text;
            string dataNascimento = dtpDataNascimento.Value.ToString("dd/MM/yyyy");
            char genero = rbMasculino.Checked ? 'M' : 'F';
            string telefone = tbTelefone.Text;
            string cargo = tbCargo.Text;
            string salario = tbSalario.Text;

            funcionario.setNome(nome);
            funcionario.setDataNascimento(dataNascimento);
            funcionario.setGenero(genero);
            funcionario.setTelefone(telefone);
            funcionario.setCargo(cargo);
            funcionario.setSalario(salario);

            FuncionarioBLL.validarCampos(funcionario); //já cria no banco se validar

            if (Erro.getErro())
            {
                MessageBox.Show(Erro.getMsgErro());
                return;
            }

            string imgEditarPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"imgs\img_editar.png");
            string imgRemoverPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"imgs\img_remover.png");

            Bitmap imgEditar = GetThumbnailImage(imgEditarPath, 22, 22);
            Bitmap imgRemover = GetThumbnailImage(imgRemoverPath, 22, 22);

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

        private Bitmap GetThumbnailImage(string path, int width, int height)
        {
            using (Bitmap originalImage = new Bitmap(path))
            {
                return new Bitmap(originalImage.GetThumbnailImage(width, height, null, IntPtr.Zero));
            }
        }

        private void editarFuncionario(object sender, EventArgs e)
        {
            lbOperacaoFunc.Text = "Editar funcionário";
            // Additional code to edit the employee
        }

        private void removerFuncionario(object sender, EventArgs e)
        {
            // Code to remove the employee
        }
    }
}
