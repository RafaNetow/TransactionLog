using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using TransactionLog.Clases;
using TransactionLog.View;

namespace TransactionLog
{
    public class Principal : Form
    {

        public ManagerLog manager = new ManagerLog();



        private ListBox listBoxTable;
        private Label label3;
        private Label label1;
        private DataGridViewTextBoxColumn ID_Transaction;
        private DataGridViewTextBoxColumn Fecha_Hora;
        private DataGridViewTextBoxColumn RolowContent;


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
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.listBoxTable = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ID_Transaction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha_Hora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RolowContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize) (this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(506, 118);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Show delete logs";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]
            {
                this.ID_Transaction,
                this.Fecha_Hora,
                this.RolowContent
            });
            this.dataGridView1.Location = new System.Drawing.Point(169, 160);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(526, 143);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellContentClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // listBoxTable
            // 
            this.listBoxTable.FormattingEnabled = true;
            this.listBoxTable.Location = new System.Drawing.Point(21, 91);
            this.listBoxTable.Name = "listBoxTable";
            this.listBoxTable.Size = new System.Drawing.Size(120, 212);
            this.listBoxTable.TabIndex = 6;
            this.listBoxTable.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Seleccione una Tabla";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(302, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Transaction Log RowContent 0";
            // 
            // ID_Transaction
            // 
            this.ID_Transaction.HeaderText = "ID_Transaction";
            this.ID_Transaction.Name = "ID_Transaction";
            // 
            // Fecha_Hora
            // 
            this.Fecha_Hora.HeaderText = "Fecha y Hora";
            this.Fecha_Hora.Name = "Fecha_Hora";
            // 
            // RolowContent
            // 
            this.RolowContent.HeaderText = "Row Log Content";
            this.RolowContent.Name = "RolowContent";
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 344);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBoxTable);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Name = "Principal";
            this.Text = "TransactionLog";
            this.Load += new System.EventHandler(this.Principal_Load);
            ((System.ComponentModel.ISupportInitialize) (this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;

        public Principal()
        {
            InitializeComponent();

            var tables = this.manager.GetTables();

            while (tables.Read())
            {
                var content = tables.GetString(0);
                listBoxTable.Items.Add(content);
            }
            tables.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBoxTable.Text.Length == 0)
                MessageBox.Show("Seleccione una tabla", "Error", MessageBoxButtons.OK);
            else
            {
                var rowLogInformation = manager.GetRowLogContents0Information(listBoxTable.Text);
                if (rowLogInformation != null)
                {
                    while (rowLogInformation.Read())
                    {
                        var transactionId = rowLogInformation.GetString(0);
                        DataGridViewRow row = (DataGridViewRow) this.dataGridView1.Rows[0].Clone();
                        row.Cells[0].Value = transactionId;


                    }


                }
            }

        }

        private void Principal_Load(object sender, EventArgs e)
        {

        }

        

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            {
                var columnsAmount = this.dataGridView1.Columns.Count;
                if (columnsAmount > 3)
                {
                    for (int deletColumns = columnsAmount - 1; deletColumns <= columnsAmount; deletColumns--)
                    {
                        if (deletColumns == 2)
                            break;
                        dataGridView1.Columns.RemoveAt(deletColumns);
                    }
                    dataGridView1.Refresh();
                }


                var columns = manager.GetColumns(listBoxTable.Text);
                if (columns != null)
                {
                    while (columns.Read())
                    {
                        var content = columns.GetString(0);
                        dataGridView1.Columns.Add(content, content);
                    }
                    columns.Close();
                }

                var columnsType = manager.GetColumns(listBoxTable.Text);
                dataGridView1.Rows[0].Cells["ID_Transaction"].Value = "int";
                dataGridView1.Rows[0].Cells["Fecha_Hora"].Value = "datetime2";
                dataGridView1.Rows[0].Cells["RoLowContent"].Value = "hex";
                int posColumns = 0;
                if (columnsType != null)
                {
                    while (columnsType.Read())
                    {
                        var content = columnsType.GetString(0);

                        var contentType = columnsType.GetString(1);
                        dataGridView1.Rows[0].Cells[content].Value = contentType;
                        posColumns++;
                    }
                    columnsType.Close();
                }

            }
        }
    }
}

