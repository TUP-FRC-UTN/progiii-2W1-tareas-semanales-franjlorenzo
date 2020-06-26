using ABM_Persona.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ABM_Persona.AccesoDeDatos
{
    public class AccesoDatos_PersonaListado
    {
            public static List<Persona> ListadoPersonas()
            {
                List<Persona> listaPersona = new List<Persona>();
                string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["cadenaBD"].ToString();

                SqlConnection conexion = new SqlConnection(cadenaConexion); //creamos una nueva conexion con la BBDD

                try
                {
                    SqlCommand comando = new SqlCommand(); //creamos un nuevo comando para ejecutar consultas
                    string consulta = "SELECT * FROM Persona"; //guardamos la consulta en una variable string
                    comando.Parameters.Clear();

                    comando.CommandType = System.Data.CommandType.Text; //le decimos al comando que le pasamos una consulta de tipo texto
                    comando.CommandText = consulta; //le pasamos al comando la consulta guardada en la variable

                    conexion.Open();
                    comando.Connection = conexion; //al comando le decimos a donde conectarse, en este caso a nuestra conexion

                    SqlDataReader lector = comando.ExecuteReader();
                    if(lector != null)
                    {
                        while(lector.Read())
                        {
                            Persona auxiliar = new Persona();
                            auxiliar.Id = int.Parse(lector["id"].ToString());
                            auxiliar.Nombre = lector["nombre"].ToString();
                            auxiliar.Apellido = lector["apellido"].ToString();
                            auxiliar.Telefono = lector["telefono"].ToString();
                            auxiliar.Edad = int.Parse(lector["edad"].ToString());
                            //auxiliar.IdSexo = int.Parse(lector["idSexo"].ToString()); //ESTO PARA VIEWMODEL

                            listaPersona.Add(auxiliar);
                        }
                    }
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    conexion.Close();
                }
                return listaPersona;
            }
    }
}