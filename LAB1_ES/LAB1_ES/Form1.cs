using System;
using System.Windows.Forms;

namespace LAB1_ES
{
    //Перелічуваний тип видів проектів
    public enum ProjectType
    {
        Розповсюджений = 0,
        Напівнезалежний = 1,
        Вбудований = 2
    }

    public partial class Form1 : Form
    {
        private BasicModel bm = new BasicModel();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Трудоємність: {bm.GetEfforts(Convert.ToInt32(textBox1.Text), comboBox1.SelectedIndex)}\n" +
                $"Термін: {bm.GetTimeToDevelop(Convert.ToInt32(textBox1.Text), comboBox1.SelectedIndex)}\n" +
                $"Розробники: {bm.GetPersonsToDevelop(Convert.ToInt32(textBox1.Text), comboBox1.SelectedIndex)}");

        }
    }

    public class BasicModel
    {
        //Таблиця коефіцієнтів
        double[][] modelTable = new double[3][];
        public BasicModel()
        {
            modelTable[0] = new[] { 2.4, 1.05, 2.5, 0.38 };
            modelTable[1] = new[] { 3.0, 1.12, 2.5, 0.35 };
            modelTable[2] = new[] { 3.6, 1.20, 2.5, 0.32 };
        }

        //Трудомісткість
        public double GetEfforts(int codeSize, int type)
        {
            return modelTable[type][0] * (Math.Pow(codeSize, modelTable[type][1]));
        }

        //Термін розробки
        public double GetTimeToDevelop(int codeSize, int type)
        {
            return modelTable[type][2] *
            (Math.Pow(GetEfforts(codeSize, type), modelTable[type][3]));
        }

        //Кількість розробників
        public double GetPersonsToDevelop(int codeSize, int type)
        {
            return GetEfforts(codeSize, type) / GetTimeToDevelop(codeSize, type);
        }
    }
}

