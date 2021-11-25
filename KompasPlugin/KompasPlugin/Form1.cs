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
		/// Словарь <see cref="Label"/>
		/// </summary>
		private readonly Dictionary<Parameters, Label> _labels;

		/// <summary>
		/// Список всех <see cref="System.Windows.Forms.ToolTip"/>
		/// </summary>
		private readonly List<ToolTip> _toolTips;

		/// <summary>
		/// Флаг отвечающий за проверку зависимостей
		/// </summary>
		private bool _isCheckDependencies;

		/// <summary>
		/// Конструктор формы
		/// </summary>
		public Form1()
        {
            InitializeComponent();
            ShowIcon = false;
            _detailParameters = new DetailParameters();
            _detailParameters.DependencyParameterChanged += OnDependencyParameterChanged;
            _detailParameters.DefaultParameter += OnDefaultParameter;
			_detailParameters.SetMinValue();

			_labels = new Dictionary<Parameters, Label>
			{
				{ Parameters.BoltBodyHeight, BoltBodyHeightLabel },
				{ Parameters.BoltHeadHeight, BoltHeadHeightLabel },
				{ Parameters.HeadDiameter, HeadDiameterLabel },
				{ Parameters.InnerRingDiameter, InnerRingDiameterLabel },
				{ Parameters.OuterRingDiameter, OuterRingDiameterLabel },
				{ Parameters.ThreadDiameter, ThreadDiameterLabel },
			};
        }

		/// <summary>
		/// Обработчик события установления параметров в стандартное значение
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnDefaultParameter(object sender, EventArgs e)
		{
			BoltBodyHeightTextBox.Text = _detailParameters.BoltBodyHeight.ToString();
			InnerRingDiameterTextBox.Text = _detailParameters.InnerRingDiameter.ToString();
			OuterRingDiameterTextBox.Text = _detailParameters.OuterRingDiameter.ToString();
			ThreadDiameterTextBox.Text = _detailParameters.ThreadDiameter.ToString();
			HeadDiameterTextBox.Text = _detailParameters.HeadDiameter.ToString();
			BoltHeadHeightTextBox.Text = _detailParameters.BoltHeadHeight.ToString();
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
				SetValueParameter(InnerRingDiameterTextBox, ToolTip,
					Parameters.InnerRingDiameter);
				SetValueParameter(OuterRingDiameterTextBox, ToolTip,
					Parameters.OuterRingDiameter);
				SetValueParameter(ThreadDiameterTextBox, ToolTip,
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
			return _labels[parameter].Text;
		}

		/// <summary>
		/// Установить значение параметру детали
		/// </summary>
		/// <param name="textBox"><see cref="TextBox"/> из которого будет браться значение</param>
		/// <param name="toolTip"><see cref="System.Windows.Forms.ToolTip"/> для показа ошибки</param>
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

		/// <summary>
		/// Ищет <see cref="Parameters"/> по имени <see cref="TextBox"/>
		/// </summary>
		/// <param name="textBox"></param>
		/// <returns></returns>
		private Parameters FindParameters(string textBoxName)
		{
			var parameters = Enum.GetValues(typeof(Parameters))
				.Cast<Parameters>()
				.ToList();
			foreach (var parameter in parameters)
			{
				if (textBoxName.Contains(parameter.ToString()))
				{
					return parameter;
				}
			}

			throw new ArgumentException("Не найден параметр");
		}

		/// <summary>
		/// Обработчик нажатия на кнопку
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
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

		/// <summary>
		/// Обработчик события для <see cref="TextBox"/> изменении текста
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		//TODO: дубли сократить
		private void AnyTextBox_TextChanged(object sender, EventArgs e)
		{
			if (!(sender is TextBox textBox))
			{
				return;
			}
			
			SetValueParameter(textBox, ToolTip, FindParameters(textBox.Name));
		}

		/// <summary>
		/// Обработчик события для <see cref="TextBox"/> при нажатии на <see cref="TextBox"/>
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void AnyTextBox_Enter(object sender, EventArgs e)
		{
			if (!(sender is TextBox textBox))
			{
				return;
			}
			
			ToolTip.Hide(this);
			var parameter = FindParameters(textBox.Name);
			if (_errors.ContainsKey(parameter))
			{
				ToolTip.Show(_errors[parameter], textBox);
			}
		}
	}
}
