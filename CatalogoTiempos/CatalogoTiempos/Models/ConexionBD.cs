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
            //this.cnn = new SqlConnection("Database=Manejo_Tiempos_Laborales;Server=163.178.107.10;user=laboratorios;password=KmZpo.2796");
            this.cnn = new SqlConnection("Database=Manejo_Tiempos_Laborales;Server=LAPTOP-S3M5REQ9\\SQLEXPRESS;integrated security = true");
        }

        public SqlDataReader consultar(string comando) {
            SqlDataReader dr = null;

            try
            {
                this.cnn.Open();
                SqlCommand cmd = new SqlCommand(comando, cnn);
                dr = cmd.ExecuteReader();
            }
            catch
            {
                this.cnn.Close();
            }

            return dr;
        }

        public int ejecutar(string comando)
        {
            int salida = 0;
            try
            {
                this.cnn.Open();
                SqlCommand cmd = new SqlCommand(comando, this.cnn);
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

        public int executing(string comando) {
            int salida = 0;
            try {
                this.cnn.Open();
                SqlCommand cmd = new SqlCommand(comando, this.cnn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read()) {
                    salida = int.Parse(dr["respuesta"].ToString());
                }
            }
            catch (SqlException e) {
                salida = 0;
            }

            return salida;
        }

    }
}