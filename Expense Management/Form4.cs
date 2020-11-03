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
    public partial class Income : Form
    {
        Homepage x;
        public Income(Homepage f)
        {
            InitializeComponent();
            this.x = f;
        }

        private void add_Click(object sender, EventArgs e)
        {
            string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Vijay\Documents\Abhi.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection cnn = new SqlConnection(con);
            cnn.Open();
            string uname1 = x.label1.Text;
            /*string que = "select income from Userdata where uname='"+uname1+"'";
            SqlDataAdapter sda = new SqlDataAdapter(que, con);
            DataTable dt1 = new DataTable();
            sda.Fill(dt1);*/
            String a = "select id from Userdata where uname='" + x.label1.Text + "'";
            SqlDataAdapter sda2 = new SqlDataAdapter(a, con);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            int a1 = Convert.ToInt32(dt2.Rows[0][0]);
            float inc = Convert.ToInt64(txtb1.Text);
            string idate = Convert.ToString(dateTimePicker1.Text);
            String q = "Insert into idata values('" + a1 + "','" + Convert.ToInt64(txtb1.Text) + "','" + Convert.ToString(dateTimePicker1.Text) + "')";
            SqlCommand cmd = new SqlCommand(q, cnn);
            cmd.ExecuteNonQuery();
            SqlDataAdapter sda3 = new SqlDataAdapter("select income,idate from  idata where id='" + a1 + "'", con);
            DataTable dt3 = new DataTable();
            sda3.Fill(dt3);
            dtg1.DataSource = dt3;
            cnn.Close();
        
            dtg1.Visible = true;
            //txtb1.Enabled = false;
            MessageBox.Show("Submitted Succesfully", "Alert");
            //Income.ActiveForm.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void delete_Click(object sender, EventArgs e)
        {
            txtb1.Text = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {/*
            txtb1.Enabled = true;
            txtb1.Text = "";
            MessageBox.Show("Income has been set to 0", "Alert!");
            */
        }

        private void Income_Load(object sender, EventArgs e)
        {
            /*try
            {
                string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Vijay\Documents\Abhi.mdf;Integrated Security=True;Connect Timeout=30";
                SqlConnection cnn = new SqlConnection(con);
                cnn.Open();
                string uname1 = x.label1.Text;
                string que = "select income from Userdata where uname='" + uname1 + "'";
                SqlDataAdapter sda = new SqlDataAdapter(que, con);
                DataTable dt1 = new DataTable();
                sda.Fill(dt1);
                float inc = Convert.ToInt64(dt1.Rows[0][0]);
                if (inc != 0)
                {
                    txtb1.Text = inc.ToString();
                    txtb1.Enabled = false;
                }
            }catch(Exception e2) { }*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Vijay\Documents\Abhi.mdf;Integrated Security=True;Connect Timeout=30";
                SqlConnection cnn = new SqlConnection(con);
                cnn.Open();
                string uname1 = x.label1.Text;
                String a = "select id from Userdata where uname='" + x.label1.Text + "'";
                SqlDataAdapter sda2 = new SqlDataAdapter(a, con);
                DataTable dt2 = new DataTable();
                sda2.Fill(dt2);
                int a1 = Convert.ToInt32(dt2.Rows[0][0]);
                SqlDataAdapter sda3 = new SqlDataAdapter("Update idata set income ='" + Convert.ToInt32(txtb1.Text) + "' where id = '" + a1 + "' and idate='" + Convert.ToString(dateTimePicker1.Text) + "'", con);
                DataTable dt3 = new DataTable();
                sda3.Fill(dt3);
               // dtg1.DataSource = dt3;
                cnn.Close();
                MessageBox.Show("updated successfully", "Update!");
                Income.ActiveForm.Close();
            }
            catch(Exception e2)
            { MessageBox.Show("No entries found","Alert"); }
        }
    }
}
