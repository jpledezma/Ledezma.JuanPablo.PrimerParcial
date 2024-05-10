using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Armas
{
    public class PistolaSemiautomatica : ArmaDeFuego
    {
        private int capacidadCargador;
        private bool seguroActivo;
        private Cargador cargador;
        private List<EAccesorioPistola> accesorios;
    }
}
