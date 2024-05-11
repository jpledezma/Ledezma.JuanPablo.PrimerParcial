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
        public PistolaSemiautomatica(
                            string fabricante,
                            string numeroSerie,
                            double pesoKg,
                            EMunicion calibreMunicion,
                            List<EMaterial> materialesConstruccion,
                            uint capacidadCargador
                            ) : base(fabricante, numeroSerie, pesoKg, calibreMunicion, materialesConstruccion)
        {
            this.capacidadCargador = capacidadCargador;
            this.cargador = new Cargador(capacidadCargador, calibreMunicion);
            this.accesorios = new List<EAccesorioPistola>();
            this.seguroActivo = true;
        }

        public PistolaSemiautomatica(
                            string fabricante,
                            string numeroSerie,
                            double pesoKg,
                            EMunicion calibreMunicion,
                            List<EMaterial> materialesConstruccion,
                            uint capacidadCargador,
                            double precio
                            ) : this(fabricante, numeroSerie, pesoKg, calibreMunicion, materialesConstruccion, capacidadCargador)
        {
            base.precio = precio > 0 ? precio : 0;
        }

        public PistolaSemiautomatica
                            (
                            string fabricante,
                            string numeroSerie,
                            double pesoKg,
                            EMunicion calibreMunicion,
                            List<EMaterial> materialesConstruccion,
                            uint capacidadCargador,
                            double precio,
                            List<EAccesorioPistola> accesorios
                            ) : this(fabricante, numeroSerie, pesoKg, calibreMunicion, materialesConstruccion, capacidadCargador, precio)
        {
            // Aumentar la capacidad del cargador si contiene el accesorio "cargador ampliado"
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
                    base.pesoKg += 0.250;
                }
            }
        }
        #endregion
    }
}
