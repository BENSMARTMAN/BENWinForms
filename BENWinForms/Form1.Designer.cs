namespace BENWinForms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            fileSystemWatcher1 = new FileSystemWatcher();
            label3 = new Label();
            buttonSave = new Button();
            label4 = new Label();
            listBox1 = new ListBox();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            buttonDelete = new Button();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            tableLayoutPanel1 = new TableLayoutPanel();
            dataGridView1 = new DataGridView();
            panel1 = new Panel();
            buttonDLtoExcel = new Button();
            buttonDeleteSelected = new Button();
            buttonCreateFile = new Button();
            buttonOpenFile = new Button();
            SearchBox = new TextBox();
            buttonConnection = new Button();
            buttonSearch = new Button();
            buttonDataShow = new Button();
            buttonRemove = new Button();
            buttonNew = new Button();
            buttonUpdate = new Button();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 36);
            label1.Name = "label1";
            label1.Size = new Size(46, 19);
            label1.TabIndex = 0;
            label1.Text = "帳號 :";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 78);
            label2.Name = "label2";
            label2.Size = new Size(46, 19);
            label2.TabIndex = 1;
            label2.Text = "密碼 :";
            // 
            // fileSystemWatcher1
            // 
            fileSystemWatcher1.EnableRaisingEvents = true;
            fileSystemWatcher1.SynchronizingObject = this;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 118);
            label3.Name = "label3";
            label3.Size = new Size(46, 19);
            label3.TabIndex = 2;
            label3.Text = "說明 :";
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(3, 203);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(94, 29);
            buttonSave.TabIndex = 3;
            buttonSave.Text = "儲存";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 159);
            label4.Name = "label4";
            label4.Size = new Size(80, 19);
            label4.TabIndex = 4;
            label4.Text = "密碼強度 : ";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 19;
            listBox1.Location = new Point(280, 19);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(502, 213);
            listBox1.TabIndex = 5;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(58, 28);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(198, 27);
            textBox1.TabIndex = 6;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(59, 70);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(197, 27);
            textBox2.TabIndex = 7;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(59, 110);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(197, 27);
            textBox3.TabIndex = 8;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(119, 203);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(94, 29);
            buttonDelete.TabIndex = 9;
            buttonDelete.Text = "移除";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(1, -2);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1084, 589);
            tabControl1.TabIndex = 0;
            tabControl1.Click += buttonDataShow_Click;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(textBox1);
            tabPage1.Controls.Add(buttonDelete);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(buttonSave);
            tabPage1.Controls.Add(listBox1);
            tabPage1.Controls.Add(textBox3);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(textBox2);
            tabPage1.Controls.Add(label3);
            tabPage1.Location = new Point(4, 28);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1076, 557);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "作業一";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(tableLayoutPanel1);
            tabPage2.Location = new Point(4, 28);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1076, 557);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "作業二、八";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(dataGridView1, 0, 1);
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 66.6666641F));
            tableLayoutPanel1.Size = new Size(1070, 551);
            tableLayoutPanel1.TabIndex = 7;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(3, 186);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1064, 362);
            dataGridView1.TabIndex = 1;
            dataGridView1.ColumnHeaderMouseDoubleClick += dataGridView1_ColumnHeaderMouseDoubleClick;
            // 
            // panel1
            // 
            panel1.Controls.Add(buttonDLtoExcel);
            panel1.Controls.Add(buttonDeleteSelected);
            panel1.Controls.Add(buttonCreateFile);
            panel1.Controls.Add(buttonOpenFile);
            panel1.Controls.Add(SearchBox);
            panel1.Controls.Add(buttonConnection);
            panel1.Controls.Add(buttonSearch);
            panel1.Controls.Add(buttonDataShow);
            panel1.Controls.Add(buttonRemove);
            panel1.Controls.Add(buttonNew);
            panel1.Controls.Add(buttonUpdate);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1064, 177);
            panel1.TabIndex = 2;
            // 
            // buttonDLtoExcel
            // 
            buttonDLtoExcel.Location = new Point(620, 65);
            buttonDLtoExcel.Name = "buttonDLtoExcel";
            buttonDLtoExcel.Size = new Size(135, 39);
            buttonDLtoExcel.TabIndex = 11;
            buttonDLtoExcel.Text = "資料彙整下載";
            buttonDLtoExcel.UseVisualStyleBackColor = true;
            buttonDLtoExcel.Click += buttonDLtoExcel_Click;
            // 
            // buttonDeleteSelected
            // 
            buttonDeleteSelected.Location = new Point(619, 11);
            buttonDeleteSelected.Name = "buttonDeleteSelected";
            buttonDeleteSelected.Size = new Size(136, 44);
            buttonDeleteSelected.TabIndex = 10;
            buttonDeleteSelected.Text = "批次刪除";
            buttonDeleteSelected.UseVisualStyleBackColor = true;
            buttonDeleteSelected.Click += buttonDeleteSelected_Click;
            // 
            // buttonCreateFile
            // 
            buttonCreateFile.Location = new Point(477, 65);
            buttonCreateFile.Name = "buttonCreateFile";
            buttonCreateFile.Size = new Size(136, 39);
            buttonCreateFile.TabIndex = 9;
            buttonCreateFile.Text = "資料匯出";
            buttonCreateFile.UseVisualStyleBackColor = true;
            buttonCreateFile.Click += buttonCreateFile_Click;
            // 
            // buttonOpenFile
            // 
            buttonOpenFile.Location = new Point(477, 11);
            buttonOpenFile.Name = "buttonOpenFile";
            buttonOpenFile.Size = new Size(136, 42);
            buttonOpenFile.TabIndex = 8;
            buttonOpenFile.Text = "資料匯入";
            buttonOpenFile.UseVisualStyleBackColor = true;
            // 
            // SearchBox
            // 
            SearchBox.Font = new Font("微軟正黑體", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 136);
            SearchBox.Location = new Point(12, 125);
            SearchBox.Name = "SearchBox";
            SearchBox.Size = new Size(459, 43);
            SearchBox.TabIndex = 7;
            // 
            // buttonConnection
            // 
            buttonConnection.Location = new Point(12, 12);
            buttonConnection.Name = "buttonConnection";
            buttonConnection.Size = new Size(149, 43);
            buttonConnection.TabIndex = 0;
            buttonConnection.Text = "連線測試";
            buttonConnection.UseVisualStyleBackColor = true;
            buttonConnection.Click += buttonConnection_Click;
            // 
            // buttonSearch
            // 
            buttonSearch.Location = new Point(322, 65);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(149, 39);
            buttonSearch.TabIndex = 6;
            buttonSearch.Text = "搜尋";
            buttonSearch.UseVisualStyleBackColor = true;
            buttonSearch.Click += buttonSearch_Click;
            // 
            // buttonDataShow
            // 
            buttonDataShow.Location = new Point(12, 61);
            buttonDataShow.Name = "buttonDataShow";
            buttonDataShow.Size = new Size(149, 43);
            buttonDataShow.TabIndex = 2;
            buttonDataShow.Text = "資料顯示";
            buttonDataShow.UseVisualStyleBackColor = true;
            buttonDataShow.Click += buttonDataShow_Click;
            // 
            // buttonRemove
            // 
            buttonRemove.Location = new Point(322, 13);
            buttonRemove.Name = "buttonRemove";
            buttonRemove.Size = new Size(149, 40);
            buttonRemove.TabIndex = 5;
            buttonRemove.Text = "刪除";
            buttonRemove.UseVisualStyleBackColor = true;
            buttonRemove.Click += buttonRemove_Click;
            // 
            // buttonNew
            // 
            buttonNew.Location = new Point(167, 13);
            buttonNew.Name = "buttonNew";
            buttonNew.Size = new Size(149, 40);
            buttonNew.TabIndex = 3;
            buttonNew.Text = "新增";
            buttonNew.UseVisualStyleBackColor = true;
            buttonNew.Click += buttonNew_Click;
            // 
            // buttonUpdate
            // 
            buttonUpdate.Location = new Point(167, 65);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(149, 39);
            buttonUpdate.TabIndex = 4;
            buttonUpdate.Text = "編輯";
            buttonUpdate.UseVisualStyleBackColor = true;
            buttonUpdate.Click += buttonUpdate_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1082, 582);
            Controls.Add(tabControl1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "表單作業";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private FileSystemWatcher fileSystemWatcher1;
        private ListBox listBox1;
        private Label label4;
        private Button buttonSave;
        private Label label3;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private Button buttonDelete;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Button buttonConnection;
        private DataGridView dataGridView1;
        private Button buttonDataShow;
        private Button buttonRemove;
        private Button buttonUpdate;
        private Button buttonNew;
        private Button buttonSearch;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private TextBox SearchBox;
        private Button buttonDeleteSelected;
        private Button buttonCreateFile;
        private Button buttonOpenFile;
        private Button buttonDLtoExcel;
    }
}
