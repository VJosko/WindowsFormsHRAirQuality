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
            this.comboBoxStations = new System.Windows.Forms.ComboBox();
            this.comboBoxPollutant = new System.Windows.Forms.ComboBox();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.dataGridViewReadings = new System.Windows.Forms.DataGridView();
            this.search = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReadings)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxStations
            // 
            this.comboBoxStations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStations.FormattingEnabled = true;
            this.comboBoxStations.Location = new System.Drawing.Point(130, 98);
            this.comboBoxStations.Name = "comboBoxStations";
            this.comboBoxStations.Size = new System.Drawing.Size(256, 24);
            this.comboBoxStations.TabIndex = 0;
            this.comboBoxStations.SelectedIndexChanged += new System.EventHandler(this.comboBoxStations_SelectedIndexChanged);
            // 
            // comboBoxPollutant
            // 
            this.comboBoxPollutant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPollutant.FormattingEnabled = true;
            this.comboBoxPollutant.Location = new System.Drawing.Point(130, 154);
            this.comboBoxPollutant.Name = "comboBoxPollutant";
            this.comboBoxPollutant.Size = new System.Drawing.Size(256, 24);
            this.comboBoxPollutant.TabIndex = 1;
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerFrom.Location = new System.Drawing.Point(130, 212);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(256, 22);
            this.dateTimePickerFrom.TabIndex = 2;
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerTo.Location = new System.Drawing.Point(130, 261);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(256, 22);
            this.dateTimePickerTo.TabIndex = 4;
            // 
            // dataGridViewReadings
            // 
            this.dataGridViewReadings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReadings.Location = new System.Drawing.Point(457, 98);
            this.dataGridViewReadings.Name = "dataGridViewReadings";
            this.dataGridViewReadings.RowTemplate.Height = 24;
            this.dataGridViewReadings.Size = new System.Drawing.Size(358, 452);
            this.dataGridViewReadings.TabIndex = 5;
            // 
            // search
            // 
            this.search.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.search.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.search.Location = new System.Drawing.Point(130, 347);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(256, 59);
            this.search.TabIndex = 6;
            this.search.Text = "PRETRAŽI";
            this.search.UseVisualStyleBackColor = false;
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1108, 610);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxStations;
        private System.Windows.Forms.ComboBox comboBoxPollutant;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.DataGridView dataGridViewReadings;
        private System.Windows.Forms.Button search;
    }
}

