namespace MuDownloader
{
    partial class MuDownloader
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MuDownloader));
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.downloadInfos = new System.ComponentModel.BackgroundWorker();
            this.closeBtn = new System.Windows.Forms.Button();
            this.minimizeBtn = new System.Windows.Forms.Button();
            this.progressoTxt = new System.Windows.Forms.Label();
            this.downloadBtn = new System.Windows.Forms.PictureBox();
            this.clienteCompletoBtn = new System.Windows.Forms.PictureBox();
            this.clienteSemSomBtn = new System.Windows.Forms.PictureBox();
            this.clientePatchBtn = new System.Windows.Forms.PictureBox();
            this.nomeCliente = new System.Windows.Forms.Label();
            this.tamanhoCliente = new System.Windows.Forms.Label();
            this.downloadClienteCompleto = new System.ComponentModel.BackgroundWorker();
            this.downloadClienteSemSom = new System.ComponentModel.BackgroundWorker();
            this.downloadPatch = new System.ComponentModel.BackgroundWorker();
            this.checkAutoExe = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.downloadBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clienteCompletoBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clienteSemSomBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientePatchBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.progressBar1.ForeColor = System.Drawing.Color.DarkRed;
            this.progressBar1.Location = new System.Drawing.Point(24, 315);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(646, 12);
            this.progressBar1.TabIndex = 0;
            // 
            // downloadInfos
            // 
            this.downloadInfos.WorkerReportsProgress = true;
            this.downloadInfos.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // closeBtn
            // 
            this.closeBtn.BackColor = System.Drawing.Color.Transparent;
            this.closeBtn.BackgroundImage = global::MuDownloader.Properties.Resources.close1;
            this.closeBtn.FlatAppearance.BorderSize = 0;
            this.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeBtn.Location = new System.Drawing.Point(647, 12);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(34, 26);
            this.closeBtn.TabIndex = 13;
            this.closeBtn.UseVisualStyleBackColor = false;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            this.closeBtn.MouseEnter += new System.EventHandler(this.closeBtn_MouseEnter);
            this.closeBtn.MouseLeave += new System.EventHandler(this.closeBtn_MouseLeave);
            // 
            // minimizeBtn
            // 
            this.minimizeBtn.BackColor = System.Drawing.Color.Transparent;
            this.minimizeBtn.BackgroundImage = global::MuDownloader.Properties.Resources.minimize1;
            this.minimizeBtn.FlatAppearance.BorderSize = 0;
            this.minimizeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimizeBtn.Location = new System.Drawing.Point(619, 12);
            this.minimizeBtn.Name = "minimizeBtn";
            this.minimizeBtn.Size = new System.Drawing.Size(34, 26);
            this.minimizeBtn.TabIndex = 14;
            this.minimizeBtn.UseVisualStyleBackColor = false;
            this.minimizeBtn.Click += new System.EventHandler(this.minimizeBtn_Click);
            this.minimizeBtn.MouseEnter += new System.EventHandler(this.minimizeBtn_MouseEnter);
            this.minimizeBtn.MouseLeave += new System.EventHandler(this.minimizeBtn_MouseLeave);
            // 
            // progressoTxt
            // 
            this.progressoTxt.AutoSize = true;
            this.progressoTxt.BackColor = System.Drawing.Color.Transparent;
            this.progressoTxt.ForeColor = System.Drawing.Color.Transparent;
            this.progressoTxt.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.progressoTxt.Location = new System.Drawing.Point(26, 297);
            this.progressoTxt.Name = "progressoTxt";
            this.progressoTxt.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.progressoTxt.Size = new System.Drawing.Size(103, 13);
            this.progressoTxt.TabIndex = 2;
            this.progressoTxt.Text = "Escolha o download";
            // 
            // downloadBtn
            // 
            this.downloadBtn.BackgroundImage = global::MuDownloader.Properties.Resources.btn;
            this.downloadBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.downloadBtn.Location = new System.Drawing.Point(570, 282);
            this.downloadBtn.Name = "downloadBtn";
            this.downloadBtn.Size = new System.Drawing.Size(99, 21);
            this.downloadBtn.TabIndex = 7;
            this.downloadBtn.TabStop = false;
            this.downloadBtn.Click += new System.EventHandler(this.downloadBtn_Click);
            // 
            // clienteCompletoBtn
            // 
            this.clienteCompletoBtn.BackgroundImage = global::MuDownloader.Properties.Resources.ClienteCompleto;
            this.clienteCompletoBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clienteCompletoBtn.Location = new System.Drawing.Point(105, 136);
            this.clienteCompletoBtn.Name = "clienteCompletoBtn";
            this.clienteCompletoBtn.Size = new System.Drawing.Size(206, 24);
            this.clienteCompletoBtn.TabIndex = 8;
            this.clienteCompletoBtn.TabStop = false;
            this.clienteCompletoBtn.Click += new System.EventHandler(this.ClienteCompletoBtn_Click);
            // 
            // clienteSemSomBtn
            // 
            this.clienteSemSomBtn.BackgroundImage = global::MuDownloader.Properties.Resources.ClienteSemSom;
            this.clienteSemSomBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clienteSemSomBtn.Location = new System.Drawing.Point(105, 191);
            this.clienteSemSomBtn.Name = "clienteSemSomBtn";
            this.clienteSemSomBtn.Size = new System.Drawing.Size(206, 24);
            this.clienteSemSomBtn.TabIndex = 9;
            this.clienteSemSomBtn.TabStop = false;
            this.clienteSemSomBtn.Click += new System.EventHandler(this.clienteSemSomBtn_Click);
            // 
            // clientePatchBtn
            // 
            this.clientePatchBtn.BackgroundImage = global::MuDownloader.Properties.Resources.ClientePatch;
            this.clientePatchBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clientePatchBtn.Location = new System.Drawing.Point(105, 245);
            this.clientePatchBtn.Name = "clientePatchBtn";
            this.clientePatchBtn.Size = new System.Drawing.Size(206, 24);
            this.clientePatchBtn.TabIndex = 10;
            this.clientePatchBtn.TabStop = false;
            this.clientePatchBtn.Click += new System.EventHandler(this.clientePatchBtn_Click);
            // 
            // nomeCliente
            // 
            this.nomeCliente.AutoSize = true;
            this.nomeCliente.BackColor = System.Drawing.Color.Transparent;
            this.nomeCliente.ForeColor = System.Drawing.Color.ForestGreen;
            this.nomeCliente.Location = new System.Drawing.Point(453, 278);
            this.nomeCliente.Name = "nomeCliente";
            this.nomeCliente.Size = new System.Drawing.Size(34, 13);
            this.nomeCliente.TabIndex = 11;
            this.nomeCliente.Text = "---------";
            // 
            // tamanhoCliente
            // 
            this.tamanhoCliente.AutoSize = true;
            this.tamanhoCliente.BackColor = System.Drawing.Color.Transparent;
            this.tamanhoCliente.ForeColor = System.Drawing.Color.ForestGreen;
            this.tamanhoCliente.Location = new System.Drawing.Point(486, 293);
            this.tamanhoCliente.Name = "tamanhoCliente";
            this.tamanhoCliente.Size = new System.Drawing.Size(34, 13);
            this.tamanhoCliente.TabIndex = 12;
            this.tamanhoCliente.Text = "---------";
            // 
            // downloadClienteCompleto
            // 
            this.downloadClienteCompleto.WorkerReportsProgress = true;
            this.downloadClienteCompleto.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.downloadClienteCompleto.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker2_ProgressChanged2);
            this.downloadClienteCompleto.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker2_RunWorkerCompleted2);
            // 
            // downloadClienteSemSom
            // 
            this.downloadClienteSemSom.WorkerReportsProgress = true;
            this.downloadClienteSemSom.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker3_DoWork);
            this.downloadClienteSemSom.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker3_ProgressChanged3);
            this.downloadClienteSemSom.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker3_RunWorkerCompleted3);
            // 
            // downloadPatch
            // 
            this.downloadPatch.WorkerReportsProgress = true;
            this.downloadPatch.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker4_DoWork);
            this.downloadPatch.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker4_ProgressChanged4);
            this.downloadPatch.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker4_RunWorkerCompleted4);
            // 
            // checkAutoExe
            // 
            this.checkAutoExe.AutoSize = true;
            this.checkAutoExe.BackColor = System.Drawing.Color.Transparent;
            this.checkAutoExe.Cursor = System.Windows.Forms.Cursors.Help;
            this.checkAutoExe.ForeColor = System.Drawing.Color.Transparent;
            this.checkAutoExe.Location = new System.Drawing.Point(570, 259);
            this.checkAutoExe.Name = "checkAutoExe";
            this.checkAutoExe.Size = new System.Drawing.Size(93, 17);
            this.checkAutoExe.TabIndex = 15;
            this.checkAutoExe.Text = "Auto Executar";
            this.checkAutoExe.UseVisualStyleBackColor = false;
            // 
            // MuDownloader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(72)))), ((int)(((byte)(72)))));
            this.BackgroundImage = global::MuDownloader.Properties.Resources.fundo;
            this.ClientSize = new System.Drawing.Size(693, 346);
            this.Controls.Add(this.checkAutoExe);
            this.Controls.Add(this.tamanhoCliente);
            this.Controls.Add(this.nomeCliente);
            this.Controls.Add(this.clientePatchBtn);
            this.Controls.Add(this.clienteSemSomBtn);
            this.Controls.Add(this.clienteCompletoBtn);
            this.Controls.Add(this.downloadBtn);
            this.Controls.Add(this.minimizeBtn);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.progressoTxt);
            this.Controls.Add(this.progressBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MuDownloader";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MuFoxx Downloader";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.downloadBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clienteCompletoBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clienteSemSomBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientePatchBtn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker downloadInfos;
        private System.ComponentModel.BackgroundWorker downloadClienteCompleto;
        private System.ComponentModel.BackgroundWorker downloadClienteSemSom;
        private System.ComponentModel.BackgroundWorker downloadPatch;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Button minimizeBtn;
        private System.Windows.Forms.Label progressoTxt;
        private System.Windows.Forms.PictureBox downloadBtn;
        private System.Windows.Forms.PictureBox clienteCompletoBtn;
        private System.Windows.Forms.PictureBox clienteSemSomBtn;
        private System.Windows.Forms.PictureBox clientePatchBtn;
        private System.Windows.Forms.Label nomeCliente;
        private System.Windows.Forms.Label tamanhoCliente;
        private System.Windows.Forms.CheckBox checkAutoExe;
    }
}

