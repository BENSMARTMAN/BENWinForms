using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BENWinForms
{
    public partial class BlueButtonContainer1 : UserControl
    {
        // 按鈕控制項，只能讀取
        public Button InnerButton { get => this.BlueButtonControl; }
        // 按鈕的顯示文字，可以讀跟改按鈕的顯示文字
        public string ButtonText { get => this.BlueButtonControl.Text; set => this.BlueButtonControl.Text = value; }
        public BlueButtonContainer1()
        {
            InitializeComponent();
        }

       
    }
}
