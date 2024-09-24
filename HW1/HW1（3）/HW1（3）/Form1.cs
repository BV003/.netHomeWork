namespace HW1_3_
{
    public partial class Form1 : Form
    {
        private int score = 0;
        public int idx = 0;//����ĵ���
        private int maxQuestions = 10;
        public int curans = 0;
        public int userans = 0;
        public int time = 10;
        private int currentQuestion = 0;
        private int timePerQuestion = 60; // ��
        private Random random = new Random();


        //�������Ŀ����Ӧ����ȷ��
        public void Makeup()
        {
            int num1 = random.Next(1, 10); // ����1��9֮��������
            int num2 = random.Next(1, 10); // ����1��9֮��������
            string operation;
            // ���ѡ��ӷ������
            if (random.Next(2) == 0)
            {
                operation = "+";
            }
            else
            {
                operation = "-";
            }
            int correctAnswer;
            if (operation == "+")
            {
                correctAnswer = num1 + num2;
            }
            else
            {
                // ȷ�������Ľ��Ϊ����
                if (num1 < num2)
                {
                    int temp = num1;
                    num1 = num2;
                    num2 = temp;
                }
                correctAnswer = num1 - num2;
            }
            // ������Ŀ�ַ���
            label2.Text = $"{num1} {operation} {num2}";
            curans = correctAnswer;
        }
        //�ж���ȷ�����ȷ�ӷ�
        public void judge()
        {
            GetUserAnswer();
            if (userans == curans)
            {
                score = score + 10;
                label8.Text = "�ش���ȷ";
            }
            else
            {
                label8.Text = "�ش����";
            }
            label5.Text = Convert.ToString(score);

        }
        public void GetUserAnswer()
        {
            bool isEmpty = string.IsNullOrEmpty(textBox1.Text);
            if (isEmpty)
            {
                userans = -10;
            }
            else
            {
                userans = int.Parse(textBox1.Text);
            }

        }

        //timeת�ַ���
        public void trans(int time)
        {
            string timeStr = time.ToString();
            // ���������ʹ�� timeStr �������������� time ���ַ�����ʾ
            label7.Text = timeStr;
        }


        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 10000;//10s����ʱ��
            timer1.Start();
            timer2.Interval = 1000;//1sʱ��
            timer2.Start();
            Makeup();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            idx++;
            Makeup();
            time = 10;
            trans(time);
            label8.Text = "δ�ش�";
            if (idx == 10)
            {
                Form2 form2 = new Form2(Convert.ToString(score));
                // ��ʾ�ڶ�������
                form2.Show();
            }
        }

        //�ύ
        private void button2_Click(object sender, EventArgs e)
        {
            judge();
            textBox1.Text = "";
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            judge();
            textBox1.Text = "";
            idx++;
            Makeup();
            time = 10;
            trans(time);
            label8.Text = "δ�ش�";
            if (idx == 10)
            {
                Form2 form2 = new Form2(Convert.ToString(score));
                // ��ʾ�ڶ�������
                form2.Show();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            time--;
            trans(time);
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
