using Armas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace CRUD
{
    public partial class FrmCRUD : Form
    {
        private Armeria armeria;
        private Usuario usuario;

        #region Constructores
        public FrmCRUD()
        {
            InitializeComponent();
            this.armeria = new Armeria();
            this.usuario = new Usuario();
            this.mnuTxtDatosLogin.Text = DateTime.Now.ToString("dd/MM/yyyy");
            this.mnuCboOrdenar.SelectedIndex = 0;
        }
        public FrmCRUD(Usuario usuario) : this()
        {
            this.usuario = usuario;
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
            this.RegistrarAccion("Inició sesión");
        }
        #endregion

        #region Eventos
        private void FrmCRUD_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult respuesta;
            respuesta = MessageBox.Show("¿Seguro que desea salir de la aplicación?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (respuesta != DialogResult.Yes)
            {
                e.Cancel = true;
            }
            else
            {
                this.RegistrarAccion("Salió de la aplicación");
            }
        }
        private void mnuBtnPistola_Click(object sender, EventArgs e)
        {
            FrmAgregarPistola frmAgregarPistola = new FrmAgregarPistola();
            DialogResult resultado = frmAgregarPistola.ShowDialog();
            if (resultado == DialogResult.OK)
                this.armeria += frmAgregarPistola.PistolaCreada;
            this.ActualizarVisor();
            this.RegistrarAccion($"Agregó {frmAgregarPistola.PistolaCreada} a la armería");
        }

        private void mnuBtnFusil_Click(object sender, EventArgs e)
        {
            FrmAgregarFusil frmAgregarFusil = new FrmAgregarFusil();
            DialogResult resultado = frmAgregarFusil.ShowDialog();
            if (resultado == DialogResult.OK)
                this.armeria += frmAgregarFusil.FusilCreado;
            this.ActualizarVisor();
            this.RegistrarAccion($"Agregó {frmAgregarFusil.FusilCreado} a la armería");
        }

        private void mnuBtnEscopeta_Click(object sender, EventArgs e)
        {
            FrmAgregarEscopeta frmAgregarEscopeta = new FrmAgregarEscopeta();
            DialogResult resultado = frmAgregarEscopeta.ShowDialog();
            if (resultado == DialogResult.OK)
                this.armeria += frmAgregarEscopeta.EscopetaCreada;
            this.ActualizarVisor();
            this.RegistrarAccion($"Agregó {frmAgregarEscopeta.EscopetaCreada} a la armería");
        }

        private void mnuBtnEliminar_Click(object sender, EventArgs e)
        {
            int indiceSeleccionado = this.lstVisor.SelectedIndex;
            if (indiceSeleccionado == -1)
            {
                MessageBox.Show("No se seleccionó ningún elemento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ArmaDeFuego armaSeleccionada = this.armeria[indiceSeleccionado];

            DialogResult resultado;

            resultado = MessageBox.Show($"¿Seguro que desea eliminar el arma {armaSeleccionada}?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (resultado == DialogResult.Yes)
            {
                this.armeria -= armaSeleccionada;
            }
            this.ActualizarVisor();
            this.RegistrarAccion($"Eliminó {armaSeleccionada} de la armería");
        }

        private void mnuBtnModificar_Click(object sender, EventArgs e)
        {
            int indiceSeleccionado = this.lstVisor.SelectedIndex;
            if (indiceSeleccionado == -1)
            {
                MessageBox.Show("No se seleccionó ningún elemento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (this.armeria[indiceSeleccionado].GetType() == typeof(PistolaSemiautomatica))
            {
                ModificarArma((PistolaSemiautomatica)this.armeria[indiceSeleccionado]);
            }
            else if (this.armeria[indiceSeleccionado].GetType() == typeof(FusilAsalto))
            {
                ModificarArma((FusilAsalto)this.armeria[indiceSeleccionado]);
            }
            else if (this.armeria[indiceSeleccionado].GetType() == typeof(EscopetaBombeo))
            {
                ModificarArma((EscopetaBombeo)this.armeria[indiceSeleccionado]);
            }

            this.ActualizarVisor();
            this.RegistrarAccion($"Modificó {this.armeria[indiceSeleccionado]} en la armería");
        }

        private void mnuBtnVerDetalles_Click(object sender, EventArgs e)
        {
            int indiceSeleccionado = this.lstVisor.SelectedIndex;
            if (indiceSeleccionado == -1)
            {
                MessageBox.Show("No se seleccionó ningún elemento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FrmVerDetalles frmVerDetalles = new FrmVerDetalles(this.armeria[indiceSeleccionado]);
            frmVerDetalles.Show();
        }

        private void mnuBtnSerializarJson_Click(object sender, EventArgs e)
        {
            try
            {
                string path = this.ObtenerPathGuardar("json");
                if (path == String.Empty) { return; }
                this.SerializarJson(path);
                this.RegistrarAccion($"Guardó la lista actual de armas en formato .json en {path}");
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
                this.RegistrarAccion($"Guardó la lista actual de armas en formato .xml en {path}");
            }
            catch (Exception ex)
            {
                this.RegistrarAccion($"Intentó guardar la lista actual de armas, pero ocurrió un error");
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
                this.RegistrarAccion($"Cargó una lista de armas a la armería desde {path}");
            }
            catch (Exception ex)
            {
                this.RegistrarAccion($"Intentó cargar una lista de armas, pero ocurrió un error");
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

        private void mnuBtnRegistro_Click(object sender, EventArgs e)
        {
            string log = String.Empty;
            try
            {
                string path = Application.StartupPath + "/usuarios.log";

                using (StreamReader sr = new StreamReader(path))
                {
                    log = sr.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo leer el archivo de registros {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FrmLog frmLog = new FrmLog(log);
            frmLog.Show();
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
                this.armeria[this.lstVisor.SelectedIndex] = frmModificarPistola.PistolaCreada;
            }
        }

        private void ModificarArma(FusilAsalto fusil)
        {
            FrmAgregarFusil frmModificarFusil = new FrmAgregarFusil(fusil);
            DialogResult resultado = frmModificarFusil.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                this.armeria[this.lstVisor.SelectedIndex] = frmModificarFusil.FusilCreado;
            }
        }

        private void ModificarArma(EscopetaBombeo escopeta)
        {
            FrmAgregarEscopeta frmModificarEscopeta = new FrmAgregarEscopeta(escopeta);
            DialogResult resultado = frmModificarEscopeta.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                this.armeria[this.lstVisor.SelectedIndex] = frmModificarEscopeta.EscopetaCreada;
            }
        }

        /// <summary>
        /// Se abre un SaveFileDialog para que el usuario elija el destino de guardado de un archivo.
        /// </summary>
        /// <param name="extension"></param>
        /// <returns><br>string</br> El path del destino seleccionado.</returns>
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

        /// <summary>
        /// Se abre un OpenFileDialog para que el usuario elija el archivo que se va a cargar.
        /// </summary>
        /// <param name="extension"></param>
        /// <returns><br>string</br> El path del archivo seleccionado.</returns>
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

                // Para serializar de manera polimórfica, se debe castear la lista a un array de tipo object
                string obj_json = System.Text.Json.JsonSerializer.Serialize((object[])this.armeria.Armas.ToArray(), opciones);
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

        /// <summary>
        /// Se escribe el archivo usuarios.log con la fecha actual y la acción realizada por el usuario.
        /// </summary>
        /// <param name="accion"></param>
        private void RegistrarAccion(string accion)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append($"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}] ");
                sb.Append($"Usuario [{this.usuario.nombre} {this.usuario.apellido} {this.usuario.correo}] ");
                sb.Append(accion);
                string log = sb.ToString();

                string path = Application.StartupPath + "/usuarios.log";

                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    sw.WriteLine(log);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar la acción {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
