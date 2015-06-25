namespace TransactionLog.View
{
    public partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonConnectar = new System.Windows.Forms.Button();
            this.textBoxNombreServidor = new System.Windows.Forms.TextBox();
            this.textBoxNombreBaseDeDatos = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(229, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Transaction Logs";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre del Servidor";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nombre de la base de Datos";
            // 
            // buttonConnectar
            // 
            this.buttonConnectar.Location = new System.Drawing.Point(243, 167);
            this.buttonConnectar.Name = "buttonConnectar";
            this.buttonConnectar.Size = new System.Drawing.Size(75, 23);
            this.buttonConnectar.TabIndex = 3;
            this.buttonConnectar.Text = "Connectar";
            this.buttonConnectar.UseVisualStyleBackColor = true;
            this.buttonConnectar.Click += new System.EventHandler(this.buttonConnectar_Click);
            // 
            // textBoxNombreServidor
            // 
            this.textBoxNombreServidor.Location = new System.Drawing.Point(165, 72);
            this.textBoxNombreServidor.Name = "textBoxNombreServidor";
            this.textBoxNombreServidor.Size = new System.Drawing.Size(329, 20);
            this.textBoxNombreServidor.TabIndex = 4;
            // 
            // textBoxNombreBaseDeDatos
            // 
            this.textBoxNombreBaseDeDatos.Location = new System.Drawing.Point(165, 124);
            this.textBoxNombreBaseDeDatos.Name = "textBoxNombreBaseDeDatos";
            this.textBoxNombreBaseDeDatos.Size = new System.Drawing.Size(329, 20);
            this.textBoxNombreBaseDeDatos.TabIndex = 5;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 277);
            this.Controls.Add(this.textBoxNombreBaseDeDatos);
            this.Controls.Add(this.textBoxNombreServidor);
            this.Controls.Add(this.buttonConnectar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Login";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonConnectar;
        private System.Windows.Forms.TextBox textBoxNombreServidor;
        private System.Windows.Forms.TextBox textBoxNombreBaseDeDatos;

    }
}