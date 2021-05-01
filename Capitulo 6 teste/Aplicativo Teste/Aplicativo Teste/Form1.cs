using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace Aplicativo_Teste
{
    public partial class Form1 : Form
    {
        SerialPort SerialCom = new SerialPort();
        
        public Form1()
        {
            InitializeComponent();
        }
    }
        
        private void Form1_Load(object sender, EventArgs e)
        {
           
            foreach (string str in SerialPort.GetPortNames())
            
            comboBox1.Items.Add(str);
                
        }
    
















