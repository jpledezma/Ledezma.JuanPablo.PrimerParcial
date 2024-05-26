using Municion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Armas
{
    public class PistolaSemiautomatica : ArmaDeFuego
    {
        private uint capacidadCargador;
        private bool seguroActivo;
        private Cargador cargador;
        private List<EAccesorioPistola> accesorios;

        #region Propiedades
        public uint CapacidadCargador
        {
            get { return this.capacidadCargador; }
            set 
            { 
                this.capacidadCargador = value;
                this.cargador = new Cargador(value, this.CalibreMunicion);
            }
        }

        public bool SeguroActivo
        {
            get { return this.seguroActivo; }
        }

        public Cargador Cargador
        {
            get { return new Cargador(this.cargador); }
        }

        public EAccesorioPistola[] Accesorios
        {
            get { return this.accesorios.ToArray(); }
            set { this.AgregarAccesorios(value); }
        }
        #endregion

        #region Constructores

        public PistolaSemiautomatica() : base()
        {
            this.cargador = new Cargador(0, EMunicion.ACP_380);
            this.accesorios = new List<EAccesorioPistola>();
        }
        public PistolaSemiautomatica(
                            string fabricante,
                            string modelo,
                            string numeroSerie,
                            double pesoBase,
                            EMunicion calibreMunicion,
                            List<EMaterial> materialesConstruccion,
                            uint capacidadCargador,
                            double precio
                            ) : base(fabricante, modelo, numeroSerie, pesoBase, calibreMunicion, materialesConstruccion, precio)
        {
            this.capacidadCargador = capacidadCargador;
            this.cargador = new Cargador(capacidadCargador, calibreMunicion);
            this.accesorios = new List<EAccesorioPistola>();
            this.seguroActivo = true;
        }

        public PistolaSemiautomatica(
                            string fabricante,
                            string modelo,
                            string numeroSerie,
                            double pesoBase,
                            EMunicion calibreMunicion,
                            List<EMaterial> materialesConstruccion,
                            uint capacidadCargador,
                            double precio,
                            List<EAccesorioPistola> accesorios
                            ) : this(fabricante, modelo, numeroSerie, pesoBase, calibreMunicion, materialesConstruccion, capacidadCargador, precio)
        {
            if (accesorios.Contains(EAccesorioPistola.CargadorAmpliado))
            {
                uint capacidadAmpliada = (uint)(capacidadCargador * 1.5);
                this.capacidadCargador = capacidadAmpliada;
                this.cargador = new Cargador(capacidadAmpliada, calibreMunicion);
            }

            this.AgregarAccesorios(accesorios.ToArray());
        }
        #endregion

        #region Metodos
        public override bool Disparar()
        {
            bool disparoExitoso;

            if (this.cargador.CartuchosCargados.Count > 0 && !this.seguroActivo)
            {
                this.cargador.QuitarCartucho();
                disparoExitoso = true;
            }
            else
            {
                disparoExitoso= false;
            }
            
            return disparoExitoso;
        }

        public override void Recargar()
        {
            this.cargador.Llenar();
        }

        public override void Recargar(List<Cartucho> cartuchos)
        {
            this.cargador.AgregarCartucho(cartuchos);
        }

        // Tuve que agregar esto por la deserializacion xml
        private void AgregarAccesorios(EAccesorioPistola[] nuevosAccesorios)
        {
            this.pesoTotal = this.pesoBase;
            this.accesorios = new List<EAccesorioPistola>();
            foreach (EAccesorioPistola accesorio in nuevosAccesorios)
            {
                if (!this.accesorios.Contains(accesorio))
                {
                    this.accesorios.Add(accesorio);
                    this.pesoTotal += 0.250;
                }
            }
        }

        public bool CambiarSeguro()
        {
            if (this.seguroActivo == true)
            {
                this.seguroActivo = false;
            }
            else
            {
                this.seguroActivo = true;
            }

            return this.seguroActivo;
        }
        #endregion
    }
}
