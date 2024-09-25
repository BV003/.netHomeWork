namespace ATMSimulation
{
    public partial class Form1 : Form
    {
        private List<Bank> banks;
        public Form1()
        {
            InitializeComponent();
            InitializeBankData();
        }

        private void InitializeBankData()
        {
            banks = new List<Bank>();

            // ������һ������
            Bank bank1 = new Bank("��������");
            bank1.AddAccount(new CreditAccount("1", "1", 20000,10000000));
            bank1.AddAccount(new Account("654321", "password2", 15000));

            // �����ڶ�������
            Bank bank2 = new Bank("JPĦ��");
            bank2.AddAccount(new Account("111222", "password3", 30000));
            bank2.AddAccount(new Account("333444", "password4", 10000));

            // ��������ӵ��б���
            banks.Add(bank1);
            banks.Add(bank2);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string selectedBankName = comboBox1.SelectedItem?.ToString();
            string accountNumber = textBox1.Text; // ������һ���ı��� txtAccountNumber
            string password = textBox2.Text; // ������һ���ı��� txtPassword

            // ���Ҷ�Ӧ������
            Bank selectedBank = banks.Find(b => b.GetBankname() == selectedBankName);

            if (selectedBank != null)
            {
                // ��֤�˻�������
                Account account = selectedBank.GetAccount(accountNumber, password); // �������� GetAccount ����

                if (account != null)
                {
                    MessageBox.Show("��¼�ɹ���", "�ɹ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form2 bankForm = new Form2(banks, selectedBankName, accountNumber, password);
                    bankForm.Show();
                }
                else
                {
                    MessageBox.Show("��¼ʧ�ܣ��˺Ż��������", "ʧ��", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("��ѡ����Ч�����С�", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
