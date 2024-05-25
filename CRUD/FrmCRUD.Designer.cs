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
            lstVisor = new ListBox();
            lblTipo = new Label();
            lblFabricante = new Label();
            lblModelo = new Label();
            lblNumeroSerie = new Label();
            lblPeso = new Label();
            lblCalibre = new Label();
            lblPrecio = new Label();
            mnuMenuPrincipal = new MenuStrip();
            mnuBtnAgregar = new ToolStripMenuItem();
            mnuBtnPistola = new ToolStripMenuItem();
            mnuBtnFusil = new ToolStripMenuItem();
            mnuBtnEscopeta = new ToolStripMenuItem();
            mnuBtnModificar = new ToolStripMenuItem();
            mnuBtnEliminar = new ToolStripMenuItem();
            mnuBtnVerDetalles = new ToolStripMenuItem();
            toolStripTextBox1 = new ToolStripTextBox();
            mnuMenuPrincipal.SuspendLayout();
            SuspendLayout();
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
            lstVisor.Size = new Size(1020, 404);
            lstVisor.TabIndex = 9;
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
            lblPeso.Size = new Size(88, 17);
            lblPeso.TabIndex = 15;
            lblPeso.Text = "Peso Total";
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
            // mnuMenuPrincipal
            // 
            mnuMenuPrincipal.BackColor = Color.FromArgb(150, 150, 165);
            mnuMenuPrincipal.Items.AddRange(new ToolStripItem[] { mnuBtnAgregar, mnuBtnModificar, mnuBtnEliminar, mnuBtnVerDetalles, toolStripTextBox1 });
            mnuMenuPrincipal.Location = new Point(0, 0);
            mnuMenuPrincipal.Name = "mnuMenuPrincipal";
            mnuMenuPrincipal.Size = new Size(1044, 24);
            mnuMenuPrincipal.TabIndex = 18;
            mnuMenuPrincipal.Text = "Menu principal";
            // 
            // mnuBtnAgregar
            // 
            mnuBtnAgregar.BackColor = Color.FromArgb(150, 150, 165);
            mnuBtnAgregar.DropDownItems.AddRange(new ToolStripItem[] { mnuBtnPistola, mnuBtnFusil, mnuBtnEscopeta });
            mnuBtnAgregar.ForeColor = Color.Black;
            mnuBtnAgregar.Name = "mnuBtnAgregar";
            mnuBtnAgregar.Size = new Size(93, 20);
            mnuBtnAgregar.Text = "Agregar Arma";
            // 
            // mnuBtnPistola
            // 
            mnuBtnPistola.BackColor = Color.FromArgb(150, 150, 165);
            mnuBtnPistola.ForeColor = Color.Black;
            mnuBtnPistola.Name = "mnuBtnPistola";
            mnuBtnPistola.Size = new Size(198, 22);
            mnuBtnPistola.Text = "Pistola Semiautomática";
            mnuBtnPistola.Click += mnuBtnPistola_Click;
            // 
            // mnuBtnFusil
            // 
            mnuBtnFusil.BackColor = Color.FromArgb(150, 150, 165);
            mnuBtnFusil.ForeColor = Color.Black;
            mnuBtnFusil.Name = "mnuBtnFusil";
            mnuBtnFusil.Size = new Size(198, 22);
            mnuBtnFusil.Text = "Fusil de asalto";
            mnuBtnFusil.Click += mnuBtnFusil_Click;
            // 
            // mnuBtnEscopeta
            // 
            mnuBtnEscopeta.BackColor = Color.FromArgb(150, 150, 165);
            mnuBtnEscopeta.ForeColor = Color.Black;
            mnuBtnEscopeta.Name = "mnuBtnEscopeta";
            mnuBtnEscopeta.Size = new Size(198, 22);
            mnuBtnEscopeta.Text = "Escopeta";
            mnuBtnEscopeta.Click += mnuBtnEscopeta_Click;
            // 
            // mnuBtnModificar
            // 
            mnuBtnModificar.ForeColor = Color.Black;
            mnuBtnModificar.Name = "mnuBtnModificar";
            mnuBtnModificar.Size = new Size(70, 20);
            mnuBtnModificar.Text = "Modificar";
            mnuBtnModificar.Click += mnuBtnModificar_Click;
            // 
            // mnuBtnEliminar
            // 
            mnuBtnEliminar.ForeColor = Color.Black;
            mnuBtnEliminar.Name = "mnuBtnEliminar";
            mnuBtnEliminar.Size = new Size(62, 20);
            mnuBtnEliminar.Text = "Eliminar";
            mnuBtnEliminar.Click += mnuBtnEliminar_Click;
            // 
            // mnuBtnVerDetalles
            // 
            mnuBtnVerDetalles.ForeColor = Color.Black;
            mnuBtnVerDetalles.Name = "mnuBtnVerDetalles";
            mnuBtnVerDetalles.Size = new Size(78, 20);
            mnuBtnVerDetalles.Text = "Ver detalles";
            mnuBtnVerDetalles.Click += mnuBtnVerDetalles_Click;
            // 
            // toolStripTextBox1
            // 
            toolStripTextBox1.Alignment = ToolStripItemAlignment.Right;
            toolStripTextBox1.BackColor = Color.FromArgb(150, 150, 165);
            toolStripTextBox1.BorderStyle = BorderStyle.None;
            toolStripTextBox1.ForeColor = Color.Black;
            toolStripTextBox1.Name = "toolStripTextBox1";
            toolStripTextBox1.ReadOnly = true;
            toolStripTextBox1.Size = new Size(100, 20);
            toolStripTextBox1.Text = "datos-usuario";
            // 
            // FrmCRUD
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(38, 40, 51);
            ClientSize = new Size(1044, 495);
            Controls.Add(lblPrecio);
            Controls.Add(lblCalibre);
            Controls.Add(lblPeso);
            Controls.Add(lblNumeroSerie);
            Controls.Add(lblModelo);
            Controls.Add(lblFabricante);
            Controls.Add(lblTipo);
            Controls.Add(lstVisor);
            Controls.Add(mnuMenuPrincipal);
            ForeColor = SystemColors.ButtonFace;
            MainMenuStrip = mnuMenuPrincipal;
            Name = "FrmCRUD";
            Text = "Principal";
            mnuMenuPrincipal.ResumeLayout(false);
            mnuMenuPrincipal.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ListBox lstVisor;
        private Label lblTipo;
        private Label lblFabricante;
        private Label lblModelo;
        private Label lblNumeroSerie;
        private Label lblPeso;
        private Label lblCalibre;
        private Label lblPrecio;
        private MenuStrip mnuMenuPrincipal;
        private ToolStripMenuItem mnuBtnAgregar;
        private ToolStripMenuItem mnuBtnPistola;
        private ToolStripMenuItem mnuBtnFusil;
        private ToolStripMenuItem mnuBtnEscopeta;
        private ToolStripMenuItem mnuBtnModificar;
        private ToolStripMenuItem mnuBtnEliminar;
        private ToolStripMenuItem mnuBtnVerDetalles;
        private ToolStripTextBox toolStripTextBox1;
    }
}