using Armas;
using Municion;

namespace TestArmas
{
    [TestClass]
    public class ArmasTest
    {
        /// <summary>
        /// Se comparan 2 armas que solo coinciden en numero de serie y tipo.
        /// </summary>
        [TestMethod]
        public void TestComprobarIgualdad_Ok()
        {
            PistolaSemiautomatica pistola1;
            pistola1 = new PistolaSemiautomatica(
                "pistola_1",
                "pistola_1",
                "IGUAL",
                1,
                EMunicion.ACP_45,
                new List<EMaterial>() { EMaterial.Acero },
                10,
                100
                );

            PistolaSemiautomatica pistola2;
            pistola2 = new PistolaSemiautomatica(
                "pistola_2",
                "pistola_2",
                "IGUAL",
                2,
                EMunicion.PARABELLUM_9x19,
                new List<EMaterial>() { EMaterial.Polimero },
                20,
                200
                );


            bool rta = pistola1 == pistola2;


            Assert.IsTrue(rta);
        }

        /// <summary>
        /// Se comparan 2 armas que coinciden en todos sus atributos, pero son de diferente tipo.
        /// </summary>
        [TestMethod]
        public void TestComprobarIgualdad_Fallak()
        {
            PistolaSemiautomatica pistola;
            pistola = new PistolaSemiautomatica(
                "IGUAL",
                "IGUAL",
                "IGUAL",
                1,
                EMunicion.ACP_45,
                new List<EMaterial>() { EMaterial.Acero },
                10,
                100
                );

            EscopetaBombeo escopeta;
            escopeta = new EscopetaBombeo(
                "IGUAL",
                "IGUAL",
                "IGUAL",
                2,
                EMunicion.ACP_45,
                new List<EMaterial>() { EMaterial.Acero },
                10,
                100
                );


            bool rta = pistola == escopeta;


            Assert.IsFalse(rta);
        }

        /// <summary>
        /// Se intenta efectuar un disparo, pero el mismo no es exitoso.<br></br>
        /// 1er intento: las armas no están cargadas.
        /// 2do intento: la pistola tiene el seguro activo, la escopeta no está amartillada.
        /// </summary>
        [TestMethod]
        public void TestDisparar_Falla()
        {
            PistolaSemiautomatica pistola;
            pistola = new PistolaSemiautomatica(
                "pistola",
                "pistola",
                "pistola",
                1,
                EMunicion.ACP_45,
                new List<EMaterial>() { EMaterial.Polimero },
                7,
                1000
                );

            EscopetaBombeo escopeta;
            escopeta = new EscopetaBombeo(
                "escopeta",
                "escopeta",
                "escopeta",
                4.2,
                EMunicion.SHELL_12g,
                new List<EMaterial>() { EMaterial.Acero, EMaterial.Madera },
                5,
                1000
                );

            FusilAsalto fusil;
            fusil = new FusilAsalto(
                "fusil",
                "fusil",
                "fusil",
                3.6,
                EMunicion.OTAN_5_56x45,
                new List<EMaterial>() { EMaterial.Aluminio },
                30,
                200,
                1500
                );

            bool disparoCargadorVacio = pistola.Disparar() || escopeta.Disparar() || fusil.Disparar();

            pistola.Recargar();
            escopeta.Recargar();

            bool disparoSeguroActivo = pistola.Disparar() || escopeta.Disparar();

            bool algunDisparoExitoso = disparoCargadorVacio || disparoSeguroActivo;

            Assert.IsFalse( algunDisparoExitoso );
        }

        /// <summary>
        /// Se intenta disparar todas las armas. Todas están sin seguro y tienen el cargador lleno.
        /// </summary>
        [TestMethod]
        public void TestDisparar_Ok()
        {
            PistolaSemiautomatica pistola;
            pistola = new PistolaSemiautomatica(
                "pistola",
                "pistola",
                "pistola",
                1,
                EMunicion.ACP_45,
                new List<EMaterial>() { EMaterial.Polimero },
                7,
                1000
                );

            EscopetaBombeo escopeta;
            escopeta = new EscopetaBombeo(
                "escopeta",
                "escopeta",
                "escopeta",
                4.2,
                EMunicion.SHELL_12g,
                new List<EMaterial>() { EMaterial.Acero, EMaterial.Madera },
                5,
                1000
                );

            FusilAsalto fusil;
            fusil = new FusilAsalto(
                "fusil",
                "fusil",
                "fusil",
                3.6,
                EMunicion.OTAN_5_56x45,
                new List<EMaterial>() { EMaterial.Aluminio },
                30,
                200,
                1500
                );

            pistola.Recargar();
            escopeta.Recargar();
            fusil.Recargar();
            pistola.CambiarSeguro();
            escopeta.Amartillar();

            bool todosDisparosExitosos = pistola.Disparar() && escopeta.Disparar() && fusil.Disparar();

            Assert.IsTrue(todosDisparosExitosos);
        }

