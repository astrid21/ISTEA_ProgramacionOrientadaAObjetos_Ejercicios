namespace WindowsFormApplication
{
    partial class ConsultaEnPrestamoForm
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
            this.dataGridViewEnPrestamo = new System.Windows.Forms.DataGridView();
            this.buttonRefrescar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEnPrestamo)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewEnPrestamo
            // 
            this.dataGridViewEnPrestamo.AllowUserToAddRows = false;
            this.dataGridViewEnPrestamo.AllowUserToDeleteRows = false;
            this.dataGridViewEnPrestamo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEnPrestamo.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewEnPrestamo.Location = new System.Drawing.Point(2, 62);
            this.dataGridViewEnPrestamo.Name = "dataGridViewEnPrestamo";
            this.dataGridViewEnPrestamo.RowTemplate.Height = 24;
            this.dataGridViewEnPrestamo.Size = new System.Drawing.Size(540, 169);
            this.dataGridViewEnPrestamo.TabIndex = 0;
            // 
            // buttonRefrescar
            // 
            this.buttonRefrescar.Location = new System.Drawing.Point(2, 12);
            this.buttonRefrescar.Name = "buttonRefrescar";
            this.buttonRefrescar.Size = new System.Drawing.Size(176, 34);
            this.buttonRefrescar.TabIndex = 1;
            this.buttonRefrescar.Text = "Actualizar consulta.";
            this.buttonRefrescar.UseVisualStyleBackColor = true;
            this.buttonRefrescar.Click += new System.EventHandler(this.buttonRefrescar_Click);
            // 
            // EnPrestamoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 243);
            this.Controls.Add(this.buttonRefrescar);
            this.Controls.Add(this.dataGridViewEnPrestamo);
            this.Name = "EnPrestamoForm";
            this.Text = "Listado de libros en préstamo.";
            this.Load += new System.EventHandler(this.EnPrestamoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEnPrestamo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewEnPrestamo;
        private System.Windows.Forms.Button buttonRefrescar;
    }
}