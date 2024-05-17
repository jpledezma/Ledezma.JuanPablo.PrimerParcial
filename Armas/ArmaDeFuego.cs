using System.Text;

namespace Armas
{
    public class ArmaDeFuego
    {
        private string fabricante;
        private string modelo;
        private string numeroSerie;
        protected double precio;
        protected double pesoBase;
        protected double pesoTotal;
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
        public double PesoBase
        {
            get { return this.pesoBase; }
        }
        public double PesoTotal
        {
            get { return this.pesoTotal; }
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
                           double pesoBase,
                           EMunicion calibreMunicion,
                           List<EMaterial> materialesConstruccion,
                           double precio)
        {
            this.fabricante = fabricante;
            this.modelo = modelo;
            this.numeroSerie = numeroSerie;
            this.pesoBase = pesoBase >= 0 ? pesoBase : 0;
            this.pesoTotal = this.pesoBase;
            this.calibreMunicion = calibreMunicion;
            this.materialesConstruccion = new List<EMaterial>();
            this.precio = precio >= 0 ? precio : 0;

            foreach (EMaterial material in materialesConstruccion)
            {
                if (!this.materialesConstruccion.Contains(material))
                {
                    this.materialesConstruccion.Add(material);
                }
            }
        }
        #endregion

        public string MostrarEnVisor()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(String.Format("{0,-28}", this.GetType().Name.ToString()));
            sb.Append(String.Format("{0,-20}", this.fabricante));
            sb.Append(String.Format("{0,-20}", this.modelo));
            sb.Append(String.Format("{0,-20}", this.numeroSerie));
            sb.Append(String.Format("{0,-20}", $"{this.pesoTotal} Kg"));
            sb.Append(String.Format("{0,-20}", $"{this.calibreMunicion}"));
            sb.Append(String.Format("{0,-20}", $"${this.precio}"));

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
