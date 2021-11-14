using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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

		/// <summary>
		/// Словарь ошибок
		/// </summary>
        private readonly Dictionary<Parameters, string> _errors = new Dictionary<Parameters, string>();

		/// <summary>
		/// Флаг отвечающий за проверку зависимостей
		/// </summary>
		private bool _isCheckDependencies;

		public Form1()
        {
            InitializeComponent();
            ShowIcon = false;
            _detailParameters = new DetailParameters();
        }

		/// <summary>
		/// Получить из строки число типа <see cref="double"/>
		/// </summary>
		/// <param name="valueString">Строка для парса</param>
		/// <returns>Число типа <see cref="double"/></returns>
        private double GetValueFromString(string valueString)
        {
	        if (string.IsNullOrEmpty(valueString))
	        {
		        throw new ArgumentException("Строка не должна быть пуста.");
			}

	        if (!double.TryParse(valueString, out var value))
	        {
		        throw new ArgumentException("Введено некорректное значение." +
		                                    " Нужно ввести либо целое число, либо число с плавающей точкой");
	        }

	        return value;
        }

		/// <summary>
		/// Получить название неверного поля
		/// </summary>
		/// <param name="parameter"></param>
		/// <returns></returns>
		private string GetNameLabel(Parameters parameter)
		{
			var labelText = string.Empty;
			switch (parameter)
			{
				case Parameters.BoltBodyHeight:
				{
					labelText = "Длина болта: ";
					break;
				}
				case Parameters.InnerRingDiameter:
				{
					labelText = "Диаметр внутреннего кольца: ";
					break;
				}
				case Parameters.OuterRingDiameter:
				{
					labelText = "Диаметр внешнего кольца: ";
					break;
				}
				case Parameters.ThreadDiameter:
				{
					labelText = "Диаметр резьбы: ";
					break;
				}
				case Parameters.HeadDiameter:
				{
					labelText = "Диаметр шляпки болта:";
					break;
				}
				case Parameters.BoltHeadHeight:
				{
					labelText = "Высота шляпки болта:";
					break;
				}
				default:
				{
					throw new ArgumentOutOfRangeException(nameof(parameter), parameter, null);
				}
			}

			return labelText;
		}

		private void BuilderButton_Click(object sender, MouseEventArgs e)
        {
	        if (_errors.Any())
	        {
		        var message = string.Empty;
		        foreach (var error in _errors)
		        {
			        message += GetNameLabel(error.Key) + error.Value + '\n';
		        }

		        MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
	        }

	        var builder = new DetailBuilder(_detailParameters);
            builder.Build();
        }

        private void BodyHeightTextBox_TextChanged(object sender, EventArgs e)
		{
			var textBox = BodyHeightTextBox;
			var toolTip = BodyHeightErrorToolTip;
			try
			{
				var value = GetValueFromString(textBox.Text);
				_detailParameters.BoltBodytHeight = value;
				if (_errors.ContainsKey(Parameters.BoltBodyHeight))
				{
					_errors.Remove(Parameters.BoltBodyHeight);
				}
			}
			catch (ArgumentException exception)
			{
				textBox.BackColor = Color.MistyRose;
				toolTip.ToolTipTitle = exception.Message;
				toolTip.Show(string.Empty, textBox);
				if (!_errors.ContainsKey(Parameters.BoltBodyHeight))
				{
					_errors.Add(Parameters.BoltBodyHeight, exception.Message);
				}

				return;
			}

			textBox.BackColor = Color.White;
			toolTip.Hide(textBox);
		}

		private void InnerRingDiameterTextBox_TextChanged(object sender, EventArgs e)
		{
			var textBox = InnerRingDiameterTextBox;
			var toolTip = InnerRingDiameterErrorToolTip;
			try
			{
				var value = GetValueFromString(textBox.Text);
				_detailParameters.InnerRingDiameter = value;
				if (_errors.ContainsKey(Parameters.InnerRingDiameter))
				{
					_errors.Remove(Parameters.InnerRingDiameter);
				}

				if (!_isCheckDependencies)
				{
					_isCheckDependencies = true;
					OuterRingDiameterTextBox_TextChanged(this, EventArgs.Empty);
					ThreadDiameterTextBox_TextChanged(this, EventArgs.Empty);
					_isCheckDependencies = false;
				}
			}
			catch (ArgumentException exception)
			{
				textBox.BackColor = Color.MistyRose;
				toolTip.Show(exception.Message, textBox);
				if (!_errors.ContainsKey(Parameters.InnerRingDiameter))
				{
					_errors.Add(Parameters.InnerRingDiameter, exception.Message);
				}

				return;
			}

			textBox.BackColor = Color.White;
			toolTip.Hide(textBox);
		}

		private void OuterRingDiameterTextBox_TextChanged(object sender, EventArgs e)
		{
			var textBox = OuterRingDiameterTextBox;
			var toolTip = OuterRingDiameterErrorToolTip;
			try
			{
				var value = GetValueFromString(textBox.Text);
				_detailParameters.OuterRingDiameter = value;
				if (_errors.ContainsKey(Parameters.OuterRingDiameter))
				{
					_errors.Remove(Parameters.OuterRingDiameter);
				}

				if (!_isCheckDependencies)
				{
					_isCheckDependencies = true;
					InnerRingDiameterTextBox_TextChanged(this, EventArgs.Empty);
					_isCheckDependencies = false;
				}
			}
			catch (ArgumentException exception)
			{
				textBox.BackColor = Color.MistyRose;
				toolTip.Show(exception.Message, textBox);
				if (!_errors.ContainsKey(Parameters.OuterRingDiameter))
				{
					_errors.Add(Parameters.OuterRingDiameter, exception.Message);
				}

				return;
			}

			textBox.BackColor = Color.White;
			toolTip.Hide(textBox);
		}

		private void ThreadDiameterTextBox_TextChanged(object sender, EventArgs e)
		{
			var textBox = ThreadDiameterTextBox;
			var toolTip = ThreadDiameterErrorToolTip;
			try
			{
				var value = GetValueFromString(textBox.Text);
				_detailParameters.ThreadDiameter = value;
				if (_errors.ContainsKey(Parameters.ThreadDiameter))
				{
					_errors.Remove(Parameters.ThreadDiameter);
				}

				if (!_isCheckDependencies)
				{
					_isCheckDependencies = true;
					InnerRingDiameterTextBox_TextChanged(this, EventArgs.Empty);
					_isCheckDependencies = false;
				}
			}
			catch (ArgumentException exception)
			{
				textBox.BackColor = Color.MistyRose;
				toolTip.Show(exception.Message, textBox);
				if (!_errors.ContainsKey(Parameters.ThreadDiameter))
				{
					_errors.Add(Parameters.ThreadDiameter, exception.Message);
				}

				return;
			}

			textBox.BackColor = Color.White;
			toolTip.Hide(textBox);
		}

		private void HeadDiameterTextBox_TextChanged(object sender, EventArgs e)
		{
			var textBox = HeadDiameterTextBox;
			var toolTip = HeadDiameterErrorToolTip;
			try
			{
				var value = GetValueFromString(textBox.Text);
				_detailParameters.HeadDiameter = value;
				if (_errors.ContainsKey(Parameters.HeadDiameter))
				{
					_errors.Remove(Parameters.HeadDiameter);
				}
			}
			catch (ArgumentException exception)
			{
				textBox.BackColor = Color.MistyRose;
				toolTip.Show(exception.Message, textBox);
				if (!_errors.ContainsKey(Parameters.HeadDiameter))
				{
					_errors.Add(Parameters.HeadDiameter, exception.Message);
				}
				return;
			}

			textBox.BackColor = Color.White;
			toolTip.Hide(textBox);
		}

		private void HeadHeightTextBox_TextChanged(object sender, EventArgs e)
		{
			var textBox = HeadHeightTextBox;
			var toolTip = HeadHeightErrorToolTip;
			try
			{
				var value = GetValueFromString(textBox.Text);
				_detailParameters.BoltHeadHeight = value;
				if (_errors.ContainsKey(Parameters.BoltHeadHeight))
				{
					_errors.Remove(Parameters.BoltHeadHeight);
				}
			}
			catch (ArgumentException exception)
			{
				textBox.BackColor = Color.MistyRose;
				toolTip.Show(exception.Message, textBox);
				if (!_errors.ContainsKey(Parameters.BoltHeadHeight))
				{
					_errors.Add(Parameters.BoltHeadHeight, exception.Message);
				}

				return;
			}

			textBox.BackColor = Color.White;
			toolTip.Hide(textBox);
		}
	}
}
