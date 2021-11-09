using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace pro_studentsnru_117_135
{
    public partial class Form1 : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        public Form1()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/resumestd.mdb;Persist Security Info=False;";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {


                connection.Open();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error  " + ex);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            connection.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "Select * from tb_uspa where usename ='" + txtUsername.Text + "' and password ='" + txtpassword.Text + "'";
            

            OleDbDataReader reader = command.ExecuteReader();
            int count = 0;
            while (reader.Read())
            {
                count = count + 1;
                //count++;
                //
            }
            if (count == 1)
            {
                MessageBox.Show("Username และ password ถูกต้อง");
                connection.Close();
                connection.Dispose();
                this.Hide();
                menu f2 = new menu();
                f2.ShowDialog();
            }
            if (count > 1)
            {
                MessageBox.Show("Username และ password ซ้ำกัน");
            }
            else
            {
                MessageBox.Show("Username และ password ไม่ถูกต้อง");
                txtpassword.Text = "";
            }
            connection.Close();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            connection.Dispose();
            this.Hide();
            Register f2 = new Register();
            f2.ShowDialog();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtpassword.PasswordChar = '\0';
               
            }
            else
            {
                txtpassword.PasswordChar = '•';
                
            }
        }
    }
    
}
