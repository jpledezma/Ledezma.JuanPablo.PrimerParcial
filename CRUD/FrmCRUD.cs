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
        private Armeria<ArmaDeFuego> armeria;
        private Usuario usuario;
        private AccesoDB ado;
        private bool cambiosSinGuardar;
        private List<ArmaDeFuego> armasModificadas;
        private List<ArmaDeFuego> armasEliminadas;
        private Armeria<ArmaDeFuego>.Comparar[] comparaciones;
        bool cargadoDesdeDB;

        #region Constructores
        public FrmCRUD()
        {
            InitializeComponent();
            this.InstanciarArmeria();
            this.armasModificadas = new List<ArmaDeFuego>();
            this.armasEliminadas = new List<ArmaDeFuego>();
            this.usuario = new Usuario();
            this.ado = new AccesoDB(); 
            this.stsLblDatosLogin.Text = DateTime.Now.ToString("dd/MM/yyyy");
            this.mnuCboOrden.SelectedIndex = 0;
            this.mnuCboCriterio.SelectedIndex = 0;
            this.stsLblDatosLogin.Alignment = ToolStripItemAlignment.Right;
            this.cambiosSinGuardar = false;
            this.cargadoDesdeDB = false;
            this.ado.EventoAdvertencia += (string msj) => MessageBox.Show(msj, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            this.comparaciones = new Armeria<ArmaDeFuego>.Comparar[]
            {
                (ArmaDeFuego a1, ArmaDeFuego a2) => a1.CalibreMunicion.ToString().CompareTo(a2.CalibreMunicion.ToString()) == 1,
                (ArmaDeFuego a1, ArmaDeFuego a2) => a1.Fabricante.CompareTo(a2.Fabricante) == 1,
                (ArmaDeFuego a1, ArmaDeFuego a2) => a1.NumeroSerie.CompareTo(a2.NumeroSerie) == 1,
                (ArmaDeFuego a1, ArmaDeFuego a2) => a1.PesoTotal > a2.PesoTotal,
                (ArmaDeFuego a1, ArmaDeFuego a2) => a1.Precio > a2.Precio,
                (ArmaDeFuego a1, ArmaDeFuego a2) => a1.GetType().Name.CompareTo(a2.GetType().Name) == 1,
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
            this.stsLblDatosLogin.Text = nombreUsuario + this.stsLblDatosLogin.Text;
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
                this.AgregarArma(frmAgregarPistola.PistolaCreada);
                this.NotificarCambiosRealizados(sender);
            }
        }

        private void mnuBtnFusil_Click(object sender, EventArgs e)
        {
            FrmAgregarFusil frmAgregarFusil = new FrmAgregarFusil();
            DialogResult resultado = frmAgregarFusil.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                this.AgregarArma(frmAgregarFusil.FusilCreado);
                this.NotificarCambiosRealizados(sender);
            }
        }

        private void mnuBtnEscopeta_Click(object sender, EventArgs e)
        {
            FrmAgregarEscopeta frmAgregarEscopeta = new FrmAgregarEscopeta();
            DialogResult resultado = frmAgregarEscopeta.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                this.AgregarArma(frmAgregarEscopeta.EscopetaCreada);
                this.NotificarCambiosRealizados(sender);
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
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.ActualizarVisor();
                this.NotificarCambiosRealizados(sender);
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
                if (this.cargadoDesdeDB)
                    this.armasModificadas.Add(this.armeria[indiceSeleccionado]);

                this.RegistrarAccion($"Modificó {this.armeria[indiceSeleccionado]} en la armería");
                this.NotificarCambiosRealizados(sender);
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

                this.NotificarCambiosRealizados(sender);
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

                this.NotificarCambiosRealizados(sender);
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
            this.NotificarCambiosRealizados(sender);
        }

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

            if (!this.ado.ProbarConexion())
                return;

            Armeria<ArmaDeFuego> armasEnDB = new Armeria<ArmaDeFuego>(this.ado.ObtenerListaArmas());

            // Sólo elimino/modifico armas si la lista fue cargada desde la DB, para evitar comportamiento no deseado
            if (this.cargadoDesdeDB)
            {
                foreach (ArmaDeFuego arma in this.armasEliminadas)
                {
                    this.ado.EliminarArma(arma);
                }
                foreach (ArmaDeFuego arma in this.armasModificadas)
                {
                    this.ado.ModificarArma(arma);
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

                if (this.ado.AgregarArma(arma) == true)
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
            this.NotificarCambiosRealizados(sender);
        }

        private void mnuBtnCargarDB_Click(object sender, EventArgs e)
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

            this.Cursor = Cursors.AppStarting;
            this.stsLblEstadoTareas.Text = "Cargando desde la base de datos...";

            Task.Run( () => this.CargarDB() );            
        }

        private void lstVisor_KeyDown(object sender, KeyEventArgs e)
        {
            int indiceSeleccionado = this.lstVisor.SelectedIndex;

            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Insert){
                this.mnuArma.ShowDropDown();
                this.mnuBtnAgregar.ShowDropDown();
                this.mnuBtnPistola.ShowDropDown();
            }
            
            if (indiceSeleccionado == -1)
                return;

            switch (e.KeyCode)
            {
                case Keys.Enter or Keys.Space:
                    this.mnuBtnVerDetalles_Click(sender, e);
                    break;
                case Keys.Delete:
                    this.mnuBtnEliminar_Click(sender, e);
                    break;
                case Keys.M:
                    this.mnuBtnModificar_Click(sender, e);
                    break;
            }
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Se eliminan todos los elementos de la listbox Visor. Luego se le agregan los elementos de la armería.
        /// </summary>
        private void ActualizarVisor()
        {
            this.lstVisor.Items.Clear();
            foreach (var arma in this.armeria)
            {
                this.lstVisor.Items.Add(arma.MostrarEnVisor());
            }
        }

        /// <summary>
        /// Se intenta agregar un arma a la armeria. Si ya existe una con su tipo y numero de serie, se muestra un mensaje de error.
        /// </summary>
        /// <param name="arma"></param>
        private void AgregarArma(ArmaDeFuego arma)
        {
            try
            {
                this.armeria += arma;
                this.RegistrarAccion($"Agregó {arma} a la armería");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.RegistrarAccion($"Intentó agregar {arma} a la armería, pero ya existía un arma con su tipo y número de serie.");
            }
            this.ActualizarVisor();
        }

        /// <summary>
        /// Se abre un formulario para modificar las propiedades de la pistola seleccionada.
        /// Si se aceptan los cambios, se modifica la pistola en la armeria.
        /// </summary>
        /// <param name="pistola"></param>
        /// <returns><b>true</b> Si se aceptan los cambios. <b>false</b> Si se cancela la modificacion</returns>
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

        /// <summary>
        /// Se abre un formulario para modificar las propiedades del fusil seleccionado.
        /// Si se aceptan los cambios, se modifica el fusil en la armeria.
        /// </summary>
        /// <param name="fusil"></param>
        /// <returns><b>true</b> Si se aceptan los cambios. <b>false</b> Si se cancela la modificacion</returns>
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

        /// <summary>
        /// Se abre un formulario para modificar las propiedades de la escopeta seleccionada.
        /// Si se aceptan los cambios, se modifica la escopeta en la armeria.
        /// </summary>
        /// <param name="escopeta"></param>
        /// <returns><b>true</b> Si se aceptan los cambios. <b>false</b> Si se cancela la modificacion</returns>
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
                this.InstanciarArmeria(armas);
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

        private void InstanciarArmeria(List<ArmaDeFuego>? armas = null)
        {
            if (armas == null)
                this.armeria = new Armeria<ArmaDeFuego>();
            else
                this.armeria = new Armeria<ArmaDeFuego>(armas);

            this.armeria.EventoEliminacion += (string msj) => MessageBox.Show(msj, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.armeria.EventoInsercion += (string msj) => MessageBox.Show(msj, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CargarDB(string estadoFinal = "")
        {
            if (this.stsEstado.InvokeRequired)
            {
                string resultado;

                if (this.ado.ProbarConexion())
                {
                    List<ArmaDeFuego> datos = this.ado.ObtenerListaArmas();
                    this.InstanciarArmeria(datos);
                    resultado = "Listo";
                }
                else
                {
                    resultado = "Error. No se pudo conectar a la base de datos.";
                }

                Action<string> delegado = new Action<string>(this.CargarDB);
                //Thread.Sleep(3000);
                this.stsEstado.Invoke(delegado, resultado);
            }
            else
            {
                this.ActualizarVisor();
                this.stsLblEstadoTareas.Text = estadoFinal;
                this.Cursor = Cursors.Default;
                this.NotificarCambiosRealizados(this.mnuBtnCargarDB);
            }
        }

        private void NotificarCambiosRealizados(object sender)
        {
            string? msj = null;

            if (sender == this.mnuBtnGuardarDB)
            {
                this.Text = this.Text.TrimEnd('*');
                this.cambiosSinGuardar = false;
                this.armasEliminadas.Clear();
                this.armasModificadas.Clear();
                msj = "Actualizó la base de datos";
            }
            else if (sender == this.mnuBtnCargarDB)
            {
                this.Text = this.Text.TrimEnd('*');
                this.cambiosSinGuardar = false;
                this.cargadoDesdeDB = true;
                this.armasEliminadas.Clear();
                this.armasModificadas.Clear();
                msj = "Cargó una lista de armas a la armería desde la base de datos";
            }
            else if(sender == this.mnuBtnDeserializarXml)
            {
                this.Text = this.Text.TrimEnd('*');
                this.cambiosSinGuardar = false;
                this.cargadoDesdeDB = false;
                this.armasEliminadas.Clear();
                this.armasModificadas.Clear();
            }
            else if (sender == this.mnuBtnSerializarJson || sender == this.mnuBtnSerializarXml)
            {
                this.Text = this.Text.TrimEnd('*');
                this.cambiosSinGuardar = false;
            }
            else if (sender == this.mnuBtnPistola || sender ==this.mnuBtnFusil || sender == this.mnuBtnEscopeta || 
                sender == this.mnuBtnModificar || sender == this.mnuBtnEliminar)
            {
                this.Text += this.cambiosSinGuardar == false ? "*" : "";
                this.cambiosSinGuardar = true;
            }
            

            if (msj is not null)
            {
                this.RegistrarAccion(msj);
            }
        }
        #endregion
    }
}
