using CatalogoTiempos.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlClient;

namespace TestsUnitarios
{
    [TestClass]
    public class TiemposTests
    {

        [TestMethod]
        public void agregarTiempos_Return1()
        {
            Tiempos tiempos = new Tiempos();
            tiempos.TC_Horario = "Salida";
            tiempos.TH_Duracion = "00:00:00";

            int res = tiempos.agregarTiempos(tiempos);

            Assert.AreEqual(1, res);
        }

        [TestMethod]
        public void consultarTiempos_ReturnTiempos()
        {
            Tiempos tiempos = new Tiempos();
            tiempos.TC_Horario = "Salida";
            tiempos.TH_Duracion = "00:00:00";

            Tiempos res = tiempos.consultarTiempo(tiempos);

            Assert.AreEqual(tiempos.TC_Horario, res.TC_Horario);
            Assert.AreEqual(tiempos.TH_Duracion, res.TH_Duracion);
        }

        public void actualizarTiempos_Return1() {
            Tiempos t = new Tiempos();

        }
    }
}
