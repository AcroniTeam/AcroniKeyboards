﻿namespace AcroniUI
{
    partial class Template
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Template));
            this.pnlSuperior = new System.Windows.Forms.Panel();
            this.lblArquivo = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.PictureBox();
            this.btnMinimize = new System.Windows.Forms.PictureBox();
            this.lblAcroni = new System.Windows.Forms.Label();
            this.timerFade = new System.Windows.Forms.Timer(this.components);
            this.pnlArquivos = new System.Windows.Forms.Panel();
            this.lblSalvarComo = new System.Windows.Forms.Label();
            this.lblSalvar = new System.Windows.Forms.Label();
            this.lblNovo = new System.Windows.Forms.Label();
            this.lblAbrir = new System.Windows.Forms.Label();
            this.pnlSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).BeginInit();
            this.pnlArquivos.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSuperior
            // 
            this.pnlSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(47)))));
            this.pnlSuperior.Controls.Add(this.lblArquivo);
            this.pnlSuperior.Controls.Add(this.btnClose);
            this.pnlSuperior.Controls.Add(this.btnMinimize);
            this.pnlSuperior.Controls.Add(this.lblAcroni);
            this.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSuperior.Location = new System.Drawing.Point(0, 0);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Size = new System.Drawing.Size(1280, 40);
            this.pnlSuperior.TabIndex = 11;
            this.pnlSuperior.Click += new System.EventHandler(this.generalClickCancel);
            this.pnlSuperior.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlSuperior_Paint);
            // 
            // lblArquivo
            // 
            this.lblArquivo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblArquivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblArquivo.ForeColor = System.Drawing.Color.White;
            this.lblArquivo.Location = new System.Drawing.Point(108, 5);
            this.lblArquivo.Name = "lblArquivo";
            this.lblArquivo.Size = new System.Drawing.Size(62, 30);
            this.lblArquivo.TabIndex = 14;
            this.lblArquivo.Text = "Arquivo";
            this.lblArquivo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblArquivo.Click += new System.EventHandler(this.lblArquivo_Click);
            this.lblArquivo.MouseEnter += new System.EventHandler(this.lblMenus_MouseOver);
            this.lblArquivo.MouseLeave += new System.EventHandler(this.lblMenus_MouseLeave);
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(1182, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(71, 30);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnClose.TabIndex = 12;
            this.btnClose.TabStop = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimize.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimize.Image")));
            this.btnMinimize.Location = new System.Drawing.Point(1140, 0);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(42, 30);
            this.btnMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnMinimize.TabIndex = 12;
            this.btnMinimize.TabStop = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // lblAcroni
            // 
            this.lblAcroni.AutoSize = true;
            this.lblAcroni.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lblAcroni.ForeColor = System.Drawing.Color.White;
            this.lblAcroni.Location = new System.Drawing.Point(9, 6);
            this.lblAcroni.Name = "lblAcroni";
            this.lblAcroni.Size = new System.Drawing.Size(80, 26);
            this.lblAcroni.TabIndex = 2;
            this.lblAcroni.Text = "Acroni";
            // 
            // timerFade
            // 
            this.timerFade.Tick += new System.EventHandler(this.timerFade_Tick);
            // 
            // pnlArquivos
            // 
            this.pnlArquivos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(47)))));
            this.pnlArquivos.Controls.Add(this.lblSalvarComo);
            this.pnlArquivos.Controls.Add(this.lblSalvar);
            this.pnlArquivos.Controls.Add(this.lblNovo);
            this.pnlArquivos.Controls.Add(this.lblAbrir);
            this.pnlArquivos.Location = new System.Drawing.Point(108, 35);
            this.pnlArquivos.Name = "pnlArquivos";
            this.pnlArquivos.Size = new System.Drawing.Size(276, 120);
            this.pnlArquivos.TabIndex = 16;
            this.pnlArquivos.Visible = false;
            // 
            // lblSalvarComo
            // 
            this.lblSalvarComo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(47)))));
            this.lblSalvarComo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSalvarComo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblSalvarComo.ForeColor = System.Drawing.Color.White;
            this.lblSalvarComo.Location = new System.Drawing.Point(0, 90);
            this.lblSalvarComo.Name = "lblSalvarComo";
            this.lblSalvarComo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblSalvarComo.Size = new System.Drawing.Size(276, 30);
            this.lblSalvarComo.TabIndex = 20;
            this.lblSalvarComo.Text = "Salvar como...      Ctrl + Shift + S";
            this.lblSalvarComo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSalvarComo.Click += new System.EventHandler(this.lblSalvarComo_Click);
            this.lblSalvarComo.MouseLeave += new System.EventHandler(this.scroll_leave);
            this.lblSalvarComo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.scroll_move);
            // 
            // lblSalvar
            // 
            this.lblSalvar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(47)))));
            this.lblSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblSalvar.ForeColor = System.Drawing.Color.White;
            this.lblSalvar.Location = new System.Drawing.Point(0, 60);
            this.lblSalvar.Name = "lblSalvar";
            this.lblSalvar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblSalvar.Size = new System.Drawing.Size(276, 30);
            this.lblSalvar.TabIndex = 19;
            this.lblSalvar.Text = "Salvar                                Ctrl + S";
            this.lblSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSalvar.Click += new System.EventHandler(this.lblSalvar_Click);
            this.lblSalvar.MouseLeave += new System.EventHandler(this.scroll_leave);
            this.lblSalvar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.scroll_move);
            // 
            // lblNovo
            // 
            this.lblNovo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(47)))));
            this.lblNovo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblNovo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblNovo.ForeColor = System.Drawing.Color.White;
            this.lblNovo.Location = new System.Drawing.Point(0, 0);
            this.lblNovo.Name = "lblNovo";
            this.lblNovo.Size = new System.Drawing.Size(276, 30);
            this.lblNovo.TabIndex = 18;
            this.lblNovo.Text = "Novo                                  Ctrl + N";
            this.lblNovo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNovo.Click += new System.EventHandler(this.lblNovo_Click);
            this.lblNovo.MouseLeave += new System.EventHandler(this.scroll_leave);
            this.lblNovo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.scroll_move);
            // 
            // lblAbrir
            // 
            this.lblAbrir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(47)))));
            this.lblAbrir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblAbrir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblAbrir.ForeColor = System.Drawing.Color.White;
            this.lblAbrir.Location = new System.Drawing.Point(0, 30);
            this.lblAbrir.Name = "lblAbrir";
            this.lblAbrir.Size = new System.Drawing.Size(276, 30);
            this.lblAbrir.TabIndex = 17;
            this.lblAbrir.Text = "Abrir                                   Ctrl + O";
            this.lblAbrir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblAbrir.Click += new System.EventHandler(this.lblAbrir_Click);
            this.lblAbrir.MouseLeave += new System.EventHandler(this.scroll_leave);
            this.lblAbrir.MouseMove += new System.Windows.Forms.MouseEventHandler(this.scroll_move);
            // 
            // Template
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(42)))), ((int)(((byte)(44)))));
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.pnlArquivos);
            this.Controls.Add(this.pnlSuperior);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Template";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.Template_Load);
            this.Click += new System.EventHandler(this.generalClickCancel);
            this.pnlSuperior.ResumeLayout(false);
            this.pnlSuperior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).EndInit();
            this.pnlArquivos.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        protected System.Windows.Forms.Label lblAcroni;
        private System.Windows.Forms.Timer timerFade;
        private System.Windows.Forms.PictureBox btnClose;
        private System.Windows.Forms.PictureBox btnMinimize;
        private System.Windows.Forms.Panel pnlSuperior;
        private System.Windows.Forms.Label lblArquivo;
        private System.Windows.Forms.Label lblSalvarComo;
        private System.Windows.Forms.Label lblSalvar;
        private System.Windows.Forms.Label lblNovo;
        private System.Windows.Forms.Label lblAbrir;
        protected System.Windows.Forms.Panel pnlArquivos;
    }
}