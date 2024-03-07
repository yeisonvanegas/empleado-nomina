
using System;
using System.Data;
using System.Data.SqlClient;

namespace AplicacionEmpleadosNomina.ModelL
{
    class ConexionML
    {
        SqlConnection conexion;
        private string cadenaconexion = "Data Source=YEISON-VANEGAS\\MSSQLSERVER01; Integrated Security=True;";

        public SqlConnection EstablecerConexion()
        {
            try
            {
                this.conexion = new SqlConnection(this.cadenaconexion);
                return this.conexion;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al establecer la conexión: " + ex.Message);
                return null;
            }
        }

        public bool ProbarConexion()
        {
            try
            {
                using (SqlConnection connection = EstablecerConexion())
                {
                    connection.Open();
                    SqlCommand comando = new SqlCommand();
                    comando.Connection = connection;
                    comando.CommandText = "SELECT * FROM dbo.employees";
                    comando.ExecuteNonQuery();
                    connection.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al probar la conexión: " + ex.Message);
                return false;
            }
        }
    }
}
