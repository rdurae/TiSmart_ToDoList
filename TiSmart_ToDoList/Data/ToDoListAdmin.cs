using System;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using TiSmart_ToDoList.Models;

namespace TiSmart_ToDoList.Data
{
    public class ToDoListAdmin : Connection
    {
        public IEnumerable<ToDoListModel> Consultar()
        {
            Conectar();
            List<ToDoListModel> lista = new List<ToDoListModel>();
            try
            {
                SqlCommand comando = new SqlCommand("spconsultar", cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader lector = comando.ExecuteReader();
                while(lector.Read())
                {
                    ToDoListModel modelo = new ToDoListModel()
                    {
                        Id = int.Parse(lector[0].ToString()),
                        Titulo = lector[1].ToString(),
                        //EstadoTarea = (lector[2].ToString() == "1") ? true : false,
                        EstadoTarea = bool.Parse(lector[2].ToString()),
                        FechaCreacion = DateTime.Parse(lector[3].ToString()),
                        //FechaFin = DateTime.Parse(lector[4].ToString()),
                        //FechaFin = DateTime.Parse(lector[4].ToString()),
                        //FechaFin = (lector[4] == null) ? SqlDateTime.MinValue : DateTime.Parse(lector[4].ToString()),
                        //FechaFin = DateTime.Parse(lector[4].ToString()),
                        //FechaFin = (DateTime)SqlDateTime.Null,
                        //FechaFin = (lector[4] == null) ? (DateTime)SqlDateTime.Null : DateTime.Now,
                        FechaFin = DateTime.Parse(lector[4].ToString()),
                        //FechaFin = (lector[4] == null) ? DateTime.MinValue : DateTime.Parse(lector[4].ToString()),
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
                Desconectar(); 
            }
            return lista;
         
        }

        public void Guardar(ToDoListModel modelo)
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
            //finally
            //{
            //    Desconectar();
            //}
            //return lista;

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
    }
}
