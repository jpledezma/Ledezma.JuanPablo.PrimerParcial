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
        private DateTime fechaIngreso;

        public string Fabricante
        {
            get { return this.fabricante; }
        }
        public string NumeroSerie
        {
            get { return this.numeroSerie; }
        }
        public double Precio
        {
            get { return this.precio; }
            set { precio = value >= 0 ? value : 0; }
        }
        public double Peso
        {
            get { return this.pesoKg; }
        }
        public EMunicion CalibreMunicion
        {
            get { return this.calibreMunicion; }
        }
        public List<EMaterial> MaterialesConstruccion
        {
            get { return new List<EMaterial>(this.materialesConstruccion); }
        }
        public DateTime FechaIngreso
        {
            get { return this.fechaIngreso; }
        }

        public ArmaDeFuego(string fabricante, 
                           string numeroSerie, 
                           double pesoKg,
                           EMunicion calibreMunicion,
                           List<EMaterial> materialesConstruccion)
        {
            this.fabricante = fabricante;
            this.numeroSerie = numeroSerie;
            this.pesoKg = pesoKg >= 0 ? pesoKg : 0;
            this.calibreMunicion = calibreMunicion;
            this.materialesConstruccion = new List<EMaterial>();
            this.precio = 0;
            this.fechaIngreso = DateTime.Now;

            foreach(EMaterial material in materialesConstruccion)
            {
                if (!this.materialesConstruccion.Contains(material))
                {
                    this.materialesConstruccion.Add(material);
                }
            }
        }
        
        public ArmaDeFuego(string fabricante,
                           string numeroSerie,
                           double pesoKg,
                           EMunicion calibreMunicion,
                           List<EMaterial> materialesConstruccion,
                           double precio) : this(fabricante, numeroSerie, pesoKg, calibreMunicion, materialesConstruccion)
        {
            this.precio = precio >= 0 ? precio : 0;
        }

        public ArmaDeFuego(string fabricante,
                           string numeroSerie,
                           double pesoKg,
                           EMunicion calibreMunicion,
                           List<EMaterial> materialesConstruccion,
                           double precio,
                           DateTime fechaIngreso) : this(fabricante, numeroSerie, pesoKg, calibreMunicion, materialesConstruccion, precio)
        {
            this.fechaIngreso = fechaIngreso;
        }
    }
}
