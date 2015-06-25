using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using TransactionLog.Entidades;

namespace TransactionLog.Clases
{
     class ManagerLog
     {
         public static Resultado ManagerResult;
         public SqlConnection _connection;
         public ManagerLog()
         {
              ManagerResult = new Resultado();
         }


         public  SqlConnection SetConnectioString(string server, string dbName)
         {
              string dataSource = "Data Source=" + server + ";";
            string catalog = "Initial Catalog=" + dbName + ";";
            string type = "Integrated Security=True";
            try
            {
                
                
                    _connection = new SqlConnection(dataSource + catalog + type);
                
                    
                _connection.Open();
                return _connection;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

         
        


        public  Resultado ShearchTable(string Table)
        {
            //This function is to put the connectionString in mode Window Autentication 
            
            SqlConnection sqlConnection = new SqlConnection("Data Source=(localdb)\\ProjectsV12;Initial Catalog=CHF_DEV;Integrated Security=SSPI;");
           
           
            var dataTable = new DataTable();
             sqlConnection.Open();
             SqlCommand myCommand = new SqlCommand("Select* From fn_dblog(null, null)",sqlConnection);

             SqlDataReader myReader;
            try
            {
                myReader = myCommand.ExecuteReader();
                dataTable.Load(myReader);

                ManagerResult.SelectResult = dataTable;
                ManagerResult.FindObject = true;
                ManagerResult.response = "Tabla Encontrada";


            }
            catch (Exception ex)
            {
                  ManagerResult.SelectResult = null;
                  ManagerResult.FindObject = false;
                ManagerResult.response = ex.Message;
               
                
            }
            sqlConnection.Close();

            return ManagerResult;
        }

        public static Resultado ShearchDataBase(string DataBase)
        {
            
            return new Resultado();
        }
        public SqlDataReader GetRowLogContents0(string tableName)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT [Begin Time] FROM ::fn_dblog(NULL,NULL)  where AllocUnitName = 'dbo." + tableName;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = _connection;
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
                return reader;
            return null;
        }

   
     
     }


}

