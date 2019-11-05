namespace AcroniUI
{
    partial class MinhaConta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MinhaConta));
            this.apnlCPF = new System.Windows.Forms.Panel();
            this.txtCPF = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.apnlNome = new System.Windows.Forms.Panel();
            this.txtNome = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtEmail = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnAlterarPlano = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlUserImg = new System.Windows.Forms.Panel();
            this.pnlEscurecerImg = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.eBtnSave = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.ePnlUserImg = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.apnlEmail = new System.Windows.Forms.Panel();
            this.txtCEP = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtPass = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.ebtnAlterarPlano = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtUser = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.apnlCPF.SuspendLayout();
            this.apnlNome.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.pnlUserImg.SuspendLayout();
            this.pnlEscurecerImg.SuspendLayout();
            this.apnlEmail.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // apnlCPF
            // 
            this.apnlCPF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(56)))), ((int)(((byte)(62)))));
            this.apnlCPF.Controls.Add(this.txtCPF);
            this.apnlCPF.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(98)))), ((int)(((byte)(98)))));
            this.apnlCPF.Location = new System.Drawing.Point(430, 226);
            this.apnlCPF.Name = "apnlCPF";
            this.apnlCPF.Size = new System.Drawing.Size(306, 50);
            this.apnlCPF.TabIndex = 99;
            // 
            // txtCPF
            // 
            this.txtCPF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(56)))), ((int)(((byte)(62)))));
            this.txtCPF.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCPF.Font = new System.Drawing.Font("Open Sans", 10F, System.Drawing.FontStyle.Bold);
            this.txtCPF.ForeColor = System.Drawing.Color.White;
            this.txtCPF.HintForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(118)))), ((int)(((byte)(125)))));
            this.txtCPF.HintText = "Seu CPF";
            this.txtCPF.isPassword = false;
            this.txtCPF.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(56)))), ((int)(((byte)(62)))));
            this.txtCPF.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(56)))), ((int)(((byte)(62)))));
            this.txtCPF.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(56)))), ((int)(((byte)(62)))));
            this.txtCPF.LineThickness = 3;
            this.txtCPF.Location = new System.Drawing.Point(4, 3);
            this.txtCPF.Margin = new System.Windows.Forms.Padding(4);
            this.txtCPF.Name = "txtCPF";
            this.txtCPF.Size = new System.Drawing.Size(297, 44);
            this.txtCPF.TabIndex = 1;
            this.txtCPF.Tag = "cpf";
            this.txtCPF.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtCPF.OnValueChanged += new System.EventHandler(this.txtBoxMyAccount_MouseLeave);
            // 
            // apnlNome
            // 
            this.apnlNome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(56)))), ((int)(((byte)(62)))));
            this.apnlNome.Controls.Add(this.txtNome);
            this.apnlNome.Location = new System.Drawing.Point(430, 150);
            this.apnlNome.Name = "apnlNome";
            this.apnlNome.Size = new System.Drawing.Size(306, 50);
            this.apnlNome.TabIndex = 95;
            // 
            // txtNome
            // 
            this.txtNome.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.txtNome.AllowDrop = true;
            this.txtNome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(56)))), ((int)(((byte)(62)))));
            this.txtNome.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNome.Font = new System.Drawing.Font("Open Sans", 10F, System.Drawing.FontStyle.Bold);
            this.txtNome.ForeColor = System.Drawing.Color.White;
            this.txtNome.HintForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(118)))), ((int)(((byte)(125)))));
            this.txtNome.HintText = "Nome completo";
            this.txtNome.isPassword = false;
            this.txtNome.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(56)))), ((int)(((byte)(62)))));
            this.txtNome.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(56)))), ((int)(((byte)(62)))));
            this.txtNome.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(56)))), ((int)(((byte)(62)))));
            this.txtNome.LineThickness = 15555;
            this.txtNome.Location = new System.Drawing.Point(4, 3);
            this.txtNome.Margin = new System.Windows.Forms.Padding(4);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(298, 44);
            this.txtNome.TabIndex = 0;
            this.txtNome.Tag = "nome";
            this.txtNome.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtNome.OnValueChanged += new System.EventHandler(this.txtBoxMyAccount_MouseLeave);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(427, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 19);
            this.label1.TabIndex = 101;
            this.label1.Text = "Informações básicas";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(427, 382);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 27);
            this.label2.TabIndex = 101;
            this.label2.Text = "Credenciais";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(56)))), ((int)(((byte)(62)))));
            this.panel4.Controls.Add(this.txtEmail);
            this.panel4.Location = new System.Drawing.Point(429, 437);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(306, 50);
            this.panel4.TabIndex = 102;
            // 
            // txtEmail
            // 
            this.txtEmail.AllowDrop = true;
            this.txtEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(56)))), ((int)(((byte)(62)))));
            this.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmail.Font = new System.Drawing.Font("Open Sans", 10F, System.Drawing.FontStyle.Bold);
            this.txtEmail.ForeColor = System.Drawing.Color.White;
            this.txtEmail.HintForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(118)))), ((int)(((byte)(125)))));
            this.txtEmail.HintText = "Email";
            this.txtEmail.isPassword = false;
            this.txtEmail.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(56)))), ((int)(((byte)(62)))));
            this.txtEmail.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(56)))), ((int)(((byte)(62)))));
            this.txtEmail.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(56)))), ((int)(((byte)(62)))));
            this.txtEmail.LineThickness = 3;
            this.txtEmail.Location = new System.Drawing.Point(4, 3);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(298, 44);
            this.txtEmail.TabIndex = 0;
            this.txtEmail.Tag = "email";
            this.txtEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtEmail.OnValueChanged += new System.EventHandler(this.txtBoxMyAccount_MouseLeave);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            this.panel5.Controls.Add(this.btnAlterarPlano);
            this.panel5.Controls.Add(this.label8);
            this.panel5.Controls.Add(this.label7);
            this.panel5.Controls.Add(this.label6);
            this.panel5.Controls.Add(this.pnlUserImg);
            this.panel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(111)))), ((int)(((byte)(119)))));
            this.panel5.Location = new System.Drawing.Point(813, 100);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(415, 472);
            this.panel5.TabIndex = 108;
            // 
            // btnAlterarPlano
            // 
            this.btnAlterarPlano.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(51)))), ((int)(((byte)(58)))));
            this.btnAlterarPlano.FlatAppearance.BorderSize = 0;
            this.btnAlterarPlano.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(51)))), ((int)(((byte)(57)))));
            this.btnAlterarPlano.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(51)))), ((int)(((byte)(57)))));
            this.btnAlterarPlano.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlterarPlano.Font = new System.Drawing.Font("Open Sans SemiBold", 11F, System.Drawing.FontStyle.Bold);
            this.btnAlterarPlano.ForeColor = System.Drawing.Color.White;
            this.btnAlterarPlano.Location = new System.Drawing.Point(90, 405);
            this.btnAlterarPlano.Name = "btnAlterarPlano";
            this.btnAlterarPlano.Size = new System.Drawing.Size(235, 38);
            this.btnAlterarPlano.TabIndex = 109;
            this.btnAlterarPlano.Text = "Alterar plano";
            this.btnAlterarPlano.UseVisualStyleBackColor = false;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Open Sans", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(111)))), ((int)(((byte)(119)))));
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(0, 305);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(100, 0, 0, 0);
            this.label8.Size = new System.Drawing.Size(415, 65);
            this.label8.TabIndex = 110;
            this.label8.Text = "• Teclados limitados (até 5)\r\n• Coleções limitadas (no máximo 1)\r\n• Registro de 1" +
    " cartão de crédito";
            this.label8.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Open Sans", 10.75F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(111)))), ((int)(((byte)(119)))));
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(0, 254);
            this.label7.Margin = new System.Windows.Forms.Padding(0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(415, 26);
            this.label7.TabIndex = 105;
            this.label7.Text = "Você está usando o seguinte plano:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Open Sans", 11.75F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(2, 276);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(415, 28);
            this.label6.TabIndex = 104;
            this.label6.Text = "Básico";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlUserImg
            // 
            this.pnlUserImg.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlUserImg.BackgroundImage")));
            this.pnlUserImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlUserImg.Controls.Add(this.pnlEscurecerImg);
            this.pnlUserImg.Location = new System.Drawing.Point(117, 36);
            this.pnlUserImg.Margin = new System.Windows.Forms.Padding(0);
            this.pnlUserImg.Name = "pnlUserImg";
            this.pnlUserImg.Size = new System.Drawing.Size(180, 180);
            this.pnlUserImg.Tag = "imagem_cliente";
            this.pnlUserImg.TabIndex = 111;
            this.pnlUserImg.MouseEnter += new System.EventHandler(this.pnlUserImg_MouseEnter);
            // 
            // pnlEscurecerImg
            // 
            this.pnlEscurecerImg.BackColor = System.Drawing.Color.Black;
            this.pnlEscurecerImg.Controls.Add(this.label3);
            this.pnlEscurecerImg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlEscurecerImg.Location = new System.Drawing.Point(0, 0);
            this.pnlEscurecerImg.Name = "pnlEscurecerImg";
            this.pnlEscurecerImg.Size = new System.Drawing.Size(180, 180);
            this.pnlEscurecerImg.TabIndex = 0;
            this.pnlEscurecerImg.Click += new System.EventHandler(this.AlterarImagem);
            this.pnlEscurecerImg.MouseEnter += new System.EventHandler(this.pnlEscurecerImg_MouseEnter);
            this.pnlEscurecerImg.MouseLeave += new System.EventHandler(this.pnlEscurecerImg_MouseLeave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Open Sans", 11.75F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(24, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 22);
            this.label3.TabIndex = 112;
            this.label3.Text = "Alterar imagem";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.Click += new System.EventHandler(this.AlterarImagem);
            this.label3.MouseEnter += new System.EventHandler(this.pnlEscurecerImg_MouseEnter);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(40)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Open Sans SemiBold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSave.Location = new System.Drawing.Point(993, 627);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(189, 55);
            this.btnSave.TabIndex = 110;
            this.btnSave.Tag = "Dont handler";
            this.btnSave.Text = "Salvo";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // eBtnSave
            // 
            this.eBtnSave.ElipseRadius = 5;
            this.eBtnSave.TargetControl = this.btnSave;
            // 
            // ePnlUserImg
            // 
            this.ePnlUserImg.ElipseRadius = 250;
            this.ePnlUserImg.TargetControl = this.pnlUserImg;
            // 
            // apnlEmail
            // 
            this.apnlEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(56)))), ((int)(((byte)(62)))));
            this.apnlEmail.Controls.Add(this.txtCEP);
            this.apnlEmail.Location = new System.Drawing.Point(430, 297);
            this.apnlEmail.Name = "apnlEmail";
            this.apnlEmail.Size = new System.Drawing.Size(306, 50);
            this.apnlEmail.TabIndex = 112;
            // 
            // txtCEP
            // 
            this.txtCEP.AccessibleDescription = "Validated";
            this.txtCEP.AllowDrop = true;
            this.txtCEP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(56)))), ((int)(((byte)(62)))));
            this.txtCEP.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCEP.Font = new System.Drawing.Font("Open Sans", 10F, System.Drawing.FontStyle.Bold);
            this.txtCEP.ForeColor = System.Drawing.Color.White;
            this.txtCEP.HintForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(118)))), ((int)(((byte)(125)))));
            this.txtCEP.HintText = "CEP";
            this.txtCEP.isPassword = false;
            this.txtCEP.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(56)))), ((int)(((byte)(62)))));
            this.txtCEP.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(56)))), ((int)(((byte)(62)))));
            this.txtCEP.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(56)))), ((int)(((byte)(62)))));
            this.txtCEP.LineThickness = 3;
            this.txtCEP.Location = new System.Drawing.Point(4, 3);
            this.txtCEP.Margin = new System.Windows.Forms.Padding(4);
            this.txtCEP.Name = "txtCEP";
            this.txtCEP.Size = new System.Drawing.Size(298, 44);
            this.txtCEP.TabIndex = 0;
            this.txtCEP.Tag = "cep";
            this.txtCEP.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtCEP.OnValueChanged += new System.EventHandler(this.txtBoxMyAccount_MouseLeave);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(56)))), ((int)(((byte)(62)))));
            this.panel2.Controls.Add(this.txtPass);
            this.panel2.Location = new System.Drawing.Point(429, 574);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(306, 50);
            this.panel2.TabIndex = 114;
            // 
            // txtPass
            // 
            this.txtPass.AccessibleDescription = "Validated";
            this.txtPass.AllowDrop = true;
            this.txtPass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(56)))), ((int)(((byte)(62)))));
            this.txtPass.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPass.Font = new System.Drawing.Font("Open Sans", 10F, System.Drawing.FontStyle.Bold);
            this.txtPass.ForeColor = System.Drawing.Color.White;
            this.txtPass.HintForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(118)))), ((int)(((byte)(125)))));
            this.txtPass.HintText = "Senha";
            this.txtPass.isPassword = false;
            this.txtPass.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(56)))), ((int)(((byte)(62)))));
            this.txtPass.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(56)))), ((int)(((byte)(62)))));
            this.txtPass.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(56)))), ((int)(((byte)(62)))));
            this.txtPass.LineThickness = 3;
            this.txtPass.Location = new System.Drawing.Point(4, 3);
            this.txtPass.Margin = new System.Windows.Forms.Padding(4);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(298, 44);
            this.txtPass.TabIndex = 0;
            this.txtPass.Tag = "senha";
            this.txtPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPass.OnValueChanged += new System.EventHandler(this.txtBoxMyAccount_MouseLeave);
            // 
            // ebtnAlterarPlano
            // 
            this.ebtnAlterarPlano.ElipseRadius = 5;
            this.ebtnAlterarPlano.TargetControl = this.btnAlterarPlano;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(56)))), ((int)(((byte)(62)))));
            this.panel3.Controls.Add(this.txtUser);
            this.panel3.Location = new System.Drawing.Point(429, 507);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(306, 50);
            this.panel3.TabIndex = 115;
            // 
            // txtUser
            // 
            this.txtUser.AllowDrop = true;
            this.txtUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(56)))), ((int)(((byte)(62)))));
            this.txtUser.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUser.Font = new System.Drawing.Font("Open Sans", 10F, System.Drawing.FontStyle.Bold);
            this.txtUser.ForeColor = System.Drawing.Color.White;
            this.txtUser.HintForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(118)))), ((int)(((byte)(125)))));
            this.txtUser.HintText = "Nome de usuário";
            this.txtUser.isPassword = false;
            this.txtUser.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(56)))), ((int)(((byte)(62)))));
            this.txtUser.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(56)))), ((int)(((byte)(62)))));
            this.txtUser.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(56)))), ((int)(((byte)(62)))));
            this.txtUser.LineThickness = 3;
            this.txtUser.Location = new System.Drawing.Point(4, 3);
            this.txtUser.Margin = new System.Windows.Forms.Padding(4);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(298, 44);
            this.txtUser.TabIndex = 0;
            this.txtUser.Tag = "usuario";
            this.txtUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtUser.OnValueChanged += new System.EventHandler(this.txtBoxMyAccount_MouseLeave);
            // 
            // MinhaConta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(51)))), ((int)(((byte)(58)))));
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.apnlEmail);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.apnlCPF);
            this.Controls.Add(this.apnlNome);
            this.Name = "MinhaConta";
            this.Text = "MinhaConta";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MinhaConta_FormClosing);
            this.Controls.SetChildIndex(this.apnlNome, 0);
            this.Controls.SetChildIndex(this.apnlCPF, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.panel4, 0);
            this.Controls.SetChildIndex(this.panel5, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.apnlEmail, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.apnlCPF.ResumeLayout(false);
            this.apnlNome.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.pnlUserImg.ResumeLayout(false);
            this.pnlEscurecerImg.ResumeLayout(false);
            this.pnlEscurecerImg.PerformLayout();
            this.apnlEmail.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel apnlCPF;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtCPF;
        private System.Windows.Forms.Panel apnlNome;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtNome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtEmail;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnAlterarPlano;
        private System.Windows.Forms.Panel pnlUserImg;
        private System.Windows.Forms.Button btnSave;
        private Bunifu.Framework.UI.BunifuElipse eBtnSave;
        private Bunifu.Framework.UI.BunifuElipse ePnlUserImg;
        private System.Windows.Forms.Panel apnlEmail;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtCEP;
        private System.Windows.Forms.Panel panel2;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtPass;
        private Bunifu.Framework.UI.BunifuElipse ebtnAlterarPlano;
        private System.Windows.Forms.Panel panel3;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtUser;
        private System.Windows.Forms.Panel pnlEscurecerImg;
        private System.Windows.Forms.Label label3;
    }
}