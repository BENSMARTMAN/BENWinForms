namespace BENWinForms
{
    partial class BlueButtonContainer1
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            BlueButtonControl = new Button();
            SuspendLayout();
            // 
            // BlueButtonControl
            // 
            BlueButtonControl.Dock = DockStyle.Fill;
            BlueButtonControl.Location = new Point(0, 0);
            BlueButtonControl.Name = "BlueButtonControl";
            BlueButtonControl.Size = new Size(150, 150);
            BlueButtonControl.TabIndex = 0;
            BlueButtonControl.Text = "下載";
            BlueButtonControl.UseVisualStyleBackColor = true;
            
            // 
            // BlueButtonContainer1
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(BlueButtonControl);
            Name = "BlueButtonContainer1";
            ResumeLayout(false);
        }

        #endregion

        private Button BlueButtonControl;
    }
}
