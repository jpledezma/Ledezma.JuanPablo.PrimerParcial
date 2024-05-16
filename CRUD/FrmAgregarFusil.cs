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
    public partial class FrmAgregarFusil : FrmAgregarBase
    {
        private FusilAsalto fusilCreado;

        public FusilAsalto FusilCreado
        {
            get { return this.fusilCreado; }
        }

        public FrmAgregarFusil()
        {
            InitializeComponent();
        }

        protected override bool CrearArma()
        {
            bool formatoInvalido = base.CrearArma();

            uint capacidadCargador;
            uint cadencia;
            List<EAccesorioFusil> accesorios = new List<EAccesorioFusil>();

            if (!UInt32.TryParse(txtCapacidadCargador.Text, out capacidadCargador) || capacidadCargador < 1)
            {
                MessageBox.Show("La capacidad del cargador ingresado está en un formato incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                formatoInvalido = true;
            }

            if (!UInt32.TryParse(txtCadencia.Text, out cadencia) || cadencia < 1)
            {
                MessageBox.Show("La cadencia de fuego ingresado está en un formato incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                formatoInvalido = true;
            }

            // Accesorios
            if (chkBipode.Checked) accesorios.Add(EAccesorioFusil.Bipode);
            if (chkCargadorTambor.Checked) accesorios.Add(EAccesorioFusil.CargadorTambor);
            if (chkCorrea.Checked) accesorios.Add(EAccesorioFusil.Correa);
            if (chkCulataPlegable.Checked) accesorios.Add(EAccesorioFusil.CulataPlegable);
            if (chkFrenoBoca.Checked) accesorios.Add(EAccesorioFusil.FrenoDeBoca);
            if (chkLinterna.Checked) accesorios.Add(EAccesorioFusil.Linterna);
            if (chkMiraLaser.Checked) accesorios.Add(EAccesorioFusil.MiraLaser);
            if (chkMiraTelescopica.Checked) accesorios.Add(EAccesorioFusil.MiraTelescopica);

            if (!formatoInvalido)
            {


                this.fusilCreado = new FusilAsalto(base.fabricante,
                                                   base.modelo,
                                                   base.numeroSerie,
                                                   base.pesoKg,
                                                   base.calibreMunicion,
                                                   base.materialesConstruccion,
                                                   capacidadCargador,
                                                   cadencia,
                                                   base.precio,
                                                   accesorios
                                                  );
            }

            return formatoInvalido;
        }
    }
}
