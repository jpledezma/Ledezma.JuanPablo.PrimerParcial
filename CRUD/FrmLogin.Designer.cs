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
            btnLimpiar = new Button();
            btnAutocompletar = new Button();
            SuspendLayout();
            // 
            // txtUsuario
            // 
            txtUsuario.BackColor = Color.FromArgb(224, 242, 241);
            txtUsuario.Location = new Point(102, 165);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(141, 23);
            txtUsuario.TabIndex = 0;
            // 
            // txtClave
            // 
            txtClave.BackColor = Color.FromArgb(224, 242, 241);
            txtClave.Location = new Point(102, 236);
            txtClave.Name = "txtClave";
            txtClave.PasswordChar = '*';
            txtClave.Size = new Size(141, 23);
            txtClave.TabIndex = 1;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitulo.ForeColor = Color.FromArgb(225, 225, 225);
            lblTitulo.Location = new Point(35, 52);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(292, 64);
            lblTitulo.TabIndex = 2;
            lblTitulo.Text = "Armería\r\n\"Dos tiros de un pájaro\"";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblUsuario.ForeColor = Color.FromArgb(225, 225, 225);
            lblUsuario.Location = new Point(102, 141);
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
            lblClave.Location = new Point(102, 212);
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
            btnIngresar.Location = new Point(116, 281);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(116, 37);
            btnIngresar.TabIndex = 5;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = false;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.FromArgb(2, 118, 170);
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnLimpiar.ForeColor = Color.FromArgb(240, 240, 240);
            btnLimpiar.Location = new Point(116, 333);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(116, 37);
            btnLimpiar.TabIndex = 6;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnAutocompletar
            // 
            btnAutocompletar.BackColor = Color.FromArgb(2, 118, 170);
            btnAutocompletar.FlatStyle = FlatStyle.Flat;
            btnAutocompletar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnAutocompletar.ForeColor = Color.FromArgb(240, 240, 240);
            btnAutocompletar.Location = new Point(116, 385);
            btnAutocompletar.Name = "btnAutocompletar";
            btnAutocompletar.Size = new Size(116, 37);
            btnAutocompletar.TabIndex = 7;
            btnAutocompletar.Text = "Autocompletar";
            btnAutocompletar.UseVisualStyleBackColor = false;
            btnAutocompletar.Click += btnAutocompletar_Click;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(38, 40, 51);
            ClientSize = new Size(385, 456);
            Controls.Add(btnAutocompletar);
            Controls.Add(btnLimpiar);
            Controls.Add(btnIngresar);
            Controls.Add(lblClave);
            Controls.Add(lblUsuario);
            Controls.Add(lblTitulo);
            Controls.Add(txtClave);
            Controls.Add(txtUsuario);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
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
        private Button btnLimpiar;
        private Button btnAutocompletar;
    }
}
