namespace sg_funcionarios.UI
{
    partial class FormFuncionarioEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSair = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.dtpDataNascimento = new System.Windows.Forms.DateTimePicker();
            this.rbFeminino = new System.Windows.Forms.RadioButton();
            this.rbMasculino = new System.Windows.Forms.RadioButton();
            this.tbSalario = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbCargo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbTelefone = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbNome = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel1.Controls.Add(this.btnSair);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(483, 71);
            this.panel1.TabIndex = 9;
            // 
            // btnSair
            // 
            this.btnSair.BackColor = System.Drawing.Color.Transparent;
            this.btnSair.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSair.FlatAppearance.BorderSize = 0;
            this.btnSair.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSair.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSair.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.ForeColor = System.Drawing.Color.White;
            this.btnSair.Location = new System.Drawing.Point(458, 4);
            this.btnSair.Margin = new System.Windows.Forms.Padding(0);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(25, 35);
            this.btnSair.TabIndex = 10;
            this.btnSair.Text = "X";
            this.btnSair.UseVisualStyleBackColor = false;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(13, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(172, 22);
            this.label3.TabIndex = 4;
            this.label3.Text = "editar funcionário";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "TeamSync";
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnConfirmar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmar.ForeColor = System.Drawing.Color.White;
            this.btnConfirmar.Location = new System.Drawing.Point(17, 312);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(112, 35);
            this.btnConfirmar.TabIndex = 32;
            this.btnConfirmar.Text = "EDITAR";
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // dtpDataNascimento
            // 
            this.dtpDataNascimento.CalendarFont = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDataNascimento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataNascimento.Location = new System.Drawing.Point(17, 186);
            this.dtpDataNascimento.Name = "dtpDataNascimento";
            this.dtpDataNascimento.Size = new System.Drawing.Size(102, 20);
            this.dtpDataNascimento.TabIndex = 55;
            // 
            // rbFeminino
            // 
            this.rbFeminino.AutoSize = true;
            this.rbFeminino.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbFeminino.Location = new System.Drawing.Point(129, 248);
            this.rbFeminino.Name = "rbFeminino";
            this.rbFeminino.Size = new System.Drawing.Size(91, 24);
            this.rbFeminino.TabIndex = 54;
            this.rbFeminino.Text = "Feminino";
            this.rbFeminino.UseVisualStyleBackColor = true;
            // 
            // rbMasculino
            // 
            this.rbMasculino.AutoSize = true;
            this.rbMasculino.Checked = true;
            this.rbMasculino.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMasculino.Location = new System.Drawing.Point(17, 248);
            this.rbMasculino.Name = "rbMasculino";
            this.rbMasculino.Size = new System.Drawing.Size(102, 24);
            this.rbMasculino.TabIndex = 53;
            this.rbMasculino.TabStop = true;
            this.rbMasculino.Text = "Masculino";
            this.rbMasculino.UseVisualStyleBackColor = true;
            // 
            // tbSalario
            // 
            this.tbSalario.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSalario.Location = new System.Drawing.Point(250, 248);
            this.tbSalario.Name = "tbSalario";
            this.tbSalario.Size = new System.Drawing.Size(117, 27);
            this.tbSalario.TabIndex = 52;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(247, 227);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 18);
            this.label9.TabIndex = 51;
            this.label9.Text = "Salário";
            // 
            // tbCargo
            // 
            this.tbCargo.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCargo.Location = new System.Drawing.Point(250, 183);
            this.tbCargo.Name = "tbCargo";
            this.tbCargo.Size = new System.Drawing.Size(203, 27);
            this.tbCargo.TabIndex = 50;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(247, 162);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 18);
            this.label8.TabIndex = 49;
            this.label8.Text = "Cargo";
            // 
            // tbTelefone
            // 
            this.tbTelefone.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTelefone.Location = new System.Drawing.Point(250, 117);
            this.tbTelefone.Name = "tbTelefone";
            this.tbTelefone.Size = new System.Drawing.Size(203, 27);
            this.tbTelefone.TabIndex = 48;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(247, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 18);
            this.label7.TabIndex = 47;
            this.label7.Text = "Telefone";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 227);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 18);
            this.label5.TabIndex = 46;
            this.label5.Text = "Gênero";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 18);
            this.label4.TabIndex = 45;
            this.label4.Text = "Data de nascimento";
            // 
            // tbNome
            // 
            this.tbNome.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNome.Location = new System.Drawing.Point(17, 117);
            this.tbNome.Name = "tbNome";
            this.tbNome.Size = new System.Drawing.Size(203, 27);
            this.tbNome.TabIndex = 44;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 18);
            this.label1.TabIndex = 43;
            this.label1.Text = "Nome";
            // 
            // FormFuncionarioEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 373);
            this.Controls.Add(this.dtpDataNascimento);
            this.Controls.Add(this.rbFeminino);
            this.Controls.Add(this.rbMasculino);
            this.Controls.Add(this.tbSalario);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbCargo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbTelefone);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbNome);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormFuncionarioEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormFuncionarioAdd";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.DateTimePicker dtpDataNascimento;
        private System.Windows.Forms.RadioButton rbFeminino;
        private System.Windows.Forms.RadioButton rbMasculino;
        private System.Windows.Forms.TextBox tbSalario;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbCargo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbTelefone;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbNome;
        private System.Windows.Forms.Label label1;
    }
}