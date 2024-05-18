using Municion;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Armas
{
    public class Cargador
    {
        private uint capacidad;
        private EMunicion calibreMunicion;
        private Stack<Cartucho> cartuchosCargados;

        #region Propiedades
        public uint Capacidad
        {
            get { return this.capacidad; }
        }
        public EMunicion CalibreMunicion
        {
            get { return this.calibreMunicion; }
        }
        public Stack<Cartucho> CartuchosCargados
        {
            get { return new Stack<Cartucho>(this.cartuchosCargados); }
        }
        #endregion

        #region Constructores
        public Cargador(uint capacidad, EMunicion calibreMunicion)
        {
            this.capacidad = capacidad;
            this.calibreMunicion = calibreMunicion;
            this.cartuchosCargados = new Stack<Cartucho>();
        }

        public Cargador(uint capacidad, EMunicion calibreMunicion, List<Cartucho> cartuchos) : this(capacidad, calibreMunicion)
        {
            foreach(Cartucho c in cartuchos)
            {
                if (this.cartuchosCargados.Count < capacidad && c.Calibre == calibreMunicion)
                {
                    this.cartuchosCargados.Push(c);
                }
            }
        }
        public Cargador(Cargador c)
        {
            this.capacidad = c.capacidad;
            this.calibreMunicion = c.calibreMunicion;
            this.cartuchosCargados = new Stack<Cartucho>(c.CartuchosCargados);
        }
        #endregion

        #region Metodos
        public void AgregarCartucho(Cartucho cartucho)
        {
            if (cartucho.Calibre == this.calibreMunicion && this.cartuchosCargados.Count < this.capacidad)
            {
                this.cartuchosCargados.Push(cartucho);
            }
        }
        
        public void AgregarCartucho(Cartucho cartucho, uint cantidad)
        {
            if (cartucho.Calibre != this.calibreMunicion)
            {
                return;
            }

            int contador = 0;
            while(contador < cantidad && this.cartuchosCargados.Count < this.capacidad)
            {
                this.cartuchosCargados.Push(cartucho);
                contador++;
            }
        }

        public void AgregarCartucho(List<Cartucho> cartuchos)
        {
            foreach (Cartucho cartucho in cartuchos)
            {
                if (this.cartuchosCargados.Count >= this.capacidad)
                {
                    break;
                }

                if (cartucho.Calibre == this.calibreMunicion)
                {
                    this.cartuchosCargados.Push(cartucho);
                }
            }
        }

        public void QuitarCartucho()
        {
            if (this.cartuchosCargados.Count > 0)
            {
                this.cartuchosCargados.Pop();
            }
        }

        public void QuitarCartucho(int cantidad)
        {
            int contador = cantidad;
            while(contador > 0 && this.cartuchosCargados.Count > 0)
            {
                this.cartuchosCargados.Pop();
                contador--;
            }
        }

        public void Vaciar()
        {
            this.cartuchosCargados.Clear();
        }

        public void Llenar()
        {
            this.AgregarCartucho(new Cartucho(this.calibreMunicion), this.capacidad);
        }

        public void Llenar(Cartucho cartucho)
        {
            this.AgregarCartucho(cartucho, this.capacidad);
        }
        #endregion

        #region Sobrecargas de operadores
        public static int operator +(Cargador c1, Cargador c2)
        {
            int cartuchosTotales = c1.cartuchosCargados.Count;

            if(c1.calibreMunicion == c2.calibreMunicion)
            {
                cartuchosTotales += c2.cartuchosCargados.Count;
            }

            return c1.cartuchosCargados.Count + c2.cartuchosCargados.Count;
        }
        #endregion
    }
}
