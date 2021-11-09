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
    
    public partial class menu : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        public menu()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:/resumestd.mdb;Persist Security Info=False;";
        }

        private void menu_Load(object sender, EventArgs e)
        {
            
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select * from tb_resumestd ";

                command.CommandText = query;



                OleDbDataAdapter da = new OleDbDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;


                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error  " + ex);
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "insert into tb_resumestd(idstd,namestd,surnamestd,oldstd,depstd,subjectstd,addressstd,callstd,emailstd,chastd,levelstd,wutstd)" +
                    "values('" + txtid.Text + "','" + txtname.Text + "','" + txtsurname.Text + "','" + txtold.Text + "','" + cbxdep.Text + "','" + txtsubject.Text +
                    "','" + txtadress.Text + "','" + txtcall.Text + "','" + txtemail.Text + "','" + txtcha.Text + "','" + cbxlevel.Text + "','" + cbxwut.Text + "')";

                command.ExecuteNonQuery();
                MessageBox.Show("เซฟข้อมูล");
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error  " + ex);
            }
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "update tb_resumestd set namestd ='" + txtname.Text + "',surnamestd ='" + txtsurname.Text + "',oldstd ='" + txtold.Text + "',depstd ='" + cbxdep.Text + "'," +
                    "subjectstd ='" + txtsubject.Text + "',addressstd ='" + txtadress.Text + "',callstd ='" + txtcall.Text + "',emailstd ='" + txtemail.Text + "',chastd ='" + txtcha.Text + "',levelstd ='" + cbxlevel.Text + "',wutstd ='" + cbxwut.Text + "' where idstd  = '" + txtid.Text + "'";
                MessageBox.Show(query);
                command.CommandText = query;

                command.ExecuteNonQuery();
                MessageBox.Show("แก้ไขข้อมูล");
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error  " + ex);
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "delete from tb_resumestd where idstd = '" + txtid.Text + "' ";
                MessageBox.Show(query);
                command.CommandText = query;

                command.ExecuteNonQuery();
                MessageBox.Show("ลบข้อมูลเสร็จสิ้น");
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error  " + ex);
            }
        }

        private void btnbacklogin_Click(object sender, EventArgs e)
        {
            connection.Dispose();
            this.Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            txtid.Text = "";
            txtname.Text = "";
            txtsurname.Text = "";
            txtold.Text = "";
            cbxdep.Text = "";
            cbxlevel.Text = "";
            cbxwut.Text = "";
            txtcall.Text = "";
            txtadress.Text = "";
            txtcha.Text = "";
            txtsubject.Text = "";
            txtemail.Text = "";
            

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtid.Text = row.Cells[0].Value.ToString();
                txtname.Text = row.Cells[1].Value.ToString();
                txtsurname.Text = row.Cells[2].Value.ToString();
                txtold.Text = row.Cells[3].Value.ToString();
                cbxdep.Text = row.Cells[4].Value.ToString();
                txtsubject.Text = row.Cells[5].Value.ToString();

                txtadress.Text = row.Cells[6].Value.ToString();
                txtcall.Text = row.Cells[7].Value.ToString();
                txtemail.Text = row.Cells[8].Value.ToString();
                txtcha.Text = row.Cells[9].Value.ToString();
                cbxlevel.Text = row.Cells[10].Value.ToString();
                cbxwut.Text = row.Cells[11].Value.ToString();

            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
