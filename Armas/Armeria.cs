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
    }
}
