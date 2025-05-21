using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestWinForms.Controls
{
    public partial class test : Button
    {
        public test()
        {
            InitializeComponent();
            //BackColor = Color.Green;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
