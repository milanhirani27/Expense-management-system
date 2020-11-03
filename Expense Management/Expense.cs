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
    public partial class Expense : Form
    {
        Homepage x;
        public Expense(Homepage f)
        {
            InitializeComponent();
            this.x = f;
        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Rent");
            comboBox1.Items.Add("Utilities");
            comboBox1.Items.Add("Debt Payment");
        }
       
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Entertainment");
            comboBox1.Items.Add("Clothing");
            comboBox1.Items.Add("Groceries");
            comboBox1.Items.Add("Food");
        }

        private void add_Click(object sender, EventArgs e)
        {
            string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Vijay\Documents\Abhi.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection cnn = new SqlConnection(con);
            cnn.Open();
            string uname1 = x.label1.Text;

            string edate = Convert.ToString(dateTimePicker1.Text);                  
            float exp = Convert.ToInt64(textBox1.Text);
            
            string que="select id from Userdata where uname='"+uname1+"'";
            SqlDataAdapter sda = new SqlDataAdapter(que, con);
            DataTable dt1 = new DataTable();
            sda.Fill(dt1);
            int a = Convert.ToInt32(dt1.Rows[0][0]);
            String q = "insert into edata values('" + a + "','" + exp + "','" + edate + "')";
            SqlCommand cmd = new SqlCommand(q, cnn);
            cmd.ExecuteNonQuery();
            cnn.Close();
            MessageBox.Show("Submitted Succesfully","Alert");
            Expense.ActiveForm.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Vijay\Documents\Abhi.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection cnn = new SqlConnection(con);
            cnn.Open();
            string uname1 = x.label1.Text;
            //dateTimePicker1.Format("dd-mm-yyyy");
            string edate = Convert.ToString(dateTimePicker1.Text);
            float exp = Convert.ToInt64(textBox1.Text);

            string que = "select id from Userdata where uname='" + uname1 + "'";
            SqlDataAdapter sda = new SqlDataAdapter(que, con);
            DataTable dt1 = new DataTable();
            sda.Fill(dt1);
            int a = Convert.ToInt32(dt1.Rows[0][0]);
            float q1 = Convert.ToInt64(textBox1.Text);
            String q = "update  edata set exp='"+q1+"' where id='"+a+"' and edate='"+edate+"'";
            SqlCommand cmd = new SqlCommand(q, cnn);
            cmd.ExecuteNonQuery();
            cnn.Close();
            MessageBox.Show("Submitted Succesfully", "Alert");
            Expense.ActiveForm.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Vijay\Documents\Abhi.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection cnn = new SqlConnection(con);
            cnn.Open();
            string uname1 = x.label1.Text;

            string edate = Convert.ToString(dateTimePicker1.Text);
            //float exp = Convert.ToInt64(textBox1.Text);

            string que = "select id from Userdata where uname='" + uname1 + "'";
            SqlDataAdapter sda = new SqlDataAdapter(que, con);
            DataTable dt1 = new DataTable();
            sda.Fill(dt1);
            int a = Convert.ToInt32(dt1.Rows[0][0]);
            //float q1 = Convert.ToInt64(textBox1.Text);
            String q = "update  edata set exp='" + 0 + "' where id='" + a + "' and edate='" + edate + "'";
            SqlCommand cmd = new SqlCommand(q, cnn);
            cmd.ExecuteNonQuery();
            cnn.Close();
            MessageBox.Show("Submitted Succesfully", "Alert");
            Expense.ActiveForm.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Vijay\Documents\Abhi.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection cnn = new SqlConnection(con);
            cnn.Open();
            string uname1 = x.label1.Text;

            string edate = Convert.ToString(dateTimePicker1.Text);
            //float exp = Convert.ToInt64(textBox1.Text);

            string que = "select id from Userdata where uname='" + uname1 + "'";
            SqlDataAdapter sda = new SqlDataAdapter(que, con);
            DataTable dt1 = new DataTable();
            sda.Fill(dt1);
            int a = Convert.ToInt32(dt1.Rows[0][0]);
            //float q1 = Convert.ToInt64(textBox1.Text);
            String q = "update  edata set exp='" + 0 + "' where id='" + a + "'";
            SqlCommand cmd = new SqlCommand(q, cnn);
            cmd.ExecuteNonQuery();
            cnn.Close();
            MessageBox.Show("Submitted Succesfully", "Alert");
            Expense.ActiveForm.Close();
        }
    }
}
