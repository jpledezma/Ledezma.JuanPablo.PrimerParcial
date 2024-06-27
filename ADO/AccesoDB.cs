using Armas;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection.Emit;
using System.Text;
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

        public List<ArmaDeFuego> ObtenerListaArmas()
        {
            List<ArmaDeFuego> listaArmas = new List<ArmaDeFuego>();

            try
            {
                this.comando = new SqlCommand();

                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = "SELECT id, Tipo, Fabricante, Modelo, NumeroSerie, PesoBase, CalibreMunicion, MaterialesConstruccion, Capacidad, Cadencia, Precio, Accesorios FROM armeria";
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

        public bool AgregarArma(ArmaDeFuego arma)
        {
            bool rta = true;

            try
            {

                this.comando = new SqlCommand();

                this.comando.Parameters.AddWithValue("@Tipo", arma.GetType().Name);
                this.comando.Parameters.AddWithValue("@Fabricante", arma.Fabricante);
                this.comando.Parameters.AddWithValue("@Modelo", arma.Modelo);
                this.comando.Parameters.AddWithValue("@NumeroSerie", arma.NumeroSerie);
                this.comando.Parameters.AddWithValue("@PesoBase", arma.PesoBase.ToString());
                this.comando.Parameters.AddWithValue("@Precio", arma.Precio.ToString());
                this.comando.Parameters.AddWithValue("@CalibreMunicion", JsonSerializer.Serialize(arma.CalibreMunicion));
                this.comando.Parameters.AddWithValue("@MaterialesConstruccion", JsonSerializer.Serialize(arma.MaterialesConstruccion));

                if (arma.GetType().Name == typeof(PistolaSemiautomatica).Name)
                {
                    this.comando.Parameters.AddWithValue("@Capacidad", ((int)((PistolaSemiautomatica)arma).CapacidadCargador));
                    this.comando.Parameters.AddWithValue("@Cadencia", DBNull.Value);
                    this.comando.Parameters.AddWithValue("@Accesorios", JsonSerializer.Serialize(((PistolaSemiautomatica)arma).Accesorios));
                }
                else if (arma.GetType().Name == typeof(FusilAsalto).Name)
                {
                    this.comando.Parameters.AddWithValue("@Capacidad", ((int)((FusilAsalto)arma).CapacidadCargador));
                    this.comando.Parameters.AddWithValue("@Cadencia", ((int)((FusilAsalto)arma).Cadencia));
                    this.comando.Parameters.AddWithValue("@Accesorios", JsonSerializer.Serialize(((FusilAsalto)arma).Accesorios));
                }
                else
                {
                    this.comando.Parameters.AddWithValue("@Capacidad", ((int)((EscopetaBombeo)arma).Capacidad));
                    this.comando.Parameters.AddWithValue("@Cadencia", DBNull.Value);
                    this.comando.Parameters.AddWithValue("@Accesorios", JsonSerializer.Serialize(((EscopetaBombeo)arma).Accesorios));
                }

                string sql = "INSERT INTO armeria ";
                sql += "(Tipo, Fabricante, Modelo, NumeroSerie, PesoBase, CalibreMunicion, MaterialesConstruccion, Capacidad, Cadencia, Precio, Accesorios) ";
                sql += "VALUES(@Tipo, @Fabricante, @Modelo, @NumeroSerie, @PesoBase, @CalibreMunicion, @MaterialesConstruccion, @Capacidad, @Cadencia, @Precio, @Accesorios)";

                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = sql;
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                this.comando.ExecuteNonQuery();

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

        public bool EliminarArma(ArmaDeFuego arma)
        {
            bool rta = true;

            try
            {
                this.comando = new SqlCommand();

                this.comando.Parameters.AddWithValue("@NumeroSerie", arma.NumeroSerie);

                string sql = "DELETE FROM armeria ";
                sql += "WHERE NumeroSerie = @NumeroSerie";

                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = sql;
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                int filasAfectadas = this.comando.ExecuteNonQuery();

                if (filasAfectadas == 0)
                {
                    rta = false;
                }

            }
            catch (Exception)
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

        public bool ModificarArma(ArmaDeFuego arma)
        {
            bool rta = true;

            try
            {
                this.comando = new SqlCommand();

                this.comando.Parameters.AddWithValue("@Fabricante", arma.Fabricante);
                this.comando.Parameters.AddWithValue("@Modelo", arma.Modelo);
                this.comando.Parameters.AddWithValue("@NumeroSerie", arma.NumeroSerie);
                this.comando.Parameters.AddWithValue("@PesoBase", arma.PesoBase.ToString());
                this.comando.Parameters.AddWithValue("@Precio", arma.Precio.ToString());
                this.comando.Parameters.AddWithValue("@CalibreMunicion", JsonSerializer.Serialize(arma.CalibreMunicion));
                this.comando.Parameters.AddWithValue("@MaterialesConstruccion", JsonSerializer.Serialize(arma.MaterialesConstruccion));

                if (arma.GetType().Name == typeof(PistolaSemiautomatica).Name)
                {
                    this.comando.Parameters.AddWithValue("@Capacidad", ((int)((PistolaSemiautomatica)arma).CapacidadCargador));
                    this.comando.Parameters.AddWithValue("@Accesorios", JsonSerializer.Serialize(((PistolaSemiautomatica)arma).Accesorios));
                    this.comando.Parameters.AddWithValue("@Cadencia", DBNull.Value);
                }
                else if (arma.GetType().Name == typeof(FusilAsalto).Name)
                {
                    this.comando.Parameters.AddWithValue("@Capacidad", ((int)((FusilAsalto)arma).CapacidadCargador));
                    this.comando.Parameters.AddWithValue("@Cadencia", ((int)((FusilAsalto)arma).Cadencia));
                    this.comando.Parameters.AddWithValue("@Accesorios", JsonSerializer.Serialize(((FusilAsalto)arma).Accesorios));
                }
                else
                {
                    this.comando.Parameters.AddWithValue("@Capacidad", ((int)((EscopetaBombeo)arma).Capacidad));
                    this.comando.Parameters.AddWithValue("@Accesorios", JsonSerializer.Serialize(((EscopetaBombeo)arma).Accesorios));
                    this.comando.Parameters.AddWithValue("@Cadencia", DBNull.Value);
                }

                StringBuilder sql = new StringBuilder();
                sql.Append("UPDATE armeria SET ");
                sql.Append("Fabricante = @Fabricante, ");
                sql.Append("Modelo = @Modelo, ");
                sql.Append("PesoBase = @PesoBase, ");
                sql.Append("Precio = @Precio, ");
                sql.Append("CalibreMunicion = @CalibreMunicion, ");
                sql.Append("MaterialesConstruccion = @MaterialesConstruccion, ");
                sql.Append("Capacidad = @Capacidad, ");
                sql.Append("Accesorios = @Accesorios, ");
                sql.Append("Cadencia = @Cadencia ");
                sql.Append("WHERE NumeroSerie = @NumeroSerie");

                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = sql.ToString();
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                int filasAfectadas = this.comando.ExecuteNonQuery();

                if (filasAfectadas == 0)
                {
                    rta = false;
                }

            }
            catch (Exception)
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
