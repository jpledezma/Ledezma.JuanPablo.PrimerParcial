using Municion;
using System.Text;
using System.Xml.Serialization;

namespace Armas
{
    [XmlInclude(typeof(PistolaSemiautomatica))]
    [XmlInclude(typeof(FusilAsalto))]
    [XmlInclude(typeof(EscopetaBombeo))]
    // Todo esto es un desastre por culpa del xml
    public abstract class ArmaDeFuego
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
            set { this.fabricante = value; }
        }
        public string Modelo
        {
            get { return this.modelo; }
            set { this.modelo = value; }
        }
        public string NumeroSerie
        {
            get { return this.numeroSerie; }
            set { this.numeroSerie = FormatearNumeroSerie(value); }
        }
        public double Precio
        {
            get { return this.precio; }
            set { precio = value >= 0 ? value : 0; }
        }
        public double PesoBase
        {
            get { return this.pesoBase; }
            set 
            { 
                this.pesoBase = value >= 0 ? value : 0;
                this.pesoTotal = this.PesoBase;
            }
        }
        public double PesoTotal
        {
            get { return this.pesoTotal; }
        }
        public EMunicion CalibreMunicion
        {
            get { return this.calibreMunicion; }
            set { this.calibreMunicion = value; }
        }
        public EMaterial[] MaterialesConstruccion
        {
            get { return this.materialesConstruccion.ToArray(); }
            set { this.AgregarMaterialesConstruccion(value); }
        }
        #endregion

        #region Constructores
        protected ArmaDeFuego()
        {
            this.materialesConstruccion = new List<EMaterial>();
            this.fabricante = "desconocido";
            this.modelo = "desconocido";
            this.numeroSerie = "desconocido";
        }
        public ArmaDeFuego(string fabricante, 
                           string modelo,
                           string numeroSerie, 
                           double pesoBase,
                           EMunicion calibreMunicion,
                           List<EMaterial> materialesConstruccion,
                           double precio)
        {
            this.fabricante = fabricante.Trim();
            this.modelo = modelo.Trim();
            this.pesoBase = pesoBase >= 0 ? pesoBase : 0;
            this.pesoTotal = this.pesoBase;
            this.calibreMunicion = calibreMunicion;
            this.materialesConstruccion = new List<EMaterial>();
            this.precio = precio >= 0 ? precio : 0;
            this.numeroSerie = FormatearNumeroSerie(numeroSerie);

            foreach (EMaterial material in materialesConstruccion)
            {
                if (!this.materialesConstruccion.Contains(material))
                {
                    this.materialesConstruccion.Add(material);
                }
            }
        }
        #endregion

        #region Sobrecarga de operadores
        public static bool operator ==(ArmaDeFuego arma1, ArmaDeFuego arma2)
        {
            string tipoArma1 = arma1.GetType().Name;
            string tipoArma2 = arma2.GetType().Name;
            return (arma1.numeroSerie == arma2.numeroSerie && tipoArma1 == tipoArma2);
        }

        public static bool operator !=(ArmaDeFuego arma1, ArmaDeFuego arma2)
        {
            return !(arma1 == arma2);
        }

        public static implicit operator string(ArmaDeFuego arma)
        {
            return arma.ToString();
        }
        #endregion

        #region Metodos
        public abstract bool Disparar();

        public abstract void Recargar();

        public abstract void Recargar(List<Cartucho> cartuchos);

        public override bool Equals(object? obj)
        {
            ArmaDeFuego? arma = obj as ArmaDeFuego;
            return (arma is not null && this == arma);
        }

        public override int GetHashCode()
        {
            return (this.GetType().Name, this.numeroSerie).GetHashCode();
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} {this.fabricante} {this.modelo} {this.numeroSerie}";
        }

        protected static string FormatearNumeroSerie(string numeroSerie)
        {
            char[] caracteresNumeroSerie = numeroSerie.ToArray();
            StringBuilder sb = new StringBuilder();
            foreach (char c in caracteresNumeroSerie)
            {
                if (Char.IsLetter(c) || Char.IsNumber(c))
                {
                    sb.Append(c);
                }
            }

            return sb.ToString().ToUpper();
        }

        protected void AgregarMaterialesConstruccion(EMaterial[] nuevosMateriales)
        {
            this.materialesConstruccion = new List<EMaterial>();
            foreach(EMaterial material in nuevosMateriales)
            {
                if (!this.materialesConstruccion.Contains(material))
                {
                    this.materialesConstruccion.Add(material);
                }
            }
        }

        public static string MostrarEnVisor(ArmaDeFuego arma)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(String.Format("{0,-28}", arma.GetType().Name.ToString()));
            sb.Append(String.Format("{0,-20}", arma.fabricante));
            sb.Append(String.Format("{0,-20}", arma.modelo));
            sb.Append(String.Format("{0,-20}", arma.numeroSerie));
            sb.Append(String.Format("{0,-20}", $"{arma.pesoTotal:N2} Kg"));
            sb.Append(String.Format("{0,-20}", $"{arma.calibreMunicion}"));
            sb.Append(String.Format("{0,-20}", $"${arma.precio:N2}"));

            return sb.ToString();
        }
        #endregion
    }
}
