namespace CRUD
{
    partial class FrmAgregarEscopeta
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
            lblCapacidad = new Label();
            txtCapacidad = new TextBox();
            chkCorrea = new CheckBox();
            chkCulataAcolchada = new CheckBox();
            chkEstrangulador = new CheckBox();
            chkMiraLaser = new CheckBox();
            chkMiraMetalica = new CheckBox();
            chkLinterna = new CheckBox();
            lblAccesorios = new Label();
            chkPostacartuchos = new CheckBox();
            SuspendLayout();
            // 
            // cboCalibre
            // 
            // No sé por qué el visual metió esto, pero lo tuve que sacar porque duplicaba los items de la combobox.
            //cboCalibre.Items.AddRange(new object[] { EMunicion.ACP_380, EMunicion.ACP_45, EMunicion.AE_50, EMunicion.LC_45, EMunicion.LR_22, EMunicion.MAGNUM_44, EMunicion.MAGNUM_357, EMunicion.OTAN_5_56x45, EMunicion.PARABELLUM_9x19, EMunicion.REM_223, EMunicion.SOVIET_5_45X39, EMunicion.SOVIET_7_62X39, EMunicion.WIN_308, EMunicion.SHELL_12g, EMunicion.SHELL_10g, EMunicion.SHELL_20g, EMunicion.ACP_380, EMunicion.ACP_45, EMunicion.AE_50, EMunicion.LC_45, EMunicion.LR_22, EMunicion.MAGNUM_44, EMunicion.MAGNUM_357, EMunicion.OTAN_5_56x45, EMunicion.PARABELLUM_9x19, EMunicion.REM_223, EMunicion.SOVIET_5_45X39, EMunicion.SOVIET_7_62X39, EMunicion.WIN_308, EMunicion.SHELL_12g, EMunicion.SHELL_10g, EMunicion.SHELL_20g });
            // 
            // lblCapacidad
            // 
            lblCapacidad.AutoSize = true;
            lblCapacidad.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblCapacidad.ForeColor = Color.FromArgb(225, 225, 225);
            lblCapacidad.Location = new Point(230, 9);
            lblCapacidad.Name = "lblCapacidad";
            lblCapacidad.Size = new Size(164, 20);
            lblCapacidad.TabIndex = 39;
            lblCapacidad.Text = "Capacidad (cartuchos):";
            // 
            // txtCapacidad
            // 
            txtCapacidad.BackColor = Color.FromArgb(224, 242, 241);
            txtCapacidad.Location = new Point(230, 33);
            txtCapacidad.Name = "txtCapacidad";
            txtCapacidad.Size = new Size(161, 23);
            txtCapacidad.TabIndex = 10;
            // 
            // chkCorrea
            // 
            chkCorrea.AutoSize = true;
            chkCorrea.ForeColor = SystemColors.ButtonFace;
            chkCorrea.Location = new Point(230, 82);
            chkCorrea.Name = "chkCorrea";
            chkCorrea.Size = new Size(61, 19);
            chkCorrea.TabIndex = 11;
            chkCorrea.Text = "Correa";
            chkCorrea.UseVisualStyleBackColor = true;
            // 
            // chkCulataAcolchada
            // 
            chkCulataAcolchada.AutoSize = true;
            chkCulataAcolchada.ForeColor = SystemColors.ButtonFace;
            chkCulataAcolchada.Location = new Point(230, 107);
            chkCulataAcolchada.Name = "chkCulataAcolchada";
            chkCulataAcolchada.Size = new Size(117, 19);
            chkCulataAcolchada.TabIndex = 12;
            chkCulataAcolchada.Text = "Culata acolchada";
            chkCulataAcolchada.UseVisualStyleBackColor = true;
            // 
            // chkEstrangulador
            // 
            chkEstrangulador.AutoSize = true;
            chkEstrangulador.ForeColor = SystemColors.ButtonFace;
            chkEstrangulador.Location = new Point(230, 132);
            chkEstrangulador.Name = "chkEstrangulador";
            chkEstrangulador.Size = new Size(99, 19);
            chkEstrangulador.TabIndex = 13;
            chkEstrangulador.Text = "Estrangulador";
            chkEstrangulador.UseVisualStyleBackColor = true;
            // 
            // chkMiraLaser
            // 
            chkMiraLaser.AutoSize = true;
            chkMiraLaser.ForeColor = SystemColors.ButtonFace;
            chkMiraLaser.Location = new Point(230, 182);
            chkMiraLaser.Name = "chkMiraLaser";
            chkMiraLaser.Size = new Size(80, 19);
            chkMiraLaser.TabIndex = 15;
            chkMiraLaser.Text = "Mira Láser";
            chkMiraLaser.UseVisualStyleBackColor = true;
            // 
            // chkMiraMetalica
            // 
            chkMiraMetalica.AutoSize = true;
            chkMiraMetalica.ForeColor = SystemColors.ButtonFace;
            chkMiraMetalica.Location = new Point(230, 207);
            chkMiraMetalica.Name = "chkMiraMetalica";
            chkMiraMetalica.Size = new Size(98, 19);
            chkMiraMetalica.TabIndex = 16;
            chkMiraMetalica.Text = "Mira metálica";
            chkMiraMetalica.UseVisualStyleBackColor = true;
            // 
            // chkLinterna
            // 
            chkLinterna.AutoSize = true;
            chkLinterna.ForeColor = SystemColors.ButtonFace;
            chkLinterna.Location = new Point(230, 157);
            chkLinterna.Name = "chkLinterna";
            chkLinterna.Size = new Size(69, 19);
            chkLinterna.TabIndex = 14;
            chkLinterna.Text = "Linterna";
            chkLinterna.UseVisualStyleBackColor = true;
            // 
            // lblAccesorios
            // 
            lblAccesorios.AutoSize = true;
            lblAccesorios.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblAccesorios.ForeColor = Color.FromArgb(225, 225, 225);
            lblAccesorios.Location = new Point(230, 59);
            lblAccesorios.Name = "lblAccesorios";
            lblAccesorios.Size = new Size(85, 20);
            lblAccesorios.TabIndex = 40;
            lblAccesorios.Text = "Accesorios:";
            // 
            // chkPostacartuchos
            // 
            chkPostacartuchos.AutoSize = true;
            chkPostacartuchos.ForeColor = SystemColors.ButtonFace;
            chkPostacartuchos.Location = new Point(230, 232);
            chkPostacartuchos.Name = "chkPostacartuchos";
            chkPostacartuchos.Size = new Size(106, 19);
            chkPostacartuchos.TabIndex = 17;
            chkPostacartuchos.Text = "Portacartuchos";
            chkPostacartuchos.UseVisualStyleBackColor = true;
            // 
            // FrmAgregarEscopeta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(464, 501);
            Controls.Add(chkPostacartuchos);
            Controls.Add(chkCorrea);
            Controls.Add(chkCulataAcolchada);
            Controls.Add(chkEstrangulador);
            Controls.Add(chkMiraLaser);
            Controls.Add(chkMiraMetalica);
            Controls.Add(chkLinterna);
            Controls.Add(lblAccesorios);
            Controls.Add(lblCapacidad);
            Controls.Add(txtCapacidad);
            Name = "FrmAgregarEscopeta";
            Text = "Agregar escopeta de bombeo";
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
            Controls.SetChildIndex(txtCapacidad, 0);
            Controls.SetChildIndex(lblCapacidad, 0);
            Controls.SetChildIndex(lblAccesorios, 0);
            Controls.SetChildIndex(chkLinterna, 0);
            Controls.SetChildIndex(chkMiraMetalica, 0);
            Controls.SetChildIndex(chkMiraLaser, 0);
            Controls.SetChildIndex(chkEstrangulador, 0);
            Controls.SetChildIndex(chkCulataAcolchada, 0);
            Controls.SetChildIndex(chkCorrea, 0);
            Controls.SetChildIndex(chkPostacartuchos, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCapacidad;
        private TextBox txtCapacidad;
        private CheckBox chkCorrea;
        private CheckBox chkCulataAcolchada;
        private CheckBox chkEstrangulador;
        private CheckBox chkMiraLaser;
        private CheckBox chkMiraMetalica;
        private CheckBox chkLinterna;
        private Label lblAccesorios;
        private CheckBox chkPostacartuchos;
    }
}