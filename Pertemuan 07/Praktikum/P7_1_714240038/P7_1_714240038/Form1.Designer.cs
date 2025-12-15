namespace P7_1_714240038
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonCek = new System.Windows.Forms.Button();
            this.buttonTutup = new System.Windows.Forms.Button();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.textBoxNama = new System.Windows.Forms.TextBox();
            this.textBoxKelas = new System.Windows.Forms.TextBox();
            this.comboBoxAngkatan = new System.Windows.Forms.ComboBox();
            this.adioButtonWeekday = new System.Windows.Forms.RadioButton();
            this.radioButtonWeekend = new System.Windows.Forms.RadioButton();
            this.checkBoxKuliah = new System.Windows.Forms.CheckBox();
            this.checkBoxTidur = new System.Windows.Forms.CheckBox();
            this.checkBoxLiburan = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nama";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Angkatan";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Kelas";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(391, 227);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(85, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Kegiatan";
            // 
            // buttonCek
            // 
            this.buttonCek.Location = new System.Drawing.Point(35, 145);
            this.buttonCek.Name = "buttonCek";
            this.buttonCek.Size = new System.Drawing.Size(75, 23);
            this.buttonCek.TabIndex = 5;
            this.buttonCek.Text = "Cek";
            this.buttonCek.UseVisualStyleBackColor = true;
            this.buttonCek.Click += new System.EventHandler(this.buttonCek_Click);
            // 
            // buttonTutup
            // 
            this.buttonTutup.Location = new System.Drawing.Point(147, 145);
            this.buttonTutup.Name = "buttonTutup";
            this.buttonTutup.Size = new System.Drawing.Size(75, 23);
            this.buttonTutup.TabIndex = 6;
            this.buttonTutup.Text = "Tutup";
            this.buttonTutup.UseVisualStyleBackColor = true;
            this.buttonTutup.Click += new System.EventHandler(this.buttonTutup_Click);
            // 
            // buttonPrint
            // 
            this.buttonPrint.Location = new System.Drawing.Point(35, 415);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(75, 23);
            this.buttonPrint.TabIndex = 7;
            this.buttonPrint.Text = "Print";
            this.buttonPrint.UseVisualStyleBackColor = true;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(147, 415);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 23);
            this.buttonReset.TabIndex = 8;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // textBoxNama
            // 
            this.textBoxNama.Location = new System.Drawing.Point(147, 6);
            this.textBoxNama.Name = "textBoxNama";
            this.textBoxNama.Size = new System.Drawing.Size(121, 20);
            this.textBoxNama.TabIndex = 9;
            // 
            // textBoxKelas
            // 
            this.textBoxKelas.Location = new System.Drawing.Point(147, 103);
            this.textBoxKelas.Name = "textBoxKelas";
            this.textBoxKelas.Size = new System.Drawing.Size(121, 20);
            this.textBoxKelas.TabIndex = 10;
            // 
            // comboBoxAngkatan
            // 
            this.comboBoxAngkatan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAngkatan.FormattingEnabled = true;
            this.comboBoxAngkatan.Items.AddRange(new object[] {
            "2020",
            "2021",
            "2022",
            "2023",
            "2024",
            "2025"});
            this.comboBoxAngkatan.Location = new System.Drawing.Point(147, 57);
            this.comboBoxAngkatan.Name = "comboBoxAngkatan";
            this.comboBoxAngkatan.Size = new System.Drawing.Size(121, 21);
            this.comboBoxAngkatan.TabIndex = 11;
            // 
            // adioButtonWeekday
            // 
            this.adioButtonWeekday.AutoSize = true;
            this.adioButtonWeekday.Location = new System.Drawing.Point(15, 238);
            this.adioButtonWeekday.Name = "adioButtonWeekday";
            this.adioButtonWeekday.Size = new System.Drawing.Size(89, 17);
            this.adioButtonWeekday.TabIndex = 12;
            this.adioButtonWeekday.TabStop = true;
            this.adioButtonWeekday.Text = "Senin - Jumat";
            this.adioButtonWeekday.UseVisualStyleBackColor = true;
            this.adioButtonWeekday.CheckedChanged += new System.EventHandler(this.adioButtonWeekday_CheckedChanged);
            // 
            // radioButtonWeekend
            // 
            this.radioButtonWeekend.AutoSize = true;
            this.radioButtonWeekend.Location = new System.Drawing.Point(15, 281);
            this.radioButtonWeekend.Name = "radioButtonWeekend";
            this.radioButtonWeekend.Size = new System.Drawing.Size(94, 17);
            this.radioButtonWeekend.TabIndex = 13;
            this.radioButtonWeekend.TabStop = true;
            this.radioButtonWeekend.Text = "Sabtu -Minggu";
            this.radioButtonWeekend.UseVisualStyleBackColor = true;
            this.radioButtonWeekend.CheckedChanged += new System.EventHandler(this.radioButtonWeekend_CheckedChanged);
            // 
            // checkBoxKuliah
            // 
            this.checkBoxKuliah.AutoSize = true;
            this.checkBoxKuliah.Location = new System.Drawing.Point(15, 331);
            this.checkBoxKuliah.Name = "checkBoxKuliah";
            this.checkBoxKuliah.Size = new System.Drawing.Size(55, 17);
            this.checkBoxKuliah.TabIndex = 14;
            this.checkBoxKuliah.Text = "Kuliah";
            this.checkBoxKuliah.UseVisualStyleBackColor = true;
            // 
            // checkBoxTidur
            // 
            this.checkBoxTidur.AutoSize = true;
            this.checkBoxTidur.Location = new System.Drawing.Point(15, 354);
            this.checkBoxTidur.Name = "checkBoxTidur";
            this.checkBoxTidur.Size = new System.Drawing.Size(50, 17);
            this.checkBoxTidur.TabIndex = 15;
            this.checkBoxTidur.Text = "Tidur";
            this.checkBoxTidur.UseVisualStyleBackColor = true;
            // 
            // checkBoxLiburan
            // 
            this.checkBoxLiburan.AutoSize = true;
            this.checkBoxLiburan.Location = new System.Drawing.Point(15, 377);
            this.checkBoxLiburan.Name = "checkBoxLiburan";
            this.checkBoxLiburan.Size = new System.Drawing.Size(61, 17);
            this.checkBoxLiburan.TabIndex = 16;
            this.checkBoxLiburan.Text = "Liburan";
            this.checkBoxLiburan.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 177);
            this.Controls.Add(this.checkBoxLiburan);
            this.Controls.Add(this.checkBoxTidur);
            this.Controls.Add(this.checkBoxKuliah);
            this.Controls.Add(this.radioButtonWeekend);
            this.Controls.Add(this.adioButtonWeekday);
            this.Controls.Add(this.comboBoxAngkatan);
            this.Controls.Add(this.textBoxKelas);
            this.Controls.Add(this.textBoxNama);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonPrint);
            this.Controls.Add(this.buttonTutup);
            this.Controls.Add(this.buttonCek);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonCek;
        private System.Windows.Forms.Button buttonTutup;
        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.TextBox textBoxNama;
        private System.Windows.Forms.TextBox textBoxKelas;
        private System.Windows.Forms.ComboBox comboBoxAngkatan;
        private System.Windows.Forms.RadioButton adioButtonWeekday;
        private System.Windows.Forms.RadioButton radioButtonWeekend;
        private System.Windows.Forms.CheckBox checkBoxKuliah;
        private System.Windows.Forms.CheckBox checkBoxTidur;
        private System.Windows.Forms.CheckBox checkBoxLiburan;
    }
}

