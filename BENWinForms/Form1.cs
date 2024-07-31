using System.Data.SqlClient;
using System.Windows.Forms;
using Dapper;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BENWinForms
{
    public partial class Form1 : Form
    {
        public string ConnString { get; set; }
        private List<string> accountInfoList = new List<string>();
        public Form1()
        {
            InitializeComponent();
            // �Ы� TabControl
            TabControl tabControl = new TabControl();
            tabControl.Dock = DockStyle.Fill;

            // �ЫزĤ@�� TabPage
            TabPage tabPage1 = new TabPage("Tab 1");
            // �K�[��L����� tabPage1

            // �ЫزĤG�� TabPage
            TabPage tabPage2 = new TabPage("Tab 2");
            // �K�[��L����� tabPage2

            // �N TabPages �K�[�� TabControl
            tabControl.TabPages.Add(tabPage1);
            tabControl.TabPages.Add(tabPage2);

            // �N TabControl �K�[�쵡��
            this.Controls.Add(tabControl);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string account = textBox1.Text;
            string password = textBox2.Text;
            string description = textBox3.Text;
            if (string.IsNullOrWhiteSpace(account) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(description))
            {
                MessageBox.Show("�b���B�K�X�M������짡���o���ťաI");
                return;
            }
            string strength = CheckPasswordStrength(password);
            string info = $"�b��: {account}, �K�X:{password}, ����: {description}, �K�X�j��: {strength} ";
            listBox1.Items.Add(info);
            label4.Text = "�K�X�j��: " + strength;


            // �M�� TextBox
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

        }
        private string CheckPasswordStrength(string password)
        {
            bool hasUpperCase = false;
            bool hasLowerCase = false;
            bool hasDigit = false;
            bool hasSpecialChar = false;
            bool isLongEnough = password.Length >= 8;

            // �S��Ÿ����ˬd
            string specialChars = "!@#$%^&*";
            foreach (char c in password)
            {
                if (char.IsUpper(c)) hasUpperCase = true;
                else if (char.IsLower(c)) hasLowerCase = true;
                else if (char.IsDigit(c)) hasDigit = true;
                else if (specialChars.Contains(c)) hasSpecialChar = true;
            }

            int criteriaCount = 0;

            if (hasUpperCase) criteriaCount++;
            if (hasLowerCase) criteriaCount++;
            if (hasDigit) criteriaCount++;
            if (hasSpecialChar) criteriaCount++;
            if (isLongEnough) criteriaCount++;

            switch (criteriaCount)
            {
                case 5:
                    return "�j";
                case 4:
                case 3:
                    return "��";
                default:
                    return "�z";
            }
        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int selectedIndex = listBox1.SelectedIndex;
            if (selectedIndex == -1)
            {
                MessageBox.Show("�п�ܤ@�ӱb��");
                return;
            }

            listBox1.Items.RemoveAt(selectedIndex);

            MessageBox.Show("�������\!!!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // ���լO�_�i�H�s���Ʈw
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = @"
                        Server=localhost;
                        Database=HRIS;
                        User Id=SYSADM;
                        Password=SYSADM";
                this.ConnString = conn.ConnectionString;
                ItemsService.ConnString = conn.ConnectionString;
                // �ϥ� builder
                //SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                //// ���A��
                //builder.DataSource = "localhost";
                //builder.InitialCatalog = "HRIS";
                //builder.UserID = "SYSADM";
                //builder.Password = "SYSADM";

                //conn.ConnectionString = builder.ConnectionString;

                // �i�H�Υ��ѳ����X�T��
                conn.Open();
                MessageBox.Show("�s�u���\!");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("�o�Ϳ��~: " + ex.Message + "���̿�?" + ex.StackTrace);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConnString;
            conn.Open();
            List<Items> items = new List<Items>();
            items = conn.Query<Items>("Select * From Items").ToList();
            conn.Close();
            dataGridView1.DataSource = items;
            
            // set so whole row is selected �����Q���
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            // can only select one row at a time ���i�H�h��
            dataGridView1.MultiSelect = false;
            // read only
            dataGridView1.ReadOnly = true;
        }
    }
}
