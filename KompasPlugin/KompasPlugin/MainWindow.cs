using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Core;
using Kompas;

namespace KompasPlugin
{
	//TODO: naming (+)
    public partial class MainWindow : Form
    {
        /// <summary>
        /// Параметры болта с внутренней резьбой
        /// </summary>
	    private readonly DetailParameters _detailParameters;

		/// <summary>
		/// Словарь ошибок
		/// </summary>
        private readonly Dictionary<ParameterTypes, string> _errors = new Dictionary<ParameterTypes, string>();

		/// <summary>
		/// Словарь <see cref="Label"/>
		/// </summary>
		private readonly Dictionary<ParameterTypes, Label> _labels;

		/// <summary>
		/// Флаг отвечающий за проверку зависимостей
		/// </summary>
		private bool _isCheckDependencies;

		/// <summary>
		/// Конструктор формы
		/// </summary>
		public MainWindow()
        {
            InitializeComponent();
            ShowIcon = false;
            _detailParameters = new DetailParameters();
            _detailParameters.DependencyParameterChanged += OnDependencyParameterChanged;
            SetDefaultParameter();

			_labels = new Dictionary<ParameterTypes, Label>
			{
				{ ParameterTypes.BoltBodyHeight, BoltBodyHeightLabel },
				{ ParameterTypes.BoltHeadHeight, BoltHeadHeightLabel },
				{ ParameterTypes.HeadDiameter, HeadDiameterLabel },
				{ ParameterTypes.InnerRingDiameter, InnerRingDiameterLabel },
				{ ParameterTypes.OuterRingDiameter, OuterRingDiameterLabel },
				{ ParameterTypes.ThreadDiameter, ThreadDiameterLabel },
			};

			ScrewdriverTypeComboBox.SelectedIndex = 0;
        }

		/// <summary>
		/// Обработчик события установления параметров в стандартное значение
		/// </summary>
		private void SetDefaultParameter()
		{
			
			BoltBodyHeightTextBox.Text = _detailParameters.GetValue(
				ParameterTypes.BoltBodyHeight).ToString();
			InnerRingDiameterTextBox.Text = _detailParameters.GetValue(
				ParameterTypes.InnerRingDiameter).ToString();
			OuterRingDiameterTextBox.Text = _detailParameters.GetValue(
				ParameterTypes.OuterRingDiameter).ToString();
			ThreadDiameterTextBox.Text = _detailParameters.GetValue(
				ParameterTypes.ThreadDiameter).ToString();
			HeadDiameterTextBox.Text = _detailParameters.GetValue(
				ParameterTypes.HeadDiameter).ToString();
			BoltHeadHeightTextBox.Text = _detailParameters.GetValue(
				ParameterTypes.BoltHeadHeight).ToString();
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
					ParameterTypes.InnerRingDiameter);
				SetValueParameter(OuterRingDiameterTextBox, ToolTip,
					ParameterTypes.OuterRingDiameter);
				SetValueParameter(ThreadDiameterTextBox, ToolTip,
					ParameterTypes.ThreadDiameter);
				_isCheckDependencies = false;
			}
		}

		/// <summary>
		/// Получить название неверного поля
		/// </summary>
		/// <param name="parameterType"></param>
		/// <returns></returns>
		private string GetNameLabel(ParameterTypes parameterType)
		{
			return _labels[parameterType].Text;
		}

		/// <summary>
		/// Установить значение параметру детали
		/// </summary>
		/// <param name="textBox"><see cref="TextBox"/> из которого будет браться значение</param>
		/// <param name="toolTip"><see cref="System.Windows.Forms.ToolTip"/> для показа ошибки</param>
		/// <param name="parameterType">Параметр для записи</param>
		private void SetValueParameter(TextBox textBox, ToolTip toolTip, ParameterTypes parameterType)
		{
			try
			{
				var value = Validator.GetValueFromString(textBox.Text);
				_detailParameters.SetValue(parameterType, value);
				if (_errors.ContainsKey(parameterType))
				{
					_errors.Remove(parameterType);
				}
			}
			catch (ArgumentException exception)
			{
				textBox.BackColor = Color.MistyRose;
				toolTip.Show(exception.Message, textBox);
				if (!_errors.ContainsKey(parameterType))
				{
					_errors.Add(parameterType, exception.Message);
				}
				else
				{
					_errors[parameterType] = exception.Message;
				}

				return;
			}

			textBox.BackColor = Color.White;
			toolTip.Hide(textBox);
		}

		//TODO: xml комментарии(+)
		/// <summary>
		/// Ищет <see cref="ParameterTypes"/> по имени <see cref="TextBox"/>
		/// </summary>
		/// <param name="textBoxName"></param>
		/// <returns></returns>
		private ParameterTypes FindParameters(string textBoxName)
		{
			var parameters = Enum.GetValues(typeof(ParameterTypes))
				.Cast<ParameterTypes>()
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

		private void ScrewdriverTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			_detailParameters.ScrewdriverType = (ScrewdriverTypes)ScrewdriverTypeComboBox.SelectedIndex;
		}
	}
}
