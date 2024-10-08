﻿using Municion;
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
            set 
            {
                this.capacidadCargador = value;
                this.cargador = new Cargador(this.capacidadCargador, this.CalibreMunicion);
            }
        }

        public uint Cadencia
        {
            get { return this.cadencia;  }
            set { this.cadencia = value; }
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

        public EAccesorioFusil[] Accesorios
        {
            get { return this.accesorios.ToArray(); }
            set 
            {
                this.accesorios = new List<EAccesorioFusil>();
                base.pesoTotal = base.pesoBase;
                this.AgregarAccesorios(value); 
            }
        }
        #endregion

        #region Constructores

        public FusilAsalto() : base()
        {
            this.cargador = new Cargador(0, EMunicion.WIN_308);
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

            this.AgregarAccesorios(accesorios.ToArray());
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

        /// <summary>
        /// Se dispara el fusil. Si el mismo está en módo ráfaga, se dispara 3 veces seguidas.
        /// </summary>
        /// <returns><b>true</b> si el disparo es exitoso. <b>false</b> si no se pudo efectuar.</returns>
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

        /// <summary>
        /// Si el fusil está en modo automático, dispara constantemente durante el tiempo establecido, hasta que finalice o se quede sin munición.<br></br>
        /// Si el fusil no está en modo automático, dispara una vez o una ráfaga de 3 disparos.
        /// </summary>
        /// <param name="segundos"></param>
        /// <returns><b>true</b> si el disparo es exitoso. <b>false</b> si no se pudo efectuar.</returns>
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
                contador++;
            }

            return true;
        }

        /// <summary>
        /// Se toma un array de accesorios y se agregan al arma, sólo si ésta no los contiene.
        /// </summary>
        /// <param name="nuevosAccesorios"></param>
        public void AgregarAccesorios(EAccesorioFusil[] nuevosAccesorios)
        {
            foreach (EAccesorioFusil accesorio in nuevosAccesorios)
            {
                if (!this.accesorios.Contains(accesorio))
                {
                    this.accesorios.Add(accesorio);
                    this.pesoTotal += 0.190;
                }
            }
        }
        #endregion
    }
}
