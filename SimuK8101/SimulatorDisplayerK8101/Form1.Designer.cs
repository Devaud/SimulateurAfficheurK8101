namespace SimulatorDisplayerK8101
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.mspGeneral = new System.Windows.Forms.MenuStrip();
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSimulator = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDisconnect = new System.Windows.Forms.ToolStripMenuItem();
            this.mspGeneral.SuspendLayout();
            this.SuspendLayout();
            // 
            // mspGeneral
            // 
            this.mspGeneral.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile,
            this.tsmiSimulator});
            this.mspGeneral.Location = new System.Drawing.Point(0, 0);
            this.mspGeneral.Name = "mspGeneral";
            this.mspGeneral.Size = new System.Drawing.Size(493, 24);
            this.mspGeneral.TabIndex = 0;
            this.mspGeneral.Text = "menuStrip1";
            // 
            // tsmiFile
            // 
            this.tsmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiQuit});
            this.tsmiFile.Name = "tsmiFile";
            this.tsmiFile.Size = new System.Drawing.Size(37, 20);
            this.tsmiFile.Text = "&File";
            // 
            // tsmiQuit
            // 
            this.tsmiQuit.Image = global::SimulatorDisplayerK8101.Properties.Resources.door_out;
            this.tsmiQuit.Name = "tsmiQuit";
            this.tsmiQuit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.tsmiQuit.Size = new System.Drawing.Size(140, 22);
            this.tsmiQuit.Text = "&Quit";
            this.tsmiQuit.Click += new System.EventHandler(this.tsmiQuit_Click);
            // 
            // tsmiSimulator
            // 
            this.tsmiSimulator.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiConnect,
            this.tsmiDisconnect});
            this.tsmiSimulator.Name = "tsmiSimulator";
            this.tsmiSimulator.Size = new System.Drawing.Size(70, 20);
            this.tsmiSimulator.Text = "&Simulator";
            // 
            // tsmiConnect
            // 
            this.tsmiConnect.Image = global::SimulatorDisplayerK8101.Properties.Resources.connect;
            this.tsmiConnect.Name = "tsmiConnect";
            this.tsmiConnect.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.tsmiConnect.Size = new System.Drawing.Size(175, 22);
            this.tsmiConnect.Text = "&Connect";
            this.tsmiConnect.Click += new System.EventHandler(this.tsmiConnect_Click);
            // 
            // tsmiDisconnect
            // 
            this.tsmiDisconnect.Enabled = false;
            this.tsmiDisconnect.Image = global::SimulatorDisplayerK8101.Properties.Resources.disconnect;
            this.tsmiDisconnect.Name = "tsmiDisconnect";
            this.tsmiDisconnect.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.tsmiDisconnect.Size = new System.Drawing.Size(175, 22);
            this.tsmiDisconnect.Text = "&Disconnect";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 383);
            this.Controls.Add(this.mspGeneral);
            this.MainMenuStrip = this.mspGeneral;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.mspGeneral.ResumeLayout(false);
            this.mspGeneral.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mspGeneral;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiQuit;
        private System.Windows.Forms.ToolStripMenuItem tsmiSimulator;
        private System.Windows.Forms.ToolStripMenuItem tsmiConnect;
        private System.Windows.Forms.ToolStripMenuItem tsmiDisconnect;

    }
}

