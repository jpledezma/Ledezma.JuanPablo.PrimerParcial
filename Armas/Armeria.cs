using System;
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

        public Armeria()
        {
            this.armas = new List<ArmaDeFuego>();
        }

        public static List<ArmaDeFuego> operator +(Armeria armeria, ArmaDeFuego arma)
        {
            List<ArmaDeFuego> listaActualizada = armeria.Armas;
            bool estaIncluida = false;

            foreach(ArmaDeFuego a in listaActualizada)
            {
                if (arma == a)
                {
                    estaIncluida = true;
                    break;
                }
            }
            if (!estaIncluida)
            {
                listaActualizada.Add(arma);
            }
            return listaActualizada;
        }

        public static List<ArmaDeFuego> operator -(Armeria armeria, ArmaDeFuego arma)
        {
            List<ArmaDeFuego> listaActualizada = armeria.Armas;
            if (listaActualizada.Contains(arma)) 
            {
                listaActualizada.Remove(arma);
            }
            return listaActualizada;
        }
    }
}
