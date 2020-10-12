using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CatalogoTiempos.Models
{
    public class Tiempos
    {
        public string TC_Horario { set; get; }
        public int TH_Duracion { set; get; }

        //retorna 1 si fue correcto, -1 si hubo un error en la base de datos, 0 si el registro ya existe
        public int agregarTiempos(Tiempos tiempos) {
            ConexionBD myCon = new ConexionBD();
            return myCon.ejecutar($"exec sp_registrar_horario '{tiempos.TC_Horario}', {tiempos.TH_Duracion}");
        }

        //retorna 1 si fue correcto, -1 si hubo un error en la base de datos, 0 si el registro ya existe
        public int eliminarTiempos(string _TC_Horario)
        {
            ConexionBD myCon = new ConexionBD();
            return myCon.ejecutar($"exec sp_eliminar_horario '{_TC_Horario}'");
        }

        public int actualizarTiempos(Tiempos tiempos)
        {
            ConexionBD myCon = new ConexionBD();
            return myCon.ejecutar($"exec sp_actualizar_horario '{tiempos.TC_Horario}', {tiempos.TH_Duracion}");
        }

        public Tiempos consultarTiempo(Tiempos tiempos)
        {
            ConexionBD myCon = new ConexionBD();
            Tiempos t = new Tiempos();

            SqlDataReader dataReader = myCon.consultar($"exec sp_consultar_horario '{tiempos.TC_Horario}', {tiempos.TH_Duracion}");

            while (dataReader.Read())
            {
                t.TC_Horario = dataReader["TC_Horario"].ToString();
                t.TH_Duracion = int.Parse(dataReader["TH_Duracion"].ToString());
            }

            return t;
        }

        public List<Tiempos> listarTiempos()
        {
            ConexionBD myCon = new ConexionBD();
            List<Tiempos> lista = new List<Tiempos>();
            SqlDataReader dataReader = myCon.consultar($"exec sp_listar_horarios");

            while (dataReader.Read())
            {
                Tiempos t = new Tiempos();
                t.TC_Horario = dataReader["TC_Horario"].ToString();
                t.TH_Duracion = int.Parse(dataReader["TH_Duracion"].ToString());
                lista.Add(t);
            }

            return lista;
        }

    }
}