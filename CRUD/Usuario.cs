using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD
{
    public class Usuario
    {
        private string _nombre;
        private string _apellido;
        private string _correo;
        private string _clave;
        private string _perfil;
        private int _legajo;

        public string nombre
        {
            get { return this._nombre; }
            set { this._nombre = value; }
        }
        public string apellido
        {
            get { return this._apellido; }
            set { this._apellido = value;}
        }
        public string correo 
        { 
            get {  return this._correo; } 
            set {  this._correo = value; } 
        } 
        public string clave 
        { 
            get { return this._clave; } 
            set { this._clave = value; } 
        }
        public string perfil
        {
            get { return this._perfil; }
            set { this._perfil = value; }
        }
        public int legajo
        {
            get { return this._legajo; }
            set { this._legajo = value;}
        }

        public Usuario()
        {

        }

        public Usuario(string nombre, string apellido, string correo, string clave, string perfil, int legajo)
        {
            this._nombre = nombre;
            this._apellido = apellido;
            this._correo = correo;
            this._clave = clave;
            this._perfil = perfil;
            this._legajo = legajo;
        }

        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(this._nombre);
            sb.AppendLine(this._apellido);
            sb.AppendLine(this._correo);
            sb.AppendLine(this._clave);
            sb.AppendLine(this._perfil);
            sb.AppendLine(this._legajo.ToString());
            return sb.ToString();
        }
    }
}
