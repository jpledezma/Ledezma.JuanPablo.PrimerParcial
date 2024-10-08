﻿using Armas;
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
            this.fusilCreado = new FusilAsalto();
            this.MaximizeBox = false;
        }

        public FrmAgregarFusil(FusilAsalto fusil) : this()
        {
            this.fusilCreado = fusil;
            this.LeerDatosArma(fusil);
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
            if (chkCorrea.Checked) accesorios.Add(EAccesorioFusil.Correa);
            if (chkCulataPlegable.Checked) accesorios.Add(EAccesorioFusil.CulataPlegable);
            if (chkFrenoDeBoca.Checked) accesorios.Add(EAccesorioFusil.FrenoDeBoca);
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

        protected override void LeerDatosArma(ArmaDeFuego arma)
        {
            base.LeerDatosArma(arma);
            this.txtCapacidadCargador.Enabled = false;
            this.txtCadencia.Enabled = false;

            this.txtCapacidadCargador.Text = this.fusilCreado.CapacidadCargador.ToString();
            this.txtCadencia.Text = this.fusilCreado.Cadencia.ToString();
            if (this.fusilCreado.Accesorios.Contains(EAccesorioFusil.Bipode)) this.chkBipode.Checked = true;
            if (this.fusilCreado.Accesorios.Contains(EAccesorioFusil.Correa)) this.chkCorrea.Checked = true;
            if (this.fusilCreado.Accesorios.Contains(EAccesorioFusil.CulataPlegable)) this.chkCulataPlegable.Checked = true;
            if (this.fusilCreado.Accesorios.Contains(EAccesorioFusil.FrenoDeBoca)) this.chkFrenoDeBoca.Checked = true;
            if (this.fusilCreado.Accesorios.Contains(EAccesorioFusil.Linterna)) this.chkLinterna.Checked = true;
            if (this.fusilCreado.Accesorios.Contains(EAccesorioFusil.MiraLaser)) this.chkMiraLaser.Checked = true;
            if (this.fusilCreado.Accesorios.Contains(EAccesorioFusil.MiraTelescopica)) this.chkMiraTelescopica.Checked = true;
        }
    }
}
