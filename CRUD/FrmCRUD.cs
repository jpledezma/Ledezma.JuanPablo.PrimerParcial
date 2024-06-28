using ADO;
using Armas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace CRUD
{
    public partial class FrmCRUD : Form
    {
        // los cambios sin guardar podrian ser un evento
        private Armeria<ArmaDeFuego> armeria;
        private Usuario usuario;
        private bool cambiosSinGuardar;
        private List<ArmaDeFuego> armasModificadas;
        private List<ArmaDeFuego> armasEliminadas;
        private Armeria<ArmaDeFuego>.Comparar[] comparaciones;
        bool cargadoDesdeDB;

        #region Constructores
        public FrmCRUD()
        {
            InitializeComponent();
            this.armeria = new Armeria<ArmaDeFuego>();
            this.armasModificadas = new List<ArmaDeFuego>();
            this.armasEliminadas = new List<ArmaDeFuego>();
            this.usuario = new Usuario();
            this.mnuTxtDatosLogin.Text = DateTime.Now.ToString("dd/MM/yyyy");
            this.mnuCboOrden.SelectedIndex = 0;
            this.mnuCboCriterio.SelectedIndex = 0;
            this.cambiosSinGuardar = false;
            this.cargadoDesdeDB = false;
            this.comparaciones = new Armeria<ArmaDeFuego>.Comparar[]
            {
                (ArmaDeFuego a1, ArmaDeFuego a2) => { return a1.CalibreMunicion.ToString().CompareTo(a2.CalibreMunicion.ToString()) == 1; },
                (ArmaDeFuego a1, ArmaDeFuego a2) => { return a1.Fabricante.CompareTo(a2.Fabricante) == 1; },
                (ArmaDeFuego a1, ArmaDeFuego a2) => { return a1.NumeroSerie.CompareTo(a2.NumeroSerie) == 1; },
                (ArmaDeFuego a1, ArmaDeFuego a2) => { return a1.PesoTotal > a2.PesoTotal; },
                (ArmaDeFuego a1, ArmaDeFuego a2) => { return a1.Precio > a2.Precio; },
                (ArmaDeFuego a1, ArmaDeFuego a2) => { return a1.GetType().Name.CompareTo(a2.GetType().Name) == 1; },
            };
            /*
                Calibre
                Fabricante
                Número de serie
                Peso
                Precio
                Tipo
            */
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
            this.OcultarItemsMenu(usuario);
            this.RegistrarAccion("Inició sesión");
        }
        #endregion

        #region Eventos
        private void FrmCRUD_FormClosing(object sender, FormClosingEventArgs e)
        {
            string mensaje = "¿Seguro que desea salir de la aplicación?\nSe perderán todos los cambios sin guardar.";
            DialogResult respuesta;
            respuesta = MessageBox.Show(mensaje, "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

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
            {
                this.armeria += frmAgregarPistola.PistolaCreada;
                this.ActualizarVisor();
                this.RegistrarAccion($"Agregó {frmAgregarPistola.PistolaCreada} a la armería");

                this.Text += this.cambiosSinGuardar == false ? "*" : "";
                this.cambiosSinGuardar = true;
            }
        }

        private void mnuBtnFusil_Click(object sender, EventArgs e)
        {
            FrmAgregarFusil frmAgregarFusil = new FrmAgregarFusil();
            DialogResult resultado = frmAgregarFusil.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                this.armeria += frmAgregarFusil.FusilCreado;
                this.ActualizarVisor();
                this.RegistrarAccion($"Agregó {frmAgregarFusil.FusilCreado} a la armería");

                this.Text += this.cambiosSinGuardar == false ? "*" : "";
                this.cambiosSinGuardar = true;
            }
        }

        private void mnuBtnEscopeta_Click(object sender, EventArgs e)
        {
            FrmAgregarEscopeta frmAgregarEscopeta = new FrmAgregarEscopeta();
            DialogResult resultado = frmAgregarEscopeta.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                this.armeria += frmAgregarEscopeta.EscopetaCreada;
                this.ActualizarVisor();
                this.RegistrarAccion($"Agregó {frmAgregarEscopeta.EscopetaCreada} a la armería");

                this.Text += this.cambiosSinGuardar == false ? "*" : "";
                this.cambiosSinGuardar = true;
            }
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
            string msj = $"¿Seguro que desea eliminar el arma {armaSeleccionada}?";
            resultado = MessageBox.Show(msj, "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (resultado == DialogResult.Yes)
            {
                try
                {
                    this.armeria -= armaSeleccionada;
                    this.RegistrarAccion($"Eliminó {armaSeleccionada} de la armería");
                    if (this.cargadoDesdeDB)
                        this.armasEliminadas.Add(armaSeleccionada);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.ActualizarVisor();

                this.Text += this.cambiosSinGuardar == false ? "*" : "";
                this.cambiosSinGuardar = true;
            }

        }

        private void mnuBtnModificar_Click(object sender, EventArgs e)
        {
            int indiceSeleccionado = this.lstVisor.SelectedIndex;
            if (indiceSeleccionado == -1)
            {
                MessageBox.Show("No se seleccionó ningún elemento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool modificacion = false;
            if (this.armeria[indiceSeleccionado].GetType() == typeof(PistolaSemiautomatica))
            {
                modificacion = ModificarArma((PistolaSemiautomatica)this.armeria[indiceSeleccionado]);
            }
            else if (this.armeria[indiceSeleccionado].GetType() == typeof(FusilAsalto))
            {
                modificacion = ModificarArma((FusilAsalto)this.armeria[indiceSeleccionado]);
            }
            else if (this.armeria[indiceSeleccionado].GetType() == typeof(EscopetaBombeo))
            {
                modificacion = ModificarArma((EscopetaBombeo)this.armeria[indiceSeleccionado]);
            }

            if (modificacion)
            {
                if(this.cargadoDesdeDB)
                    this.armasModificadas.Add(this.armeria[indiceSeleccionado]);

                this.RegistrarAccion($"Modificó {this.armeria[indiceSeleccionado]} en la armería");
                this.Text += this.cambiosSinGuardar == false ? "*" : "";
                this.cambiosSinGuardar = true;
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

                this.Text = this.Text.TrimEnd('*');
                this.cambiosSinGuardar = false;
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

                this.Text = this.Text.TrimEnd('*');
                this.cambiosSinGuardar = false;
            }
            catch (Exception ex)
            {
                this.RegistrarAccion($"Intentó guardar la lista actual de armas, pero ocurrió un error");
                MessageBox.Show($"No se pudo guardar el archivo\n\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuBtnDeserializarXml_Click(object sender, EventArgs e)
        {
            if (this.cambiosSinGuardar)
            {
                string mensaje = "Tiene cambios sin guardar.\n¿Desea continuar de todos modos?";
                DialogResult respuesta;
                respuesta = MessageBox.Show(mensaje, "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (respuesta == DialogResult.No)
                {
                    return;
                }
            }
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

            this.Text = this.Text.TrimEnd('*');
            this.cambiosSinGuardar = false;
            this.cargadoDesdeDB = false;
            this.armasEliminadas.Clear();
            this.armasModificadas.Clear();
        }

        /*private void mnuBtnOrdenar_Click(object sender, EventArgs e)
        {
            if (this.armeria.Armas.Count == 0)
            {
                return;
            }
            string propiedad;
            int indiceCriterio = this.mnuCboCriterio.SelectedIndex;
            string[] criterios = {
                                    "calibre",
                                    "fabricante",
                                    "numero_serie",
                                    "peso",
                                    "precio",
                                    "tipo"
                                 };

            propiedad = criterios[indiceCriterio];

            if (this.mnuCboOrden.Text == "Ascendente")
                this.armeria.OrdenarArmeria(propiedad);
            else if (this.mnuCboOrden.Text == "Descendente")
                this.armeria.OrdenarArmeria(propiedad, true);

            this.ActualizarVisor();
            this.Text += this.cambiosSinGuardar == false ? "*" : "";
            this.cambiosSinGuardar = true;
        }*/
        private void mnuBtnOrdenar_Click(object sender, EventArgs e)
        {
            if (this.armeria.Armas.Count == 0)
            {
                return;
            }
            
            int indiceCriterio = this.mnuCboCriterio.SelectedIndex;

            Armeria<ArmaDeFuego>.Comparar comparacion = this.comparaciones[indiceCriterio];

            if (this.mnuCboOrden.Text == "Ascendente")
                this.armeria.OrdenarArmeria(comparacion);
            else if (this.mnuCboOrden.Text == "Descendente")
                this.armeria.OrdenarArmeria(comparacion, true);

            this.ActualizarVisor();
            this.Text += this.cambiosSinGuardar == false ? "*" : "";
            this.cambiosSinGuardar = true;
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

        private void mnuBtnGuardarDB_Click(object sender, EventArgs e)
        {
            string mensaje = "Esta acción no se puede deshacer.\n¿Desea continuar de todos modos?";
            DialogResult respuesta;
            respuesta = MessageBox.Show(mensaje, "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (respuesta == DialogResult.No)
                return;

            var ado = new AccesoDB();

            if (!this.ProbarConexionDB(ado))
                return;

            Armeria<ArmaDeFuego> armasEnDB = new Armeria<ArmaDeFuego>(ado.ObtenerListaArmas());

            // Sólo elimino/modifico armas si la lista fue cargada desde la DB, para evitar comportamiento no deseado
            if (this.cargadoDesdeDB)
            {
                foreach (ArmaDeFuego arma in this.armasEliminadas)
                {
                    ado.EliminarArma(arma);
                }
                foreach (ArmaDeFuego arma in this.armasModificadas)
                {
                    ado.ModificarArma(arma);
                }
            }

            int armasAgregadas = 0;
            int armasDuplicadas = 0;
            int fallos = 0;
            foreach (ArmaDeFuego arma in this.armeria)
            {
                if (armasEnDB.Armas.Contains(arma))
                {
                    armasDuplicadas++;
                    continue;
                }

                if (ado.AgregarArma(arma) == true)
                    armasAgregadas++;
                else
                    fallos++;
            }

            string msj = "Se actualizó la base de datos.\n";
            msj += $"Armas agregadas: {armasAgregadas}\n";
            msj += $"Armas NO agregadas (duplicadas): {armasDuplicadas}\n";
            msj += $"Armas NO agregadas (fallido): {fallos}\n";
            msj += $"Armas modificadas: {this.armasModificadas.Count}\n";
            msj += $"Armas eliminadas: {this.armasEliminadas.Count}";
            MessageBox.Show(msj, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.RegistrarAccion($"Actualizó la base de datos");
            this.Text = this.Text.TrimEnd('*');
            this.cambiosSinGuardar = false;
            this.armasModificadas.Clear();
            this.armasEliminadas.Clear();
        }

        private void mnuBtnCargarDB_Click(object sender, EventArgs e)
        {
            var ado = new AccesoDB();

            if (!this.ProbarConexionDB(ado))
                return;

            if (this.cambiosSinGuardar)
            {
                string mensaje = "Tiene cambios sin guardar.\n¿Desea continuar de todos modos?";
                DialogResult respuesta;
                respuesta = MessageBox.Show(mensaje, "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (respuesta == DialogResult.No)
                {
                    return;
                }
            }

            var datos = ado.ObtenerListaArmas();

            this.armeria = new Armeria<ArmaDeFuego>(datos);

            this.ActualizarVisor();
            this.Text = this.Text.TrimEnd('*');
            this.cambiosSinGuardar = false;
            this.cargadoDesdeDB = true;
            this.armasEliminadas.Clear();
            this.armasModificadas.Clear();
        }
        #endregion

        #region Metodos
        private void ActualizarVisor()
        {
            this.lstVisor.Items.Clear();
            foreach (var arma in this.armeria)
            {
                this.lstVisor.Items.Add(arma.MostrarEnVisor());
            }
        }

        private bool ModificarArma(PistolaSemiautomatica pistola)
        {
            bool armaModificada = false;
            FrmAgregarPistola frmModificarPistola = new FrmAgregarPistola(pistola);
            DialogResult resultado = frmModificarPistola.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                this.armeria[this.lstVisor.SelectedIndex] = frmModificarPistola.PistolaCreada;
                armaModificada = true;
            }
            return armaModificada;
        }

        private bool ModificarArma(FusilAsalto fusil)
        {
            bool armaModificada = false;
            FrmAgregarFusil frmModificarFusil = new FrmAgregarFusil(fusil);
            DialogResult resultado = frmModificarFusil.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                this.armeria[this.lstVisor.SelectedIndex] = frmModificarFusil.FusilCreado;
                armaModificada = true;
            }
            return armaModificada;
        }

        private bool ModificarArma(EscopetaBombeo escopeta)
        {
            bool armaModificada = false;
            FrmAgregarEscopeta frmModificarEscopeta = new FrmAgregarEscopeta(escopeta);
            DialogResult resultado = frmModificarEscopeta.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                this.armeria[this.lstVisor.SelectedIndex] = frmModificarEscopeta.EscopetaCreada;
                armaModificada = true;
            }
            return armaModificada;
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
                this.armeria = new Armeria<ArmaDeFuego>(armas);
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

        private void OcultarItemsMenu(Usuario? usuario)
        {
            if (usuario is null || usuario.perfil != "administrador" && usuario.perfil != "supervisor")
            {
                this.mnuBtnRegistro.Visible = false;
                this.mnuArma.Visible = false;
                this.mnuBtnGuardar.Visible = false;
            }
            else if (usuario.perfil == "supervisor")
            {
                this.mnuBtnEliminar.Visible = false;
                this.mnuBtnRegistro.Visible = false;
            }

        }

        private bool ProbarConexionDB(AccesoDB ado)
        {
            if (ado.ProbarConexion())
            {
                return true;
            }
            else
            {
                MessageBox.Show("No se pudo conectar a la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        #endregion
    }
}
