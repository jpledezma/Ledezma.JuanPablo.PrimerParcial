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
    // No puede ser abstracta porque los forms heredaros no podrían abrir el designer
    public partial class FrmAgregarBase : Form
    {
        protected string fabricante;
        protected string modelo;
        protected string numeroSerie;
        protected double precio;
        protected double pesoKg;
        protected EMunicion calibreMunicion;
        protected List<EMaterial> materialesConstruccion;

        public FrmAgregarBase()
        {
            InitializeComponent();
        }

        private void FrmAgregarBase_Load(object sender, EventArgs e)
        {
            this.CargarTiposCalibre();
        }

        private void CargarTiposCalibre()
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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            bool error = this.CrearArma();

            if (!error)
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        protected virtual bool CrearArma()
        {
            bool formatoInvalido = false;

            this.materialesConstruccion = new List<EMaterial>();

            this.fabricante = txtFabricante.Text;
            this.modelo = txtModelo.Text;
            this.numeroSerie = txtNumeroSerie.Text;
            this.calibreMunicion = (EMunicion)cboCalibre.SelectedItem;

            if( !Double.TryParse(this.txtPrecio.Text, out this.precio) || this.precio < 0 )
            {
                MessageBox.Show("El precio ingresado está en un formato incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                formatoInvalido = true;
            }
            if (!Double.TryParse(this.txtPeso.Text, out this.pesoKg) || this.pesoKg <= 0)
            {
                MessageBox.Show("El peso ingresado está en un formato incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                formatoInvalido = true;
            }
            if (!(this.chkAcero.Checked || this.chkAluminio.Checked || this.chkMadera.Checked || this.chkPolimero.Checked))
            {
                MessageBox.Show("Debe seleccionar al menos un material de construcción", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                formatoInvalido = true;
            }

            // Materiales de construccion
            if (this.chkAcero.Checked) this.materialesConstruccion.Add(EMaterial.Acero);
            if (this.chkAluminio.Checked) this.materialesConstruccion.Add(EMaterial.Aluminio);
            if (this.chkMadera.Checked) this.materialesConstruccion.Add(EMaterial.Madera);
            if (this.chkPolimero.Checked) this.materialesConstruccion.Add(EMaterial.Polimero);

            return formatoInvalido;
        }

        protected virtual void LeerDatosArma(ArmaDeFuego arma)
        {
            this.txtFabricante.Text = arma.Fabricante;
            this.txtModelo.Text = arma.Modelo;
            this.txtNumeroSerie.Text = arma.NumeroSerie;
            this.txtPeso.Text = arma.PesoBase.ToString();
            this.txtPrecio.Text = arma.Precio.ToString();
            this.cboCalibre.SelectedItem = arma.CalibreMunicion;
            if (arma.MaterialesConstruccion.Contains(EMaterial.Acero))
                this.chkAcero.Checked = true;
            if (arma.MaterialesConstruccion.Contains(EMaterial.Aluminio))
                this.chkAluminio.Checked = true;
            if (arma.MaterialesConstruccion.Contains(EMaterial.Madera))
                this.chkMadera.Checked = true;
            if (arma.MaterialesConstruccion.Contains(EMaterial.Polimero))
                this.chkPolimero.Checked = true;

            this.txtFabricante.Enabled = false;
            this.txtModelo.Enabled = false;
            this.txtNumeroSerie.Enabled = false;
            this.txtPeso.Enabled = false;
            this.cboCalibre.Enabled = false;
            this.chkAcero.Enabled = false;
            this.chkAluminio.Enabled = false;
            this.chkMadera.Enabled = false;
            this.chkPolimero.Enabled = false;
        }
    }
}
