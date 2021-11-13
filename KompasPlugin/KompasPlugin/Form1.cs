using System;
using System.Windows.Forms;
using Core;

namespace KompasPlugin
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Параметры болта с внутренней резьбой
        /// </summary>
	    private DetailParameters _detailParameters;

        public Form1()
        {
            InitializeComponent();
            ShowIcon = false;
            _detailParameters = new DetailParameters();
        }

        private void button1_Click(object sender, MouseEventArgs e)
		{

			MessageBox.Show("Введено неверное значение длины болта, нужные значения: от 10 до 20 мм\n" +
			                "Введено неверное значение диаметра резьбы, нужные значения: от 4 до 7 мм", "Ошибка",
				MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

		private void textBox1_Enter(object sender, EventArgs e)
		{
			toolTip1.Show("Введено неверное значение длины болта,\nнужные значения: от 10 до 20 мм", textBox1);
        }
	}
}
