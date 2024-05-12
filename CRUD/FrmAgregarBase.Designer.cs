namespace CRUD
{
    partial class FrmAgregarBase
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
            txtFabricante = new TextBox();
            lblFabricante = new Label();
            lblModelo = new Label();
            txtModelo = new TextBox();
            lblPrecio = new Label();
            txtPrecio = new TextBox();
            lblNumeroSerie = new Label();
            txtNumeroSerie = new TextBox();
            lblPeso = new Label();
            txtPeso = new TextBox();
            cboCalibre = new ComboBox();
            lblCalibre = new Label();
            label1 = new Label();
            chkAluminio = new CheckBox();
            chkAcero = new CheckBox();
            chkMadera = new CheckBox();
            chkPolimero = new CheckBox();
            btnAceptar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // txtFabricante
            // 
            txtFabricante.BackColor = Color.FromArgb(224, 242, 241);
            txtFabricante.Location = new Point(12, 33);
            txtFabricante.Name = "txtFabricante";
            txtFabricante.Size = new Size(161, 23);
            txtFabricante.TabIndex = 0;
            // 
            // lblFabricante
            // 
            lblFabricante.AutoSize = true;
            lblFabricante.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblFabricante.ForeColor = Color.FromArgb(225, 225, 225);
            lblFabricante.Location = new Point(12, 9);
            lblFabricante.Name = "lblFabricante";
            lblFabricante.Size = new Size(84, 20);
            lblFabricante.TabIndex = 4;
            lblFabricante.Text = "Fabricante:";
            // 
            // lblModelo
            // 
            lblModelo.AutoSize = true;
            lblModelo.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblModelo.ForeColor = Color.FromArgb(225, 225, 225);
            lblModelo.Location = new Point(12, 59);
            lblModelo.Name = "lblModelo";
            lblModelo.Size = new Size(66, 20);
            lblModelo.TabIndex = 6;
            lblModelo.Text = "Modelo:";
            // 
            // txtModelo
            // 
            txtModelo.BackColor = Color.FromArgb(224, 242, 241);
            txtModelo.Location = new Point(12, 83);
            txtModelo.Name = "txtModelo";
            txtModelo.Size = new Size(161, 23);
            txtModelo.TabIndex = 5;
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblPrecio.ForeColor = Color.FromArgb(225, 225, 225);
            lblPrecio.Location = new Point(12, 159);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(56, 20);
            lblPrecio.TabIndex = 8;
            lblPrecio.Text = "Precio:";
            // 
            // txtPrecio
            // 
            txtPrecio.BackColor = Color.FromArgb(224, 242, 241);
            txtPrecio.Location = new Point(12, 183);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(161, 23);
            txtPrecio.TabIndex = 7;
            // 
            // lblNumeroSerie
            // 
            lblNumeroSerie.AutoSize = true;
            lblNumeroSerie.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblNumeroSerie.ForeColor = Color.FromArgb(225, 225, 225);
            lblNumeroSerie.Location = new Point(12, 109);
            lblNumeroSerie.Name = "lblNumeroSerie";
            lblNumeroSerie.Size = new Size(127, 20);
            lblNumeroSerie.TabIndex = 10;
            lblNumeroSerie.Text = "Número de serie:";
            // 
            // txtNumeroSerie
            // 
            txtNumeroSerie.BackColor = Color.FromArgb(224, 242, 241);
            txtNumeroSerie.Location = new Point(12, 133);
            txtNumeroSerie.Name = "txtNumeroSerie";
            txtNumeroSerie.Size = new Size(161, 23);
            txtNumeroSerie.TabIndex = 9;
            // 
            // lblPeso
            // 
            lblPeso.AutoSize = true;
            lblPeso.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblPeso.ForeColor = Color.FromArgb(225, 225, 225);
            lblPeso.Location = new Point(12, 209);
            lblPeso.Name = "lblPeso";
            lblPeso.Size = new Size(75, 20);
            lblPeso.TabIndex = 12;
            lblPeso.Text = "Peso (kg):";
            // 
            // txtPeso
            // 
            txtPeso.BackColor = Color.FromArgb(224, 242, 241);
            txtPeso.Location = new Point(12, 233);
            txtPeso.Name = "txtPeso";
            txtPeso.Size = new Size(161, 23);
            txtPeso.TabIndex = 11;
            // 
            // cboCalibre
            // 
            cboCalibre.BackColor = Color.FromArgb(224, 242, 241);
            cboCalibre.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCalibre.FormattingEnabled = true;
            cboCalibre.Location = new Point(12, 282);
            cboCalibre.Name = "cboCalibre";
            cboCalibre.Size = new Size(161, 23);
            cboCalibre.TabIndex = 13;
            // 
            // lblCalibre
            // 
            lblCalibre.AutoSize = true;
            lblCalibre.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblCalibre.ForeColor = Color.FromArgb(225, 225, 225);
            lblCalibre.Location = new Point(12, 259);
            lblCalibre.Name = "lblCalibre";
            lblCalibre.Size = new Size(61, 20);
            lblCalibre.TabIndex = 14;
            lblCalibre.Text = "Calibre:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(225, 225, 225);
            label1.Location = new Point(12, 308);
            label1.Name = "label1";
            label1.Size = new Size(196, 20);
            label1.TabIndex = 15;
            label1.Text = "Materiales de construcción:";
            // 
            // chkAluminio
            // 
            chkAluminio.AutoSize = true;
            chkAluminio.ForeColor = SystemColors.ButtonFace;
            chkAluminio.Location = new Point(12, 356);
            chkAluminio.Name = "chkAluminio";
            chkAluminio.Size = new Size(75, 19);
            chkAluminio.TabIndex = 16;
            chkAluminio.Text = "Aluminio";
            chkAluminio.UseVisualStyleBackColor = true;
            // 
            // chkAcero
            // 
            chkAcero.AutoSize = true;
            chkAcero.ForeColor = SystemColors.ButtonFace;
            chkAcero.Location = new Point(12, 331);
            chkAcero.Name = "chkAcero";
            chkAcero.Size = new Size(57, 19);
            chkAcero.TabIndex = 17;
            chkAcero.Text = "Acero";
            chkAcero.UseVisualStyleBackColor = true;
            // 
            // chkMadera
            // 
            chkMadera.AutoSize = true;
            chkMadera.ForeColor = SystemColors.ButtonFace;
            chkMadera.Location = new Point(12, 381);
            chkMadera.Name = "chkMadera";
            chkMadera.Size = new Size(66, 19);
            chkMadera.TabIndex = 18;
            chkMadera.Text = "Madera";
            chkMadera.UseVisualStyleBackColor = true;
            // 
            // chkPolimero
            // 
            chkPolimero.AutoSize = true;
            chkPolimero.ForeColor = SystemColors.ButtonFace;
            chkPolimero.Location = new Point(13, 406);
            chkPolimero.Name = "chkPolimero";
            chkPolimero.Size = new Size(74, 19);
            chkPolimero.TabIndex = 19;
            chkPolimero.Text = "Polímero";
            chkPolimero.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            btnAceptar.BackColor = Color.FromArgb(2, 108, 155);
            btnAceptar.FlatAppearance.BorderSize = 0;
            btnAceptar.FlatStyle = FlatStyle.Flat;
            btnAceptar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnAceptar.ForeColor = Color.White;
            btnAceptar.Location = new Point(104, 445);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(78, 37);
            btnAceptar.TabIndex = 20;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = false;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.FromArgb(135, 15, 15);
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(249, 445);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(78, 37);
            btnCancelar.TabIndex = 21;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FrmAgregarBase
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(38, 40, 51);
            ClientSize = new Size(464, 501);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(chkPolimero);
            Controls.Add(chkMadera);
            Controls.Add(chkAcero);
            Controls.Add(chkAluminio);
            Controls.Add(label1);
            Controls.Add(lblCalibre);
            Controls.Add(cboCalibre);
            Controls.Add(lblPeso);
            Controls.Add(txtPeso);
            Controls.Add(lblNumeroSerie);
            Controls.Add(txtNumeroSerie);
            Controls.Add(lblPrecio);
            Controls.Add(txtPrecio);
            Controls.Add(lblModelo);
            Controls.Add(txtModelo);
            Controls.Add(lblFabricante);
            Controls.Add(txtFabricante);
            ForeColor = SystemColors.ButtonFace;
            Name = "FrmAgregarBase";
            Text = "FrmAgregarBase";
            Load += FrmAgregarBase_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtFabricante;
        private Label lblFabricante;
        private Label lblModelo;
        private TextBox txtModelo;
        private Label lblPrecio;
        private TextBox txtPrecio;
        private Label lblNumeroSerie;
        private TextBox txtNumeroSerie;
        private Label lblPeso;
        private TextBox txtPeso;
        private ComboBox cboCalibre;
        private Label lblCalibre;
        private Label label1;
        private CheckBox chkAluminio;
        private CheckBox chkAcero;
        private CheckBox chkMadera;
        private CheckBox chkPolimero;
        private Button btnAceptar;
        private Button btnCancelar;
    }
}