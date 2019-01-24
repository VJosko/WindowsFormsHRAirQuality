namespace PresentationLayer
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.comboBoxStations = new System.Windows.Forms.ComboBox();
            this.comboBoxPollutant = new System.Windows.Forms.ComboBox();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.dataGridViewReadings = new System.Windows.Forms.DataGridView();
            this.search = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.labelFrom = new System.Windows.Forms.Label();
            this.labelTO = new System.Windows.Forms.Label();
            this.btnDodaj = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReadings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxStations
            // 
            this.comboBoxStations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStations.FormattingEnabled = true;
            this.comboBoxStations.Location = new System.Drawing.Point(45, 73);
            this.comboBoxStations.Name = "comboBoxStations";
            this.comboBoxStations.Size = new System.Drawing.Size(256, 24);
            this.comboBoxStations.TabIndex = 0;
            this.comboBoxStations.SelectedIndexChanged += new System.EventHandler(this.comboBoxStations_SelectedIndexChanged);
            // 
            // comboBoxPollutant
            // 
            this.comboBoxPollutant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPollutant.FormattingEnabled = true;
            this.comboBoxPollutant.Location = new System.Drawing.Point(45, 129);
            this.comboBoxPollutant.Name = "comboBoxPollutant";
            this.comboBoxPollutant.Size = new System.Drawing.Size(256, 24);
            this.comboBoxPollutant.TabIndex = 1;
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerFrom.Location = new System.Drawing.Point(45, 187);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(256, 22);
            this.dateTimePickerFrom.TabIndex = 2;
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerTo.Location = new System.Drawing.Point(45, 236);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(256, 22);
            this.dateTimePickerTo.TabIndex = 4;
            // 
            // dataGridViewReadings
            // 
            this.dataGridViewReadings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReadings.Location = new System.Drawing.Point(336, 73);
            this.dataGridViewReadings.Name = "dataGridViewReadings";
            this.dataGridViewReadings.RowTemplate.Height = 24;
            this.dataGridViewReadings.Size = new System.Drawing.Size(358, 452);
            this.dataGridViewReadings.TabIndex = 5;
            // 
            // search
            // 
            this.search.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.search.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.search.Location = new System.Drawing.Point(45, 322);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(256, 59);
            this.search.TabIndex = 6;
            this.search.Text = "PRETRAŽI";
            this.search.UseVisualStyleBackColor = false;
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // chart1
            // 
            chartArea2.AxisX.LabelStyle.Format = "\"\"";
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Enabled = false;
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(751, 73);
            this.chart1.Name = "chart1";
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Vrijednost";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(621, 452);
            this.chart1.TabIndex = 7;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // labelFrom
            // 
            this.labelFrom.AutoSize = true;
            this.labelFrom.Location = new System.Drawing.Point(787, 508);
            this.labelFrom.Name = "labelFrom";
            this.labelFrom.Size = new System.Drawing.Size(0, 17);
            this.labelFrom.TabIndex = 8;
            // 
            // labelTO
            // 
            this.labelTO.AutoSize = true;
            this.labelTO.Location = new System.Drawing.Point(1296, 508);
            this.labelTO.Name = "labelTO";
            this.labelTO.Size = new System.Drawing.Size(0, 17);
            this.labelTO.TabIndex = 9;
            // 
            // btnDodaj
            // 
            this.btnDodaj.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnDodaj.Location = new System.Drawing.Point(62, 431);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(219, 62);
            this.btnDodaj.TabIndex = 10;
            this.btnDodaj.Text = "DODAJ NOVO";
            this.btnDodaj.UseVisualStyleBackColor = false;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1393, 564);
            this.Controls.Add(this.btnDodaj);
            this.Controls.Add(this.labelTO);
            this.Controls.Add(this.labelFrom);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.search);
            this.Controls.Add(this.dataGridViewReadings);
            this.Controls.Add(this.dateTimePickerTo);
            this.Controls.Add(this.dateTimePickerFrom);
            this.Controls.Add(this.comboBoxPollutant);
            this.Controls.Add(this.comboBoxStations);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReadings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxStations;
        private System.Windows.Forms.ComboBox comboBoxPollutant;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.DataGridView dataGridViewReadings;
        private System.Windows.Forms.Button search;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label labelFrom;
        private System.Windows.Forms.Label labelTO;
        private System.Windows.Forms.Button btnDodaj;
    }
}

