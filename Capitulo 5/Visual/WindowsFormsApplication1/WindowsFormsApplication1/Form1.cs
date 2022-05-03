using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //Declaração das variaveis
                int Tcel, Tkel, TFah;

                //Lendo a variavel digitada no text box
                Tcel = int.Parse(textBox1.Text);

                //Executando o calculo das conversões
                Tkel = (Tcel + 273);
                TFah = (((Tcel * 9) / 5) + 32);

                label3.Text = Tkel.ToString();
                label5.Text = TFah.ToString();
            }

            catch (Exception)
            {
                MessageBox.Show("Esta não e uma entrada valida", "****ATENÇÃO ERRO****", MessageBoxButtons.OK, MessageBoxIcon.Error);

                textBox1.Text = "";
                textBox1.Focus();

            }
         }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
  }
}
