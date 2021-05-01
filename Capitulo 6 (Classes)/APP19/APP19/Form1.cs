using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace APP19
{
    public partial class Form1 : Form
    {

        SerialPort SerialCom = new SerialPort();
        string bfRecebe = string.Empty;

        public delegate void Fdelegate (string a);

        public Form1()
        {        
            InitializeComponent();
            SerialCom.DataReceived +=new SerialDataReceivedEventHandler(SerialCom_DataReceived);
        }

        void SerialCom_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
        bfRecebe = SerialCom.ReadExisting();
        
        this.BeginInvoke(new Fdelegate(recebe_serial), new object[] {bfRecebe}); 
        }
        
        public void recebe_serial(string a)
        {
        textBox2.Text += a;
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
            int i = 0;
            #region Carrega Portas
            foreach (string str in SerialPort.GetPortNames())
            {
                comboBox1.Items.Add(str);
                if (str == "COM1") comboBox1.SelectedIndex = i;
                i++;
            }
            
            #endregion
            
            comboBox2.SelectedText = "9600";

            #region Carrega Paridade
            
            i = 0;

            foreach (string str in Enum.GetNames(typeof(Parity)))
            {
                comboBox3.Items.Add(str);

                if (str == "None")
                    comboBox3.SelectedIndex = i;
                i++;
            }
            #endregion

            comboBox4.SelectedText = "8";

            #region Carrega Stop Bits
            i = 0;

            foreach (string str in Enum.GetNames(typeof(StopBits)))
            {
                comboBox5.Items.Add(str);

                if (str == "One") comboBox5.SelectedIndex = i;

                i++;
            }
            #endregion
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            // CHECA SE A PORTA DA FECHADA E SE PRESSIONADO BOTÃO ABRE IRA ABRIR           
            if (SerialCom.IsOpen == true) SerialCom.Close();
            // AJUSTE DAS PROPRIEDADES DA CLASSE SERIAL PORT
            SerialCom.PortName = comboBox1.Text;
            SerialCom.BaudRate = Int32.Parse(comboBox2.Text);
            SerialCom.Parity   = (Parity)comboBox3.SelectedIndex;
            SerialCom.DataBits = Int32.Parse(comboBox4.Text);
            SerialCom.StopBits = (StopBits)comboBox5.SelectedIndex;


            // NECESSARIO ESTAR DENTRO DE TRY PAARA ABRIR A PORTA SERIAL
            try
            {
                SerialCom.Open();
                button1.Enabled = false;
                button2.Enabled = true;
                button3.Enabled = false;
            }


                // SE HOUVE ERRO APARECERA A MENSAGEM A SEGUIR E FECHARA A PORTA SERIAL
            catch
            {
                MessageBox.Show("Não foi possivel abrir a porta selecionada");
                button2.Enabled = false;
                button1.Enabled = true;
                button3.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        // AO FECHARMOS A PORTA ELE LIBERA NOVAMENTE A FUNÇÃO ABRE PORTA
        {
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = true;
        }

      
        private void button4_Click(object sender, EventArgs e)
        {
            //VERIFICA SE A PORTA ESTA ABERTA, SE TIVER ENVIAR O VALOR DO TEXTBOX
            if (SerialCom.IsOpen)
            {
                SerialCom.Write(textBox1.Text);
            }

            if (SerialCom.IsOpen)
            {
                SerialCom.Write(textBox1.Text + "\r\\n");
                textBox1.Text = "";
            }
       
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }    
    } 
}
