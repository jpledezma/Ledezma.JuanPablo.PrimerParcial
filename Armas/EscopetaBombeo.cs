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
        private Stack<Cartucho> cartuchosCargados;
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

        public Stack<Cartucho> CartuchosCargados
        {
            get { return new Stack<Cartucho>(this.cartuchosCargados); }
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
            this.cartuchosCargados = new Stack<Cartucho>();
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

        #region Metodos
        public void Amartillar()
        {
            if (this.cartuchosCargados.Count > 0)
            {
                if (this.amartillada)
                {
                    this.cartuchosCargados.Pop();
                }
                else
                {
                    this.amartillada = true;
                }
            }
            // Hay que meter esta condicion por si expulsa el último cartucho que quedaba al amartillar
            if (this.cartuchosCargados.Count == 0)
            {
                this.amartillada = false;
            }
        }

        private void InsertarCartucho(Cartucho cartucho)
        {
            if (cartucho.Calibre == this.CalibreMunicion && this.cartuchosCargados.Count < this.capacidad)
            {
                this.cartuchosCargados.Push(cartucho);
            }
        }

        public override void Recargar()
        {
            for (int i = 0; i < this.capacidad; i++)
            {
                this.InsertarCartucho(new Cartucho(this.CalibreMunicion));
            }
        }

        public override void Recargar(List<Cartucho> cartuchos)
        {
            foreach(Cartucho cartucho in cartuchos)
            {
                if(this.cartuchosCargados.Count >= this.capacidad)
                {
                    break;
                }
                this.InsertarCartucho(cartucho);
            }
        }

        public override bool Disparar()
        {
            bool disparoExitoso;

            if (this.amartillada && this.cartuchosCargados.Count > 0)
            {
                this.cartuchosCargados.Pop();
                disparoExitoso = true;
            }
            else
            {
                disparoExitoso = false;
            }

            this.amartillada = false;

            return disparoExitoso;
        }
        #endregion
    }
}