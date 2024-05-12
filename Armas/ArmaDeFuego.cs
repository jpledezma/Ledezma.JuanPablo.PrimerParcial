using System.Text;

namespace Armas
{
    public class ArmaDeFuego
    {
        private string fabricante;
        private string modelo;
        private string numeroSerie;
        protected double precio;
        protected double pesoKg;
        private EMunicion calibreMunicion;
        private List<EMaterial> materialesConstruccion;

        #region Propiedades
        public string Fabricante
        {
            get { return this.fabricante; }
        }
        public string Modelo
        {
            get { return this.modelo; }
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
        #endregion

        #region Constructores
        public ArmaDeFuego(string fabricante, 
                           string modelo,
                           string numeroSerie, 
                           double pesoKg,
                           EMunicion calibreMunicion,
                           List<EMaterial> materialesConstruccion)
        {
            this.fabricante = fabricante;
            this.modelo = modelo;
            this.numeroSerie = numeroSerie;
            this.pesoKg = pesoKg >= 0 ? pesoKg : 0;
            this.calibreMunicion = calibreMunicion;
            this.materialesConstruccion = new List<EMaterial>();
            this.precio = 0;

            foreach(EMaterial material in materialesConstruccion)
            {
                if (!this.materialesConstruccion.Contains(material))
                {
                    this.materialesConstruccion.Add(material);
                }
            }
        }
        
        public ArmaDeFuego(string fabricante,
                           string modelo,
                           string numeroSerie,
                           double pesoKg,
                           EMunicion calibreMunicion,
                           List<EMaterial> materialesConstruccion,
                           double precio) : this(fabricante, modelo, numeroSerie, pesoKg, calibreMunicion, materialesConstruccion)
        {
            this.precio = precio >= 0 ? precio : 0;
        }
        #endregion

        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{this.fabricante} - ");
            sb.Append($"{this.modelo} - ");
            sb.Append($"{this.numeroSerie} - ");
            sb.Append($"{this.precio.ToString()} - ");
            sb.Append($"{this.pesoKg.ToString()} - ");

            return sb.ToString();
        }

        #region Sobrecarga de operadores
        public static bool operator ==(ArmaDeFuego arma1, ArmaDeFuego arma2)
        {
            return arma1.numeroSerie == arma2.numeroSerie;
        }

        public static bool operator !=(ArmaDeFuego arma1, ArmaDeFuego arma2)
        {
            return !(arma1 == arma2);
        }
        #endregion
    }
}
