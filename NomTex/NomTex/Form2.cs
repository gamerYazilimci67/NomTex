using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NomTex
{
    public partial class Form2 : Form
    {
        private Form1 anaForm;
        public Form2(Form1 form)
        {
            InitializeComponent();
            anaForm = form;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            anaForm.ara(textBox1.Text);
            this.Close();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                anaForm.ara(textBox1.Text);
                this.Close();
            }
        }
    }
}
