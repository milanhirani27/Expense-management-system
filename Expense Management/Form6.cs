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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            foreach (Control x in Controls)
            {
                if (x is TextBox)
                {
                    x.Text = "";
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("Please Enter Valid credentials", "Alert");
            }
            else if (textBox2.Text.Length != 10)
            {
                MessageBox.Show("Enter a valid 10 digit mobile number", "Alert");
            }
            else if (textBox4.Text != textBox5.Text)
            {
                MessageBox.Show("Password and re-enter password do not match", "Alert");
            }
            else
            {

                string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Vijay\Documents\Abhi.mdf;Integrated Security=True;Connect Timeout=30";
                SqlConnection cnn = new SqlConnection(con);
                cnn.Open();
                string uname1 = textBox1.Text;
                float mobile =Convert.ToInt64(textBox2.Text);
                string mail = textBox3.Text;
                string pass = textBox4.Text;
                string city = comboBox1.Text;
                string idate=("");
                float income = 0;
                //SqlCommand cmd = new SqlCommand(x, cnn);
                //cmd.ExecuteNonQuery();
                SqlDataAdapter sda = new SqlDataAdapter("select * from Userdata where uname = '" + uname1 + "'", con);
                DataTable dt1 = new DataTable();
                sda.Fill(dt1);
                if (dt1.Rows.Count > 0)
                {
                    MessageBox.Show("Username already exists!!");
                }
                else
                {
                    String q = "insert into Userdata values('" + uname1 + "','" + mail + "','" + mobile + "','" + pass + "','" + city + "','" + income + "','" + idate + "')";
                    SqlCommand cmd = new SqlCommand(q, cnn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Submitted Successfully", "Alert");
                    Homepage.ActiveForm.Close();
                }
                cnn.Close();
                
            }

        }

        private void Form6_Load(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
