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
            set 
            {
                this.accesorios = new List<EAccesorioPistola>();
                base.pesoTotal = base.pesoBase;
                this.AgregarAccesorios(value); 
            }
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

            this.AgregarAccesorios(accesorios.ToArray());
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Se efectua un disparo, solo si quedan cartuchos en el cargador y el seguro no está puesto.
        /// </summary>
        /// <returns><b>true</b> si el disparo es exitoso. <b>false</b> si no se pudo efectuar.</returns>
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

        /// <summary>
        /// Se toma un array de accesorios y se agregan al arma, sólo si ésta no los contiene.
        /// </summary>
        /// <param name="nuevosAccesorios"></param>
        public void AgregarAccesorios(EAccesorioPistola[] nuevosAccesorios)
        {
            foreach (EAccesorioPistola accesorio in nuevosAccesorios)
            {
                if (!this.accesorios.Contains(accesorio))
                {
                    this.accesorios.Add(accesorio);
                    base.pesoTotal += 0.100;
                }
            }
        }

        /// <summary>
        /// Se pone el seguro a la pistola si no lo tiene puesto, y se saca si ya estaba activo.
        /// </summary>
        /// <returns><b>bool</b> El estado actual del seguro</returns>
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
