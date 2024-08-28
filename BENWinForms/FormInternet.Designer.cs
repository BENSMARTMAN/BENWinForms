namespace BENWinForms
{
    partial class FormInternet
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
            button1 = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            listBox1 = new ListBox();
            dataGridViewData = new DataGridView();
            buttonExportExcel = new Button();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            dataGridView1 = new DataGridView();
            listBox2 = new ListBox();
            buttonExportExcel2 = new Button();
            buttonDL = new Button();
            label2 = new Label();
            textBox2 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewData).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(67, 71);
            button1.Name = "button1";
            button1.Size = new Size(137, 48);
            button1.TabIndex = 0;
            button1.Text = "下載按鈕";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(126, 23);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(583, 27);
            textBox1.TabIndex = 1;
            textBox1.Text = "https://www.twse.com.tw/exchangeReport/STOCK_DAY_ALL?response=open_data";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(68, 26);
            label1.Name = "label1";
            label1.Size = new Size(38, 19);
            label1.TabIndex = 2;
            label1.Text = "URL";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 19;
            listBox1.Location = new Point(67, 145);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(616, 213);
            listBox1.TabIndex = 3;
            // 
            // dataGridViewData
            // 
            dataGridViewData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewData.Location = new Point(68, 377);
            dataGridViewData.Name = "dataGridViewData";
            dataGridViewData.RowHeadersWidth = 51;
            dataGridViewData.Size = new Size(615, 327);
            dataGridViewData.TabIndex = 4;
            // 
            // buttonExportExcel
            // 
            buttonExportExcel.Location = new Point(227, 71);
            buttonExportExcel.Name = "buttonExportExcel";
            buttonExportExcel.Size = new Size(151, 48);
            buttonExportExcel.TabIndex = 5;
            buttonExportExcel.Text = "產出excel";
            buttonExportExcel.UseVisualStyleBackColor = true;
            buttonExportExcel.Click += buttonExportExcel_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(925, 831);
            tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(textBox1);
            tabPage1.Controls.Add(dataGridViewData);
            tabPage1.Controls.Add(buttonExportExcel);
            tabPage1.Controls.Add(listBox1);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(button1);
            tabPage1.Location = new Point(4, 28);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(917, 799);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "上課範例";
            tabPage1.UseVisualStyleBackColor = true;
            tabPage1.Click += tabPage1_Click;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dataGridView1);
            tabPage2.Controls.Add(listBox2);
            tabPage2.Controls.Add(buttonExportExcel2);
            tabPage2.Controls.Add(buttonDL);
            tabPage2.Controls.Add(label2);
            tabPage2.Controls.Add(textBox2);
            tabPage2.Location = new Point(4, 28);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(917, 799);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "作業七";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(40, 356);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(856, 222);
            dataGridView1.TabIndex = 5;
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 19;
            listBox2.Location = new Point(40, 147);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(856, 194);
            listBox2.TabIndex = 4;
            // 
            // buttonExportExcel2
            // 
            buttonExportExcel2.Location = new Point(155, 95);
            buttonExportExcel2.Name = "buttonExportExcel2";
            buttonExportExcel2.Size = new Size(114, 42);
            buttonExportExcel2.TabIndex = 3;
            buttonExportExcel2.Text = "資料匯出";
            buttonExportExcel2.UseVisualStyleBackColor = true;
            buttonExportExcel2.Click += buttonExportExcel2_Click;
            // 
            // buttonDL
            // 
            buttonDL.Location = new Point(40, 95);
            buttonDL.Name = "buttonDL";
            buttonDL.Size = new Size(100, 42);
            buttonDL.TabIndex = 2;
            buttonDL.Text = "資料下載";
            buttonDL.UseVisualStyleBackColor = true;
            buttonDL.Click += buttonDL_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft JhengHei UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 136);
            label2.Location = new Point(40, 39);
            label2.Name = "label2";
            label2.Size = new Size(80, 38);
            label2.TabIndex = 1;
            label2.Text = "URL:";
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Microsoft JhengHei UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 136);
            textBox2.Location = new Point(126, 35);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(649, 42);
            textBox2.TabIndex = 0;
            textBox2.Text = "https://data.ntpc.gov.tw/api/datasets/467157c2-15d2-482e-9870-0c91f5901409/csv/file";
            // 
            // FormInternet
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(925, 831);
            Controls.Add(tabControl1);
            Name = "FormInternet";
            Text = "FormInternet";
            ((System.ComponentModel.ISupportInitialize)dataGridViewData).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private TextBox textBox1;
        private Label label1;
        private ListBox listBox1;
        private DataGridView dataGridViewData;
        private Button buttonExportExcel;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private DataGridView dataGridView1;
        private ListBox listBox2;
        private Button buttonExportExcel2;
        private Button buttonDL;
        private Label label2;
        private TextBox textBox2;
    }
}