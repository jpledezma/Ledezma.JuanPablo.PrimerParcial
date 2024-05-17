namespace CRUD
{
    partial class FrmCRUD
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
            btnAgregar = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            lstVisor = new ListBox();
            btnDetalles = new Button();
            lblTipo = new Label();
            lblFabricante = new Label();
            lblModelo = new Label();
            lblNumeroSerie = new Label();
            lblPeso = new Label();
            lblCalibre = new Label();
            lblPrecio = new Label();
            SuspendLayout();
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.FromArgb(53, 122, 56);
            btnAgregar.FlatAppearance.BorderSize = 0;
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnAgregar.ForeColor = Color.White;
            btnAgregar.Location = new Point(34, 446);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(94, 37);
            btnAgregar.TabIndex = 6;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnModificar
            // 
            btnModificar.BackColor = Color.FromArgb(2, 108, 155);
            btnModificar.FlatAppearance.BorderSize = 0;
            btnModificar.FlatStyle = FlatStyle.Flat;
            btnModificar.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnModificar.ForeColor = Color.White;
            btnModificar.Location = new Point(180, 446);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(94, 37);
            btnModificar.TabIndex = 7;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = false;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.FromArgb(135, 15, 15);
            btnEliminar.FlatAppearance.BorderSize = 0;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(335, 446);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(94, 37);
            btnEliminar.TabIndex = 8;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            // 
            // lstVisor
            // 
            lstVisor.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lstVisor.BackColor = Color.FromArgb(15, 15, 15);
            lstVisor.Font = new Font("Cascadia Code", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lstVisor.ForeColor = Color.FromArgb(212, 189, 113);
            lstVisor.FormattingEnabled = true;
            lstVisor.ItemHeight = 16;
            lstVisor.Location = new Point(12, 56);
            lstVisor.Name = "lstVisor";
            lstVisor.Size = new Size(1108, 308);
            lstVisor.TabIndex = 9;
            // 
            // btnDetalles
            // 
            btnDetalles.BackColor = Color.FromArgb(2, 108, 155);
            btnDetalles.FlatAppearance.BorderSize = 0;
            btnDetalles.FlatStyle = FlatStyle.Flat;
            btnDetalles.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnDetalles.ForeColor = Color.White;
            btnDetalles.Location = new Point(964, 446);
            btnDetalles.Name = "btnDetalles";
            btnDetalles.Size = new Size(107, 37);
            btnDetalles.TabIndex = 10;
            btnDetalles.Text = "Ver detalles";
            btnDetalles.UseVisualStyleBackColor = false;
            btnDetalles.Click += btnDetalles_Click;
            // 
            // lblTipo
            // 
            lblTipo.AutoSize = true;
            lblTipo.Font = new Font("Cascadia Code SemiBold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblTipo.Location = new Point(12, 36);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(40, 17);
            lblTipo.TabIndex = 11;
            lblTipo.Text = "Tipo";
            // 
            // lblFabricante
            // 
            lblFabricante.AutoSize = true;
            lblFabricante.Font = new Font("Cascadia Code SemiBold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblFabricante.Location = new Point(207, 36);
            lblFabricante.Name = "lblFabricante";
            lblFabricante.Size = new Size(88, 17);
            lblFabricante.TabIndex = 12;
            lblFabricante.Text = "Fabricante";
            // 
            // lblModelo
            // 
            lblModelo.AutoSize = true;
            lblModelo.Font = new Font("Cascadia Code SemiBold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblModelo.Location = new Point(349, 36);
            lblModelo.Name = "lblModelo";
            lblModelo.Size = new Size(56, 17);
            lblModelo.TabIndex = 13;
            lblModelo.Text = "Modelo";
            // 
            // lblNumeroSerie
            // 
            lblNumeroSerie.AutoSize = true;
            lblNumeroSerie.Font = new Font("Cascadia Code SemiBold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblNumeroSerie.Location = new Point(483, 36);
            lblNumeroSerie.Name = "lblNumeroSerie";
            lblNumeroSerie.Size = new Size(128, 17);
            lblNumeroSerie.TabIndex = 14;
            lblNumeroSerie.Text = "Número de serie";
            // 
            // lblPeso
            // 
            lblPeso.AutoSize = true;
            lblPeso.Font = new Font("Cascadia Code SemiBold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblPeso.Location = new Point(626, 36);
            lblPeso.Name = "lblPeso";
            lblPeso.Size = new Size(80, 17);
            lblPeso.TabIndex = 15;
            lblPeso.Text = "Peso (Kg)";
            // 
            // lblCalibre
            // 
            lblCalibre.AutoSize = true;
            lblCalibre.Font = new Font("Cascadia Code SemiBold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblCalibre.Location = new Point(764, 36);
            lblCalibre.Name = "lblCalibre";
            lblCalibre.Size = new Size(64, 17);
            lblCalibre.TabIndex = 16;
            lblCalibre.Text = "Calibre";
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Font = new Font("Cascadia Code SemiBold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblPrecio.Location = new Point(907, 36);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(56, 17);
            lblPrecio.TabIndex = 17;
            lblPrecio.Text = "Precio";
            // 
            // FrmCRUD
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(38, 40, 51);
            ClientSize = new Size(1132, 495);
            Controls.Add(lblPrecio);
            Controls.Add(lblCalibre);
            Controls.Add(lblPeso);
            Controls.Add(lblNumeroSerie);
            Controls.Add(lblModelo);
            Controls.Add(lblFabricante);
            Controls.Add(lblTipo);
            Controls.Add(btnDetalles);
            Controls.Add(lstVisor);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnAgregar);
            ForeColor = SystemColors.ButtonFace;
            Name = "FrmCRUD";
            Text = "Principal";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAgregar;
        private Button btnModificar;
        private Button btnEliminar;
        private ListBox lstVisor;
        private Button btnDetalles;
        private Label lblTipo;
        private Label lblFabricante;
        private Label lblModelo;
        private Label lblNumeroSerie;
        private Label lblPeso;
        private Label lblCalibre;
        private Label lblPrecio;
    }
}