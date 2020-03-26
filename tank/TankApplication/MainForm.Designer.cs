namespace BrilliantApplication
{
    partial class MainForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.waterLimitStateChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.valveCoefficientLabel = new System.Windows.Forms.Label();
            this.waterLevelLabel = new System.Windows.Forms.Label();
            this.reduceInputStreamButton = new System.Windows.Forms.Button();
            this.increaseInputStreamButton = new System.Windows.Forms.Button();
            this.preasureLabel = new System.Windows.Forms.Label();
            this.helpInputStreamLabel = new System.Windows.Forms.Label();
            this.helpWaterLavelLabel = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            this.x10Button = new System.Windows.Forms.Button();
            this.x1Button = new System.Windows.Forms.Button();
            this.objectPictureBox = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.helpValveLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.waterLimitStateChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // waterLimitStateChart
            // 
            chartArea1.Name = "ChartArea1";
            this.waterLimitStateChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.waterLimitStateChart.Legends.Add(legend1);
            this.waterLimitStateChart.Location = new System.Drawing.Point(674, 14);
            this.waterLimitStateChart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.waterLimitStateChart.Name = "waterLimitStateChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.Name = "Water level";
            this.waterLimitStateChart.Series.Add(series1);
            this.waterLimitStateChart.Size = new System.Drawing.Size(611, 310);
            this.waterLimitStateChart.TabIndex = 1;
            this.waterLimitStateChart.Text = "chart1";
            // 
            // valveCoefficientLabel
            // 
            this.valveCoefficientLabel.AutoSize = true;
            this.valveCoefficientLabel.Location = new System.Drawing.Point(533, 60);
            this.valveCoefficientLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.valveCoefficientLabel.Name = "valveCoefficientLabel";
            this.valveCoefficientLabel.Size = new System.Drawing.Size(18, 20);
            this.valveCoefficientLabel.TabIndex = 4;
            this.valveCoefficientLabel.Text = "0";
            // 
            // waterLevelLabel
            // 
            this.waterLevelLabel.AutoSize = true;
            this.waterLevelLabel.Location = new System.Drawing.Point(336, 156);
            this.waterLevelLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.waterLevelLabel.Name = "waterLevelLabel";
            this.waterLevelLabel.Size = new System.Drawing.Size(18, 20);
            this.waterLevelLabel.TabIndex = 6;
            this.waterLevelLabel.Text = "0";
            // 
            // reduceInputStreamButton
            // 
            this.reduceInputStreamButton.Location = new System.Drawing.Point(48, 181);
            this.reduceInputStreamButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.reduceInputStreamButton.Name = "reduceInputStreamButton";
            this.reduceInputStreamButton.Size = new System.Drawing.Size(46, 35);
            this.reduceInputStreamButton.TabIndex = 8;
            this.reduceInputStreamButton.Text = "<";
            this.reduceInputStreamButton.UseVisualStyleBackColor = true;
            this.reduceInputStreamButton.Click += new System.EventHandler(this.reducePreasureButton_Click);
            // 
            // increaseInputStreamButton
            // 
            this.increaseInputStreamButton.Location = new System.Drawing.Point(148, 181);
            this.increaseInputStreamButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.increaseInputStreamButton.Name = "increaseInputStreamButton";
            this.increaseInputStreamButton.Size = new System.Drawing.Size(46, 35);
            this.increaseInputStreamButton.TabIndex = 9;
            this.increaseInputStreamButton.Text = ">";
            this.increaseInputStreamButton.UseVisualStyleBackColor = true;
            this.increaseInputStreamButton.Click += new System.EventHandler(this.increasePreasureButton_Click);
            // 
            // preasureLabel
            // 
            this.preasureLabel.AutoSize = true;
            this.preasureLabel.Location = new System.Drawing.Point(115, 188);
            this.preasureLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.preasureLabel.Name = "preasureLabel";
            this.preasureLabel.Size = new System.Drawing.Size(18, 20);
            this.preasureLabel.TabIndex = 10;
            this.preasureLabel.Text = "0";
            // 
            // helpInputStreamLabel
            // 
            this.helpInputStreamLabel.AutoSize = true;
            this.helpInputStreamLabel.Location = new System.Drawing.Point(97, 156);
            this.helpInputStreamLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.helpInputStreamLabel.Name = "helpInputStreamLabel";
            this.helpInputStreamLabel.Size = new System.Drawing.Size(36, 20);
            this.helpInputStreamLabel.TabIndex = 11;
            this.helpInputStreamLabel.Text = "Xin:";
            // 
            // helpWaterLavelLabel
            // 
            this.helpWaterLavelLabel.AutoSize = true;
            this.helpWaterLavelLabel.Location = new System.Drawing.Point(303, 118);
            this.helpWaterLavelLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.helpWaterLavelLabel.Name = "helpWaterLavelLabel";
            this.helpWaterLavelLabel.Size = new System.Drawing.Size(91, 20);
            this.helpWaterLavelLabel.TabIndex = 12;
            this.helpWaterLavelLabel.Text = "Water level:";
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(148, 291);
            this.startButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(112, 35);
            this.startButton.TabIndex = 16;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(282, 291);
            this.stopButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(112, 35);
            this.stopButton.TabIndex = 17;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(416, 291);
            this.refreshButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(112, 35);
            this.refreshButton.TabIndex = 18;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // x10Button
            // 
            this.x10Button.Location = new System.Drawing.Point(21, 353);
            this.x10Button.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.x10Button.Name = "x10Button";
            this.x10Button.Size = new System.Drawing.Size(112, 35);
            this.x10Button.TabIndex = 19;
            this.x10Button.Text = "+ x10";
            this.x10Button.UseVisualStyleBackColor = true;
            this.x10Button.Click += new System.EventHandler(this.x10Button_Click);
            // 
            // x1Button
            // 
            this.x1Button.Location = new System.Drawing.Point(148, 353);
            this.x1Button.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.x1Button.Name = "x1Button";
            this.x1Button.Size = new System.Drawing.Size(112, 35);
            this.x1Button.TabIndex = 21;
            this.x1Button.Text = "x1";
            this.x1Button.UseVisualStyleBackColor = true;
            this.x1Button.Click += new System.EventHandler(this.x1Button_Click);
            // 
            // objectPictureBox
            // 
            this.objectPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("objectPictureBox.Image")));
            this.objectPictureBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("objectPictureBox.InitialImage")));
            this.objectPictureBox.Location = new System.Drawing.Point(21, 16);
            this.objectPictureBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.objectPictureBox.Name = "objectPictureBox";
            this.objectPictureBox.Size = new System.Drawing.Size(610, 265);
            this.objectPictureBox.TabIndex = 0;
            this.objectPictureBox.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(473, 181);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(46, 35);
            this.button1.TabIndex = 22;
            this.button1.Text = "<";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(574, 181);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(46, 35);
            this.button2.TabIndex = 23;
            this.button2.Text = ">";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(533, 156);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 20);
            this.label1.TabIndex = 24;
            this.label1.Text = "Xout:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(536, 188);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 20);
            this.label2.TabIndex = 25;
            this.label2.Text = "0";
            // 
            // helpValveLabel
            // 
            this.helpValveLabel.AutoSize = true;
            this.helpValveLabel.Location = new System.Drawing.Point(516, 26);
            this.helpValveLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.helpValveLabel.Name = "helpValveLabel";
            this.helpValveLabel.Size = new System.Drawing.Size(49, 20);
            this.helpValveLabel.TabIndex = 7;
            this.helpValveLabel.Text = "Noise";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1269, 401);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.x1Button);
            this.Controls.Add(this.x10Button);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.helpWaterLavelLabel);
            this.Controls.Add(this.helpInputStreamLabel);
            this.Controls.Add(this.preasureLabel);
            this.Controls.Add(this.increaseInputStreamButton);
            this.Controls.Add(this.reduceInputStreamButton);
            this.Controls.Add(this.helpValveLabel);
            this.Controls.Add(this.waterLevelLabel);
            this.Controls.Add(this.valveCoefficientLabel);
            this.Controls.Add(this.waterLimitStateChart);
            this.Controls.Add(this.objectPictureBox);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.waterLimitStateChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox objectPictureBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataVisualization.Charting.Chart waterLimitStateChart;
        private System.Windows.Forms.Label valveCoefficientLabel;
        private System.Windows.Forms.Label waterLevelLabel;
        private System.Windows.Forms.Button reduceInputStreamButton;
        private System.Windows.Forms.Button increaseInputStreamButton;
        private System.Windows.Forms.Label preasureLabel;
        private System.Windows.Forms.Label helpInputStreamLabel;
        private System.Windows.Forms.Label helpWaterLavelLabel;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Button x10Button;
        private System.Windows.Forms.Button x1Button;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label helpValveLabel;
    }
}

