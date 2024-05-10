namespace Armas
{
    public class ArmaDeFuego
    {
        private string fabricante;
        private string numeroSerie;
        private double precio;
        private double pesoKg;
        private EMunicion calibreMunicion;
        private List<EMaterial> materialesConstruccion;

        public ArmaDeFuego()
        {
            
        }
        public ArmaDeFuego(string fabricante, 
                           string numeroSerie, 
                           double precio, 
                           double pesoKg,
                           EMunicion calibreMunicion,
                           List<EMaterial> materialesConstruccion)
        {
            this.fabricante = fabricante;
            this.numeroSerie = numeroSerie;
            this.precio = precio >= 0 ? precio : 0;
            this.pesoKg = pesoKg >= 0 ? pesoKg : 0;
            this.calibreMunicion = calibreMunicion;
            this.materialesConstruccion = new List<EMaterial>();

            foreach(EMaterial material in materialesConstruccion)
            {
                if (!this.materialesConstruccion.Contains(material))
                {
                    this.materialesConstruccion.Add(material);
                }
            }
        }
    }
}
