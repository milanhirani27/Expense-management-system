using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Expense_Management
{
    public partial class Homepage : Form
    {
        Form5 x; Form1 im4; Income im; Expense im1; Form7 im3;
        public Homepage(Form5 f)
        {
            InitializeComponent();
            this.x = f;
        }

        private void label1_Click(object sender, EventArgs e)
        {
  
            //MessageBox.Show("Hii There");
        }
        
        private void income_Click(object sender, EventArgs e)
        {
            if (im == null)
            {
                im = new Income(this);
                im.FormClosed += new FormClosedEventHandler(Im_FormClosed);
                im.Show();
                // income.Enabled = false;
            }
            else
            {
                im = null;
            }
            /*im1.Hide();
            im3.Hide();
            im4.Hide();*/
        }

        private void Im_FormClosed(object sender, FormClosedEventArgs e)
        {
           // im = null;
        }

        private void Im_Activated(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
       
        private void expense_Click(object sender, EventArgs e)
        {
            
            if (im1 == null)
            {
                im1 = new Expense(this);
                im1.FormClosed += new FormClosedEventHandler(Im1_FormClosed);
                im1.Show();
            }
            else
            {
                im1 = null;
                //this.Hide();
                //im = new Income(this);
                //im.FormClosed +=this.FormClosed();
                
            }
            /*im.Hide();
            im3.Hide();
            im4.Hide();*/
        }

        private void Im_FormClosed1(object sender, FormClosedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Im1_FormClosed(object sender, FormClosedEventArgs e)
        {
            im1 = null;
        }

        private void Homepage_Load(object sender, EventArgs e)
        {
            label1.Text =x.textBox1.Text;
            BackgroundImageLayout = ImageLayout.Stretch;
            Home.ForeColor = Color.LightBlue;
        }

        private void Home_Click(object sender, EventArgs e)
        {
            Home.ForeColor = Color.Blue;
            cntus.ForeColor = Color.LightBlue;
        }
       
        private void Report_Click(object sender, EventArgs e)
        {
            if (im3 == null)
            {
                im3 = new Form7(this);
                im3.FormClosed += new FormClosedEventHandler(Im3_FormClosed);
                im3.Show();
            }
            else
            {
                im3 = null;
            }
            /*im.Hide();
            im1.Hide();
            im4.Hide();*/
        }

        private void Im3_FormClosed(object sender, FormClosedEventArgs e)
        {
            im3 = null;
        }
        
        private void cntus_Click(object sender, EventArgs e)
        {
            cntus.ForeColor = Color.Blue;
            Home.ForeColor = Color.LightBlue;
            if (im4 == null)
            {
                im4 = new Form1();
                im4.FormClosed += new FormClosedEventHandler(Im4_FormClosed);
                im4.Show();
            }
            else
            {
                im4 = null;
            }
            /*im.Hide();
            im3.Hide();
            im1.Hide();*/

        }

        private void Im4_FormClosed(object sender, FormClosedEventArgs e)
        {
            im4 = null;
        }

        private void Homepage_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
