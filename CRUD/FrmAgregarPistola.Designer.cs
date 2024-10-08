﻿namespace CRUD
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
            // lblAccesorios
            // 
            lblAccesorios.AutoSize = true;
            lblAccesorios.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblAccesorios.ForeColor = Color.FromArgb(225, 225, 225);
            lblAccesorios.Location = new Point(230, 78);
            lblAccesorios.Name = "lblAccesorios";
            lblAccesorios.Size = new Size(85, 20);
            lblAccesorios.TabIndex = 40;
            lblAccesorios.Text = "Accesorios:";
            // 
            // chkLinterna
            // 
            chkLinterna.AutoSize = true;
            chkLinterna.ForeColor = SystemColors.ButtonFace;
            chkLinterna.Location = new Point(230, 101);
            chkLinterna.Name = "chkLinterna";
            chkLinterna.Size = new Size(69, 19);
            chkLinterna.TabIndex = 12;
            chkLinterna.Text = "Linterna";
            chkLinterna.UseVisualStyleBackColor = true;
            // 
            // chkMiraHolografica
            // 
            chkMiraHolografica.AutoSize = true;
            chkMiraHolografica.ForeColor = SystemColors.ButtonFace;
            chkMiraHolografica.Location = new Point(230, 126);
            chkMiraHolografica.Name = "chkMiraHolografica";
            chkMiraHolografica.Size = new Size(113, 19);
            chkMiraHolografica.TabIndex = 13;
            chkMiraHolografica.Text = "Mira holográfica";
            chkMiraHolografica.UseVisualStyleBackColor = true;
            // 
            // chkMiraLaser
            // 
            chkMiraLaser.AutoSize = true;
            chkMiraLaser.ForeColor = SystemColors.ButtonFace;
            chkMiraLaser.Location = new Point(230, 151);
            chkMiraLaser.Name = "chkMiraLaser";
            chkMiraLaser.Size = new Size(80, 19);
            chkMiraLaser.TabIndex = 14;
            chkMiraLaser.Text = "Mira Láser";
            chkMiraLaser.UseVisualStyleBackColor = true;
            // 
            // chkSupresor
            // 
            chkSupresor.AutoSize = true;
            chkSupresor.ForeColor = SystemColors.ButtonFace;
            chkSupresor.Location = new Point(230, 176);
            chkSupresor.Name = "chkSupresor";
            chkSupresor.Size = new Size(72, 19);
            chkSupresor.TabIndex = 15;
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
            Controls.Add(lblAccesorios);
            Controls.Add(lblCapacidadCargador);
            Controls.Add(txtCapacidadCargador);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "FrmAgregarPistola";
            Text = "Agregar Pistola Semiautomática";
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
        private CheckBox chkLinterna;
        private CheckBox chkMiraHolografica;
        private CheckBox chkMiraLaser;
        private CheckBox chkSupresor;
    }
}