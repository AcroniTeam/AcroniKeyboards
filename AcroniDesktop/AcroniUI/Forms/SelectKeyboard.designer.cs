namespace AcroniUI
{
    partial class SelectKeyboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectKeyboard));
            this.btnOpenCompacto = new System.Windows.Forms.Panel();
            this.lblCompacto = new System.Windows.Forms.Label();
            this.picBoxCompacto = new System.Windows.Forms.PictureBox();
            this.picBoxOpenFullSize = new System.Windows.Forms.PictureBox();
            this.btnOpenTenkeyless = new System.Windows.Forms.Panel();
            this.lblTenkeyless = new System.Windows.Forms.Label();
            this.picBoxOpenTenkeyless = new System.Windows.Forms.PictureBox();
            this.btnOpenFullSize = new System.Windows.Forms.Panel();
            this.lblFullSize = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.btnMax)).BeginInit();
            this.btnOpenCompacto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxCompacto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxOpenFullSize)).BeginInit();
            this.btnOpenTenkeyless.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxOpenTenkeyless)).BeginInit();
            this.btnOpenFullSize.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnMax
            // 
            // 
            // btnOpenCompacto
            // 
            this.btnOpenCompacto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(42)))), ((int)(((byte)(44)))));
            this.btnOpenCompacto.Controls.Add(this.lblCompacto);
            this.btnOpenCompacto.Controls.Add(this.picBoxCompacto);
            this.btnOpenCompacto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpenCompacto.Location = new System.Drawing.Point(320, 265);
            this.btnOpenCompacto.Name = "btnOpenCompacto";
            this.btnOpenCompacto.Size = new System.Drawing.Size(960, 227);
            this.btnOpenCompacto.TabIndex = 16;
            this.btnOpenCompacto.Click += new System.EventHandler(this.picBoxCompacto_Click);
            // 
            // lblCompacto
            // 
            this.lblCompacto.AutoSize = true;
            this.lblCompacto.BackColor = System.Drawing.Color.Transparent;
            this.lblCompacto.Font = new System.Drawing.Font("Microsoft Sans Serif", 33F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompacto.ForeColor = System.Drawing.Color.White;
            this.lblCompacto.Location = new System.Drawing.Point(355, 84);
            this.lblCompacto.Name = "lblCompacto";
            this.lblCompacto.Size = new System.Drawing.Size(256, 57);
            this.lblCompacto.TabIndex = 5;
            this.lblCompacto.Text = "Compacto";
            this.lblCompacto.Click += new System.EventHandler(this.picBoxCompacto_Click);
            // 
            // picBoxCompacto
            // 
            this.picBoxCompacto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBoxCompacto.Image = ((System.Drawing.Image)(resources.GetObject("picBoxCompacto.Image")));
            this.picBoxCompacto.Location = new System.Drawing.Point(151, 11);
            this.picBoxCompacto.Name = "picBoxCompacto";
            this.picBoxCompacto.Size = new System.Drawing.Size(651, 201);
            this.picBoxCompacto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxCompacto.TabIndex = 4;
            this.picBoxCompacto.TabStop = false;
            this.picBoxCompacto.Click += new System.EventHandler(this.picBoxCompacto_Click);
            this.picBoxCompacto.MouseEnter += new System.EventHandler(this.btnOpenFullSize_MouseEnter);
            this.picBoxCompacto.MouseLeave += new System.EventHandler(this.picBoxOpenFullSize_MouseLeave);
            // 
            // picBoxOpenFullSize
            // 
            this.picBoxOpenFullSize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBoxOpenFullSize.Image = ((System.Drawing.Image)(resources.GetObject("picBoxOpenFullSize.Image")));
            this.picBoxOpenFullSize.Location = new System.Drawing.Point(151, 13);
            this.picBoxOpenFullSize.Name = "picBoxOpenFullSize";
            this.picBoxOpenFullSize.Size = new System.Drawing.Size(651, 201);
            this.picBoxOpenFullSize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxOpenFullSize.TabIndex = 0;
            this.picBoxOpenFullSize.TabStop = false;
            this.picBoxOpenFullSize.Click += new System.EventHandler(this.picBoxOpenFullSize_Click);
            this.picBoxOpenFullSize.MouseEnter += new System.EventHandler(this.btnOpenFullSize_MouseEnter);
            this.picBoxOpenFullSize.MouseLeave += new System.EventHandler(this.picBoxOpenFullSize_MouseLeave);
            // 
            // btnOpenTenkeyless
            // 
            this.btnOpenTenkeyless.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(42)))), ((int)(((byte)(44)))));
            this.btnOpenTenkeyless.Controls.Add(this.lblTenkeyless);
            this.btnOpenTenkeyless.Controls.Add(this.picBoxOpenTenkeyless);
            this.btnOpenTenkeyless.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpenTenkeyless.Location = new System.Drawing.Point(320, 35);
            this.btnOpenTenkeyless.Name = "btnOpenTenkeyless";
            this.btnOpenTenkeyless.Size = new System.Drawing.Size(960, 227);
            this.btnOpenTenkeyless.TabIndex = 17;
            this.btnOpenTenkeyless.Visible = false;
            // 
            // lblTenkeyless
            // 
            this.lblTenkeyless.AutoSize = true;
            this.lblTenkeyless.BackColor = System.Drawing.Color.Transparent;
            this.lblTenkeyless.Font = new System.Drawing.Font("Microsoft Sans Serif", 33F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenkeyless.ForeColor = System.Drawing.Color.White;
            this.lblTenkeyless.Location = new System.Drawing.Point(351, 88);
            this.lblTenkeyless.Name = "lblTenkeyless";
            this.lblTenkeyless.Size = new System.Drawing.Size(285, 57);
            this.lblTenkeyless.TabIndex = 3;
            this.lblTenkeyless.Text = "Tenkeyless";
            // 
            // picBoxOpenTenkeyless
            // 
            this.picBoxOpenTenkeyless.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBoxOpenTenkeyless.Image = ((System.Drawing.Image)(resources.GetObject("picBoxOpenTenkeyless.Image")));
            this.picBoxOpenTenkeyless.Location = new System.Drawing.Point(151, 12);
            this.picBoxOpenTenkeyless.Name = "picBoxOpenTenkeyless";
            this.picBoxOpenTenkeyless.Size = new System.Drawing.Size(651, 201);
            this.picBoxOpenTenkeyless.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxOpenTenkeyless.TabIndex = 2;
            this.picBoxOpenTenkeyless.TabStop = false;
            this.picBoxOpenTenkeyless.MouseEnter += new System.EventHandler(this.btnOpenFullSize_MouseEnter);
            this.picBoxOpenTenkeyless.MouseLeave += new System.EventHandler(this.picBoxOpenFullSize_MouseLeave);
            // 
            // btnOpenFullSize
            // 
            this.btnOpenFullSize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(42)))), ((int)(((byte)(44)))));
            this.btnOpenFullSize.Controls.Add(this.lblFullSize);
            this.btnOpenFullSize.Controls.Add(this.picBoxOpenFullSize);
            this.btnOpenFullSize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpenFullSize.Location = new System.Drawing.Point(320, 493);
            this.btnOpenFullSize.Name = "btnOpenFullSize";
            this.btnOpenFullSize.Size = new System.Drawing.Size(960, 227);
            this.btnOpenFullSize.TabIndex = 18;
            this.btnOpenFullSize.Visible = false;
            this.btnOpenFullSize.Click += new System.EventHandler(this.picBoxOpenFullSize_Click);
            // 
            // lblFullSize
            // 
            this.lblFullSize.AutoSize = true;
            this.lblFullSize.BackColor = System.Drawing.Color.Transparent;
            this.lblFullSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 33F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFullSize.ForeColor = System.Drawing.Color.White;
            this.lblFullSize.Location = new System.Drawing.Point(388, 96);
            this.lblFullSize.Name = "lblFullSize";
            this.lblFullSize.Size = new System.Drawing.Size(203, 57);
            this.lblFullSize.TabIndex = 1;
            this.lblFullSize.Text = "Fullsize";
            this.lblFullSize.Click += new System.EventHandler(this.picBoxOpenFullSize_Click);
            // 
            // SelectKeyboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(42)))), ((int)(((byte)(44)))));
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.btnOpenFullSize);
            this.Controls.Add(this.btnOpenTenkeyless);
            this.Controls.Add(this.btnOpenCompacto);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "SelectKeyboard";
            this.Text = "SelecionarTeclado";
            this.Controls.SetChildIndex(this.pnlArquivos, 0);
            this.Controls.SetChildIndex(this.btnOpenCompacto, 0);
            this.Controls.SetChildIndex(this.btnOpenTenkeyless, 0);
            this.Controls.SetChildIndex(this.btnOpenFullSize, 0);
            ((System.ComponentModel.ISupportInitialize)(this.btnMax)).EndInit();
            this.btnOpenCompacto.ResumeLayout(false);
            this.btnOpenCompacto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxCompacto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxOpenFullSize)).EndInit();
            this.btnOpenTenkeyless.ResumeLayout(false);
            this.btnOpenTenkeyless.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxOpenTenkeyless)).EndInit();
            this.btnOpenFullSize.ResumeLayout(false);
            this.btnOpenFullSize.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel btnOpenCompacto;
        private System.Windows.Forms.Panel btnOpenTenkeyless;
        private System.Windows.Forms.Panel btnOpenFullSize;
        private System.Windows.Forms.PictureBox picBoxOpenFullSize;
        private System.Windows.Forms.Label lblFullSize;
        private System.Windows.Forms.Label lblTenkeyless;
        private System.Windows.Forms.PictureBox picBoxOpenTenkeyless;
        private System.Windows.Forms.Label lblCompacto;
        private System.Windows.Forms.PictureBox picBoxCompacto;
    }
}