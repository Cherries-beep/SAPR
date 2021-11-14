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
            _detailParameters.DependencyParameterChanged += OnDependencyParameterChanged;
            _detailParameters.DefaultParameter += OnDefaultParameter;
			_detailParameters.SetMinValue();
        }

		/// <summary>
		/// Обработчик события установления параметров в стандартное значение
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnDefaultParameter(object sender, EventArgs e)
		{
			BodyHeightTextBox.Text = _detailParameters.BoltBodytHeight.ToString();
			InnerRingDiameterTextBox.Text = _detailParameters.InnerRingDiameter.ToString();
			OuterRingDiameterTextBox.Text = _detailParameters.OuterRingDiameter.ToString();
			ThreadDiameterTextBox.Text = _detailParameters.ThreadDiameter.ToString();
			HeadDiameterTextBox.Text = _detailParameters.HeadDiameter.ToString();
			HeadHeightTextBox.Text = _detailParameters.BoltHeadHeight.ToString();
		}

		/// <summary>
		/// Обработчик событий изменения завис
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnDependencyParameterChanged(object sender, EventArgs e)
		{
			if (!_isCheckDependencies)
			{
				_isCheckDependencies = true;
				SetValueParameter(InnerRingDiameterTextBox, InnerRingDiameterErrorToolTip,
					Parameters.InnerRingDiameter);
				SetValueParameter(OuterRingDiameterTextBox, OuterRingDiameterErrorToolTip,
					Parameters.OuterRingDiameter);
				SetValueParameter(ThreadDiameterTextBox, ThreadDiameterErrorToolTip,
					Parameters.ThreadDiameter);
				_isCheckDependencies = false;
			}
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

		/// <summary>
		/// Установить значение параметру детали
		/// </summary>
		/// <param name="textBox"><see cref="TextBox"/> из которого будет браться значение</param>
		/// <param name="toolTip"><see cref="ToolTip"/> для показа ошибки</param>
		/// <param name="parameter">Параметр для записи</param>
		private void SetValueParameter(TextBox textBox, ToolTip toolTip, Parameters parameter)
		{
			try
			{
				var value = Validator.GetValueFromString(textBox.Text);
				_detailParameters.SetValue(parameter, value);
				if (_errors.ContainsKey(parameter))
				{
					_errors.Remove(parameter);
				}
			}
			catch (ArgumentException exception)
			{
				textBox.BackColor = Color.MistyRose;
				toolTip.Show(exception.Message, textBox);
				if (!_errors.ContainsKey(parameter))
				{
					_errors.Add(parameter, exception.Message);
				}
				else
				{
					_errors[parameter] = exception.Message;
				}

				return;
			}

			textBox.BackColor = Color.White;
			toolTip.Hide(textBox);
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
			SetValueParameter(BodyHeightTextBox, BodyHeightErrorToolTip,
				Parameters.BoltBodyHeight);
		}

		private void InnerRingDiameterTextBox_TextChanged(object sender, EventArgs e)
		{
			SetValueParameter(InnerRingDiameterTextBox, InnerRingDiameterErrorToolTip,
				Parameters.InnerRingDiameter);
		}

		private void OuterRingDiameterTextBox_TextChanged(object sender, EventArgs e)
		{
			SetValueParameter(OuterRingDiameterTextBox, OuterRingDiameterErrorToolTip,
				Parameters.OuterRingDiameter);
		}

		private void ThreadDiameterTextBox_TextChanged(object sender, EventArgs e)
		{
			SetValueParameter(ThreadDiameterTextBox, ThreadDiameterErrorToolTip,
				Parameters.ThreadDiameter);
		}

		private void HeadDiameterTextBox_TextChanged(object sender, EventArgs e)
		{
			SetValueParameter(HeadDiameterTextBox, HeadDiameterErrorToolTip,
				Parameters.HeadDiameter);
		}

		private void HeadHeightTextBox_TextChanged(object sender, EventArgs e)
		{
			SetValueParameter(HeadHeightTextBox, HeadHeightErrorToolTip,
				Parameters.BoltHeadHeight);
		}
	}
}
