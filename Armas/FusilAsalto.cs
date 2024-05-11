using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Armas
{
    public class FusilAsalto : ArmaDeFuego
    {
        private uint capacidadCargador;
        private uint cadencia;
        private EModoFusil modoDisparo;
        private Cargador cargador;
        private List<EAccesorioFusil> accesorios;

        #region Propiedades
        public uint CapacidadCargador
        {
            get { return this.capacidadCargador; }

        }

        public uint Cadencia
        {
            get { return this.cadencia;  }
        }

        public EModoFusil ModoDisparo
        {
            get { return this.modoDisparo; }
            set { this.modoDisparo = value; }
        }

        public Cargador Cargador
        {
            get { return new Cargador(this.cargador); }
        }

        public List<EAccesorioFusil> Accesorios
        {
            get { return new List<EAccesorioFusil>(this.accesorios); } 
        }
        #endregion

        #region Constructores
        public FusilAsalto(
                           string fabricante,
                           string modelo,
                           string numeroSerie,
                           double pesoKg,
                           EMunicion calibreMunicion,
                           List<EMaterial> materialesConstruccion,
                           uint capacidadCargador,
                           uint cadencia
                          ) : base(fabricante, modelo, numeroSerie, pesoKg, calibreMunicion, materialesConstruccion)
        {
            this.capacidadCargador = capacidadCargador;
            this.cadencia = cadencia;
            this.modoDisparo = EModoFusil.Semiautomatico;
            this.cargador = new Cargador(capacidadCargador, calibreMunicion);
            this.accesorios = new List<EAccesorioFusil>();
        }

        public FusilAsalto(
                           string fabricante,
                           string modelo,
                           string numeroSerie,
                           double pesoKg,
                           EMunicion calibreMunicion,
                           List<EMaterial> materialesConstruccion,
                           uint capacidadCargador,
                           uint cadencia,
                           double precio
                          ) : this(fabricante, modelo, numeroSerie, pesoKg, calibreMunicion, materialesConstruccion, capacidadCargador, cadencia)
        {
            base.precio = precio > 0 ? precio : 0;
        }

        public FusilAsalto(
                           string fabricante,
                           string modelo,
                           string numeroSerie,
                           double pesoKg,
                           EMunicion calibreMunicion,
                           List<EMaterial> materialesConstruccion,
                           uint capacidadCargador,
                           uint cadencia,
                           double precio,
                           List<EAccesorioFusil> accesorios
                          ) : this(fabricante, modelo, numeroSerie, pesoKg, calibreMunicion, materialesConstruccion, capacidadCargador, cadencia, precio)
        {
            // Aumentar la capacidad del cargador si contiene el accesorio "cargador ampliado"
            if (accesorios.Contains(EAccesorioFusil.CargadorTambor))
            {
                this.capacidadCargador = 100;
                this.cargador = new Cargador(100, calibreMunicion);
            }

            foreach (EAccesorioFusil a in accesorios)
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
