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
                this.AgregarParametrosComando(arma);

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
                this.comando.Parameters.AddWithValue("@Tipo", arma.GetType().Name);

                string sql = "DELETE FROM armeria ";
                sql += "WHERE NumeroSerie = @NumeroSerie AND Tipo = @Tipo";

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
                this.AgregarParametrosComando(arma);

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
                sql.Append("WHERE NumeroSerie = @NumeroSerie AND Tipo = @Tipo");

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
                arma = new PistolaSemiautomatica();
                arma.PesoBase = this.lector.GetDouble("PesoBase");
                ((PistolaSemiautomatica)arma).CapacidadCargador = (uint)this.lector.GetInt32("Capacidad");
                ((PistolaSemiautomatica)arma).Accesorios = JsonSerializer.Deserialize<EAccesorioPistola[]>(this.lector["Accesorios"].ToString());
            }
            else if (this.lector["Tipo"].ToString() == typeof(FusilAsalto).Name)
            {
                arma = new FusilAsalto();
                arma.PesoBase = this.lector.GetDouble("PesoBase");
                ((FusilAsalto)arma).CapacidadCargador = (uint)this.lector.GetInt32("Capacidad");
                ((FusilAsalto)arma).Cadencia = (uint)this.lector.GetInt32("Cadencia");
                ((FusilAsalto)arma).Accesorios = JsonSerializer.Deserialize<EAccesorioFusil[]>(this.lector["Accesorios"].ToString());
            }
            else
            {
                arma = new EscopetaBombeo();
                arma.PesoBase = this.lector.GetDouble("PesoBase");
                ((EscopetaBombeo)arma).Capacidad = (uint)this.lector.GetInt32("Capacidad");
                ((EscopetaBombeo)arma).Accesorios = JsonSerializer.Deserialize<EAccesorioEscopeta[]>(this.lector["Accesorios"].ToString());
            }

            arma.Fabricante = this.lector.GetString("Fabricante");
            arma.Modelo = this.lector.GetString("Modelo");
            arma.NumeroSerie = this.lector.GetString("NumeroSerie");
            arma.CalibreMunicion = JsonSerializer.Deserialize<EMunicion>(this.lector["CalibreMunicion"].ToString());
            arma.MaterialesConstruccion = JsonSerializer.Deserialize<EMaterial[]>(this.lector["MaterialesConstruccion"].ToString());
            arma.Precio = this.lector.GetDouble("Precio");

            return arma;
        }

        private void AgregarParametrosComando(ArmaDeFuego arma)
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
        }
    }
}
