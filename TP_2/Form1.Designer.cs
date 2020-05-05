namespace TP_2
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gestionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionDesÉtudiantsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionDesNotesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quiterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.etudiant1 = new TP_2.Etudiant();
            this.notes1 = new TP_2.Notes();
            this.consutlation1 = new TP_2.Consutlation();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestionToolStripMenuItem,
            this.consultationToolStripMenuItem,
            this.quiterToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(852, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gestionToolStripMenuItem
            // 
            this.gestionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestionDesÉtudiantsToolStripMenuItem,
            this.gestionDesNotesToolStripMenuItem});
            this.gestionToolStripMenuItem.Name = "gestionToolStripMenuItem";
            this.gestionToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.gestionToolStripMenuItem.Text = "Gestion";
            // 
            // gestionDesÉtudiantsToolStripMenuItem
            // 
            this.gestionDesÉtudiantsToolStripMenuItem.Name = "gestionDesÉtudiantsToolStripMenuItem";
            this.gestionDesÉtudiantsToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.gestionDesÉtudiantsToolStripMenuItem.Text = "Gestion des étudiants";
            this.gestionDesÉtudiantsToolStripMenuItem.Click += new System.EventHandler(this.gestionDesÉtudiantsToolStripMenuItem_Click);
            // 
            // gestionDesNotesToolStripMenuItem
            // 
            this.gestionDesNotesToolStripMenuItem.Name = "gestionDesNotesToolStripMenuItem";
            this.gestionDesNotesToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.gestionDesNotesToolStripMenuItem.Text = "Gestion des notes";
            this.gestionDesNotesToolStripMenuItem.Click += new System.EventHandler(this.gestionDesNotesToolStripMenuItem_Click);
            // 
            // consultationToolStripMenuItem
            // 
            this.consultationToolStripMenuItem.Name = "consultationToolStripMenuItem";
            this.consultationToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.consultationToolStripMenuItem.Text = "Consultation";
            this.consultationToolStripMenuItem.Click += new System.EventHandler(this.consultationToolStripMenuItem_Click);
            // 
            // quiterToolStripMenuItem
            // 
            this.quiterToolStripMenuItem.Name = "quiterToolStripMenuItem";
            this.quiterToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.quiterToolStripMenuItem.Text = "Quiter";
            this.quiterToolStripMenuItem.Click += new System.EventHandler(this.quiterToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.etudiant1);
            this.panel1.Controls.Add(this.notes1);
            this.panel1.Controls.Add(this.consutlation1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(852, 407);
            this.panel1.TabIndex = 1;
            // 
            // etudiant1
            // 
            this.etudiant1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.etudiant1.Location = new System.Drawing.Point(0, 0);
            this.etudiant1.Name = "etudiant1";
            this.etudiant1.Size = new System.Drawing.Size(852, 407);
            this.etudiant1.TabIndex = 2;
            // 
            // notes1
            // 
            this.notes1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.notes1.Location = new System.Drawing.Point(0, 0);
            this.notes1.Name = "notes1";
            this.notes1.Size = new System.Drawing.Size(852, 407);
            this.notes1.TabIndex = 1;
            // 
            // consutlation1
            // 
            this.consutlation1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.consutlation1.Location = new System.Drawing.Point(0, 0);
            this.consutlation1.Name = "consutlation1";
            this.consutlation1.Size = new System.Drawing.Size(852, 407);
            this.consutlation1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 431);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MENU PRINCIPAL";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Leave += new System.EventHandler(this.Form1_Leave);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gestionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionDesÉtudiantsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionDesNotesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quiterToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private Etudiant etudiant1;
        private Notes notes1;
        private Consutlation consutlation1;
    }
}

