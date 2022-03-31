namespace ExcepcionesApplication
{
    partial class Form1
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
            this.labelPruebaA = new System.Windows.Forms.Label();
            this.labelPruebaB = new System.Windows.Forms.Label();
            this.buttonEjecutarPruebas = new System.Windows.Forms.Button();
            this.labelPruebaC = new System.Windows.Forms.Label();
            this.labelPruebaD = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelPruebaA
            // 
            this.labelPruebaA.AutoSize = true;
            this.labelPruebaA.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPruebaA.Location = new System.Drawing.Point(81, 69);
            this.labelPruebaA.Name = "labelPruebaA";
            this.labelPruebaA.Size = new System.Drawing.Size(101, 25);
            this.labelPruebaA.TabIndex = 0;
            this.labelPruebaA.Text = "Prueba A";
            // 
            // labelPruebaB
            // 
            this.labelPruebaB.AutoSize = true;
            this.labelPruebaB.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPruebaB.Location = new System.Drawing.Point(81, 108);
            this.labelPruebaB.Name = "labelPruebaB";
            this.labelPruebaB.Size = new System.Drawing.Size(101, 25);
            this.labelPruebaB.TabIndex = 1;
            this.labelPruebaB.Text = "Prueba B";
            // 
            // buttonEjecutarPruebas
            // 
            this.buttonEjecutarPruebas.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEjecutarPruebas.Location = new System.Drawing.Point(13, 13);
            this.buttonEjecutarPruebas.Name = "buttonEjecutarPruebas";
            this.buttonEjecutarPruebas.Size = new System.Drawing.Size(267, 36);
            this.buttonEjecutarPruebas.TabIndex = 2;
            this.buttonEjecutarPruebas.Text = "Ejecutar pruebas";
            this.buttonEjecutarPruebas.UseVisualStyleBackColor = true;
            this.buttonEjecutarPruebas.Click += new System.EventHandler(this.buttonEjecutarPruebas_Click);
            // 
            // labelPruebaC
            // 
            this.labelPruebaC.AutoSize = true;
            this.labelPruebaC.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPruebaC.Location = new System.Drawing.Point(81, 148);
            this.labelPruebaC.Name = "labelPruebaC";
            this.labelPruebaC.Size = new System.Drawing.Size(102, 25);
            this.labelPruebaC.TabIndex = 3;
            this.labelPruebaC.Text = "Prueba C";
            // 
            // labelPruebaD
            // 
            this.labelPruebaD.AutoSize = true;
            this.labelPruebaD.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPruebaD.Location = new System.Drawing.Point(80, 187);
            this.labelPruebaD.Name = "labelPruebaD";
            this.labelPruebaD.Size = new System.Drawing.Size(102, 25);
            this.labelPruebaD.TabIndex = 4;
            this.labelPruebaD.Text = "Prueba D";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 226);
            this.Controls.Add(this.labelPruebaD);
            this.Controls.Add(this.labelPruebaC);
            this.Controls.Add(this.buttonEjecutarPruebas);
            this.Controls.Add(this.labelPruebaB);
            this.Controls.Add(this.labelPruebaA);
            this.Name = "Form1";
            this.Text = "Banco de pruebas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPruebaA;
        private System.Windows.Forms.Label labelPruebaB;
        private System.Windows.Forms.Button buttonEjecutarPruebas;
        private System.Windows.Forms.Label labelPruebaC;
        private System.Windows.Forms.Label labelPruebaD;
    }
}

