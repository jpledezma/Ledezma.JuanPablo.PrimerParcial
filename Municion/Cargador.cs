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
        private int capacidad;
        private EMunicion calibreMunicion;
        private Stack<Cartucho> cartuchos;

        public int Capacidad
        {
            get { return this.capacidad; }
        }
        public EMunicion CalibreMunicion
        {
            get { return this.calibreMunicion; }
        }
        public Stack<Cartucho> Cartuchos
        {
            get { return cartuchos; }
        }

        public Cargador(int capacidad, EMunicion calibreMunicion)
        {
            this.capacidad = capacidad;
            this.calibreMunicion = calibreMunicion;
            this.cartuchos = new Stack<Cartucho>();
        }
        /*
         * En lugar de pasar un Stack, es mejor pasar una lista;
         * para simular que se pasa un conjunto de balas y la persona
         * las va metiendo al cargador una por una
        public Cargador(int capacidad, EMunicion calibreMunicion, Stack<Cartucho> cartuchos) : this(capacidad, calibreMunicion)
        {
            this.cartuchos = new Stack<Cartucho>(cartuchos);
        }
        */
        public Cargador(int capacidad, EMunicion calibreMunicion, List<Cartucho> cartuchos) : this(capacidad, calibreMunicion)
        {
            foreach(Cartucho c in cartuchos)
            {
                if (this.cartuchos.Count < capacidad && c.Calibre == calibreMunicion)
                {
                    this.cartuchos.Push(c);
                }
            }
        }

        public void AgregarCartucho(Cartucho cartucho)
        {
            if (cartucho.Calibre == this.calibreMunicion && this.cartuchos.Count < this.capacidad)
            {
                this.cartuchos.Push(cartucho);
            }
        }

        public void AgregarCartucho(Cartucho cartucho, int cantidad)
        {
            if (cartucho.Calibre != this.calibreMunicion)
            {
                return;
            }

            int contador = cantidad;
            while(contador > 0 && this.cartuchos.Count < this.capacidad)
            {
                this.cartuchos.Push(cartucho);
                contador--;
            }
        }

        public void QuitarCartucho()
        {
            this.cartuchos.Pop();
        }

        public void QuitarCartucho(int cantidad)
        {
            int contador = cantidad;
            while(contador > 0 && this.cartuchos.Count > 0)
            {
                this.cartuchos.Pop();
                contador--;
            }
        }

        public void Vaciar()
        {
            this.cartuchos.Clear();
        }

        public void Llenar()
        {
            this.AgregarCartucho(new Cartucho(this.calibreMunicion), this.capacidad);
        }

        public void Llenar(Cartucho cartucho)
        {
            this.AgregarCartucho(cartucho, this.capacidad);
        }

        public static int operator +(Cargador c1, Cargador c2)
        {
            int cartuchosTotales = c1.cartuchos.Count;

            if(c1.calibreMunicion == c2.calibreMunicion)
            {
                cartuchosTotales += c2.cartuchos.Count;
            }

            return c1.cartuchos.Count + c2.cartuchos.Count;
        }
    }
}
