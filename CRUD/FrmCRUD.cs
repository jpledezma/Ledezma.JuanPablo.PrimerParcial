using Armas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace CRUD
{
    // TODO
    // serializar/deserializar objetos del visor
    // ordenar visor
    // crear un log de las acciones del usuario
    // agregar visualizador para el log
    // generar diagrama de clases (cambiar a la vista completa full signature) - no hace falta de los formularios
    // README
    // docstrings

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
            this.mnuCboOrdenar.SelectedIndex = 0;
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
            int indiceSeleccionado = this.lstVisor.SelectedIndex;
            if (indiceSeleccionado == -1)
            {
                MessageBox.Show("No se seleccionó ningún elemento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FrmVerDetalles frmVerDetalles = new FrmVerDetalles(this.armeria.Armas[indiceSeleccionado]);
            frmVerDetalles.Show();
        }

        private void mnuBtnSerializarJson_Click(object sender, EventArgs e)
        {
            try
            {
                string path = this.ObtenerPathGuardar("json");
                if (path == String.Empty) { return; }
                this.SerializarJson(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo guardar el archivo\n\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuBtnSerializarXml_Click(object sender, EventArgs e)
        {
            try
            {
                string path = this.ObtenerPathGuardar("xml");
                if (path == String.Empty) { return; }
                this.SerializarXml(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo guardar el archivo\n\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deserializarXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string path = this.ObtenerPathCargar("xml");
                if (path == String.Empty) { return; }
                this.DeserializarXML(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo cargar el archivo\n\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.ActualizarVisor();
        }

        private void mnuBtnOrdenar_Click(object sender, EventArgs e)
        {
            string propiedad = "";

            if (sender == this.mnuBtnOrdenarCalibre)
                propiedad = "calibre";

            else if (sender == this.mnuBtnOrdenarFabricante)
                propiedad = "fabricante";

            if (sender == this.mnuBtnOrdenarNumeroSerie)
                propiedad = "numero_serie";

            else if (sender == this.mnuBtnOrdenarPeso)
                propiedad = "peso";

            if (sender == this.mnuBtnOrdenarPrecio)
                propiedad = "precio";

            else if (sender == this.mnuBtnOrdenarTipo)
                propiedad = "tipo";

            if (this.mnuCboOrdenar.Text == "Ascendente")
                this.armeria.OrdenarArmeria(propiedad);
            else if (this.mnuCboOrdenar.Text == "Descendente")
                this.armeria.OrdenarArmeria(propiedad, true);
            this.ActualizarVisor();
        }
        #endregion

        #region Metodos
        private void ActualizarVisor()
        {
            this.lstVisor.Items.Clear();
            foreach (var arma in this.armeria.Armas)
            {
                this.lstVisor.Items.Add(ArmaDeFuego.MostrarEnVisor(arma));
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

        private string ObtenerPathGuardar(string extension = "")
        {
            string path = String.Empty;

            using (SaveFileDialog fileDialog = new SaveFileDialog())
            {
                fileDialog.InitialDirectory = Application.StartupPath;

                if (extension == "json")
                {
                    fileDialog.Filter = "Archivos json (*.json)|*.json|Todos los archivos (*.*)|*.*";
                }
                else if (extension == "xml")
                {
                    fileDialog.Filter = "Archivos xml (*.xml)|*.xml|Todos los archivos (*.*)|*.*";
                }
                else
                {
                    fileDialog.Filter = "Todos los archivos (*.*)|*.*";
                }

                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    path = fileDialog.FileName;
                }
            }

            return path;
        }

        private string ObtenerPathCargar(string extension = "")
        {
            string path = String.Empty;

            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.InitialDirectory = Application.StartupPath;

                if (extension == "json")
                {
                    fileDialog.Filter = "Archivos json (*.json)|*.json|Todos los archivos (*.*)|*.*";
                }
                else if (extension == "xml")
                {
                    fileDialog.Filter = "Archivos xml (*.xml)|*.xml|Todos los archivos (*.*)|*.*";
                }
                else
                {
                    fileDialog.Filter = "Todos los archivos (*.*)|*.*";
                }

                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    path = fileDialog.FileName;
                }
            }

            return path;
        }

        private void SerializarJson(string path)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                System.Text.Json.JsonSerializerOptions opciones = new System.Text.Json.JsonSerializerOptions();
                opciones.WriteIndented = true;

                var obj_json = System.Text.Json.JsonSerializer.Serialize((object[])this.armeria.Armas.ToArray(), opciones);
                sw.WriteLine(obj_json);
            }
        }

        private void SerializarXml(string path)
        {
            using (XmlTextWriter writer = new XmlTextWriter(path, Encoding.UTF8))
            {
                XmlSerializer ser = new XmlSerializer((typeof(List<ArmaDeFuego>)));
                ser.Serialize(writer, this.armeria.Armas);
            }
        }

        private void DeserializarXML(string path)
        {
            using (XmlTextReader reader = new XmlTextReader(path))
            {
                XmlSerializer ser = new XmlSerializer(typeof(List<ArmaDeFuego>));

                List<ArmaDeFuego> armas = (List<ArmaDeFuego>)ser.Deserialize(reader);
                this.armeria = new Armeria(armas);
            }
        }
        #endregion
    }
}
