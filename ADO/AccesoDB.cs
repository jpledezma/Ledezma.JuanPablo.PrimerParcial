using Armas;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Text.Json;

namespace ADO
{
    // Que lluevan las advertencias
    public class AccesoDB
    {
        private static string stringConexion;
        private SqlConnection conexion;
        private SqlCommand? comando;
        private SqlDataReader? lector;

        static AccesoDB()
        {
            AccesoDB.stringConexion = ADO.Properties.Resources.conexionEstandar;
        }
        public AccesoDB()
        {
            this.conexion = new SqlConnection(AccesoDB.stringConexion);
        }


        public bool ProbarConexion()
        {
            bool rta = true;

            try
            {
                this.conexion.Open();
            }
            catch (Exception e)
            {
                rta = false;
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return rta;
        }

        public List<ArmaDeFuego> ObtenerListaDato()
        {
            List<ArmaDeFuego> listaArmas = new List<ArmaDeFuego>();

            try
            {
                this.comando = new SqlCommand();

                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = "SELECT id, Tipo, Fabricante, Modelo, NumeroSerie, PesoBase, CalibreMunicion, MaterialesConstruccion, Capacidad, Cadencia, Precio, Accesorios  FROM armeria";
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                this.lector = comando.ExecuteReader();

                while (this.lector.Read())
                {
                    listaArmas.Add(this.CrearArma());
                }

                lector.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return listaArmas;
        }

        private ArmaDeFuego CrearArma() 
        {
            ArmaDeFuego arma;

            if (this.lector["Tipo"].ToString() == typeof(PistolaSemiautomatica).Name)
            {
                arma = new PistolaSemiautomatica(
                    this.lector.GetString("Fabricante"),
                    this.lector.GetString("Modelo"),
                    this.lector.GetString("NumeroSerie"),
                    this.lector.GetDouble("PesoBase"),
                    JsonSerializer.Deserialize<EMunicion>(this.lector["CalibreMunicion"].ToString()),
                    JsonSerializer.Deserialize<List<EMaterial>>(this.lector["MaterialesConstruccion"].ToString()),
                    (uint)this.lector.GetInt32("Capacidad"),
                    this.lector.GetDouble("Precio"),
                    JsonSerializer.Deserialize<List<EAccesorioPistola>>(this.lector["Accesorios"].ToString())
                    );
            }
            else if (this.lector["Tipo"].ToString() == typeof(FusilAsalto).Name)
            {
                arma = new FusilAsalto(
                   this.lector.GetString("Fabricante"),
                   this.lector.GetString("Modelo"),
                   this.lector.GetString("NumeroSerie"),
                   this.lector.GetDouble("PesoBase"),
                   JsonSerializer.Deserialize<EMunicion>(this.lector["CalibreMunicion"].ToString()),
                   JsonSerializer.Deserialize<List<EMaterial>>(this.lector["MaterialesConstruccion"].ToString()),
                   (uint)this.lector.GetInt32("Capacidad"),
                   (uint)this.lector.GetInt32("Cadencia"),
                    this.lector.GetDouble("Precio"),
                   JsonSerializer.Deserialize<List<EAccesorioFusil>>(this.lector["Accesorios"].ToString())
                   );
            }
            else
            {
                arma = new EscopetaBombeo(
                   this.lector.GetString("Fabricante"),
                   this.lector.GetString("Modelo"),
                   this.lector.GetString("NumeroSerie"),
                   this.lector.GetDouble("PesoBase"),
                   JsonSerializer.Deserialize<EMunicion>(this.lector["CalibreMunicion"].ToString()),
                   JsonSerializer.Deserialize<List<EMaterial>>(this.lector["MaterialesConstruccion"].ToString()),
                   (uint)this.lector.GetInt32("Capacidad"),
                    this.lector.GetDouble("Precio"),
                   JsonSerializer.Deserialize<List<EAccesorioEscopeta>>(this.lector["Accesorios"].ToString())
                   );
            }

            return arma;
        }
    }
}
