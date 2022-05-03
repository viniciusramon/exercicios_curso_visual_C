using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace APP1911
{
    public partial class Arm_all : Form
    {
        public Arm_all()
        {
            InitializeComponent();
        }

        private void Arm_all_Load(object sender, EventArgs e)
        {
            Arm_1 nForm = new Arm_1();
            nForm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
