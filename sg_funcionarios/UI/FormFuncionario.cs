using sg_funcionarios.BLL;
using sg_funcionarios.UI;
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
        public FormFuncionario()
        {
            InitializeComponent();
            this.Load += loadFuncionarios;
            dataGridView1.CellContentClick += clicarImagens;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private Bitmap GetThumbnailImage(String path, int width, int height)
        {
            using (Bitmap originalImage = new Bitmap(path))
            {
                return new Bitmap(originalImage.GetThumbnailImage(width, height, null, IntPtr.Zero));
            }
        }

        private void loadFuncionarios(object sender, EventArgs e)
        {
            var listaFuncionarios = FuncionarioBLL.getFuncionarios();

            if (listaFuncionarios == null)
            {
                MessageBox.Show(Erro.getMsgErro());
                return;
            }

            String imgEditarPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"imgs\img_editar.png");
            String imgRemoverPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"imgs\img_remover.png");

            Bitmap imgEditar = GetThumbnailImage(imgEditarPath, 22, 22);
            Bitmap imgRemover = GetThumbnailImage(imgRemoverPath, 22, 22);

            foreach (var funcionario in listaFuncionarios)
            {
                dataGridView1.Rows.Add(
                    funcionario.getCodigo(),
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

        private void clicarImagens(object sender, DataGridViewCellEventArgs e) //de editar e remover
        {
            String colname = dataGridView1.Columns[e.ColumnIndex].Name;

            if (colname == "editar")
            {
                editarFuncionario(e);
            }
            else if (colname == "remover")
            {
                removerFuncionario(e);
            }
        }

        private void editarFuncionario(DataGridViewCellEventArgs e)
        {
            FormFuncionarioEdit formFuncEdit = new FormFuncionarioEdit();

            int indexLinha = e.RowIndex;

            if (indexLinha >= 0)
            {
                DataGridViewRow linha = dataGridView1.Rows[indexLinha];

                String codigo   = linha.Cells[0].Value.ToString();
                String nome     = linha.Cells[1].Value.ToString();
                String dataNasc = linha.Cells[2].Value.ToString();
                String genero   = linha.Cells[3].Value.ToString();
                String telefone = linha.Cells[4].Value.ToString();
                String cargo    = linha.Cells[5].Value.ToString();
                String salario  = linha.Cells[6].Value.ToString();

                formFuncEdit.camposFuncionario = new Funcionario();

                formFuncEdit.camposFuncionario.setCodigo(codigo);
                formFuncEdit.camposFuncionario.setNome(nome);
                formFuncEdit.camposFuncionario.setDataNascimento(dataNasc);
                formFuncEdit.camposFuncionario.setGenero(genero);
                formFuncEdit.camposFuncionario.setTelefone(telefone);
                formFuncEdit.camposFuncionario.setCargo(cargo);
                formFuncEdit.camposFuncionario.setSalario(salario);

                formFuncEdit.Show();
                this.Hide();
            }
        }

        private void removerFuncionario(DataGridViewCellEventArgs e)
        {
            int indexLinha = e.RowIndex;

            if (indexLinha >= 0)
            {
                DataGridViewRow linha = dataGridView1.Rows[indexLinha];
                String nomeFuncionario = Convert.ToString(linha.Cells[1].Value);

                DialogResult dr = MessageBox.Show($"Tem certeza que deseja remover o funcionário {nomeFuncionario} permanentemente?",
                                                  "Remover funcionário",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    dataGridView1.Rows.RemoveAt(indexLinha);

                    int codigoFuncionario = Convert.ToInt32(linha.Cells[0].Value);

                    FuncionarioRemoveBLL.removerFuncionario(codigoFuncionario);

                    if (Erro.getErro())
                    {
                        MessageBox.Show(Erro.getMsgErro());
                        return;
                    }

                    MessageBox.Show("Funcionário removido com sucesso.",
                                    "Remover funcionário",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
            }
        }

        private void btnAddFuncionario_Click(object sender, EventArgs e)
        {
            FormFuncionarioAdd formFuncAdd = new FormFuncionarioAdd();
            formFuncAdd.Show();
            this.Hide();
        }
    }
}
