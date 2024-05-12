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
    public partial class FrmAgregarBase : Form
    {
        public FrmAgregarBase()
        {
            InitializeComponent();
        }

        private void FrmAgregarBase_Load(object sender, EventArgs e)
        {
            this.CargarTiposCalibre();
        }

        protected void CargarTiposCalibre()
        {
            foreach (EMunicion calibre in Enum.GetValues(typeof(EMunicion)))
            {
                this.cboCalibre.Items.Add(calibre);
            }
            this.cboCalibre.SelectedIndex = 0;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
