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
    public partial class FrmAgregarEscopeta : FrmAgregarBase
    {
        private EscopetaBombeo escopetaCreada;

        public EscopetaBombeo EscopetaCreada
        {
            get { return this.escopetaCreada; }
        }

        public FrmAgregarEscopeta()
        {
            InitializeComponent();
            this.escopetaCreada = new EscopetaBombeo();
        }

        public FrmAgregarEscopeta(EscopetaBombeo escopeta) : this()
        {
            this.escopetaCreada = escopeta;
            this.LeerDatosArma(escopeta);
        }

        protected override bool CrearArma()
        {
            bool formatoInvalido = base.CrearArma();

            uint capacidad;
            List<EAccesorioEscopeta> accesorios = new List<EAccesorioEscopeta>();

            if (!UInt32.TryParse(txtCapacidad.Text, out capacidad) || capacidad < 1)
            {
                MessageBox.Show("La capacidad del cargador ingresado está en un formato incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                formatoInvalido = true;
            }

            // Accesorios
            if (chkCorrea.Checked) accesorios.Add(EAccesorioEscopeta.Correa);
            if (chkCulataAcolchada.Checked) accesorios.Add(EAccesorioEscopeta.CulataAcolchada);
            if (chkEstrangulador.Checked) accesorios.Add(EAccesorioEscopeta.Estrangulador);
            if (chkLinterna.Checked) accesorios.Add(EAccesorioEscopeta.Linterna);
            if (chkMiraLaser.Checked) accesorios.Add(EAccesorioEscopeta.MiraLaser);
            if (chkMiraMetalica.Checked) accesorios.Add(EAccesorioEscopeta.MiraMetalica);
            if (chkPortacartuchos.Checked) accesorios.Add(EAccesorioEscopeta.Portacartuchos);

            if (!formatoInvalido)
            {


                this.escopetaCreada = new EscopetaBombeo(base.fabricante,
                                                         base.modelo,
                                                         base.numeroSerie,
                                                         base.pesoKg,
                                                         base.calibreMunicion,
                                                         base.materialesConstruccion,
                                                         capacidad,
                                                         base.precio,
                                                         accesorios
                                                        );
            }

            return formatoInvalido;
        }

        protected override void LeerDatosArma(ArmaDeFuego arma)
        {
            base.LeerDatosArma(arma);
            this.txtCapacidad.Enabled = false;

            this.txtCapacidad.Text = this.escopetaCreada.Capacidad.ToString();
            if (this.escopetaCreada.Accesorios.Contains(EAccesorioEscopeta.Correa)) this.chkCorrea.Checked = true;
            if (this.escopetaCreada.Accesorios.Contains(EAccesorioEscopeta.CulataAcolchada)) this.chkCulataAcolchada.Checked = true;
            if (this.escopetaCreada.Accesorios.Contains(EAccesorioEscopeta.Estrangulador)) this.chkEstrangulador.Checked = true;
            if (this.escopetaCreada.Accesorios.Contains(EAccesorioEscopeta.Linterna)) this.chkLinterna.Checked = true;
            if (this.escopetaCreada.Accesorios.Contains(EAccesorioEscopeta.MiraLaser)) this.chkMiraLaser.Checked = true;
            if (this.escopetaCreada.Accesorios.Contains(EAccesorioEscopeta.MiraMetalica)) this.chkMiraMetalica.Checked = true;
            if (this.escopetaCreada.Accesorios.Contains(EAccesorioEscopeta.Portacartuchos)) this.chkPortacartuchos.Checked = true;
        }
    }
}
