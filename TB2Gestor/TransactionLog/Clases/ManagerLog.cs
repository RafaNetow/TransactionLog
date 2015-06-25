using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public  class ManagerLog
     {
         public  Resultado ManagerResult;
        public static SqlConnection _connection;
         public ManagerLog()
         {
              ManagerResult = new Resultado();
         }

        //Obtengo la Connecion con el Server y La base de datos indicada
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

        //Obtengo todas las tablas de la base de datos en la cual estoy
         public SqlDataReader GetTables()
         {
            
             _connection.Close();
             _connection.Open();
             SqlCommand cmd = new SqlCommand("SELECT name FROM sysobjects WHERE type='U'",_connection);
             
            
           //  cmd.CommandText = "SELECT name FROM sysobjects WHERE type='U'";
             //cmd.CommandType = CommandType.Text;
             //cmd.Connection = _connection;
             
             SqlDataReader reader = cmd.ExecuteReader();
             if (reader.HasRows)
                 return reader;
             return null;
         }


        public  Resultado ShearchTable(string Table)
        {
            //This function is to put the connectionString in mode Window Autentication 
            
           
           
           
            var dataTable = new DataTable();
             _connection.Open();
             SqlCommand myCommand = new SqlCommand("Select* From fn_dblog(null, null)",_connection);

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
            _connection.Close();

            return ManagerResult;
        }

        public static Resultado ShearchDataBase(string DataBase)
        {
            
            return new Resultado();
        }
        public SqlDataReader GetRowLogContents0Information(string tableName)
        {
            // SqlCommand cmd = new SqlCommand("SELECT [Transaction ID], [RowLog Contents 0] FROM ::fn_dblog(NULL,NULL)  where AllocUnitName = 'dbo.Numero' AND Context IN('LCX_MARK_AS_GHOST', 'LCX_HEAP') AND Operation in('LOP_DELETE_ROWS')",_connection);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT [Transaction ID], [RowLog Contents 0] FROM ::fn_dblog(NULL,NULL)  where AllocUnitName = 'dbo.'" + tableName + " AND Context IN('LCX_MARK_AS_GHOST', 'LCX_HEAP') AND Operation in('LOP_DELETE_ROWS')";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = _connection;

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                MessageBox.Show("Entro reader", "Correcto", MessageBoxButtons.OK);

                return reader;
            }

            return null;
        }
        
        public SqlDataReader GetRowLogContents0(string tableName)
        {
            _connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT [Begin Time] FROM ::fn_dblog(NULL,NULL)  where AllocUnitName = 'dbo." + tableName;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = _connection;
            
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
                return reader;
            return null;
        }


        public SqlDataReader GetColumns(string tableName)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT COLUMN_NAME, DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + tableName + "'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = _connection;

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
                return reader;
            return null;
        }
     }


}

