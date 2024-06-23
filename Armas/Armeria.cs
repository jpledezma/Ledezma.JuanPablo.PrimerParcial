using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Armas
{
    public class Armeria<T> : IEnumerable<T>
        where T : ArmaDeFuego
    {
        private List<T> armas;

        public List<T> Armas
        {
            get { return new List<T>(armas); }
        }

        // Indexador
        public T this[int indice]
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

        #region Constructores
        public Armeria()
        {
            this.armas = new List<T>();
        }

        public Armeria(List<T> armas)
        {
            this.armas = new List<T>(armas);
        }
        #endregion

        #region Sobrecarga de operadores

        public static Armeria<T> operator +(Armeria<T> armeria, T armaAgregada)
        {
            bool estaIncluida = false;

            foreach(T arma in armeria.Armas)
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

        public static Armeria<T> operator -(Armeria<T> armeria, T arma)
        {
            if (armeria.armas.Contains(arma)) 
            {
                armeria.armas.Remove(arma);
            }
            return armeria;
        }
        #endregion

        #region Métodos

        /// <summary>
        /// Se ordena la lista de armas con el método de burbuja, según el criterio de comparación elegido.
        /// </summary>
        /// <param name="propiedad"></param>
        /// <param name="ordenInvertido"></param>
        public void OrdenarArmeria(string propiedad = "tipo", bool ordenInvertido = false)
        {
            for (int i = 0; i < this.armas.Count - 1; i++)
            {
                for (int j = i + 1; j < this.armas.Count; j++)
                {
                    if (!ordenInvertido)
                    {
                        // swap
                        if (Comparar(this.armas[i], this.armas[j], propiedad))
                        {
                            T aux = this.armas[j];
                            this.armas[j] = this.armas[i];
                            this.armas[i] = aux;
                        }
                    }
                    else
                    {
                        // swap
                        if (Comparar(this.armas[j], this.armas[i], propiedad))
                        {
                            T aux = this.armas[j];
                            this.armas[j] = this.armas[i];
                            this.armas[i] = aux;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Se comparan 2 armas según la propiedad especificada.
        /// 
        /// </summary>
        /// <param name="a1"></param>
        /// <param name="a2"></param>
        /// <param name="propiedad"></param>
        /// <returns>
        /// <b>true</b> si la propiedad numérica de a1 es mayor a la de a2, 
        /// o si la propiedad string de a1 está después de la de a2 por orden alfabético
        /// </returns>
        public static bool Comparar(T a1, T a2, string propiedad)
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

        public IEnumerator<T> GetEnumerator()
        {
            return this.armas.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        #endregion
    }
}
