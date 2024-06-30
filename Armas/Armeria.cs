using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Armas
{
    public class Armeria<T> : IEnumerable<T>
        where T : IProductoArmeria
    {
        public delegate bool Comparar(T p1, T p2);
        public event Action<string>? EventoEliminacion;
        public event Action<string>? EventoInsercion;
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
                if (this.armas[indice].Equals(value))
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
                if (armaAgregada.Equals(arma))
                {
                    estaIncluida = true;
                    break;
                }
            }
            if (!estaIncluida)
            {
                armeria.armas.Add(armaAgregada);
                if(armeria.EventoInsercion is not null)
                    armeria.EventoInsercion($"Se agregó {armaAgregada} de la armería");
            }
            else
            {
                throw new Exception("El elemento que se quiere agregar ya existe en la armeria.");
            }
            return armeria;
        }

        public static Armeria<T> operator -(Armeria<T> armeria, T arma)
        {
            if (armeria.armas.Contains(arma)) 
            {
                armeria.armas.Remove(arma);
                if (armeria.EventoEliminacion is not null)
                    armeria.EventoEliminacion($"Se aliminó {arma} de la armería");
            }
            else
            {
                throw new Exception("El elemento que se quiere eliminar no existe en la armeria.");
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
        public void OrdenarArmeria(Comparar comparacion, bool ordenInvertido = false)
        {
            for (int i = 0; i < this.armas.Count - 1; i++)
            {
                for (int j = i + 1; j < this.armas.Count; j++)
                {
                    if (!ordenInvertido)
                    {
                        // swap
                        if (comparacion(this.armas[i], this.armas[j]))
                        {
                            T aux = this.armas[j];
                            this.armas[j] = this.armas[i];
                            this.armas[i] = aux;
                        }
                    }
                    else
                    {
                        // swap
                        if (comparacion(this.armas[j], this.armas[i]))
                        {
                            T aux = this.armas[j];
                            this.armas[j] = this.armas[i];
                            this.armas[i] = aux;
                        }
                    }
                }
            }
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
