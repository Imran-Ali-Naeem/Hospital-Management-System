using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HMS
{
    public partial class Confirm_smtp : Form
    {
        public Confirm_smtp()
        {
            InitializeComponent();
        }
        private String random;

        public Confirm_smtp(String RandomCode)
        {
            InitializeComponent();
            random = RandomCode;
        }



        private void btnSearch_Click(object sender, EventArgs e)
        {

            if (random == (PasswordtextBox.Text).ToString())
            {
                //to = PasswordtextBox.Text;
                //Form2 f = new Form2();
                //f.Show();
            }
            else
            {
                MessageBox.Show("Wrong Code");
            }
        }

        private void Confirm_smtp_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
