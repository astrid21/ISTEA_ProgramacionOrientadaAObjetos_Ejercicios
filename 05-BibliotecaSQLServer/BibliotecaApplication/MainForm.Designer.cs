namespace WindowsFormApplication
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.adminLectorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lectoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.librosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enPrestamoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prestamoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lectoresSinPrestamosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.organizarFormulariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cascadaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.horizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarTodosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actualizarConsultasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminLectorToolStripMenuItem,
            this.consultasToolStripMenuItem,
            this.organizarFormulariosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(459, 26);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // adminLectorToolStripMenuItem
            // 
            this.adminLectorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lectoresToolStripMenuItem,
            this.librosToolStripMenuItem});
            this.adminLectorToolStripMenuItem.Name = "adminLectorToolStripMenuItem";
            this.adminLectorToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.adminLectorToolStripMenuItem.Text = "Administrar";
            // 
            // lectoresToolStripMenuItem
            // 
            this.lectoresToolStripMenuItem.Name = "lectoresToolStripMenuItem";
            this.lectoresToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.lectoresToolStripMenuItem.Text = "Lectores";
            this.lectoresToolStripMenuItem.Click += new System.EventHandler(this.lectoresToolStripMenuItem_Click);
            // 
            // librosToolStripMenuItem
            // 
            this.librosToolStripMenuItem.Name = "librosToolStripMenuItem";
            this.librosToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.librosToolStripMenuItem.Text = "Libros";
            this.librosToolStripMenuItem.Click += new System.EventHandler(this.librosToolStripMenuItem_Click);
            // 
            // consultasToolStripMenuItem
            // 
            this.consultasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enPrestamoToolStripMenuItem,
            this.prestamoToolStripMenuItem,
            this.lectoresSinPrestamosToolStripMenuItem});
            this.consultasToolStripMenuItem.Name = "consultasToolStripMenuItem";
            this.consultasToolStripMenuItem.Size = new System.Drawing.Size(82, 22);
            this.consultasToolStripMenuItem.Text = "Consultas";
            // 
            // enPrestamoToolStripMenuItem
            // 
            this.enPrestamoToolStripMenuItem.Name = "enPrestamoToolStripMenuItem";
            this.enPrestamoToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.enPrestamoToolStripMenuItem.Text = "En prestamo";
            this.enPrestamoToolStripMenuItem.Click += new System.EventHandler(this.enPrestamoToolStripMenuItem_Click);
            // 
            // prestamoToolStripMenuItem
            // 
            this.prestamoToolStripMenuItem.Name = "prestamoToolStripMenuItem";
            this.prestamoToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.prestamoToolStripMenuItem.Text = "Cantidades en préstamos";
            this.prestamoToolStripMenuItem.Click += new System.EventHandler(this.prestamoToolStripMenuItem_Click);
            // 
            // lectoresSinPrestamosToolStripMenuItem
            // 
            this.lectoresSinPrestamosToolStripMenuItem.Name = "lectoresSinPrestamosToolStripMenuItem";
            this.lectoresSinPrestamosToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.lectoresSinPrestamosToolStripMenuItem.Text = "Lectores sin prestamos";
            this.lectoresSinPrestamosToolStripMenuItem.Click += new System.EventHandler(this.lectoresSinPrestamosToolStripMenuItem_Click);
            // 
            // organizarFormulariosToolStripMenuItem
            // 
            this.organizarFormulariosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cascadaToolStripMenuItem,
            this.horizontalToolStripMenuItem,
            this.verticalToolStripMenuItem,
            this.cerrarTodosToolStripMenuItem,
            this.actualizarConsultasToolStripMenuItem});
            this.organizarFormulariosToolStripMenuItem.Name = "organizarFormulariosToolStripMenuItem";
            this.organizarFormulariosToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.organizarFormulariosToolStripMenuItem.Text = "Organizar formularios";
            // 
            // cascadaToolStripMenuItem
            // 
            this.cascadaToolStripMenuItem.Name = "cascadaToolStripMenuItem";
            this.cascadaToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.cascadaToolStripMenuItem.Text = "Cascada";
            this.cascadaToolStripMenuItem.Click += new System.EventHandler(this.cascadaToolStripMenuItem_Click);
            // 
            // horizontalToolStripMenuItem
            // 
            this.horizontalToolStripMenuItem.Name = "horizontalToolStripMenuItem";
            this.horizontalToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.horizontalToolStripMenuItem.Text = "Horizontal";
            this.horizontalToolStripMenuItem.Click += new System.EventHandler(this.horizontalToolStripMenuItem_Click);
            // 
            // verticalToolStripMenuItem
            // 
            this.verticalToolStripMenuItem.Name = "verticalToolStripMenuItem";
            this.verticalToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.verticalToolStripMenuItem.Text = "Vertical";
            this.verticalToolStripMenuItem.Click += new System.EventHandler(this.verticalToolStripMenuItem_Click);
            // 
            // cerrarTodosToolStripMenuItem
            // 
            this.cerrarTodosToolStripMenuItem.Name = "cerrarTodosToolStripMenuItem";
            this.cerrarTodosToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.cerrarTodosToolStripMenuItem.Text = "Cerrar todos ";
            this.cerrarTodosToolStripMenuItem.Click += new System.EventHandler(this.cerrarTodosToolStripMenuItem_Click);
            // 
            // actualizarConsultasToolStripMenuItem
            // 
            this.actualizarConsultasToolStripMenuItem.Name = "actualizarConsultasToolStripMenuItem";
            this.actualizarConsultasToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.actualizarConsultasToolStripMenuItem.Text = "Actualizar consultas";
            this.actualizarConsultasToolStripMenuItem.Click += new System.EventHandler(this.actualizarConsultasToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 257);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Main";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem adminLectorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lectoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem librosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enPrestamoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prestamoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem organizarFormulariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cascadaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem horizontalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verticalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarTodosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lectoresSinPrestamosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actualizarConsultasToolStripMenuItem;
    }
}