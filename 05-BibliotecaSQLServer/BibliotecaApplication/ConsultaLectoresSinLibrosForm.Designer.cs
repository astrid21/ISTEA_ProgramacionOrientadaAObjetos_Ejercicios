namespace WindowsFormApplication
{
    partial class ConsultaLectoresSinLibrosForm
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
            this.dataGridViewLectores = new System.Windows.Forms.DataGridView();
            this.buttonActualizar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLectores)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewLectores
            // 
            this.dataGridViewLectores.AllowUserToAddRows = false;
            this.dataGridViewLectores.AllowUserToDeleteRows = false;
            this.dataGridViewLectores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLectores.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewLectores.Location = new System.Drawing.Point(12, 42);
            this.dataGridViewLectores.Name = "dataGridViewLectores";
            this.dataGridViewLectores.RowTemplate.Height = 24;
            this.dataGridViewLectores.Size = new System.Drawing.Size(488, 214);
            this.dataGridViewLectores.TabIndex = 0;
            // 
            // buttonActualizar
            // 
            this.buttonActualizar.Location = new System.Drawing.Point(22, 4);
            this.buttonActualizar.Name = "buttonActualizar";
            this.buttonActualizar.Size = new System.Drawing.Size(150, 32);
            this.buttonActualizar.TabIndex = 1;
            this.buttonActualizar.Text = "Actualizar consulta.";
            this.buttonActualizar.UseVisualStyleBackColor = true;
            this.buttonActualizar.Click += new System.EventHandler(this.buttonActualizar_Click);
            // 
            // LectoresSinLibrosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 268);
            this.Controls.Add(this.buttonActualizar);
            this.Controls.Add(this.dataGridViewLectores);
            this.Name = "LectoresSinLibrosForm";
            this.Text = "Listado de los lectores que no tienen libros prestados.";
            this.Load += new System.EventHandler(this.LectoresSinLibrosForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLectores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewLectores;
        private System.Windows.Forms.Button buttonActualizar;
    }
}