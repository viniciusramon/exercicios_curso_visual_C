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
     
        public delegate void Fdelegate(string a);


        List<string> TempList = new List<string>();

        string txt_rec = string.Empty;
        string txt_list = string.Empty;

        int qtde_date = 0;
        float eixo_x = 0;
        float eixo_y = 0;

        
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
            string[] txtSplit;
            txt_rec += a;
            int volts = 0;
            int temp = 0;

            if (txt_rec.Length >= 8)
            {
                if (txt_rec.Substring(0, 1) == "A")
                {
                    //label6.Text = txt_rec.Substring(4, 4);

                    aGauge1.Cap_Idx = 1;
                    aGauge1.CapText = txt_rec.Substring(4, 4);
                    txt_list = txt_rec.Substring(0, 8);
                    volts = Convert.ToInt32(txt_rec.Substring(4, 4));
                    aGauge1.Value = (volts * 3300) / 4096;
                    aGauge2.Value = (volts * 50) / 4096;
                    //label7.Text = aGauge2.Value.ToString() + " mV";

                    aGauge2.Cap_Idx = 1;
                    aGauge2.CapText = aGauge2.Value.ToString() + "mV";
                }
                txt_rec = string.Empty;
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            xyGraph1.AddGraph("XtraTitle", DashStyle.Solid, Color.White, 1, false);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (SerialCom.IsOpen)
            {
                timer1.Enabled = true;
                button4.Enabled = false;
                button5.Enabled = true;

                SerialCom.Write("1");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();


        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (SerialCom.IsOpen)
            {
                button4.Enabled = true;
                button5.Enabled = false;

                SerialCom.Write("2");
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

            if (eixo_x >= 120)
            {
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
        }

        private void configuraçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 nForm = new Form2();
            nForm.ShowDialog();

            if (!Global.Cancela)
            {
                try
                {
                    if (SerialCom.IsOpen) SerialCom.Close();

                    SerialCom.PortName = Global.Porta;
                    SerialCom.BaudRate = int.Parse(Global.BRate);
                    SerialCom.StopBits = (StopBits)Enum.Parse(typeof(StopBits), Global.SBits);
                    SerialCom.DataBits = int.Parse(Global.DBits);
                    SerialCom.Parity = (Parity)Enum.Parse(typeof(Parity), Global.Paridade);

                    button4.Enabled = true;

                    SerialCom.Open();

                } //END TRY    
                catch
                {
                    MessageBox.Show("Não foi possivel abrir a Porta Serial!");
                }

                 }
            }

        private void xyGraph1_Load(object sender, EventArgs e)
        {

        }

        private void arm1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void supervisoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Arm_1 nForm = new Arm_1();
            nForm.ShowDialog();
        }

        private void supervisoryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Arm_2   nForm = new Arm_2();
            nForm.ShowDialog();
        }

        private void supervisoryToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Arm_all nForm = new Arm_all();
            nForm.ShowDialog();
        }

        private void allArmsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        } // END PUBLIC FORM
    } // END APP1911
