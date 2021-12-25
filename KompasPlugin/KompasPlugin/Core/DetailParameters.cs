using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
	/// <summary>
	/// Параметры болта с внутренней резьбой
	/// </summary>
	public class DetailParameters
	{
		/// <summary>
		/// Точность
		/// </summary>
		private const double Accuracy = 0.1;

		//TODO: RSDN
		/// <summary>
		/// Словарь параметров
		/// </summary>
		private readonly Dictionary<ParameterTypes, Parameter> _parameters = new Dictionary<ParameterTypes, Parameter>
		{
			{ ParameterTypes.BoltBodyHeight, new Parameter(10, 10, 20)},
			{ ParameterTypes.BoltHeadHeight, new Parameter(2, 2, 4)},
			{ ParameterTypes.InnerRingDiameter, new Parameter(4, 4, 7)},
			{ ParameterTypes.ThreadDiameter, new Parameter(3.7, 3, 7)},
			{ ParameterTypes.OuterRingDiameter, new Parameter(5, 5, 8)},
			{ ParameterTypes.HeadDiameter, new Parameter(10, 10, 15)},
		};

		/// <summary>
		/// Возвращает и задает отверстие под отвёртку
		/// </summary>
		public ScrewdriverTypes ScrewdriverType { get; set; }

		/// <summary>
		/// Событие изменения зависимых параметров
		/// </summary>
		public event EventHandler DependencyParameterChanged;

		/// <summary>
		/// Установить значение определенному параметру
		/// </summary>
		/// <param name="parameterType">Параметр</param>
		/// <param name="value">Значение</param>
		public void SetValue(ParameterTypes parameterType, double value)
		{
			var maxValue = _parameters[parameterType].MaxValue;
			var minValue = _parameters[parameterType].MinValue;

			switch (parameterType)
			{

				case ParameterTypes.HeadDiameter:
				case ParameterTypes.BoltHeadHeight:
				case ParameterTypes.BoltBodyHeight:
				{
					break;
				}
				case ParameterTypes.InnerRingDiameter:
				{
					if (!double.IsNaN(
						_parameters[ParameterTypes.OuterRingDiameter].Value))
					{
						maxValue = _parameters[ParameterTypes.OuterRingDiameter]
							           .Value - Accuracy;
					}

					break;
				}
				case ParameterTypes.OuterRingDiameter:
				{
					if (!double.IsNaN(
						_parameters[ParameterTypes.InnerRingDiameter].Value))
					{
						minValue = _parameters[ParameterTypes.InnerRingDiameter]
							           .Value + Accuracy;
					}

					break;
				}
				case ParameterTypes.ThreadDiameter:
				{
					if (!double.IsNaN(
						_parameters[ParameterTypes.InnerRingDiameter].Value))
					{
						maxValue = _parameters[ParameterTypes.InnerRingDiameter]
							.Value - Accuracy;
						minValue = _parameters[ParameterTypes.InnerRingDiameter]
							.Value - 3 * Accuracy;
					}
					
					break;
				}
			}

			_parameters[parameterType].MaxValue = maxValue;
			_parameters[parameterType].MinValue = minValue;
			_parameters[parameterType].Value = value;
			DependencyParameterChanged?.Invoke(this, EventArgs.Empty);
		}

		/// <summary>
		/// Получить значение параметра
		/// </summary>
		/// <param name="parameterType"></param>
		/// <returns></returns>
		public double GetValue(ParameterTypes parameterType)
		{
			return _parameters[parameterType].Value;
		}
	}
}
