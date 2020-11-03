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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form6 fm = new Form6();
            fm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Vijay\Documents\Abhi.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection cnn = new SqlConnection(con);
            cnn.Open();
            if (ifProductExist(cnn))
            {
                Homepage h = new Homepage(this);
                this.Hide();
                h.ShowDialog();
                //Application.Exit();

            }
            else 
            {
                MessageBox.Show("Wrong Credentials", "Alert");   
            }
            cnn.Close();
            
        }
        private bool ifProductExist(SqlConnection con)
        { 
            SqlDataAdapter sda=new SqlDataAdapter("select * from  Userdata where uname = '" + textBox1.Text + "' and pwd='"+textBox2.Text+"'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            { return true; }

            else
                return false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        int ab = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.Text = ab.ToString();
            ab++;
        }
    }
}
