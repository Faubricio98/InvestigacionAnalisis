using CatalogoTiempos.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestsUnitarios
{
    [TestClass]
    public class TiemposTests
    {
        [TestMethod]
        public void agregarTiempos_Return1()
        {
            Tiempos tiempos = new Tiempos { TC_Horario = "Entrada", TH_Duracion = 0 };
            int res = tiempos.agregarTiempos(tiempos);

            Assert.AreEqual(1, res);
        }
    }
}
