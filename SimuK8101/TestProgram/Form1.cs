using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Velleman.Kits;

namespace TestProgram
{
    public partial class Form1 : Form
    {
        K8101 display;

        public K8101 Display
        {
            get { return display; }
            set { display = value; }
        }

        public Form1()
        {
            InitializeComponent();
            Display = new K8101();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Display.Connect();
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
