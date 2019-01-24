namespace PresentationLayer
{
    partial class FormDodaj
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
            this.comboBoxDodajStanicu = new System.Windows.Forms.ComboBox();
            this.comboBoxDodajPolutanta = new System.Windows.Forms.ComboBox();
            this.textBoxPostoji = new System.Windows.Forms.TextBox();
            this.btnDodajNovi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxDodajStanicu
            // 
            this.comboBoxDodajStanicu.FormattingEnabled = true;
            this.comboBoxDodajStanicu.Location = new System.Drawing.Point(68, 55);
            this.comboBoxDodajStanicu.Name = "comboBoxDodajStanicu";
            this.comboBoxDodajStanicu.Size = new System.Drawing.Size(199, 24);
            this.comboBoxDodajStanicu.TabIndex = 0;
            this.comboBoxDodajStanicu.SelectedIndexChanged += new System.EventHandler(this.comboBoxDodajStanicu_SelectedIndexChanged);
            // 
            // comboBoxDodajPolutanta
            // 
            this.comboBoxDodajPolutanta.FormattingEnabled = true;
            this.comboBoxDodajPolutanta.Location = new System.Drawing.Point(68, 126);
            this.comboBoxDodajPolutanta.Name = "comboBoxDodajPolutanta";
            this.comboBoxDodajPolutanta.Size = new System.Drawing.Size(199, 24);
            this.comboBoxDodajPolutanta.TabIndex = 1;
            this.comboBoxDodajPolutanta.SelectedIndexChanged += new System.EventHandler(this.comboBoxDodajPolutanta_SelectedIndexChanged);
            // 
            // textBoxPostoji
            // 
            this.textBoxPostoji.Location = new System.Drawing.Point(323, 55);
            this.textBoxPostoji.Name = "textBoxPostoji";
            this.textBoxPostoji.Size = new System.Drawing.Size(126, 22);
            this.textBoxPostoji.TabIndex = 2;
            // 
            // btnDodajNovi
            // 
            this.btnDodajNovi.Location = new System.Drawing.Point(99, 199);
            this.btnDodajNovi.Name = "btnDodajNovi";
            this.btnDodajNovi.Size = new System.Drawing.Size(121, 30);
            this.btnDodajNovi.TabIndex = 3;
            this.btnDodajNovi.Text = "DODAJ";
            this.btnDodajNovi.UseVisualStyleBackColor = true;
            this.btnDodajNovi.Click += new System.EventHandler(this.btnDodajNovi_Click);
            // 
            // FormDodaj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnDodajNovi);
            this.Controls.Add(this.textBoxPostoji);
            this.Controls.Add(this.comboBoxDodajPolutanta);
            this.Controls.Add(this.comboBoxDodajStanicu);
            this.Name = "FormDodaj";
            this.Text = "FormDodaj";
            this.Load += new System.EventHandler(this.FormDodaj_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxDodajStanicu;
        private System.Windows.Forms.ComboBox comboBoxDodajPolutanta;
        private System.Windows.Forms.TextBox textBoxPostoji;
        private System.Windows.Forms.Button btnDodajNovi;
    }
}