using System;

namespace Core
{
	/// <summary>
	/// Класс параметра
	/// </summary>
	public class Parameter
	{
		/// <summary>
		/// Значение параметра
		/// </summary>
		private double _value;

		/// <summary>
		/// Возвращает минимальное значение
		/// </summary>
		public double MinValue { get; set; }

		/// <summary>
		/// Возвращает максимальное значение
		/// </summary>
		public double MaxValue { get; set; }

		/// <summary>
		/// Возвращает и устанавливает значение параметра
		/// </summary>
		public double Value
		{
			get => _value;
			set
			{
				_value = value;
				Validator.Validate(_value,
					MinValue, MaxValue);
			}
		}

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="minValue"></param>
		/// <param name="maxValue"></param>
		/// <param name="value"></param>
		public Parameter(double value, 
			double minValue, double maxValue)
		{
			MinValue = minValue;
			MaxValue = maxValue;
			Value = value;
		}
	}
}