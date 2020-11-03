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
    
    public partial class report : Form
    {
        Form7 z;
        public report(Form7 b)
        {
            InitializeComponent();
            this.z = b;
        }

        private void report_Load(object sender, EventArgs e)
        {
            z.label4.ForeColor = Color.Snow;
            z.label5.ForeColor = Color.Snow;
            z.label6.ForeColor = Color.Snow;
            label4.Text = z.label4.Text;
            label5.Text = z.label5.Text;
            label6.Text = z.label6.Text;
        }
    }
}
