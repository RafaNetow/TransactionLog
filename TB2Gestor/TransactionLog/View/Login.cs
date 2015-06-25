using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransactionLog.Clases;


namespace TransactionLog.View
{
    public partial class Login : Form
    {
        private ManagerLog Manager = new ManagerLog();

        public Login()
        {
            InitializeComponent();
        }

        private void buttonConnectar_Click(object sender, EventArgs e)
        {

            string serverName = textBoxNombreServidor.Text;
            string dbName = textBoxNombreBaseDeDatos.Text;


            string message = "Conexión Correcta";
            if (Manager.SetConnectioString(serverName, dbName) == null)
                message = "Conexión Incorrecta";

            var result = MessageBox.Show(message, "Estado de Conexión", MessageBoxButtons.OK);

            if (result == DialogResult.OK && message.Equals("Conexión Correcta"))
            {
                this.Hide();

              Login logForm = new Login();
                logForm.ShowDialog();
            }
        }}
}
   
