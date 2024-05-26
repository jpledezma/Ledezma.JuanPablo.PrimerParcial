using Municion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

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
            set { this.capacidad = value; }
        }

        public bool Amartillada
        {
            get { return this.amartillada; }
        }

        [XmlIgnore]
        public Stack<Cartucho> CartuchosCargados
        {
            get { return new Stack<Cartucho>(this.cartuchosCargados); }
        }

        public EAccesorioEscopeta[] Accesorios
        {
            get { return this.accesorios.ToArray(); }
            set
            {
                this.AgregarAccesorios(value);
            }
        }
        #endregion

        #region Constructores
        public EscopetaBombeo() : base()
        {
            this.accesorios = new List<EAccesorioEscopeta> ();
            this.cartuchosCargados = new Stack<Cartucho>();
        }
        public EscopetaBombeo(
                              string fabricante,
                              string modelo,
                              string numeroSerie,
                              double pesoBase,
                              EMunicion calibreMunicion,
                              List<EMaterial> materialesConstruccion,
                              uint capacidad,
                              double precio
                             ) : base(fabricante, modelo, numeroSerie, pesoBase, calibreMunicion, materialesConstruccion, precio)
        {
            this.capacidad = capacidad;
            this.cartuchosCargados = new Stack<Cartucho>();
            this.accesorios = new List<EAccesorioEscopeta>();
        }

        public EscopetaBombeo(
                              string fabricante,
                              string modelo,
                              string numeroSerie,
                              double pesoBase,
                              EMunicion calibreMunicion,
                              List<EMaterial> materialesConstruccion,
                              uint capacidad,
                              double precio,
                              List<EAccesorioEscopeta> accesorios
                             ) : this(fabricante, modelo, numeroSerie, pesoBase, calibreMunicion, materialesConstruccion, capacidad, precio)
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

        private void AgregarAccesorios(EAccesorioEscopeta[] nuevosAccesorios)
        {
            this.pesoTotal = this.pesoBase;
            this.accesorios = new List<EAccesorioEscopeta>();
            foreach (EAccesorioEscopeta accesorio in nuevosAccesorios)
            {
                if (!this.accesorios.Contains(accesorio))
                {
                    this.accesorios.Add(accesorio);
                    this.pesoTotal += 0.250;
                }
            }
        }
        #endregion
    }
}