        /// <summary>
        /// Se intenta agregar cartuchos de un calibre diferente a las armas.
        /// </summary>
        [TestMethod]
        public void TestAgregarCartucho_Falla()
        {
            PistolaSemiautomatica pistola;
            pistola = new PistolaSemiautomatica(
                "pistola",
                "pistola",
                "pistola",
                1,
                EMunicion.ACP_45,
                new List<EMaterial>() { EMaterial.Polimero },
                7,
                1000
                );

            EscopetaBombeo escopeta;
            escopeta = new EscopetaBombeo(
                "escopeta",
                "escopeta",
                "escopeta",
                4.2,
                EMunicion.SHELL_12g,
                new List<EMaterial>() { EMaterial.Acero, EMaterial.Madera },
                5,
                1000
                );

            FusilAsalto fusil;
            fusil = new FusilAsalto(
                "fusil",
                "fusil",
                "fusil",
                3.6,
                EMunicion.OTAN_5_56x45,
                new List<EMaterial>() { EMaterial.Aluminio },
                30,
                200,
                1500
                );

            List<Cartucho> cartuchos = new List<Cartucho>();
            cartuchos.Add(new Cartucho(EMunicion.MAGNUM_44));
            cartuchos.Add(new Cartucho(EMunicion.SOVIET_5_45X39));
            cartuchos.Add(new Cartucho(EMunicion.WIN_308));

            pistola.Recargar(cartuchos);
            escopeta.Recargar(cartuchos);
            fusil.Recargar(cartuchos);

            bool pistolaVacia = pistola.Cargador.CartuchosCargados.Count == 0;
            bool fusilVacio = fusil.Cargador.CartuchosCargados.Count == 0;
            bool escopetaVacia = escopeta.CartuchosCargados.Count == 0;

            bool todosVacios = pistolaVacia && fusilVacio && escopetaVacia;

            Assert.IsTrue( todosVacios );
        }

        /// <summary>
        /// Se intenta agregar cartuchos del mismo calibre que las armas.
        /// </summary>
        [TestMethod]
        public void TestAgregarCartucho_Ok()
        {
            PistolaSemiautomatica pistola;
            pistola = new PistolaSemiautomatica(
                "pistola",
                "pistola",
                "pistola",
                1,
                EMunicion.ACP_45,
                new List<EMaterial>() { EMaterial.Polimero },
                7,
                1000
                );

            EscopetaBombeo escopeta;
            escopeta = new EscopetaBombeo(
                "escopeta",
                "escopeta",
                "escopeta",
                4.2,
                EMunicion.SHELL_12g,
                new List<EMaterial>() { EMaterial.Acero, EMaterial.Madera },
                5,
                1000
                );

            FusilAsalto fusil;
            fusil = new FusilAsalto(
                "fusil",
                "fusil",
                "fusil",
                3.6,
                EMunicion.OTAN_5_56x45,
                new List<EMaterial>() { EMaterial.Aluminio },
                30,
                200,
                1500
                );

            List<Cartucho> cartuchos = new List<Cartucho>();
            cartuchos.Add(new Cartucho(EMunicion.ACP_45));
            cartuchos.Add(new Cartucho(EMunicion.SHELL_12g));
            cartuchos.Add(new Cartucho(EMunicion.OTAN_5_56x45));

            pistola.Recargar(cartuchos);
            escopeta.Recargar(cartuchos);
            fusil.Recargar(cartuchos);

            bool pistolaCargada = pistola.Cargador.CartuchosCargados.Count != 0;
            bool fusilCargado = fusil.Cargador.CartuchosCargados.Count != 0;
            bool escopetaCargada = escopeta.CartuchosCargados.Count != 0;

            bool todosCargados = pistolaCargada && fusilCargado && escopetaCargada;

            Assert.IsTrue(todosCargados);
        }
    }
}