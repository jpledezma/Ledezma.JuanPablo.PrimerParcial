namespace CRUD
{
    partial class FrmVerDetalles
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
            txtDetallesArma = new RichTextBox();
            SuspendLayout();
            // 
            // txtDetallesArma
            // 
            txtDetallesArma.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtDetallesArma.BackColor = Color.FromArgb(15, 15, 15);
            txtDetallesArma.BorderStyle = BorderStyle.None;
            txtDetallesArma.Font = new Font("Cascadia Code", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            txtDetallesArma.ForeColor = Color.FromArgb(212, 189, 113);
            txtDetallesArma.Location = new Point(12, 12);
            txtDetallesArma.Name = "txtDetallesArma";
            txtDetallesArma.ReadOnly = true;
            txtDetallesArma.Size = new Size(382, 462);
            txtDetallesArma.TabIndex = 0;
            txtDetallesArma.Text = "";
            txtDetallesArma.WordWrap = false;
            // 
            // FrmVerDetalles
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(38, 40, 51);
            ClientSize = new Size(406, 486);
            Controls.Add(txtDetallesArma);
            Name = "FrmVerDetalles";
            Text = "Detalles";
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox txtDetallesArma;
    }
}