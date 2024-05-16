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
    public partial class FrmAgregarPistola : FrmAgregarBase
    {
        private PistolaSemiautomatica pistolaCreada;

        public PistolaSemiautomatica PistolaCreada
        {
            get { return this.pistolaCreada; }
        }

        public FrmAgregarPistola()
        {
            InitializeComponent();
        }

        protected override bool CrearArma()
        {
            bool formatoInvalido = base.CrearArma();

            uint capacidadCargador;
            List<EAccesorioPistola> accesorios = new List<EAccesorioPistola>();

            if( !UInt32.TryParse(txtCapacidadCargador.Text, out capacidadCargador) || capacidadCargador < 1 )
            {
                MessageBox.Show("La capacidad del cargador ingresado está en un formato incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                formatoInvalido = true;
            }

            // Accesorios
            if (chkCargadorAmpliado.Checked) accesorios.Add(EAccesorioPistola.CargadorAmpliado);
            if (chkLinterna.Checked) accesorios.Add(EAccesorioPistola.Linterna);
            if (chkMiraHolografica.Checked) accesorios.Add(EAccesorioPistola.MiraHolografica);
            if (chkMiraLaser.Checked) accesorios.Add(EAccesorioPistola.MiraLaser);
            if (chkSupresor.Checked) accesorios.Add(EAccesorioPistola.Supresor);

            if (!formatoInvalido)
            {


                this.pistolaCreada = new PistolaSemiautomatica(base.fabricante,
                                                               base.modelo,
                                                               base.numeroSerie,
                                                               base.pesoKg,
                                                               base.calibreMunicion,
                                                               base.materialesConstruccion,
                                                               capacidadCargador,
                                                               base.precio,
                                                               accesorios
                                                              );
            }

            return formatoInvalido;
        }
    }
}
