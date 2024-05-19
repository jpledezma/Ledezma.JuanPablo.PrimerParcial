namespace Municion
{
    public class Cartucho
    {
        private EMunicion calibre;
        private EProyectil tipoProyectil;
        private bool subsonico;

        #region Propiedades
        public EMunicion Calibre
        {
            get { return this.calibre; }
        }
        public EProyectil Proyectil
        {
            get { return this.tipoProyectil; }
        }
        public bool Subsonico
        {
            get { return this.subsonico; }
        }
        #endregion

        #region Constructores
        public Cartucho(EMunicion calibre)
        {
            this.calibre = calibre;
            this.tipoProyectil = EProyectil.PuntaRedonda;
            this.subsonico = false;
        }
        public Cartucho(EMunicion calibre, EProyectil tipoProyectil) : this(calibre)
        {
            this.tipoProyectil = tipoProyectil;
        }
        public Cartucho(EMunicion calibre, EProyectil tipoProyectil, bool subsonico) : this(calibre, tipoProyectil)
        {
            this.subsonico = subsonico;
        }
        #endregion

        #region Sobrecarga de operadores
        public static bool operator ==(Cartucho c1, Cartucho c2)
        {
            return (c1.calibre == c2.calibre && c1.subsonico == c2.subsonico && c1.tipoProyectil == c2.tipoProyectil);
        }
        public static bool operator !=(Cartucho c1, Cartucho c2)
        {
            return !(c1 == c2);
        }
        #endregion
        public override bool Equals(object? obj)
        {
            Cartucho? cartucho = obj as Cartucho;
            return (cartucho is not null && this == cartucho);
        }

        public override int GetHashCode()
        {
            return (this.calibre, this.tipoProyectil, this.subsonico).GetHashCode();
        }
    }
}
