using DBConnectSvc.App_Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DBConnectSvc
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IConnection, IService1
    {
        public IEnumerable<ToDoListDataContract> Consultar()
        {
            Conectar();

            List<ToDoListDataContract> lista = new List<ToDoListDataContract>();
            try
            {
                SqlCommand comando = new SqlCommand("spconsultar", cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    ToDoListDataContract modelo = new ToDoListDataContract()
                    {
                        Id = int.Parse(lector[0].ToString()),
                        Titulo = lector[1].ToString(),
                        EstadoTarea = bool.Parse(lector[2].ToString()),
                        FechaCreacion = DateTime.Parse(lector[3].ToString()),
                        FechaFin = DateTime.Parse(lector[4].ToString()),
                        Notas = lector[5].ToString(),
                        Prioridad = int.Parse(lector[6].ToString())
                    };
                    lista.Add(modelo);
                }

            }
            catch (Exception e)
            {

                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                //listadc = lista;
                Desconectar();
            }
            return lista;
        }

        public void Eliminar(int id)
        {
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("speliminar", cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Id", id);
                comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {

                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                Desconectar();
            }
        }

        public void Guardar(ToDoListDataContract modelo)
        {
            {
                Conectar();

                try
                {
                    SqlCommand comando = new SqlCommand("spguardar", cnn);
                    comando.CommandType = System.Data.CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@titulo", modelo.Titulo.ToString());
                    comando.Parameters.AddWithValue("@estadotarea", bool.Parse(modelo.EstadoTarea.ToString()));
                    comando.Parameters.AddWithValue("@fechacreacion", modelo.FechaCreacion);
                    comando.Parameters.AddWithValue("@fechafin", modelo.FechaFin);
                    comando.Parameters.AddWithValue("@notas", modelo.Notas.ToString());
                    comando.Parameters.AddWithValue("@prioridad", int.Parse(modelo.Prioridad.ToString()));
                    comando.ExecuteNonQuery();

                }
                catch (Exception e)
                {

                    Console.WriteLine(e.StackTrace);
                }
                finally
                {
                    Desconectar();
                }


            }
        }


        public void Modificar(ToDoListDataContract modelo)
        {
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("spmodificar", cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@id", (int)modelo.Id);
                comando.Parameters.AddWithValue("@titulo", modelo.Titulo.ToString());
                comando.Parameters.AddWithValue("@estadotarea", bool.Parse(modelo.EstadoTarea.ToString()));
                comando.Parameters.AddWithValue("@fechafin", modelo.FechaFin);
                comando.Parameters.AddWithValue("@notas", modelo.Notas.ToString());
                comando.Parameters.AddWithValue("@prioridad", int.Parse(modelo.Prioridad.ToString()));
                comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {

                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                Desconectar();
            }
        }
    }
}




