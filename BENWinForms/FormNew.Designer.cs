namespace BENWinForms
{
    partial class FormNew
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("微軟正黑體", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 136);
            label1.Location = new Point(135, 56);
            label1.Name = "label1";
            label1.Size = new Size(127, 35);
            label1.TabIndex = 0;
            label1.Text = "物品名稱";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("微軟正黑體", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 136);
            label2.Location = new Point(135, 105);
            label2.Name = "label2";
            label2.Size = new Size(127, 35);
            label2.TabIndex = 1;
            label2.Text = "物品描述";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("微軟正黑體", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 136);
            label3.Location = new Point(163, 160);
            label3.Name = "label3";
            label3.Size = new Size(71, 35);
            label3.TabIndex = 2;
            label3.Text = "價值";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("微軟正黑體", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 136);
            label4.Location = new Point(163, 207);
            label4.Name = "label4";
            label4.Size = new Size(71, 35);
            label4.TabIndex = 3;
            label4.Text = "數量";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("微軟正黑體", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 136);
            label5.Location = new Point(135, 256);
            label5.Name = "label5";
            label5.Size = new Size(127, 35);
            label5.TabIndex = 4;
            label5.Text = "物品種類";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("微軟正黑體", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 136);
            textBox1.Location = new Point(268, 48);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(446, 43);
            textBox1.TabIndex = 5;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("微軟正黑體", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 136);
            textBox2.Location = new Point(268, 97);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(446, 43);
            textBox2.TabIndex = 6;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // textBox3
            // 
            textBox3.Font = new Font("微軟正黑體", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 136);
            textBox3.Location = new Point(268, 146);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(446, 43);
            textBox3.TabIndex = 7;
            // 
            // textBox4
            // 
            textBox4.Font = new Font("微軟正黑體", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 136);
            textBox4.Location = new Point(268, 199);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(446, 43);
            textBox4.TabIndex = 8;
            // 
            // textBox5
            // 
            textBox5.Font = new Font("微軟正黑體", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 136);
            textBox5.Location = new Point(268, 248);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(446, 43);
            textBox5.TabIndex = 9;
            // 
            // button1
            // 
            button1.Font = new Font("微軟正黑體", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 136);
            button1.Location = new Point(238, 328);
            button1.Name = "button1";
            button1.Size = new Size(134, 52);
            button1.TabIndex = 10;
            button1.Text = "存檔";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("微軟正黑體", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 136);
            button2.Location = new Point(491, 328);
            button2.Name = "button2";
            button2.Size = new Size(131, 52);
            button2.TabIndex = 11;
            button2.Text = "取消";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // FormNew
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormNew";
            Text = "新增物品表單";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private Button button1;
        private Button button2;
    }
}