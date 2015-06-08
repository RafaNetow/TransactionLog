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
         public ManagerLog()
         {
              ManagerResult = new Resultado();
         }
        


        public  Resultado ShearchTable(string Table)
        {
            //This function is to put the connectionString in mode Window Autentication 
            
            SqlConnection sqlConnection = new SqlConnection("Data Source=(localdb)\\ProjectsV12;Initial Catalog=CHF_DEV;Integrated Security=SSPI;");
            //SqlConnection sqlConnection3 = new SqlConnection("Provider=System.Data.SqlClient;Server=myServerAddress;Database=myDataBase;Trusted_Connection=yes");
           // SqlConnection sqlConnection2 = new SqlConnection(" Server=localdb;Database=CHF_DEV;IntegratedSecurity=yes;Uid=auth_windows;");
            //SqlConnection sqlConnection = new SqlConnection(" name=NorthwindContex ;connectionString=data source=localhost;initial catalog=northwind;persist security info=True; Integrated Security=SSPI; providerName=System.Data.SqlClient" );
           
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
    }


}

