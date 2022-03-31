namespace ApplicationArgumentNullException
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
            this.buttonEjecutarPruebas = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonEjecutarPruebas
            // 
            this.buttonEjecutarPruebas.Location = new System.Drawing.Point(49, 29);
            this.buttonEjecutarPruebas.Name = "buttonEjecutarPruebas";
            this.buttonEjecutarPruebas.Size = new System.Drawing.Size(150, 37);
            this.buttonEjecutarPruebas.TabIndex = 0;
            this.buttonEjecutarPruebas.Text = "Ejecutar pruebas";
            this.buttonEjecutarPruebas.UseVisualStyleBackColor = true;
            this.buttonEjecutarPruebas.Click += new System.EventHandler(this.buttonEjecutarPruebas_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 268);
            this.Controls.Add(this.buttonEjecutarPruebas);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonEjecutarPruebas;
    }
}

