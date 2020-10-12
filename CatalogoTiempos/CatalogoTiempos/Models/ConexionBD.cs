using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CatalogoTiempos.Models
{
    public class ConexionBD
    {

        private SqlConnection cnn;
        public ConexionBD()
        {
            this.cnn = new SqlConnection("Database=Manejo_Tiempos_Laborales;Server=163.178.107.10;user=laboratorios;password=KmZpo.2796");
        }

        public SqlDataReader consultar(string comando) {
            SqlDataReader dr = null;

            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand(comando, cnn);
                dr = cmd.ExecuteReader();
            }
            catch
            {
                cnn.Close();
            }

            return dr;
        }

        public int ejecutar(string comando)
        {
            int salida = 0;
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand(comando, cnn);
                cmd.ExecuteNonQuery();
                salida = 1;
            }
            catch (SqlException e)
            {
                salida = 0;
            }

            cnn.Close();
            return salida;
        }

    }
}