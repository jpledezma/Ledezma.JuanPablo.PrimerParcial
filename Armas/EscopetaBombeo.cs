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
        private int capacidad;
        private bool amartillada;
        private Stack<Cartucho> cartuchos;
        private List<EAccesorioEscopeta> accesorios;
    }
}
