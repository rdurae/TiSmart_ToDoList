using System;
using System.Data.SqlClient;

namespace DBConnectSvc.App_Data
{
    public class IConnection
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
