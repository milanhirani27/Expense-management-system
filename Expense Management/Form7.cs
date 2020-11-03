using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Expense_Management
{
    public partial class Form7 : Form
    {
        Homepage x;
        public Form7(Homepage y)
        {
            InitializeComponent();
            this.x = y;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void add_Click(object sender, EventArgs e)
        {
            try
            {
                string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Vijay\Documents\Abhi.mdf;Integrated Security=True;Connect Timeout=30";
                SqlConnection cnn = new SqlConnection(con);
                cnn.Open();
                /*SqlDataAdapter sda = new SqlDataAdapter("select income from  Userdata where uname = '" + x.label1.Text + "'", con);
                DataTable dt1 = new DataTable();
                sda.Fill(dt1);
                float x1 = Convert.ToInt64(dt1.Rows[0][0]);*/
                String a = "select id from Userdata where uname='" + x.label1.Text + "'";
                SqlDataAdapter sda2 = new SqlDataAdapter(a, con);
                DataTable dt2 = new DataTable();
                sda2.Fill(dt2);
                int a1 = Convert.ToInt32(dt2.Rows[0][0]);
                string date1 = Convert.ToString(dateTimePicker1.Text);
                string date2 = Convert.ToString(dateTimePicker2.Text);
                String que = "select sum(exp) from edata where edate>='" + date1 + "' and edate<='" + date2 + "' and id='" + a1 + "'";
                SqlDataAdapter sda1 = new SqlDataAdapter(que, con);
                DataTable dt = new DataTable();
                sda1.Fill(dt);
                String a4 = "select sum(income) from idata where idate>='" + date1 + "' and idate<='" + date2 + "' and id='" + a1 + "'";
                SqlDataAdapter sda4 = new SqlDataAdapter(a4, con);
                DataTable dt4 = new DataTable();
                sda4.Fill(dt4);
                float a5 = Convert.ToInt64(dt4.Rows[0][0]);
                float x2 = Convert.ToInt64(dt.Rows[0][0]);
                float x3 = a5 - x2;
                label4.Text = Convert.ToString(a5);
                label5.Text = Convert.ToString(x2);
                label6.Text = Convert.ToString(x3);
                report im1 = new report(this);
                im1.Show();
                cnn.Close();
            }
            catch (Exception e1)
            {
                MessageBox.Show("No Entry found between the mentioned dates","Alert");
            }
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Vijay\Documents\Abhi.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection cnn = new SqlConnection(con);
            cnn.Open();
            String a = "select id from Userdata where uname='" + x.label1.Text + "'";
            SqlDataAdapter sda2 = new SqlDataAdapter(a, con);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            int a1 = Convert.ToInt32(dt2.Rows[0][0]);
            string date1 = Convert.ToString(dateTimePicker1.Text);
            string date2 = Convert.ToString(dateTimePicker2.Text);
            SqlDataAdapter sda3 = new SqlDataAdapter("select exp,edate from  edata where edate>='" + date1 + "' and edate<='" + date2 + "' and id='" + a1 + "'", con);
            DataTable dt3 = new DataTable();
            sda3.Fill(dt3);
            dataGridView1.DataSource = dt3;
            /*dataGridView1.Rows.Clear();
             foreach (DataRow item in dt3.Rows)
             {
                int n = dataGridView1.Rows.Add();
                 dataGridView1.Rows[n].Cells[0].Value = item["exp"].ToString();
                 dataGridView1.Rows[n].Cells[1].Value = item["date"].ToString();
             }*/
            dataGridView1.Visible = true;
            cnn.Close();
        }
    }
}
