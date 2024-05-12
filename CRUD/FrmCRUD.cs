using Armas;
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
    public partial class FrmCRUD : Form

    /*
     * fondo: 38, 40, 51
     * azul oscuro: (2, 118, 170)
     * azul medio: (3, 169, 244)
     * azul claro: (0, 229, 255)
     * verde oscuro: (53, 122, 56)
     * verde medio: (76, 175, 80)
     * verde claro: (139, 195, 74)
     * indigo: (42, 62, 177)
     * blanco-azul: (224, 242, 241)
     */
    {

        List<ArmaDeFuego> armas = new List<ArmaDeFuego>();
        public FrmCRUD()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // A la clase ArmaDeFuego agregarle un método ObtenerDatos()
            // que devuelva un array con cada uno de los datos,
            // después las clases heredadas lo sobreescriben.
            
            FrmAgregarSeleccion frmSeleccion = new FrmAgregarSeleccion();
            DialogResult resultado = frmSeleccion.ShowDialog();

            if (resultado == DialogResult.Cancel)
            {
                return;
            }

            if(frmSeleccion.ArmaSeleccionada == "pistola")
            {
                MessageBox.Show("Pistola semiautomática");
            }
            else if (frmSeleccion.ArmaSeleccionada == "fusil")
            {
                MessageBox.Show("Fusil de asalto");
            }
            else if (frmSeleccion.ArmaSeleccionada == "escopeta")
            { 
                MessageBox.Show("Escopeta de bombeo");
            }
            FrmAgregarBase frm = new FrmAgregarBase();
            frm.ShowDialog();
        }
    }
}
