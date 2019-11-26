namespace AcroniControls
{
    partial class AcroniMessageBoxConfirm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.alblMessage2 = new System.Windows.Forms.Label();
            this.alblMessage1 = new System.Windows.Forms.Label();
            this.btnNo = new System.Windows.Forms.Button();
            this.btnYes = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(146)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.alblMessage2);
            this.panel1.Controls.Add(this.alblMessage1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(529, 150);
            this.panel1.TabIndex = 2;
            // 
            // alblMessage2
            // 
            this.alblMessage2.Font = new System.Drawing.Font("Open Sans", 12.5F);
            this.alblMessage2.ForeColor = System.Drawing.Color.White;
            this.alblMessage2.Location = new System.Drawing.Point(51, 100);
            this.alblMessage2.Name = "alblMessage2";
            this.alblMessage2.Size = new System.Drawing.Size(416, 42);
            this.alblMessage2.TabIndex = 0;
            this.alblMessage2.Text = "I dislike life as a experiente in general";
            this.alblMessage2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // alblMessage1
            // 
            this.alblMessage1.Font = new System.Drawing.Font("Open Sans", 17F, System.Drawing.FontStyle.Bold);
            this.alblMessage1.ForeColor = System.Drawing.Color.White;
            this.alblMessage1.Location = new System.Drawing.Point(0, 42);
            this.alblMessage1.Name = "alblMessage1";
            this.alblMessage1.Size = new System.Drawing.Size(516, 58);
            this.alblMessage1.TabIndex = 0;
            this.alblMessage1.Text = "What keeps you moving on?";
            this.alblMessage1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNo
            // 
            this.btnNo.BackColor = System.Drawing.Color.Transparent;
            this.btnNo.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnNo.FlatAppearance.BorderSize = 0;
            this.btnNo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(54)))), ((int)(((byte)(63)))));
            this.btnNo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(54)))), ((int)(((byte)(63)))));
            this.btnNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNo.Font = new System.Drawing.Font("Open Sans", 12.5F);
            this.btnNo.ForeColor = System.Drawing.Color.White;
            this.btnNo.Location = new System.Drawing.Point(118, 235);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(99, 41);
            this.btnNo.TabIndex = 3;
            this.btnNo.Text = "Cancelar";
            this.btnNo.UseVisualStyleBackColor = false;
            this.btnNo.Click += new System.EventHandler(this.btnCancela_Click);
            this.btnNo.MouseLeave += new System.EventHandler(this.btnCancela_MouseLeave);
            this.btnNo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnCancela_MouseMove);
            // 
            // btnYes
            // 
            this.btnYes.BackgroundImage = global::AcroniControls.Properties.Resources.fundo_botao;
            this.btnYes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnYes.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnYes.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(54)))), ((int)(((byte)(63)))));
            this.btnYes.FlatAppearance.BorderSize = 0;
            this.btnYes.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(54)))), ((int)(((byte)(63)))));
            this.btnYes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(54)))), ((int)(((byte)(63)))));
            this.btnYes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(54)))), ((int)(((byte)(63)))));
            this.btnYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYes.Font = new System.Drawing.Font("Open Sans SemiBold", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnYes.ForeColor = System.Drawing.Color.White;
            this.btnYes.Location = new System.Drawing.Point(296, 226);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(153, 58);
            this.btnYes.TabIndex = 6;
            this.btnYes.Text = "Sim!";
            this.btnYes.UseVisualStyleBackColor = true;
            this.btnYes.MouseEnter += new System.EventHandler(this.btnOk_MouseEnter);
            this.btnYes.MouseLeave += new System.EventHandler(this.btnOk_MouseLeave);
            // 
            // AcroniMessageBoxConfirm
            // 
            this.AcceptButton = this.btnYes;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(54)))), ((int)(((byte)(63)))));
            this.ClientSize = new System.Drawing.Size(529, 361);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AcroniMessageBoxConfirm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AcroniMessageBox";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label alblMessage2;
        private System.Windows.Forms.Label alblMessage1;
        private System.Windows.Forms.Button btnNo;
        private System.Windows.Forms.Button btnYes;
    }
}