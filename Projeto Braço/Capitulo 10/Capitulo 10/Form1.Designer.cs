namespace APP1911
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button3 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.arquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salvarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comunicaçãoSerialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.aGauge1 = new AGauge.AGauge();
            this.aGauge2 = new AGauge.AGauge();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.xyGraph1 = new componentXtra.XYGraph();
            this.selectArmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arm1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arm2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arm3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arm4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supervisoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlArmsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supervisoryToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.allArmsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supervisoryToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(817, 441);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 21);
            this.button3.TabIndex = 3;
            this.button3.Text = "Close";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button5
            // 
            this.button5.Enabled = false;
            this.button5.Location = new System.Drawing.Point(817, 192);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 2;
            this.button5.Text = "Finish";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Enabled = false;
            this.button4.Location = new System.Drawing.Point(817, 163);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 1;
            this.button4.Text = "Start";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arquivoToolStripMenuItem,
            this.comunicaçãoSerialToolStripMenuItem,
            this.selectArmToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(920, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // arquivoToolStripMenuItem
            // 
            this.arquivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salvarToolStripMenuItem,
            this.sairToolStripMenuItem});
            this.arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
            this.arquivoToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.arquivoToolStripMenuItem.Text = "File";
            // 
            // salvarToolStripMenuItem
            // 
            this.salvarToolStripMenuItem.Name = "salvarToolStripMenuItem";
            this.salvarToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.salvarToolStripMenuItem.Text = "Save";
            this.salvarToolStripMenuItem.Click += new System.EventHandler(this.salvarToolStripMenuItem_Click);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.sairToolStripMenuItem.Text = "Close";
            // 
            // comunicaçãoSerialToolStripMenuItem
            // 
            this.comunicaçãoSerialToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configuraçãoToolStripMenuItem,
            this.controlArmsToolStripMenuItem});
            this.comunicaçãoSerialToolStripMenuItem.Name = "comunicaçãoSerialToolStripMenuItem";
            this.comunicaçãoSerialToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.comunicaçãoSerialToolStripMenuItem.Text = "Tolls";
            // 
            // configuraçãoToolStripMenuItem
            // 
            this.configuraçãoToolStripMenuItem.Name = "configuraçãoToolStripMenuItem";
            this.configuraçãoToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.configuraçãoToolStripMenuItem.Text = "Comunication ";
            this.configuraçãoToolStripMenuItem.Click += new System.EventHandler(this.configuraçãoToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "txt";
            this.saveFileDialog1.Filter = "txt files (*.txt|All files (*.*)*.*";
            this.saveFileDialog1.Title = "Salvar Arquivo";
            // 
            // aGauge1
            // 
            this.aGauge1.BaseArcColor = System.Drawing.Color.Gray;
            this.aGauge1.BaseArcRadius = 80;
            this.aGauge1.BaseArcStart = 180;
            this.aGauge1.BaseArcSweep = 180;
            this.aGauge1.BaseArcWidth = 2;
            this.aGauge1.Cap_Idx = ((byte)(1));
            this.aGauge1.CapColors = new System.Drawing.Color[] {
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black};
            this.aGauge1.CapPosition = new System.Drawing.Point(82, 60);
            this.aGauge1.CapsPosition = new System.Drawing.Point[] {
        new System.Drawing.Point(92, 45),
        new System.Drawing.Point(82, 60),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10)};
            this.aGauge1.CapsText = new string[] {
        "ADC",
        "0000 mV",
        "",
        "",
        ""};
            this.aGauge1.CapText = "0000 mV";
            this.aGauge1.Center = new System.Drawing.Point(100, 100);
            this.aGauge1.Location = new System.Drawing.Point(22, 39);
            this.aGauge1.MaxValue = 3300F;
            this.aGauge1.MinValue = 0F;
            this.aGauge1.Name = "aGauge1";
            this.aGauge1.NeedleColor1 = AGauge.AGauge.NeedleColorEnum.Gray;
            this.aGauge1.NeedleColor2 = System.Drawing.Color.DimGray;
            this.aGauge1.NeedleRadius = 80;
            this.aGauge1.NeedleType = 0;
            this.aGauge1.NeedleWidth = 2;
            this.aGauge1.Range_Idx = ((byte)(1));
            this.aGauge1.RangeColor = System.Drawing.Color.Red;
            this.aGauge1.RangeEnabled = true;
            this.aGauge1.RangeEndValue = 3300F;
            this.aGauge1.RangeInnerRadius = 70;
            this.aGauge1.RangeOuterRadius = 80;
            this.aGauge1.RangesColor = new System.Drawing.Color[] {
        System.Drawing.Color.LightGreen,
        System.Drawing.Color.Red,
        System.Drawing.SystemColors.Control,
        System.Drawing.SystemColors.Control,
        System.Drawing.SystemColors.Control};
            this.aGauge1.RangesEnabled = new bool[] {
        true,
        true,
        false,
        false,
        false};
            this.aGauge1.RangesEndValue = new float[] {
        2500F,
        3300F,
        0F,
        0F,
        0F};
            this.aGauge1.RangesInnerRadius = new int[] {
        70,
        70,
        70,
        70,
        70};
            this.aGauge1.RangesOuterRadius = new int[] {
        80,
        80,
        80,
        80,
        80};
            this.aGauge1.RangesStartValue = new float[] {
        0F,
        2500F,
        0F,
        0F,
        0F};
            this.aGauge1.RangeStartValue = 2500F;
            this.aGauge1.ScaleLinesInterColor = System.Drawing.Color.Black;
            this.aGauge1.ScaleLinesInterInnerRadius = 73;
            this.aGauge1.ScaleLinesInterOuterRadius = 80;
            this.aGauge1.ScaleLinesInterWidth = 1;
            this.aGauge1.ScaleLinesMajorColor = System.Drawing.Color.Black;
            this.aGauge1.ScaleLinesMajorInnerRadius = 70;
            this.aGauge1.ScaleLinesMajorOuterRadius = 80;
            this.aGauge1.ScaleLinesMajorStepValue = 300F;
            this.aGauge1.ScaleLinesMajorWidth = 2;
            this.aGauge1.ScaleLinesMinorColor = System.Drawing.Color.Gray;
            this.aGauge1.ScaleLinesMinorInnerRadius = 75;
            this.aGauge1.ScaleLinesMinorNumOf = 9;
            this.aGauge1.ScaleLinesMinorOuterRadius = 80;
            this.aGauge1.ScaleLinesMinorWidth = 1;
            this.aGauge1.ScaleNumbersColor = System.Drawing.Color.Black;
            this.aGauge1.ScaleNumbersFormat = null;
            this.aGauge1.ScaleNumbersRadius = 95;
            this.aGauge1.ScaleNumbersRotation = 0;
            this.aGauge1.ScaleNumbersStartScaleLine = 0;
            this.aGauge1.ScaleNumbersStepScaleLines = 1;
            this.aGauge1.Size = new System.Drawing.Size(216, 118);
            this.aGauge1.TabIndex = 7;
            this.aGauge1.Text = "aGauge1";
            this.aGauge1.Value = 0F;
            // 
            // aGauge2
            // 
            this.aGauge2.BaseArcColor = System.Drawing.Color.Gray;
            this.aGauge2.BaseArcRadius = 80;
            this.aGauge2.BaseArcStart = 180;
            this.aGauge2.BaseArcSweep = 180;
            this.aGauge2.BaseArcWidth = 1;
            this.aGauge2.Cap_Idx = ((byte)(1));
            this.aGauge2.CapColors = new System.Drawing.Color[] {
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black,
        System.Drawing.Color.Black};
            this.aGauge2.CapPosition = new System.Drawing.Point(87, 60);
            this.aGauge2.CapsPosition = new System.Drawing.Point[] {
        new System.Drawing.Point(85, 45),
        new System.Drawing.Point(87, 60),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10),
        new System.Drawing.Point(10, 10)};
            this.aGauge2.CapsText = new string[] {
        "Temp",
        "00 ºC",
        "",
        "",
        ""};
            this.aGauge2.CapText = "00 ºC";
            this.aGauge2.Center = new System.Drawing.Point(100, 100);
            this.aGauge2.Location = new System.Drawing.Point(521, 39);
            this.aGauge2.MaxValue = 50F;
            this.aGauge2.MinValue = 0F;
            this.aGauge2.Name = "aGauge2";
            this.aGauge2.NeedleColor1 = AGauge.AGauge.NeedleColorEnum.Gray;
            this.aGauge2.NeedleColor2 = System.Drawing.Color.DimGray;
            this.aGauge2.NeedleRadius = 80;
            this.aGauge2.NeedleType = 0;
            this.aGauge2.NeedleWidth = 2;
            this.aGauge2.Range_Idx = ((byte)(1));
            this.aGauge2.RangeColor = System.Drawing.Color.Red;
            this.aGauge2.RangeEnabled = true;
            this.aGauge2.RangeEndValue = 50F;
            this.aGauge2.RangeInnerRadius = 70;
            this.aGauge2.RangeOuterRadius = 80;
            this.aGauge2.RangesColor = new System.Drawing.Color[] {
        System.Drawing.Color.LightGreen,
        System.Drawing.Color.Red,
        System.Drawing.SystemColors.Control,
        System.Drawing.SystemColors.Control,
        System.Drawing.SystemColors.Control};
            this.aGauge2.RangesEnabled = new bool[] {
        true,
        true,
        false,
        false,
        false};
            this.aGauge2.RangesEndValue = new float[] {
        40F,
        50F,
        0F,
        0F,
        0F};
            this.aGauge2.RangesInnerRadius = new int[] {
        70,
        70,
        70,
        70,
        70};
            this.aGauge2.RangesOuterRadius = new int[] {
        80,
        80,
        80,
        80,
        80};
            this.aGauge2.RangesStartValue = new float[] {
        0F,
        40F,
        0F,
        0F,
        0F};
            this.aGauge2.RangeStartValue = 40F;
            this.aGauge2.ScaleLinesInterColor = System.Drawing.Color.Black;
            this.aGauge2.ScaleLinesInterInnerRadius = 73;
            this.aGauge2.ScaleLinesInterOuterRadius = 80;
            this.aGauge2.ScaleLinesInterWidth = 1;
            this.aGauge2.ScaleLinesMajorColor = System.Drawing.Color.Black;
            this.aGauge2.ScaleLinesMajorInnerRadius = 70;
            this.aGauge2.ScaleLinesMajorOuterRadius = 80;
            this.aGauge2.ScaleLinesMajorStepValue = 5F;
            this.aGauge2.ScaleLinesMajorWidth = 2;
            this.aGauge2.ScaleLinesMinorColor = System.Drawing.Color.Gray;
            this.aGauge2.ScaleLinesMinorInnerRadius = 75;
            this.aGauge2.ScaleLinesMinorNumOf = 9;
            this.aGauge2.ScaleLinesMinorOuterRadius = 80;
            this.aGauge2.ScaleLinesMinorWidth = 1;
            this.aGauge2.ScaleNumbersColor = System.Drawing.Color.Black;
            this.aGauge2.ScaleNumbersFormat = null;
            this.aGauge2.ScaleNumbersRadius = 95;
            this.aGauge2.ScaleNumbersRotation = 0;
            this.aGauge2.ScaleNumbersStartScaleLine = 0;
            this.aGauge2.ScaleNumbersStepScaleLines = 1;
            this.aGauge2.Size = new System.Drawing.Size(275, 118);
            this.aGauge2.TabIndex = 8;
            this.aGauge2.Text = "aGauge2";
            this.aGauge2.Value = 0F;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "txt";
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "txt files (*.txt*)|*.txt|All files (*.*)|*.*";
            this.openFileDialog1.Title = "Abrir Arquivo";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // xyGraph1
            // 
            this.xyGraph1.AutoScroll = true;
            this.xyGraph1.BackColor = System.Drawing.Color.MidnightBlue;
            this.xyGraph1.ForeColor = System.Drawing.SystemColors.Window;
            this.xyGraph1.Location = new System.Drawing.Point(22, 163);
            this.xyGraph1.Name = "xyGraph1";
            this.xyGraph1.Size = new System.Drawing.Size(774, 299);
            this.xyGraph1.TabIndex = 9;
            this.xyGraph1.XtraAutoScale = false;
            this.xyGraph1.XtraClassicLabels = true;
            this.xyGraph1.XtraLabelX = "Tempo(s)";
            this.xyGraph1.XtraLabelY = "Temperatura ºC";
            this.xyGraph1.XtraLogX = false;
            this.xyGraph1.XtraLogY = false;
            this.xyGraph1.XtraMinLeftMargin = 0;
            this.xyGraph1.XtraSelectPoint = false;
            this.xyGraph1.XtraShowGrid = false;
            this.xyGraph1.XtraShowLegend = false;
            this.xyGraph1.XtraTitle = "Temperatura / Tempo";
            this.xyGraph1.XtraUpdateCursor = true;
            this.xyGraph1.XtraXdigits = 0;
            this.xyGraph1.XtraXmax = 120F;
            this.xyGraph1.XtraXmin = 0F;
            this.xyGraph1.XtraXstep = 0F;
            this.xyGraph1.XtraYdigits = 0;
            this.xyGraph1.XtraYmax = 60F;
            this.xyGraph1.XtraYmin = 0F;
            this.xyGraph1.XtraYstep = 0F;
            this.xyGraph1.Load += new System.EventHandler(this.xyGraph1_Load);
            // 
            // selectArmToolStripMenuItem
            // 
            this.selectArmToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arm1ToolStripMenuItem,
            this.arm2ToolStripMenuItem,
            this.arm3ToolStripMenuItem,
            this.arm4ToolStripMenuItem,
            this.allArmsToolStripMenuItem});
            this.selectArmToolStripMenuItem.Name = "selectArmToolStripMenuItem";
            this.selectArmToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.selectArmToolStripMenuItem.Text = "Select Arm";
            // 
            // arm1ToolStripMenuItem
            // 
            this.arm1ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.supervisoryToolStripMenuItem});
            this.arm1ToolStripMenuItem.Name = "arm1ToolStripMenuItem";
            this.arm1ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.arm1ToolStripMenuItem.Text = "Arm 1";
            this.arm1ToolStripMenuItem.Click += new System.EventHandler(this.arm1ToolStripMenuItem_Click);
            // 
            // arm2ToolStripMenuItem
            // 
            this.arm2ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.supervisoryToolStripMenuItem1});
            this.arm2ToolStripMenuItem.Name = "arm2ToolStripMenuItem";
            this.arm2ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.arm2ToolStripMenuItem.Text = "Arm 2";
            // 
            // arm3ToolStripMenuItem
            // 
            this.arm3ToolStripMenuItem.Name = "arm3ToolStripMenuItem";
            this.arm3ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.arm3ToolStripMenuItem.Text = "Arm 3";
            // 
            // arm4ToolStripMenuItem
            // 
            this.arm4ToolStripMenuItem.Name = "arm4ToolStripMenuItem";
            this.arm4ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.arm4ToolStripMenuItem.Text = "Arm 4";
            // 
            // supervisoryToolStripMenuItem
            // 
            this.supervisoryToolStripMenuItem.Name = "supervisoryToolStripMenuItem";
            this.supervisoryToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.supervisoryToolStripMenuItem.Text = "Supervisory";
            this.supervisoryToolStripMenuItem.Click += new System.EventHandler(this.supervisoryToolStripMenuItem_Click);
            // 
            // controlArmsToolStripMenuItem
            // 
            this.controlArmsToolStripMenuItem.Name = "controlArmsToolStripMenuItem";
            this.controlArmsToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.controlArmsToolStripMenuItem.Text = "Control Arm\'s";
            // 
            // supervisoryToolStripMenuItem1
            // 
            this.supervisoryToolStripMenuItem1.Name = "supervisoryToolStripMenuItem1";
            this.supervisoryToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.supervisoryToolStripMenuItem1.Text = "Supervisory";
            this.supervisoryToolStripMenuItem1.Click += new System.EventHandler(this.supervisoryToolStripMenuItem1_Click);
            // 
            // allArmsToolStripMenuItem
            // 
            this.allArmsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.supervisoryToolStripMenuItem2});
            this.allArmsToolStripMenuItem.Name = "allArmsToolStripMenuItem";
            this.allArmsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.allArmsToolStripMenuItem.Text = "All Arm\'s";
            this.allArmsToolStripMenuItem.Click += new System.EventHandler(this.allArmsToolStripMenuItem_Click);
            // 
            // supervisoryToolStripMenuItem2
            // 
            this.supervisoryToolStripMenuItem2.Name = "supervisoryToolStripMenuItem2";
            this.supervisoryToolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.supervisoryToolStripMenuItem2.Text = "Supervisory";
            this.supervisoryToolStripMenuItem2.Click += new System.EventHandler(this.supervisoryToolStripMenuItem2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 484);
            this.Controls.Add(this.xyGraph1);
            this.Controls.Add(this.aGauge2);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.aGauge1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Leitura analogica pela serial";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem arquivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salvarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private AGauge.AGauge aGauge1;
        private AGauge.AGauge aGauge2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem comunicaçãoSerialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuraçãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectArmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arm1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arm2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arm3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arm4ToolStripMenuItem;
        private componentXtra.XYGraph xyGraph1;
        private System.Windows.Forms.ToolStripMenuItem controlArmsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supervisoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supervisoryToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem allArmsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supervisoryToolStripMenuItem2;
    }
}

