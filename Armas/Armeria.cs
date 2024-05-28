using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Armas
{
    public class Armeria
    {
        private List<ArmaDeFuego> armas;

        public List<ArmaDeFuego> Armas
        {
            get { return new List<ArmaDeFuego>(armas); }
        }

        public ArmaDeFuego this[int indice]
        {
            get
            {
                if (indice < 0 || indice > this.armas.Count - 1)
                {
                    throw new ArgumentOutOfRangeException();
                }
                return this.armas[indice];
            }
            set 
            {
                if (indice < 0 || indice > this.armas.Count - 1)
                {
                    throw new IndexOutOfRangeException();
                }
                // Sólo permite modificar un arma existente
                if (this.armas[indice] == value)
                {
                    this.armas[indice] = value;
                }
            }
        }

        public Armeria()
        {
            this.armas = new List<ArmaDeFuego>();
        }

        public Armeria(List<ArmaDeFuego> armas)
        {
            this.armas = new List<ArmaDeFuego>(armas);
        }

        public static Armeria operator +(Armeria armeria, ArmaDeFuego armaAgregada)
        {
            bool estaIncluida = false;

            foreach(ArmaDeFuego arma in armeria.Armas)
            {
                if (armaAgregada == arma)
                {
                    estaIncluida = true;
                    break;
                }
            }
            if (!estaIncluida)
            {
                armeria.armas.Add(armaAgregada);
            }
            return armeria;
        }

        public static Armeria operator -(Armeria armeria, ArmaDeFuego arma)
        {
            if (armeria.armas.Contains(arma)) 
            {
                armeria.armas.Remove(arma);
            }
            return armeria;
        }

        public void OrdenarArmeria(string propiedad = "tipo", bool ordenInvertido = false)
        {
            // método de la burbuja, ineficiente pero sencillo
            for (int i = 0; i < this.armas.Count - 1; i++)
            {
                for (int j = i + 1; j < this.armas.Count; j++)
                {
                    if (!ordenInvertido)
                    {
                        if (Comparar(this.armas[i], this.armas[j], propiedad))
                        {
                            ArmaDeFuego aux = this.armas[j];
                            this.armas[j] = this.armas[i];
                            this.armas[i] = aux;
                        }
                    }
                    else
                    {
                        if (Comparar(this.armas[j], this.armas[i], propiedad))
                        {
                            ArmaDeFuego aux = this.armas[j];
                            this.armas[j] = this.armas[i];
                            this.armas[i] = aux;
                        }
                    }
                }
            }
        }

        public static bool Comparar(ArmaDeFuego a1, ArmaDeFuego a2, string propiedad)
        {
            bool comparacion = false;
            switch (propiedad)
            {
                case "peso":
                    comparacion = a1.PesoTotal > a2.PesoTotal;
                    break;
                case "precio":
                    comparacion = a1.Precio > a2.Precio;
                    break;
                case "tipo":
                    if (a1.GetType().Name.CompareTo(a2.GetType().Name) == 1)
                        comparacion = true;
                    break;
                case "fabricante":
                    if (a1.Fabricante.CompareTo(a2.Fabricante) == 1)
                        comparacion = true;
                    break;
                case "calibre":
                    if (a1.CalibreMunicion.CompareTo(a2.CalibreMunicion) == 1)
                        comparacion = true;
                    break;
                case "numero_serie":
                    if (a1.NumeroSerie.CompareTo(a2.NumeroSerie) == 1)
                        comparacion = true;
                    break;
                default:
                    comparacion = false;
                    break;
            }
            return comparacion;
        }
    }
}
