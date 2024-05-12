using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD
{
    public partial class FrmAgregarSeleccion : Form
    {
        private string armaSeleccionada;
        public string ArmaSeleccionada
        {
            get { return this.armaSeleccionada; }
        }

        public FrmAgregarSeleccion()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {            
            if (this.radPistola.Checked)
            {
                this.armaSeleccionada = "pistola";
            }
            else if (this.radFusil.Checked)
            {
                this.armaSeleccionada = "fusil";
            }
            else if (this.radEscopeta.Checked)
            {
                this.armaSeleccionada = "escopeta";
            }
            else
            {
                MessageBox.Show("No se seleccionó ningún tipo de arma", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
