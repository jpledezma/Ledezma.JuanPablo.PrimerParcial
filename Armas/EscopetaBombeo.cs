using Municion;
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
                              string modelo,
                              string numeroSerie,
                              double pesoKg,
                              EMunicion calibreMunicion,
                              List<EMaterial> materialesConstruccion,
                              uint capacidad,
                              double precio
                             ) : base(fabricante, modelo, numeroSerie, pesoKg, calibreMunicion, materialesConstruccion, precio)
        {
            this.capacidad = capacidad;
            this.accesorios = new List<EAccesorioEscopeta>();
        }

        public EscopetaBombeo(
                              string fabricante,
                              string modelo,
                              string numeroSerie,
                              double pesoKg,
                              EMunicion calibreMunicion,
                              List<EMaterial> materialesConstruccion,
                              uint capacidad,
                              double precio,
                              List<EAccesorioEscopeta> accesorios
                             ) : this(fabricante, modelo, numeroSerie, pesoKg, calibreMunicion, materialesConstruccion, capacidad, precio)
        {
            foreach (EAccesorioEscopeta a in accesorios)
            {
                if (!this.accesorios.Contains(a))
                {
                    this.accesorios.Add(a);
                    base.pesoTotal += 0.250;
                }
            }
        }
        #endregion
    }
}