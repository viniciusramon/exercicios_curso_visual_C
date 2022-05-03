using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Drawing.Drawing2D;

namespace APP1911
{
    public partial class Form1 : Form
    {
        SerialPort SerialCom = new SerialPort();
        string bfRecebe = string.Empty;
        string txt_rec = string.Empty;

        List<string> TempList = new List<string>();
        string txt_list = string.Empty;

        int qtde_date = 0;
        float eixo_x = 0;
        float eixo_y = 0;

        public delegate void Fdelegate(string a);

        public Form1()
        {
            InitializeComponent();
            SerialCom.DataReceived += new SerialDataReceivedEventHandler(SerialCom_DataReceived);
        }

        void SerialCom_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            bfRecebe = SerialCom.ReadExisting();
            this.BeginInvoke(new Fdelegate(recebe_serial), new object[] { bfRecebe });
        }

        public void recebe_serial(string a)
        {

            txt_rec += a;
            int volts = 0;

            if (txt_rec.Length >= 8)
            {
                if(txt_rec.Substring(0, 1) == "A")
                {
                    //label6.Text = txt_rec.Substring(4, 4);

                    aGauge1.Cap_Idx = 1;
                    aGauge1.CapText = txt_rec.Substring(4, 4);
                    txt_list = txt_rec.Substring(0, 8);
                    volts = Convert.ToInt32(txt_rec.Substring(4, 4));
                    aGauge1.Value = volts;
                    aGauge2.Value = (volts * 3300) / 4096;
                    //label7.Text = aGauge2.Value.ToString() + " mV";

                    aGauge2.Cap_Idx = 1;
                    aGauge2.CapText = aGauge2.Value.ToString() + "mV";
                }
                txt_rec = string.Empty;
            }
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

            xyGraph1.AddGraph("XtraTitle", DashStyle.Solid, Color.White, 1, false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // CHECA SE A PORTA DA FECHADA E SE PRESSIONADO BOTÃO ABRE IRA ABRIR           
            if (SerialCom.IsOpen == true) SerialCom.Close();
            // AJUSTE DAS PROPRIEDADES DA CLASSE SERIAL PORT
            SerialCom.PortName = comboBox1.Text;
            SerialCom.BaudRate = Int32.Parse(comboBox2.Text);
            SerialCom.Parity = (Parity)comboBox3.SelectedIndex;
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

        private void button4_Click(object sender, EventArgs e)
        {
            if (SerialCom.IsOpen)
            {
                SerialCom.Write("SET00001");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (SerialCom.IsOpen)
            {
                SerialCom.Write("SET00000");
            }


        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TempList.Add(DateTime.Now + "-" + txt_list);
            qtde_date++;

            eixo_y = aGauge2.Value;
            eixo_x++;

            if (eixo_x >= 120) {
                timer1.Enabled = false;
            }
            xyGraph1.AddValue(0, eixo_x, eixo_y);
            xyGraph1.DrawAll();
        }

        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextWriter Arq;

            try
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {

                    Arq = File.AppendText(saveFileDialog1.FileName);

                    for (int i = 0; i < qtde_date; i++)

                        Arq.WriteLine(TempList[i]);

                    Arq.Close();

                } //  END IF

                MessageBox.Show("Cadastro realizado com suacesso!");

            } // END TRY

            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
            }

        }

        private void aGauge1_ValueInRangeChanged(object sender, AGauge.AGauge.ValueInRangeChangedEventArgs e)
        {

        }

        private void aGauge1_ValueInRangeChanged_1(object sender, AGauge.AGauge.ValueInRangeChangedEventArgs e)
        {

        } //END PRIVATE

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            StreamReader Arq;
            string recebe = String.Empty;

            eixo_x = 0;

            xyGraph1.ClearGraph(0);
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    Arq = new StreamReader(openFileDialog1.FileName);
                    while (!(Arq.EndOfStream))
                    {
                        recebe = Arq.ReadLine().Substring(26, 4);
                        eixo_y = (float.Parse(recebe) * 3300) / 4095;
                        xyGraph1.AddValue(0, eixo_x, eixo_y);
                        xyGraph1.DrawAll();
                        eixo_x++;
                    } //END IF
                } //END WHILE
            } //END TRT
            catch (Exception erro)
            {
                MessageBox.Show(erro.ToString());
            } //END CATCH
        } //END FUNTION
    
    } // END PUBLIC FORM
} // END APP1911
