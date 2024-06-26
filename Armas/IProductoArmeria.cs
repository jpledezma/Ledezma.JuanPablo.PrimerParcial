using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Armas
{
    public interface IProductoArmeria
    {
        double Precio {  get; set; }
        string Fabricante {  get; set; }
        string Modelo { get; set; }
        string NumeroSerie { get; set; }
        double PesoTotal { get; }

        string MostrarEnVisor();
    }
}
