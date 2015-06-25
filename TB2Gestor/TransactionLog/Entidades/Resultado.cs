using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionLog.Entidades
{
   public  class Resultado
    {
         public string response { get; set; }
         public DataTable SelectResult{ get; set; }
         public bool FindObject { get; set; }
    
    
    }
}
