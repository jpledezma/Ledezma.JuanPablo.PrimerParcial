using Armas;

namespace TestArmas
{
    [TestClass]
    public class ArmeriaTest
    {
        /// <summary>
        /// Se intentan agregar 2 armas con el mismo numero de serie, pero de distinto tipo.
        /// </summary>
        [TestMethod]
        public void TestAgregar_Ok()
        {
            Armeria<ArmaDeFuego> armeria = new Armeria<ArmaDeFuego> ();

            PistolaSemiautomatica pistola = new PistolaSemiautomatica();
            FusilAsalto fusil = new FusilAsalto();
            fusil.NumeroSerie = "IGUAL";
            pistola.NumeroSerie = "IGUAL";

            //Act
            armeria += pistola;
            armeria += fusil;

            bool rta = armeria.Armas.Count == 2;
            //Assert
            Assert.IsTrue(rta);
        }

        /// <summary>
        /// Se intentan agregar 2 armas del mismo tipo y mismo numero de serie.
        /// </summary>
        [TestMethod]
        public void TeastAgregar_Falla()
        {
            Armeria<ArmaDeFuego> armeria = new Armeria<ArmaDeFuego>();

            PistolaSemiautomatica pistola1 = new PistolaSemiautomatica();
            PistolaSemiautomatica pistola2 = new PistolaSemiautomatica();

            pistola1.NumeroSerie = "IGUAL";
            pistola2.NumeroSerie = "IGUAL";

            Action agregar = () => { armeria += pistola2; };

            armeria += pistola1;

            Assert.ThrowsException<Exception>(agregar);
        }

        /// <summary>
        /// Se intenta eliminar un arma presente en la armeria.
        /// </summary>
        [TestMethod]
        public void TestEliminar_Ok()
        {
            Armeria<ArmaDeFuego> armeria = new Armeria<ArmaDeFuego>();

            PistolaSemiautomatica pistola;
            pistola = new PistolaSemiautomatica(
                "fabricante",
                "modelo",
                "num_serie",
                1.2,
                EMunicion.ACP_45,
                new List<EMaterial>() { EMaterial.Acero },
                10,
                137.99
                );

            int cantidadAnterior;
            int cantidadSiguiente;

            armeria += pistola;
            cantidadAnterior = armeria.Armas.Count;

            armeria -= pistola;
            cantidadSiguiente = armeria.Armas.Count;

            bool rta = cantidadAnterior != cantidadSiguiente && cantidadSiguiente == 0;

            Assert.IsTrue(rta);
        }

        /// <summary>
        /// Se intenta eliminar un arma que no se encuentra en la armeria.
        /// </summary>
        [TestMethod]
        public void TestEliminar_Falla()
        {
            Armeria<ArmaDeFuego> armeria = new Armeria<ArmaDeFuego>();

            PistolaSemiautomatica pistola = new PistolaSemiautomatica();
            FusilAsalto fusil = new FusilAsalto();

            pistola.NumeroSerie = "IGUAL";
            fusil.NumeroSerie = "IGUAL";

            Action eliminar = () => { armeria -= fusil; };

            armeria += pistola;

            Assert.ThrowsException<Exception>(eliminar);
        }

        /// <summary>
        /// Se intenta obtener un arma de la armeria accediendo mediante el indexador.
        /// </summary>
        [TestMethod]
        public void TestObtenerIndice_Ok()
        {
            Armeria<ArmaDeFuego> armeria = new Armeria<ArmaDeFuego>();

            PistolaSemiautomatica pistola;
            pistola = new PistolaSemiautomatica(
                "pistola",
                "pistola",
                "pistola",
                1.2,
                EMunicion.ACP_45,
                new List<EMaterial>() { EMaterial.Acero },
                10,
                137.99
                );

            FusilAsalto fusil;
            fusil = new FusilAsalto(
                "fusil",
                "fusil",
                "fusil",
                4.2,
                EMunicion.OTAN_5_56x45,
                new List<EMaterial>() { EMaterial.Aluminio },
                30,
                300,
                1500
                );

            armeria += pistola;
            armeria += fusil;

            bool rta = armeria[0] == pistola && armeria[1] == fusil;

            Assert.IsTrue(rta);
        }

        /// <summary>
        /// Se intenta acceder a un arma en la armeria con un indice fuera del rango de la misma.
        /// </summary>
        [TestMethod]
        public void TestObtenerIndice_Falla()
        {
            Armeria<ArmaDeFuego> armeria = new Armeria<ArmaDeFuego>();

            PistolaSemiautomatica pistola;
            pistola = new PistolaSemiautomatica(
                "pistola",
                "pistola",
                "pistola",
                1.2,
                EMunicion.ACP_45,
                new List<EMaterial>() { EMaterial.Acero },
                10,
                137.99
                );

            armeria += pistola;
            Action accion = () => { ArmaDeFuego arma = armeria[1]; };


            Assert.ThrowsException<ArgumentOutOfRangeException>(accion);
        }
    }
}