using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Armas;
using Municion;

namespace CRUD
{
    public partial class FrmVerDetalles : Form
    {
        public FrmVerDetalles()
        {
            InitializeComponent();
        }

        public FrmVerDetalles(ArmaDeFuego arma) : this()
        {
            this.Text += " " + arma;
            string datosArma;
            if (arma.GetType() == typeof(PistolaSemiautomatica))
            {
                datosArma = ObtenerDetalles((PistolaSemiautomatica)arma);
            }
            else if (arma.GetType() == typeof(FusilAsalto))
            {
                datosArma = ObtenerDetalles((FusilAsalto)arma);
            }
            else if (arma.GetType() == typeof(EscopetaBombeo))
            {
                datosArma = ObtenerDetalles((EscopetaBombeo)arma);
            }
            else
            {
                datosArma = ObtenerDetalles(arma);
            }

            this.txtDetallesArma.Text = datosArma;
        }

        public string ObtenerDetalles(ArmaDeFuego arma)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Tipo: {arma.GetType().Name}\n");
            sb.AppendLine($"Fabricante: {arma.Fabricante}\n");
            sb.AppendLine($"Modelo: {arma.Modelo}\n");
            sb.AppendLine($"Número de serie: {arma.NumeroSerie}\n");
            sb.AppendLine($"Peso base: {arma.PesoBase} Kg\n");
            sb.AppendLine($"Peso total: {arma.PesoTotal} Kg\n");
            sb.AppendLine($"Precio: ${arma.Precio}\n");
            sb.AppendLine($"Calibre: {arma.CalibreMunicion}\n");
            sb.AppendLine($"Materiales de construcción:");
            foreach (EMaterial material in arma.MaterialesConstruccion)
            {
                sb.AppendLine($"  • {material}");
            }

            return sb.ToString();
        }

        public string ObtenerDetalles(PistolaSemiautomatica pistola)
        {
            string datosGenerales = this.ObtenerDetalles((ArmaDeFuego)pistola);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(datosGenerales);
            sb.AppendLine($"Capacidad del cargador: {pistola.CapacidadCargador}\n");
            sb.AppendLine($"Accesorios:");
            foreach (EAccesorioPistola accesorio in pistola.Accesorios)
            {
                sb.AppendLine($"  • {accesorio}");
            }
            sb.AppendLine($"\nCartuchos cargados:");
            if (pistola.Cargador.CartuchosCargados.Count == 0)
            {
                sb.AppendLine("  Cargador vacío");
            }
            foreach (Cartucho cartucho in pistola.Cargador.CartuchosCargados)
            {
                sb.AppendLine($"  • {cartucho.ToString()}");
            }

            return sb.ToString();
        }

        public string ObtenerDetalles(FusilAsalto fusil)
        {
            string datosGenerales = this.ObtenerDetalles((ArmaDeFuego)fusil);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(datosGenerales);
            sb.AppendLine($"Capacidad del cargador: {fusil.CapacidadCargador}\n");
            sb.AppendLine($"Cadencia de disparo: {fusil.Cadencia}\n");
            sb.AppendLine($"Accesorios:");
            foreach (EAccesorioFusil accesorio in fusil.Accesorios)
            {
                sb.AppendLine($"  • {accesorio}");
            }
            sb.AppendLine($"\nCartuchos cargados:");
            if (fusil.Cargador.CartuchosCargados.Count == 0)
            {
                sb.AppendLine("  Cargador vacío");
            }
            foreach (Cartucho cartucho in fusil.Cargador.CartuchosCargados)
            {
                sb.AppendLine($"  • {cartucho.ToString()}");
            }

            return sb.ToString();
        }

        public string ObtenerDetalles(EscopetaBombeo escopeta)
        {
            string datosGenerales = this.ObtenerDetalles((ArmaDeFuego)escopeta);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(datosGenerales);
            sb.AppendLine($"Capacidad: {escopeta.Capacidad}\n");
            sb.AppendLine($"Accesorios:");
            foreach (EAccesorioEscopeta accesorio in escopeta.Accesorios)
            {
                sb.AppendLine($"  • {accesorio}");
            }
            sb.AppendLine($"\nCartuchos cargados:");
            if (escopeta.CartuchosCargados.Count == 0)
            {
                sb.AppendLine("  Vacío");
            }
            foreach (Cartucho cartucho in escopeta.CartuchosCargados)
            {
                sb.AppendLine($"  • {cartucho.ToString()}");
            }

            return sb.ToString();
        }
    }
}
