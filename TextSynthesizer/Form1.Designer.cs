namespace TextSynthesizer
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
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.btnSpeak = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.tbFilePath = new System.Windows.Forms.TextBox();
			this.btnSelectFile = new System.Windows.Forms.Button();
			this.btnTranslate = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.checkBOnly1 = new System.Windows.Forms.CheckBox();
			this.tbTakeRowCount = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.checkBoxAutoCalc = new System.Windows.Forms.CheckBox();
			this.tbSpeachSpeed = new System.Windows.Forms.NumericUpDown();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.tbWaitAfterEn = new System.Windows.Forms.NumericUpDown();
			this.tbRepeatCount = new System.Windows.Forms.NumericUpDown();
			this.tbWaitAfterRu = new System.Windows.Forms.NumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.panel1 = new System.Windows.Forms.Panel();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.btnSplitRuEn = new System.Windows.Forms.Button();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tbSpeachSpeed)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tbWaitAfterEn)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tbRepeatCount)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tbWaitAfterRu)).BeginInit();
			this.tabPage2.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// richTextBox1
			// 
			this.richTextBox1.Location = new System.Drawing.Point(15, 386);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(506, 75);
			this.richTextBox1.TabIndex = 2;
			this.richTextBox1.Text = "";
			// 
			// btnSpeak
			// 
			this.btnSpeak.Location = new System.Drawing.Point(6, 201);
			this.btnSpeak.Name = "btnSpeak";
			this.btnSpeak.Size = new System.Drawing.Size(75, 23);
			this.btnSpeak.TabIndex = 3;
			this.btnSpeak.Text = "SPEAK";
			this.btnSpeak.UseVisualStyleBackColor = true;
			this.btnSpeak.Click += new System.EventHandler(this.BtnSpeak_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 15);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "путь к файлу";
			// 
			// tbFilePath
			// 
			this.tbFilePath.Location = new System.Drawing.Point(105, 12);
			this.tbFilePath.Name = "tbFilePath";
			this.tbFilePath.Size = new System.Drawing.Size(378, 20);
			this.tbFilePath.TabIndex = 5;
			this.tbFilePath.Leave += new System.EventHandler(this.tbFilePath_Leave);
			// 
			// btnSelectFile
			// 
			this.btnSelectFile.Location = new System.Drawing.Point(489, 10);
			this.btnSelectFile.Name = "btnSelectFile";
			this.btnSelectFile.Size = new System.Drawing.Size(30, 23);
			this.btnSelectFile.TabIndex = 3;
			this.btnSelectFile.Text = "...";
			this.btnSelectFile.UseVisualStyleBackColor = true;
			this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
			// 
			// btnTranslate
			// 
			this.btnTranslate.Location = new System.Drawing.Point(87, 201);
			this.btnTranslate.Name = "btnTranslate";
			this.btnTranslate.Size = new System.Drawing.Size(110, 23);
			this.btnTranslate.TabIndex = 6;
			this.btnTranslate.Text = "перевести на Ru";
			this.btnTranslate.UseVisualStyleBackColor = true;
			this.btnTranslate.Click += new System.EventHandler(this.btnTranslate_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(15, 467);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 7;
			this.button1.Text = "Result";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// checkBOnly1
			// 
			this.checkBOnly1.AutoSize = true;
			this.checkBOnly1.Checked = true;
			this.checkBOnly1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBOnly1.Location = new System.Drawing.Point(9, 6);
			this.checkBOnly1.Name = "checkBOnly1";
			this.checkBOnly1.Size = new System.Drawing.Size(142, 17);
			this.checkBOnly1.TabIndex = 8;
			this.checkBOnly1.Text = "брать только 1ый лист";
			this.checkBOnly1.UseVisualStyleBackColor = true;
			// 
			// tbTakeRowCount
			// 
			this.tbTakeRowCount.Location = new System.Drawing.Point(105, 50);
			this.tbTakeRowCount.Name = "tbTakeRowCount";
			this.tbTakeRowCount.Size = new System.Drawing.Size(122, 20);
			this.tbTakeRowCount.TabIndex = 9;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 53);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(84, 13);
			this.label1.TabIndex = 10;
			this.label1.Text = "не более строк";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 53);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(110, 13);
			this.label3.TabIndex = 11;
			this.label3.Text = "ждать после РУ сек";
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(15, 80);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(511, 271);
			this.tabControl1.TabIndex = 13;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.checkBoxAutoCalc);
			this.tabPage1.Controls.Add(this.tbSpeachSpeed);
			this.tabPage1.Controls.Add(this.label6);
			this.tabPage1.Controls.Add(this.label5);
			this.tabPage1.Controls.Add(this.btnTranslate);
			this.tabPage1.Controls.Add(this.checkBOnly1);
			this.tabPage1.Controls.Add(this.tbWaitAfterEn);
			this.tabPage1.Controls.Add(this.tbRepeatCount);
			this.tabPage1.Controls.Add(this.tbWaitAfterRu);
			this.tabPage1.Controls.Add(this.btnSpeak);
			this.tabPage1.Controls.Add(this.label4);
			this.tabPage1.Controls.Add(this.label3);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(503, 245);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "tabPage1";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// checkBoxAutoCalc
			// 
			this.checkBoxAutoCalc.AutoSize = true;
			this.checkBoxAutoCalc.Location = new System.Drawing.Point(9, 27);
			this.checkBoxAutoCalc.Name = "checkBoxAutoCalc";
			this.checkBoxAutoCalc.Size = new System.Drawing.Size(201, 17);
			this.checkBoxAutoCalc.TabIndex = 21;
			this.checkBoxAutoCalc.Text = "РАССЧИТАТЬ  АВТОМАТИЧЕСКИ";
			this.checkBoxAutoCalc.UseVisualStyleBackColor = true;
			this.checkBoxAutoCalc.CheckedChanged += new System.EventHandler(this.checkBoxWaitByWords_CheckedChanged);
			// 
			// tbSpeachSpeed
			// 
			this.tbSpeachSpeed.Location = new System.Drawing.Point(122, 142);
			this.tbSpeachSpeed.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.tbSpeachSpeed.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
			this.tbSpeachSpeed.Name = "tbSpeachSpeed";
			this.tbSpeachSpeed.Size = new System.Drawing.Size(49, 20);
			this.tbSpeachSpeed.TabIndex = 20;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(6, 144);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(80, 13);
			this.label6.TabIndex = 19;
			this.label6.Text = "скорость речи";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(6, 82);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(110, 13);
			this.label5.TabIndex = 18;
			this.label5.Text = "ждать после EN сек";
			// 
			// tbWaitAfterEn
			// 
			this.tbWaitAfterEn.Location = new System.Drawing.Point(122, 80);
			this.tbWaitAfterEn.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.tbWaitAfterEn.Name = "tbWaitAfterEn";
			this.tbWaitAfterEn.Size = new System.Drawing.Size(49, 20);
			this.tbWaitAfterEn.TabIndex = 17;
			this.tbWaitAfterEn.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
			// 
			// tbRepeatCount
			// 
			this.tbRepeatCount.Location = new System.Drawing.Point(122, 108);
			this.tbRepeatCount.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.tbRepeatCount.Name = "tbRepeatCount";
			this.tbRepeatCount.Size = new System.Drawing.Size(49, 20);
			this.tbRepeatCount.TabIndex = 16;
			this.tbRepeatCount.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
			// 
			// tbWaitAfterRu
			// 
			this.tbWaitAfterRu.Location = new System.Drawing.Point(122, 50);
			this.tbWaitAfterRu.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.tbWaitAfterRu.Name = "tbWaitAfterRu";
			this.tbWaitAfterRu.Size = new System.Drawing.Size(49, 20);
			this.tbWaitAfterRu.TabIndex = 15;
			this.tbWaitAfterRu.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 110);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(80, 13);
			this.label4.TabIndex = 13;
			this.label4.Text = "повторять раз";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.btnSplitRuEn);
			this.tabPage2.Controls.Add(this.panel1);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(503, 245);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "tabPage2";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.dataGridView1);
			this.panel1.Location = new System.Drawing.Point(8, 6);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(489, 157);
			this.panel1.TabIndex = 0;
			// 
			// dataGridView1
			// 
			this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
			this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
			this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Right;
			this.dataGridView1.Location = new System.Drawing.Point(0, 0);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(489, 157);
			this.dataGridView1.TabIndex = 0;
			// 
			// Column1
			// 
			this.Column1.HeaderText = "РУССКИЙ";
			this.Column1.Name = "Column1";
			// 
			// Column2
			// 
			this.Column2.HeaderText = "АНГЛИЙСКИЙ";
			this.Column2.Name = "Column2";
			// 
			// btnSplitRuEn
			// 
			this.btnSplitRuEn.Location = new System.Drawing.Point(8, 189);
			this.btnSplitRuEn.Name = "btnSplitRuEn";
			this.btnSplitRuEn.Size = new System.Drawing.Size(75, 23);
			this.btnSplitRuEn.TabIndex = 1;
			this.btnSplitRuEn.Text = "Split";
			this.btnSplitRuEn.UseVisualStyleBackColor = true;
			this.btnSplitRuEn.Click += new System.EventHandler(this.btnSplitRuEn_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(586, 502);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tbTakeRowCount);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.tbFilePath);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnSelectFile);
			this.Controls.Add(this.richTextBox1);
			this.Name = "Form1";
			this.Text = "Говорун";
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.tbSpeachSpeed)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tbWaitAfterEn)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tbRepeatCount)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tbWaitAfterRu)).EndInit();
			this.tabPage2.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnSpeak;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbFilePath;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.Button btnTranslate;
        private System.Windows.Forms.Button button1;
		private System.Windows.Forms.CheckBox checkBOnly1;
		private System.Windows.Forms.TextBox tbTakeRowCount;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.NumericUpDown tbRepeatCount;
		private System.Windows.Forms.NumericUpDown tbWaitAfterRu;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.NumericUpDown tbWaitAfterEn;
		private System.Windows.Forms.NumericUpDown tbSpeachSpeed;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.CheckBox checkBoxAutoCalc;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
		private System.Windows.Forms.Button btnSplitRuEn;
	}
}

