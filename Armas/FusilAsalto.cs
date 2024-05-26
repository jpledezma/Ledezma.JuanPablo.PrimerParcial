using Municion;
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
            set { }
        }

        public uint Cadencia
        {
            get { return this.cadencia;  }
            set { }
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

        public FusilAsalto()
        {
            
        }
        public FusilAsalto(
                           string fabricante,
                           string modelo,
                           string numeroSerie,
                           double pesoBase,
                           EMunicion calibreMunicion,
                           List<EMaterial> materialesConstruccion,
                           uint capacidadCargador,
                           uint cadencia,
                           double precio
                          ) : base(fabricante, modelo, numeroSerie, pesoBase, calibreMunicion, materialesConstruccion, precio)
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
                           double pesoBase,
                           EMunicion calibreMunicion,
                           List<EMaterial> materialesConstruccion,
                           uint capacidadCargador,
                           uint cadencia,
                           double precio,
                           List<EAccesorioFusil> accesorios
                          ) : this(fabricante, modelo, numeroSerie, pesoBase, calibreMunicion, materialesConstruccion, capacidadCargador, cadencia, precio)
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
                    base.pesoTotal += 0.250;
                }
            }
        }
        #endregion

        #region Metodos
        public override void Recargar()
        {
            this.cargador.Llenar();
        }

        public override void Recargar(List<Cartucho> cartuchos)
        {
            this.cargador.AgregarCartucho(cartuchos);
        }

        public override bool Disparar()
        {
            bool disparoExitoso;

            if ( this.cargador.CartuchosCargados.Count == 0 )
            {
                return false;
            }

            if (this.ModoDisparo == EModoFusil.Rafaga)
            {
                this.cargador.QuitarCartucho(3);
            }
            else
            {
                this.cargador.QuitarCartucho();
            }

            disparoExitoso = true;

            return disparoExitoso;
        }
        public bool Disparar(int segundos)
        {
            if (this.cargador.CartuchosCargados.Count == 0)
            {
                return false;
            }

            if (this.modoDisparo != EModoFusil.Automatico)
            {
                return this.Disparar();
            }

            double disparosPorSegundo = this.cadencia / 60;
            double totalDisparos = disparosPorSegundo * segundos;
            int contador = 0;

            while (contador < totalDisparos && this.cargador.CartuchosCargados.Count > 0)
            {
                this.Disparar();
            }

            return true;
        }
        #endregion
    }
}
