using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace APP1911
{
    public partial class Form2 : Form
    {
        SerialPort COMSerial = new SerialPort();

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            bool setcom = false;

#region Carrega Ports

            foreach (string str in SerialPort.GetPortNames())
            {
                cmbPorta.Items.Add(str);
                if (str == "COM1") setcom = true;
            }
                if (setcom)
                    cmbPorta.SelectedText = "COM1";
                else
                    cmbPorta.SelectedIndex = 0;
                    cmbBauld.Text = "9600";
                    int i = 0;
            //--------------------------------------------------------------------------------//
#endregion

#region Carrega Paridade
             foreach (string str in Enum.GetNames(typeof(Parity)))
              {
                 cmbPar.Items.Add(str);
                  if (str == "None")
                  cmbPar.SelectedIndex = i;
                  i++;
              } //END FORECH
                  i=0;

           
#endregion

#region Carrega Stop Bits
            foreach (string str in Enum.GetNames(typeof(StopBits)))
            {
                cmbStop.Items.Add(str);
                if (str == "One")
                    cmbStop.SelectedIndex = i;
                i++;
            }
            cmbData.Text = "8";
            }
#endregion

        private void button1_Click(object sender, EventArgs e)
        {
            Global.Porta = cmbPorta.Text;
            Global.BRate = cmbBauld.Text;
            Global.SBits = cmbStop.Text;
            Global.DBits = cmbData.Text;
            Global.Paridade = cmbPar.Text;
            Global.Cancela = false;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //GARANTE O FECHAMENTO DA PORTA SERIAL
            if (COMSerial.IsOpen) COMSerial.Close();
            Global.Cancela = true;
            Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cmbData_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbPorta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        }
    }

