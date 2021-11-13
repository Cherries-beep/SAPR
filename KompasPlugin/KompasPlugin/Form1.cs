using System;
using System.Windows.Forms;
using Core;
using Kompas;

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
	        _detailParameters.InnerRingDiameter = 5;
	        _detailParameters.OuterRingDiameter = 7;
	        _detailParameters.ThreadDiameter = 4;
	        _detailParameters.BoltHeight = 10;
	        _detailParameters.HeadDiameter = 10;
	        _detailParameters.BoltHeadHeight = 2;
	        var builder = new DetailBuilder(_detailParameters);
            builder.Build();
        }

		private void textBox1_Enter(object sender, EventArgs e)
		{
			toolTip1.Show("Введено неверное значение длины болта,\nнужные значения: от 10 до 20 мм", textBox1);
        }
	}
}
