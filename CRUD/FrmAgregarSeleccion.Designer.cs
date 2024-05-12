namespace CRUD
{
    partial class FrmAgregarSeleccion
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
            btnAceptar = new Button();
            btnCancelar = new Button();
            radPistola = new RadioButton();
            radFusil = new RadioButton();
            radEscopeta = new RadioButton();
            SuspendLayout();
            // 
            // btnAceptar
            // 
            btnAceptar.BackColor = Color.FromArgb(2, 108, 155);
            btnAceptar.FlatAppearance.BorderSize = 0;
            btnAceptar.FlatStyle = FlatStyle.Flat;
            btnAceptar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnAceptar.ForeColor = Color.White;
            btnAceptar.Location = new Point(40, 203);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(78, 37);
            btnAceptar.TabIndex = 3;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = false;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.FromArgb(135, 15, 15);
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(162, 203);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(78, 37);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // radPistola
            // 
            radPistola.AutoSize = true;
            radPistola.ForeColor = SystemColors.ButtonFace;
            radPistola.Location = new Point(40, 50);
            radPistola.Name = "radPistola";
            radPistola.Size = new Size(148, 19);
            radPistola.TabIndex = 0;
            radPistola.TabStop = true;
            radPistola.Text = "Pistola semiautomática";
            radPistola.UseVisualStyleBackColor = false;
            // 
            // radFusil
            // 
            radFusil.AutoSize = true;
            radFusil.ForeColor = SystemColors.ButtonFace;
            radFusil.Location = new Point(40, 87);
            radFusil.Name = "radFusil";
            radFusil.Size = new Size(99, 19);
            radFusil.TabIndex = 5;
            radFusil.TabStop = true;
            radFusil.Text = "Fusil de asalto";
            radFusil.UseVisualStyleBackColor = false;
            // 
            // radEscopeta
            // 
            radEscopeta.AutoSize = true;
            radEscopeta.ForeColor = SystemColors.ButtonFace;
            radEscopeta.Location = new Point(40, 127);
            radEscopeta.Name = "radEscopeta";
            radEscopeta.Size = new Size(136, 19);
            radEscopeta.TabIndex = 6;
            radEscopeta.TabStop = true;
            radEscopeta.Text = "Escopeta de bombeo";
            radEscopeta.UseVisualStyleBackColor = false;
            // 
            // FrmAgregarSeleccion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(38, 40, 51);
            ClientSize = new Size(281, 280);
            Controls.Add(radEscopeta);
            Controls.Add(radFusil);
            Controls.Add(radPistola);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Name = "FrmAgregarSeleccion";
            Text = "Seleccionar tipo";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAceptar;
        private Button btnCancelar;
        private RadioButton radPistola;
        private RadioButton radFusil;
        private RadioButton radEscopeta;
    }
}