namespace AcroniUI
{
    partial class CollectionSelected
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
            this.alblMinhaGaleria = new System.Windows.Forms.Label();
            this.lblCollectionName = new System.Windows.Forms.Label();
            this.lblKeyboardsNumber = new System.Windows.Forms.Label();
            this.pnlWithKeyboards = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // alblMinhaGaleria
            // 
            this.alblMinhaGaleria.AutoSize = true;
            this.alblMinhaGaleria.Font = new System.Drawing.Font("Open Sans SemiBold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alblMinhaGaleria.ForeColor = System.Drawing.Color.White;
            this.alblMinhaGaleria.Location = new System.Drawing.Point(672, 97);
            this.alblMinhaGaleria.Name = "alblMinhaGaleria";
            this.alblMinhaGaleria.Size = new System.Drawing.Size(192, 33);
            this.alblMinhaGaleria.TabIndex = 15;
            this.alblMinhaGaleria.Text = "Minha Galeria •";
            // 
            // lblCollectionName
            // 
            this.lblCollectionName.AutoSize = true;
            this.lblCollectionName.Font = new System.Drawing.Font("Open Sans ExtraBold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCollectionName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(160)))), ((int)(((byte)(69)))));
            this.lblCollectionName.Location = new System.Drawing.Point(857, 97);
            this.lblCollectionName.Name = "lblCollectionName";
            this.lblCollectionName.Size = new System.Drawing.Size(69, 33);
            this.lblCollectionName.TabIndex = 16;
            this.lblCollectionName.Text = "JOOJ";
            // 
            // lblKeyboardsNumber
            // 
            this.lblKeyboardsNumber.AutoSize = true;
            this.lblKeyboardsNumber.Font = new System.Drawing.Font("Open Sans SemiBold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKeyboardsNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(114)))), ((int)(((byte)(123)))));
            this.lblKeyboardsNumber.Location = new System.Drawing.Point(721, 135);
            this.lblKeyboardsNumber.Name = "lblKeyboardsNumber";
            this.lblKeyboardsNumber.Size = new System.Drawing.Size(120, 30);
            this.lblKeyboardsNumber.TabIndex = 18;
            this.lblKeyboardsNumber.Text = "Teclado(s)";
            // 
            // pnlWithKeyboards
            // 
            this.pnlWithKeyboards.Location = new System.Drawing.Point(454, 200);
            this.pnlWithKeyboards.Name = "pnlWithKeyboards";
            this.pnlWithKeyboards.Size = new System.Drawing.Size(826, 459);
            this.pnlWithKeyboards.TabIndex = 19;
            // 
            // CollectionSelected
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.pnlWithKeyboards);
            this.Controls.Add(this.lblKeyboardsNumber);
            this.Controls.Add(this.lblCollectionName);
            this.Controls.Add(this.alblMinhaGaleria);
            this.Name = "CollectionSelected";
            this.Text = "CollectionSelected";
            this.Controls.SetChildIndex(this.alblMinhaGaleria, 0);
            this.Controls.SetChildIndex(this.lblCollectionName, 0);
            this.Controls.SetChildIndex(this.lblKeyboardsNumber, 0);
            this.Controls.SetChildIndex(this.pnlWithKeyboards, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label alblMinhaGaleria;
        private System.Windows.Forms.Label lblCollectionName;
        private System.Windows.Forms.Label lblKeyboardsNumber;
        private System.Windows.Forms.Panel pnlWithKeyboards;
    }
}