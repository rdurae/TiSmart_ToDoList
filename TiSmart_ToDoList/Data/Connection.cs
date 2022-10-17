using System.Data.SqlClient;

namespace TiSmart_ToDoList.Data
{
    public class Connection
    {
        protected SqlConnection cnn;
        protected void Conectar()
        {
            try
            {
                cnn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=todoapp_db;Integrated Security=True;");
                cnn.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }            
        }

        protected void Desconectar()
        {
            try
            {
                
                cnn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

    }
}
