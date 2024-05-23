namespace CRUD
{
    partial class FrmLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtUsuario = new TextBox();
            txtClave = new TextBox();
            lblTitulo = new Label();
            lblUsuario = new Label();
            lblClave = new Label();
            btnIngresar = new Button();
            SuspendLayout();
            // 
            // txtUsuario
            // 
            txtUsuario.BackColor = Color.FromArgb(224, 242, 241);
            txtUsuario.Location = new Point(102, 188);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(141, 23);
            txtUsuario.TabIndex = 0;
            txtUsuario.Text = "admin@admin.com";
            // 
            // txtClave
            // 
            txtClave.BackColor = Color.FromArgb(224, 242, 241);
            txtClave.Location = new Point(102, 259);
            txtClave.Name = "txtClave";
            txtClave.PasswordChar = '*';
            txtClave.Size = new Size(141, 23);
            txtClave.TabIndex = 1;
            txtClave.Text = "12345678";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitulo.ForeColor = Color.FromArgb(225, 225, 225);
            lblTitulo.Location = new Point(77, 60);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(223, 32);
            lblTitulo.TabIndex = 2;
            lblTitulo.Text = "Armería Don Pepe";
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblUsuario.ForeColor = Color.FromArgb(225, 225, 225);
            lblUsuario.Location = new Point(102, 164);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(69, 21);
            lblUsuario.TabIndex = 3;
            lblUsuario.Text = "Usuario:";
            // 
            // lblClave
            // 
            lblClave.AutoSize = true;
            lblClave.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblClave.ForeColor = Color.FromArgb(225, 225, 225);
            lblClave.Location = new Point(102, 235);
            lblClave.Name = "lblClave";
            lblClave.Size = new Size(96, 21);
            lblClave.TabIndex = 4;
            lblClave.Text = "Contraseña:";
            // 
            // btnIngresar
            // 
            btnIngresar.BackColor = Color.FromArgb(2, 118, 170);
            btnIngresar.FlatStyle = FlatStyle.Flat;
            btnIngresar.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnIngresar.ForeColor = Color.FromArgb(240, 240, 240);
            btnIngresar.Location = new Point(126, 311);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(94, 37);
            btnIngresar.TabIndex = 5;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = false;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(38, 40, 51);
            ClientSize = new Size(385, 476);
            Controls.Add(btnIngresar);
            Controls.Add(lblClave);
            Controls.Add(lblUsuario);
            Controls.Add(lblTitulo);
            Controls.Add(txtClave);
            Controls.Add(txtUsuario);
            Name = "FrmLogin";
            Text = "Login";
            Load += FrmLogin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtUsuario;
        private TextBox txtClave;
        private Label lblTitulo;
        private Label lblUsuario;
        private Label lblClave;
        private Button btnIngresar;
    }
}
