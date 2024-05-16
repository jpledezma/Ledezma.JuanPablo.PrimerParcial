namespace CRUD
{
    partial class FrmAgregarFusil
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
            lblCapacidadCargador = new Label();
            txtCapacidadCargador = new TextBox();
            chkFrenoBoca = new CheckBox();
            chkMiraLaser = new CheckBox();
            chkMiraTelescopica = new CheckBox();
            chkLinterna = new CheckBox();
            chkCargadorTambor = new CheckBox();
            lblAccesorios = new Label();
            chkCulataPlegable = new CheckBox();
            chkCorrea = new CheckBox();
            chkBipode = new CheckBox();
            lblCadencia = new Label();
            txtCadencia = new TextBox();
            SuspendLayout();
            // 
            // cboCalibre
            // 
            cboCalibre.Items.AddRange(new object[] { EMunicion.ACP_380, EMunicion.ACP_45, EMunicion.AE_50, EMunicion.LC_45, EMunicion.LR_22, EMunicion.MAGNUM_44, EMunicion.MAGNUM_357, EMunicion.OTAN_5_56x45, EMunicion.PARABELLUM_9x19, EMunicion.REM_223, EMunicion.SOVIET_5_45X39, EMunicion.SOVIET_7_62X39, EMunicion.WIN_308, EMunicion.SHELL_12g, EMunicion.SHELL_10g, EMunicion.SHELL_20g, EMunicion.ACP_380, EMunicion.ACP_45, EMunicion.AE_50, EMunicion.LC_45, EMunicion.LR_22, EMunicion.MAGNUM_44, EMunicion.MAGNUM_357, EMunicion.OTAN_5_56x45, EMunicion.PARABELLUM_9x19, EMunicion.REM_223, EMunicion.SOVIET_5_45X39, EMunicion.SOVIET_7_62X39, EMunicion.WIN_308, EMunicion.SHELL_12g, EMunicion.SHELL_10g, EMunicion.SHELL_20g, EMunicion.ACP_380, EMunicion.ACP_45, EMunicion.AE_50, EMunicion.LC_45, EMunicion.LR_22, EMunicion.MAGNUM_44, EMunicion.MAGNUM_357, EMunicion.OTAN_5_56x45, EMunicion.PARABELLUM_9x19, EMunicion.REM_223, EMunicion.SOVIET_5_45X39, EMunicion.SOVIET_7_62X39, EMunicion.WIN_308, EMunicion.SHELL_12g, EMunicion.SHELL_10g, EMunicion.SHELL_20g });
            // 
            // lblCapacidadCargador
            // 
            lblCapacidadCargador.AutoSize = true;
            lblCapacidadCargador.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblCapacidadCargador.ForeColor = Color.FromArgb(225, 225, 225);
            lblCapacidadCargador.Location = new Point(230, 9);
            lblCapacidadCargador.Name = "lblCapacidadCargador";
            lblCapacidadCargador.Size = new Size(120, 40);
            lblCapacidadCargador.TabIndex = 39;
            lblCapacidadCargador.Text = "Capacidad del\r\ncargador (base):";
            // 
            // txtCapacidadCargador
            // 
            txtCapacidadCargador.BackColor = Color.FromArgb(224, 242, 241);
            txtCapacidadCargador.Location = new Point(230, 52);
            txtCapacidadCargador.Name = "txtCapacidadCargador";
            txtCapacidadCargador.Size = new Size(161, 23);
            txtCapacidadCargador.TabIndex = 10;
            // 
            // chkFrenoBoca
            // 
            chkFrenoBoca.AutoSize = true;
            chkFrenoBoca.ForeColor = SystemColors.ButtonFace;
            chkFrenoBoca.Location = new Point(230, 250);
            chkFrenoBoca.Name = "chkFrenoBoca";
            chkFrenoBoca.Size = new Size(101, 19);
            chkFrenoBoca.TabIndex = 16;
            chkFrenoBoca.Text = "Freno de boca";
            chkFrenoBoca.UseVisualStyleBackColor = true;
            // 
            // chkMiraLaser
            // 
            chkMiraLaser.AutoSize = true;
            chkMiraLaser.ForeColor = SystemColors.ButtonFace;
            chkMiraLaser.Location = new Point(230, 300);
            chkMiraLaser.Name = "chkMiraLaser";
            chkMiraLaser.Size = new Size(80, 19);
            chkMiraLaser.TabIndex = 18;
            chkMiraLaser.Text = "Mira Láser";
            chkMiraLaser.UseVisualStyleBackColor = true;
            // 
            // chkMiraTelescopica
            // 
            chkMiraTelescopica.AutoSize = true;
            chkMiraTelescopica.ForeColor = SystemColors.ButtonFace;
            chkMiraTelescopica.Location = new Point(230, 325);
            chkMiraTelescopica.Name = "chkMiraTelescopica";
            chkMiraTelescopica.Size = new Size(112, 19);
            chkMiraTelescopica.TabIndex = 19;
            chkMiraTelescopica.Text = "Mira telescópica";
            chkMiraTelescopica.UseVisualStyleBackColor = true;
            // 
            // chkLinterna
            // 
            chkLinterna.AutoSize = true;
            chkLinterna.ForeColor = SystemColors.ButtonFace;
            chkLinterna.Location = new Point(230, 275);
            chkLinterna.Name = "chkLinterna";
            chkLinterna.Size = new Size(69, 19);
            chkLinterna.TabIndex = 17;
            chkLinterna.Text = "Linterna";
            chkLinterna.UseVisualStyleBackColor = true;
            // 
            // chkCargadorTambor
            // 
            chkCargadorTambor.AutoSize = true;
            chkCargadorTambor.ForeColor = SystemColors.ButtonFace;
            chkCargadorTambor.Location = new Point(230, 175);
            chkCargadorTambor.Name = "chkCargadorTambor";
            chkCargadorTambor.Size = new Size(133, 19);
            chkCargadorTambor.TabIndex = 13;
            chkCargadorTambor.Text = "Cargador de tambor";
            chkCargadorTambor.UseVisualStyleBackColor = true;
            // 
            // lblAccesorios
            // 
            lblAccesorios.AutoSize = true;
            lblAccesorios.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblAccesorios.ForeColor = Color.FromArgb(225, 225, 225);
            lblAccesorios.Location = new Point(230, 127);
            lblAccesorios.Name = "lblAccesorios";
            lblAccesorios.Size = new Size(85, 20);
            lblAccesorios.TabIndex = 41;
            lblAccesorios.Text = "Accesorios:";
            // 
            // chkCulataPlegable
            // 
            chkCulataPlegable.AutoSize = true;
            chkCulataPlegable.ForeColor = SystemColors.ButtonFace;
            chkCulataPlegable.Location = new Point(230, 225);
            chkCulataPlegable.Name = "chkCulataPlegable";
            chkCulataPlegable.Size = new Size(108, 19);
            chkCulataPlegable.TabIndex = 15;
            chkCulataPlegable.Text = "Culata plegable";
            chkCulataPlegable.UseVisualStyleBackColor = true;
            // 
            // chkCorrea
            // 
            chkCorrea.AutoSize = true;
            chkCorrea.ForeColor = SystemColors.ButtonFace;
            chkCorrea.Location = new Point(230, 200);
            chkCorrea.Name = "chkCorrea";
            chkCorrea.Size = new Size(61, 19);
            chkCorrea.TabIndex = 14;
            chkCorrea.Text = "Correa";
            chkCorrea.UseVisualStyleBackColor = true;
            // 
            // chkBipode
            // 
            chkBipode.AutoSize = true;
            chkBipode.ForeColor = SystemColors.ButtonFace;
            chkBipode.Location = new Point(230, 150);
            chkBipode.Name = "chkBipode";
            chkBipode.Size = new Size(63, 19);
            chkBipode.TabIndex = 12;
            chkBipode.Text = "Bípode";
            chkBipode.UseVisualStyleBackColor = true;
            // 
            // lblCadencia
            // 
            lblCadencia.AutoSize = true;
            lblCadencia.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblCadencia.ForeColor = Color.FromArgb(225, 225, 225);
            lblCadencia.Location = new Point(230, 78);
            lblCadencia.Name = "lblCadencia";
            lblCadencia.Size = new Size(75, 20);
            lblCadencia.TabIndex = 40;
            lblCadencia.Text = "Cadencia:";
            // 
            // txtCadencia
            // 
            txtCadencia.BackColor = Color.FromArgb(224, 242, 241);
            txtCadencia.Location = new Point(230, 101);
            txtCadencia.Name = "txtCadencia";
            txtCadencia.Size = new Size(161, 23);
            txtCadencia.TabIndex = 11;
            // 
            // FrmAgregarFusil
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(464, 501);
            Controls.Add(lblCadencia);
            Controls.Add(txtCadencia);
            Controls.Add(chkBipode);
            Controls.Add(chkCorrea);
            Controls.Add(chkCulataPlegable);
            Controls.Add(chkFrenoBoca);
            Controls.Add(chkMiraLaser);
            Controls.Add(chkMiraTelescopica);
            Controls.Add(chkLinterna);
            Controls.Add(chkCargadorTambor);
            Controls.Add(lblAccesorios);
            Controls.Add(lblCapacidadCargador);
            Controls.Add(txtCapacidadCargador);
            Name = "FrmAgregarFusil";
            Text = "Agregar fusil de asalto";
            Controls.SetChildIndex(txtFabricante, 0);
            Controls.SetChildIndex(txtModelo, 0);
            Controls.SetChildIndex(txtPrecio, 0);
            Controls.SetChildIndex(txtNumeroSerie, 0);
            Controls.SetChildIndex(txtPeso, 0);
            Controls.SetChildIndex(cboCalibre, 0);
            Controls.SetChildIndex(chkAluminio, 0);
            Controls.SetChildIndex(chkAcero, 0);
            Controls.SetChildIndex(chkMadera, 0);
            Controls.SetChildIndex(chkPolimero, 0);
            Controls.SetChildIndex(txtCapacidadCargador, 0);
            Controls.SetChildIndex(lblCapacidadCargador, 0);
            Controls.SetChildIndex(lblAccesorios, 0);
            Controls.SetChildIndex(chkCargadorTambor, 0);
            Controls.SetChildIndex(chkLinterna, 0);
            Controls.SetChildIndex(chkMiraTelescopica, 0);
            Controls.SetChildIndex(chkMiraLaser, 0);
            Controls.SetChildIndex(chkFrenoBoca, 0);
            Controls.SetChildIndex(chkCulataPlegable, 0);
            Controls.SetChildIndex(chkCorrea, 0);
            Controls.SetChildIndex(chkBipode, 0);
            Controls.SetChildIndex(txtCadencia, 0);
            Controls.SetChildIndex(lblCadencia, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCapacidadCargador;
        private TextBox txtCapacidadCargador;
        private CheckBox chkFrenoBoca;
        private CheckBox chkMiraLaser;
        private CheckBox chkMiraTelescopica;
        private CheckBox chkLinterna;
        private CheckBox chkCargadorTambor;
        private Label lblAccesorios;
        private CheckBox chkCulataPlegable;
        private CheckBox chkCorrea;
        private CheckBox chkBipode;
        private Label lblCadencia;
        private TextBox txtCadencia;
    }
}