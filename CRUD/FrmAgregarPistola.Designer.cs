namespace CRUD
{
    partial class FrmAgregarPistola
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
            lblAccesorios = new Label();
            chkCargadorAmpliado = new CheckBox();
            chkLinterna = new CheckBox();
            chkMiraHolografica = new CheckBox();
            chkMiraLaser = new CheckBox();
            chkSupresor = new CheckBox();
            SuspendLayout();
            // 
            // lblCapacidadCargador
            // 
            lblCapacidadCargador.AutoSize = true;
            lblCapacidadCargador.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblCapacidadCargador.ForeColor = Color.FromArgb(225, 225, 225);
            lblCapacidadCargador.Location = new Point(230, 9);
            lblCapacidadCargador.Name = "lblCapacidadCargador";
            lblCapacidadCargador.Size = new Size(120, 40);
            lblCapacidadCargador.TabIndex = 23;
            lblCapacidadCargador.Text = "Capacidad del\r\ncargador (base):";
            // 
            // txtCapacidadCargador
            // 
            txtCapacidadCargador.BackColor = Color.FromArgb(224, 242, 241);
            txtCapacidadCargador.Location = new Point(230, 52);
            txtCapacidadCargador.Name = "txtCapacidadCargador";
            txtCapacidadCargador.Size = new Size(161, 23);
            txtCapacidadCargador.TabIndex = 22;
            // 
            // lblAccesorios
            // 
            lblAccesorios.AutoSize = true;
            lblAccesorios.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblAccesorios.ForeColor = Color.FromArgb(225, 225, 225);
            lblAccesorios.Location = new Point(230, 78);
            lblAccesorios.Name = "lblAccesorios";
            lblAccesorios.Size = new Size(85, 20);
            lblAccesorios.TabIndex = 24;
            lblAccesorios.Text = "Accesorios:";
            // 
            // chkCargadorAmpliado
            // 
            chkCargadorAmpliado.AutoSize = true;
            chkCargadorAmpliado.ForeColor = SystemColors.ButtonFace;
            chkCargadorAmpliado.Location = new Point(230, 101);
            chkCargadorAmpliado.Name = "chkCargadorAmpliado";
            chkCargadorAmpliado.Size = new Size(130, 19);
            chkCargadorAmpliado.TabIndex = 25;
            chkCargadorAmpliado.Text = "Cargador Ampliado";
            chkCargadorAmpliado.UseVisualStyleBackColor = true;
            // 
            // chkLinterna
            // 
            chkLinterna.AutoSize = true;
            chkLinterna.ForeColor = SystemColors.ButtonFace;
            chkLinterna.Location = new Point(230, 126);
            chkLinterna.Name = "chkLinterna";
            chkLinterna.Size = new Size(69, 19);
            chkLinterna.TabIndex = 26;
            chkLinterna.Text = "Linterna";
            chkLinterna.UseVisualStyleBackColor = true;
            // 
            // chkMiraHolografica
            // 
            chkMiraHolografica.AutoSize = true;
            chkMiraHolografica.ForeColor = SystemColors.ButtonFace;
            chkMiraHolografica.Location = new Point(230, 151);
            chkMiraHolografica.Name = "chkMiraHolografica";
            chkMiraHolografica.Size = new Size(113, 19);
            chkMiraHolografica.TabIndex = 27;
            chkMiraHolografica.Text = "Mira holográfica";
            chkMiraHolografica.UseVisualStyleBackColor = true;
            // 
            // chkMiraLaser
            // 
            chkMiraLaser.AutoSize = true;
            chkMiraLaser.ForeColor = SystemColors.ButtonFace;
            chkMiraLaser.Location = new Point(230, 176);
            chkMiraLaser.Name = "chkMiraLaser";
            chkMiraLaser.Size = new Size(80, 19);
            chkMiraLaser.TabIndex = 28;
            chkMiraLaser.Text = "Mira Láser";
            chkMiraLaser.UseVisualStyleBackColor = true;
            // 
            // chkSupresor
            // 
            chkSupresor.AutoSize = true;
            chkSupresor.ForeColor = SystemColors.ButtonFace;
            chkSupresor.Location = new Point(230, 201);
            chkSupresor.Name = "chkSupresor";
            chkSupresor.Size = new Size(72, 19);
            chkSupresor.TabIndex = 29;
            chkSupresor.Text = "Supresor";
            chkSupresor.UseVisualStyleBackColor = true;
            // 
            // FrmAgregarPistola
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(464, 501);
            Controls.Add(chkSupresor);
            Controls.Add(chkMiraLaser);
            Controls.Add(chkMiraHolografica);
            Controls.Add(chkLinterna);
            Controls.Add(chkCargadorAmpliado);
            Controls.Add(lblAccesorios);
            Controls.Add(lblCapacidadCargador);
            Controls.Add(txtCapacidadCargador);
            Name = "FrmAgregarPistola";
            Text = "Agregar Pistola Semiautomática";
            Controls.SetChildIndex(txtCapacidadCargador, 0);
            Controls.SetChildIndex(lblCapacidadCargador, 0);
            Controls.SetChildIndex(lblAccesorios, 0);
            Controls.SetChildIndex(chkCargadorAmpliado, 0);
            Controls.SetChildIndex(chkLinterna, 0);
            Controls.SetChildIndex(chkMiraHolografica, 0);
            Controls.SetChildIndex(chkMiraLaser, 0);
            Controls.SetChildIndex(chkSupresor, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCapacidadCargador;
        private TextBox txtCapacidadCargador;
        private Label lblAccesorios;
        private CheckBox chkCargadorAmpliado;
        private CheckBox chkLinterna;
        private CheckBox chkMiraHolografica;
        private CheckBox chkMiraLaser;
        private CheckBox chkSupresor;
    }
}