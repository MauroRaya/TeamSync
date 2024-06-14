using sg_funcionarios.BLL;
using sg_funcionarios.ViewModels;
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
        FuncionarioVM funcionario = new FuncionarioVM();

        public FormFuncionario()
        {
            InitializeComponent();
            this.Load += Load_Funcionarios;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Load_Funcionarios(object sender, EventArgs e)
        {
            var funcionarios = FuncionarioBLL.getFuncionarios();

            if (funcionarios == null)
            {
                MessageBox.Show(Erro.getMsgErro());
                return;
            }

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

            FuncionarioBLL.validarCampos(funcionario); //ja cria no banco se validar

            if (Erro.getErro())
            {
                MessageBox.Show(Erro.getMsgErro());
                return;
            }

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
