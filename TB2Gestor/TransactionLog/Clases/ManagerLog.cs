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
             SqlConnection sqlConnection1 = new SqlConnection("data source=localhost;initial catalog=northwind;persist security info=True; Integrated Security=SSPI;");
             var dataTable = new DataTable();
             sqlConnection1.Open();
             SqlCommand myCommand = new SqlCommand("Select* From fn_dblog(null, null)");

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
            sqlConnection1.Close();

            return ManagerResult;
        }

        public static Resultado ShearchDataBase(string DataBase)
        {
            
            return new Resultado();
        }
    }


}

