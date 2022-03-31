namespace DatabaseAccessConSeguridad
{
    partial class MainForm
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
            this.buttonEjecutorPersistencia = new System.Windows.Forms.Button();
            this.labelConnectionStringCodificado = new System.Windows.Forms.Label();
            this.labelConnectionStringSinCodificar = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonEjecutorPersistencia
            // 
            this.buttonEjecutorPersistencia.Location = new System.Drawing.Point(122, 160);
            this.buttonEjecutorPersistencia.Name = "buttonEjecutorPersistencia";
            this.buttonEjecutorPersistencia.Size = new System.Drawing.Size(372, 77);
            this.buttonEjecutorPersistencia.TabIndex = 1;
            this.buttonEjecutorPersistencia.Text = "Persistir libro con seguridad";
            this.buttonEjecutorPersistencia.UseVisualStyleBackColor = true;
            this.buttonEjecutorPersistencia.Click += new System.EventHandler(this.buttonEjecutorPersistencia_Click);
            // 
            // labelConnectionStringCodificado
            // 
            this.labelConnectionStringCodificado.AutoSize = true;
            this.labelConnectionStringCodificado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelConnectionStringCodificado.Location = new System.Drawing.Point(0, 28);
            this.labelConnectionStringCodificado.Name = "labelConnectionStringCodificado";
            this.labelConnectionStringCodificado.Size = new System.Drawing.Size(251, 20);
            this.labelConnectionStringCodificado.TabIndex = 2;
            this.labelConnectionStringCodificado.Text = "labelConnectionStringCodificado";
            // 
            // labelConnectionStringSinCodificar
            // 
            this.labelConnectionStringSinCodificar.AutoSize = true;
            this.labelConnectionStringSinCodificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelConnectionStringSinCodificar.Location = new System.Drawing.Point(0, 83);
            this.labelConnectionStringSinCodificar.Name = "labelConnectionStringSinCodificar";
            this.labelConnectionStringSinCodificar.Size = new System.Drawing.Size(263, 20);
            this.labelConnectionStringSinCodificar.TabIndex = 3;
            this.labelConnectionStringSinCodificar.Text = "labelConnectionStringSinCodificar";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(460, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Cadena de conexión a la base de datos codificada en base64.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(2, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(397, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Cadena de conexión a la base de datos decodificada.";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 249);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelConnectionStringSinCodificar);
            this.Controls.Add(this.labelConnectionStringCodificado);
            this.Controls.Add(this.buttonEjecutorPersistencia);
            this.Name = "MainForm";
            this.Text = "Persistir un libro en una base de datos con clave.";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonEjecutorPersistencia;
        private System.Windows.Forms.Label labelConnectionStringCodificado;
        private System.Windows.Forms.Label labelConnectionStringSinCodificar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

