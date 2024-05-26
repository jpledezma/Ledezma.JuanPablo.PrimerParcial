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
            set { }
        }

        public bool SeguroActivo
        {
            get { return this.seguroActivo; }
        }

        public Cargador Cargador
        {
            get { return new Cargador(this.cargador); }
        }

        public List<EAccesorioPistola> Accesorios
        {
            get { return new List<EAccesorioPistola>(this.accesorios); }
        }
        #endregion

        #region Constructores

        public PistolaSemiautomatica()
        {
            
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
            
            foreach(EAccesorioPistola a in accesorios)
            {
                if (!this.accesorios.Contains(a))
                {
                    this.accesorios.Add(a);
                    base.pesoTotal += 0.250;
                }
            }
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
