﻿using Municion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Armas
{
    public class EscopetaBombeo : ArmaDeFuego
    {
        private uint capacidad;
        private bool amartillada;
        private Stack<Cartucho> cartuchos;
        private List<EAccesorioEscopeta> accesorios;

        #region Propiedades
        public uint Capacidad
        {
            get { return this.capacidad; }
        }

        public bool Amartillada
        {
            get { return this.amartillada; }
        }

        public Stack<Cartucho> Cartuchos
        {
            get { return new Stack<Cartucho>(this.cartuchos); }
        }

        public List<EAccesorioEscopeta> Accesorios
        {
            get { return new List<EAccesorioEscopeta>(this.accesorios); }
        }
        #endregion

        #region Constructores
        public EscopetaBombeo(
                              string fabricante,
                              string numeroSerie,
                              double pesoKg,
                              EMunicion calibreMunicion,
                              List<EMaterial> materialesConstruccion,
                              uint capacidad
                             ) : base(fabricante, numeroSerie, pesoKg, calibreMunicion, materialesConstruccion)
        {
            this.capacidad = capacidad;
        }

        public EscopetaBombeo(
                              string fabricante,
                              string numeroSerie,
                              double pesoKg,
                              EMunicion calibreMunicion,
                              List<EMaterial> materialesConstruccion,
                              uint capacidad,
                              double precio
                             ) : this(fabricante, numeroSerie, pesoKg, calibreMunicion, materialesConstruccion, capacidad)
        {
            base.precio = precio > 0 ? precio : 0;
        }

        public EscopetaBombeo(
                              string fabricante,
                              string numeroSerie,
                              double pesoKg,
                              EMunicion calibreMunicion,
                              List<EMaterial> materialesConstruccion,
                              uint capacidad,
                              double precio,
                              List<EAccesorioEscopeta> accesorios
                             ) : this(fabricante, numeroSerie, pesoKg, calibreMunicion, materialesConstruccion, capacidad, precio)
        {
            foreach (EAccesorioEscopeta a in accesorios)
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
