namespace BENWinForms
{
    partial class FormFiles
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
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1 = new Panel();
            labelFileName = new Label();
            buttonCreateFiles = new Button();
            buttonOpenFiles = new Button();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            listBoxFileData = new ListBox();
            tabPage2 = new TabPage();
            dataGridView = new DataGridView();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Controls.Add(tabControl1, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(800, 450);
            tableLayoutPanel1.TabIndex = 0;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
            // 
            // panel1
            // 
            panel1.Controls.Add(labelFileName);
            panel1.Controls.Add(buttonCreateFiles);
            panel1.Controls.Add(buttonOpenFiles);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(794, 94);
            panel1.TabIndex = 0;
            // 
            // labelFileName
            // 
            labelFileName.AutoSize = true;
            labelFileName.Location = new Point(317, 33);
            labelFileName.Name = "labelFileName";
            labelFileName.Size = new Size(69, 19);
            labelFileName.TabIndex = 2;
            labelFileName.Text = "檔案名稱";
            // 
            // buttonCreateFiles
            // 
            buttonCreateFiles.Font = new Font("微軟正黑體", 12F, FontStyle.Regular, GraphicsUnit.Point, 136);
            buttonCreateFiles.Location = new Point(170, 28);
            buttonCreateFiles.Name = "buttonCreateFiles";
            buttonCreateFiles.Size = new Size(110, 45);
            buttonCreateFiles.TabIndex = 1;
            buttonCreateFiles.Text = "產生檔案";
            buttonCreateFiles.UseVisualStyleBackColor = true;
            buttonCreateFiles.Click += buttonCreateFiles_Click;
            // 
            // buttonOpenFiles
            // 
            buttonOpenFiles.Font = new Font("微軟正黑體", 12F, FontStyle.Regular, GraphicsUnit.Point, 136);
            buttonOpenFiles.Location = new Point(39, 28);
            buttonOpenFiles.Name = "buttonOpenFiles";
            buttonOpenFiles.Size = new Size(110, 45);
            buttonOpenFiles.TabIndex = 0;
            buttonOpenFiles.Text = "讀取檔案";
            buttonOpenFiles.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(3, 103);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(794, 344);
            tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(listBoxFileData);
            tabPage1.Location = new Point(4, 28);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(786, 312);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "原始內容";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // listBoxFileData
            // 
            listBoxFileData.Dock = DockStyle.Fill;
            listBoxFileData.FormattingEnabled = true;
            listBoxFileData.ItemHeight = 19;
            listBoxFileData.Location = new Point(3, 3);
            listBoxFileData.Name = "listBoxFileData";
            listBoxFileData.Size = new Size(780, 306);
            listBoxFileData.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dataGridView);
            tabPage2.Location = new Point(4, 28);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(786, 312);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "表格顯示";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.Location = new Point(3, 3);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(780, 306);
            dataGridView.TabIndex = 0;
            // 
            // FormFiles
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            Name = "FormFiles";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormFiles";
            Load += FormFiles_Load;
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private Button buttonCreateFiles;
        private Button buttonOpenFiles;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Label labelFileName;
        private ListBox listBoxFileData;
        private DataGridView dataGridView;
    }
}