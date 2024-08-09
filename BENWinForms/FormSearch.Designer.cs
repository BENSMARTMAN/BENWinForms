namespace BENWinForms
{
    partial class FormSearch
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
            button2 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("微軟正黑體", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 136);
            button1.Location = new Point(190, 266);
            button1.Name = "button1";
            button1.Size = new Size(118, 49);
            button1.TabIndex = 0;
            button1.Text = "搜尋";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("微軟正黑體", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 136);
            button2.Location = new Point(364, 268);
            button2.Name = "button2";
            button2.Size = new Size(115, 47);
            button2.TabIndex = 1;
            button2.Text = "離開";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("微軟正黑體", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 136);
            label1.Location = new Point(190, 29);
            label1.Name = "label1";
            label1.Size = new Size(169, 36);
            label1.TabIndex = 2;
            label1.Text = "關鍵字搜尋 :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("微軟正黑體", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 136);
            label2.Location = new Point(190, 86);
            label2.Name = "label2";
            label2.Size = new Size(105, 29);
            label2.TabIndex = 3;
            label2.Text = "物品名稱";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("微軟正黑體", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 136);
            label3.Location = new Point(190, 139);
            label3.Name = "label3";
            label3.Size = new Size(105, 29);
            label3.TabIndex = 4;
            label3.Text = "物品描述";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("微軟正黑體", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 136);
            label4.Location = new Point(190, 196);
            label4.Name = "label4";
            label4.Size = new Size(105, 29);
            label4.TabIndex = 5;
            label4.Text = "物品種類";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(301, 86);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(178, 27);
            textBox1.TabIndex = 6;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(301, 139);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(178, 27);
            textBox2.TabIndex = 7;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(301, 198);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(178, 27);
            textBox3.TabIndex = 8;
            // 
            // FormSearch
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(707, 377);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "FormSearch";
            Text = "搜尋表單";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
    }
}