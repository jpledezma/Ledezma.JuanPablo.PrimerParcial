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
            this.AgregarArma(frmSeleccion.ArmaSeleccionada);
            this.ActualizarVisor();
        }

        private void AgregarArma(string armaSeleccionada)
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
            this.lstVisor.Items.Clear();
            foreach (var arma in this.armas)
            {
                this.lstVisor.Items.Add(arma.MostrarEnVisor());
            }
        }

        private void btnDetalles_Click(object sender, EventArgs e)
        {
            // Sacar el header de la list box y meterlo en labels, sino es un quilombo para acceder a los items
            int indiceSeleccionado = this.lstVisor.SelectedIndex;
            if (indiceSeleccionado != -1)
            {
                //MessageBox.Show(this.armas[indiceSeleccionado]);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int indiceSeleccionado = this.lstVisor.SelectedIndex;
            if (indiceSeleccionado == -1)
            {
                MessageBox.Show("No seleccionó ningún elemento");
                return;
            }

            if (armas[indiceSeleccionado].GetType() == typeof(PistolaSemiautomatica))
            {
                ModificarArma((PistolaSemiautomatica)armas[indiceSeleccionado]);
            }
            else if (armas[indiceSeleccionado].GetType() == typeof(FusilAsalto))
            {
                ModificarArma((FusilAsalto)armas[indiceSeleccionado]);
            }
            else if (armas[indiceSeleccionado].GetType() == typeof(EscopetaBombeo))
            {
                ModificarArma((EscopetaBombeo)armas[indiceSeleccionado]);
            }

            this.ActualizarVisor();
        }

        private void ModificarArma(PistolaSemiautomatica pistola)
        {
            FrmAgregarPistola frmModificarPistola = new FrmAgregarPistola(pistola);
            DialogResult resultado = frmModificarPistola.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                this.armas[this.lstVisor.SelectedIndex] = frmModificarPistola.PistolaCreada;
            }
        }

        private void ModificarArma(FusilAsalto fusil)
        {
            FrmAgregarFusil frmModificarFusil = new FrmAgregarFusil(fusil);
            DialogResult resultado = frmModificarFusil.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                this.armas[this.lstVisor.SelectedIndex] = frmModificarFusil.FusilCreado;
            }
        }

        private void ModificarArma(EscopetaBombeo escopeta)
        {
            FrmAgregarEscopeta frmModificarEscopeta = new FrmAgregarEscopeta(escopeta);
            DialogResult resultado = frmModificarEscopeta.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                this.armas[this.lstVisor.SelectedIndex] = frmModificarEscopeta.EscopetaCreada;
            }
        }
    }
}
