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

        private void FrmCRUD_Load(object sender, EventArgs e)
        {
            this.LimpiarVisor();
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
            this.MostrarForm(frmSeleccion.ArmaSeleccionada);
            this.ActualizarVisor();
        }

        private void MostrarForm(string armaSeleccionada)
        {
            DialogResult resultado;
            switch (armaSeleccionada)
            {
                case "pistola":
                    FrmAgregarPistola frmAgregarPistola = new FrmAgregarPistola();
                    resultado = frmAgregarPistola.ShowDialog();
                    if (resultado == DialogResult.OK)
                        this.armas.Add(frmAgregarPistola.PistolaCreada);
                    break;
                case "fusil":
                    FrmAgregarFusil frmAgregarFusil = new FrmAgregarFusil();
                    resultado = frmAgregarFusil.ShowDialog();
                    if (resultado == DialogResult.OK)
                        this.armas.Add(frmAgregarFusil.FusilCreado);
                    break;
                case "escopeta":
                    FrmAgregarEscopeta frmAgregarEscopeta = new FrmAgregarEscopeta();
                    resultado = frmAgregarEscopeta.ShowDialog();
                    if (resultado == DialogResult.OK)
                        this.armas.Add(frmAgregarEscopeta.EscopetaCreada);
                    break;
            }
        }

        private void ActualizarVisor()
        {
            this.LimpiarVisor();
            foreach (var arma in this.armas)
            {
                this.lstVisor.Items.Add(arma.Mostrar());
            }
        }

        private void LimpiarVisor()
        {
            this.lstVisor.Items.Clear();
            this.lstVisor.Items.Add("Tipo\t\tFabricante\t\tModelo\t\tNúmero de serie\t\tPrecio\t\tPeso\t\tCalibre");
        }
    }
}
