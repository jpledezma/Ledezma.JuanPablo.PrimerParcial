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
    // TODO
    // ordenar visor
    // serializar/deserializar objetos del visor
    // agregar metodo virtual (mostrar datos en ver detalles)
    ////  para mostrar los cartuchos, poner el tipo y la cantidad (ej. AE_50 incendiario x6)
    // README
    // generar diagrama de clases (cambiar a la vista completa full signature) - no hace falta de los formularios
    // docstrings
    // crear un log de las acciones del usuario
    // agregar visualizador para el log

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
    public partial class FrmCRUD : Form
    {
        private Armeria armeria;

        public FrmCRUD()
        {
            InitializeComponent();
            this.armeria = new Armeria();
            this.mnuTxtDatosLogin.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
        public FrmCRUD(Usuario usuario) : this()
        {
            string nombreUsuario;
            if (usuario is not null)
            {
                nombreUsuario = $"{usuario.nombre} {usuario.apellido} - ";
            }
            else
            {
                nombreUsuario = "Usuario desconocido - ";
            }
            this.mnuTxtDatosLogin.Text = nombreUsuario + this.mnuTxtDatosLogin.Text;
        }

        #region Eventos
        private void FrmCRUD_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult respuesta;
            respuesta = MessageBox.Show("¿Seguro que desea salir de la aplicación?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (respuesta != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }
        private void mnuBtnPistola_Click(object sender, EventArgs e)
        {
            FrmAgregarPistola frmAgregarPistola = new FrmAgregarPistola();
            DialogResult resultado = frmAgregarPistola.ShowDialog();
            if (resultado == DialogResult.OK)
                this.armeria += frmAgregarPistola.PistolaCreada;
            this.ActualizarVisor();
        }

        private void mnuBtnFusil_Click(object sender, EventArgs e)
        {
            FrmAgregarFusil frmAgregarFusil = new FrmAgregarFusil();
            DialogResult resultado = frmAgregarFusil.ShowDialog();
            if (resultado == DialogResult.OK)
                this.armeria += frmAgregarFusil.FusilCreado;
            this.ActualizarVisor();
        }

        private void mnuBtnEscopeta_Click(object sender, EventArgs e)
        {
            FrmAgregarEscopeta frmAgregarEscopeta = new FrmAgregarEscopeta();
            DialogResult resultado = frmAgregarEscopeta.ShowDialog();
            if (resultado == DialogResult.OK)
                this.armeria += frmAgregarEscopeta.EscopetaCreada;
            this.ActualizarVisor();
        }

        private void mnuBtnEliminar_Click(object sender, EventArgs e)
        {
            int indiceSeleccionado = this.lstVisor.SelectedIndex;
            if (indiceSeleccionado == -1)
            {
                MessageBox.Show("No se seleccionó ningún elemento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ArmaDeFuego armaSeleccionada = this.armeria.Armas[indiceSeleccionado];

            DialogResult resultado;

            resultado = MessageBox.Show($"¿Seguro que desea eliminar el arma {armaSeleccionada}?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (resultado == DialogResult.Yes)
            {
                this.armeria -= armaSeleccionada;
            }
            this.ActualizarVisor();
        }

        private void mnuBtnModificar_Click(object sender, EventArgs e)
        {
            int indiceSeleccionado = this.lstVisor.SelectedIndex;
            if (indiceSeleccionado == -1)
            {
                MessageBox.Show("No se seleccionó ningún elemento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (this.armeria.Armas[indiceSeleccionado].GetType() == typeof(PistolaSemiautomatica))
            {
                ModificarArma((PistolaSemiautomatica)this.armeria.Armas[indiceSeleccionado]);
            }
            else if (this.armeria.Armas[indiceSeleccionado].GetType() == typeof(FusilAsalto))
            {
                ModificarArma((FusilAsalto)this.armeria.Armas[indiceSeleccionado]);
            }
            else if (this.armeria.Armas[indiceSeleccionado].GetType() == typeof(EscopetaBombeo))
            {
                ModificarArma((EscopetaBombeo)this.armeria.Armas[indiceSeleccionado]);
            }

            this.ActualizarVisor();
        }

        private void mnuBtnVerDetalles_Click(object sender, EventArgs e)
        {
            // A la clase ArmaDeFuego agregarle un método ObtenerDatos()
            // que devuelva un array con cada uno de los datos,
            // después las clases heredadas lo sobreescriben.
            int indiceSeleccionado = this.lstVisor.SelectedIndex;
            if (indiceSeleccionado == -1)
            {
                MessageBox.Show("No se seleccionó ningún elemento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        #endregion

        #region Metodos
        private void ActualizarVisor()
        {
            this.lstVisor.Items.Clear();
            foreach (var arma in this.armeria.Armas)
            {
                this.lstVisor.Items.Add(arma.MostrarEnVisor());
            }
        }

        private void ModificarArma(PistolaSemiautomatica pistola)
        {
            FrmAgregarPistola frmModificarPistola = new FrmAgregarPistola(pistola);
            DialogResult resultado = frmModificarPistola.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                this.armeria -= this.armeria.Armas[this.lstVisor.SelectedIndex];
                this.armeria += frmModificarPistola.PistolaCreada;
            }
        }

        private void ModificarArma(FusilAsalto fusil)
        {
            FrmAgregarFusil frmModificarFusil = new FrmAgregarFusil(fusil);
            DialogResult resultado = frmModificarFusil.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                this.armeria -= this.armeria.Armas[this.lstVisor.SelectedIndex];
                this.armeria += frmModificarFusil.FusilCreado;
            }
        }

        private void ModificarArma(EscopetaBombeo escopeta)
        {
            FrmAgregarEscopeta frmModificarEscopeta = new FrmAgregarEscopeta(escopeta);
            DialogResult resultado = frmModificarEscopeta.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                this.armeria -= this.armeria.Armas[this.lstVisor.SelectedIndex];
                this.armeria += frmModificarEscopeta.EscopetaCreada;
            }
        }
        #endregion
    }
}
