using CatalogoTiempos.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
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

        [TestMethod]
        public void actualizarTiempos_Return1() {
            Tiempos t = new Tiempos();
            t.TC_Horario = "Salida Laboral";
            t.TH_Duracion = "00:00:00";
            string viejo = "Salida";

            int res = new Tiempos().actualizarTiempos(viejo, t);

            Assert.AreEqual(1, res);
        }

        [TestMethod]
        public void eliminarTiempos_Return1() {
            Tiempos t = new Tiempos();
            t.TC_Horario = "Entrada";
            t.TH_Duracion = "00:00:00";

            int res = new Tiempos().eliminarTiempos(t.TC_Horario);

            Assert.AreEqual(1, res);
        }

        [TestMethod]
        public void listarTiempos_ReturnLista() {
            ConexionBD con = new ConexionBD();
            SqlDataReader dataReader = con.consultar($"exec sp_listar_horarios");
            List<Tiempos> lista = new List<Tiempos>();

            while (dataReader.Read())
            {
                Tiempos t = new Tiempos();
                t.TC_Horario = dataReader["TC_Horario"].ToString();
                t.TH_Duracion = dataReader["TH_Duracion"].ToString();
                lista.Add(t);
            }

            //lista[lista.Count - 1].TC_Horario = "Hola";

            List<Tiempos> res = new Tiempos().listarTiempos();

            for (int i = 0; i<lista.Count; i++) {
                Assert.AreEqual(lista[i].TC_Horario, res[i].TC_Horario);
                Assert.AreEqual(lista[i].TH_Duracion, res[i].TH_Duracion);
            }
        }
    }
}
