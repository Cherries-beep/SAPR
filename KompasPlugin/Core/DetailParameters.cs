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

		/// <summary>
		/// Высота шляпки болта
		/// </summary>
		private double _boltHeadHeight = double.NaN;

		/// <summary>
		/// Длина болта
		/// </summary>
		private double _bolBodytHeight = double.NaN;

		/// <summary>
		/// Диаметр шляпки болта
		/// </summary>
		private double _headDiameter = double.NaN;

		/// <summary>
		/// Диаметр внутреннего кольца
		/// </summary>
		private double _innerRingDiameter = double.NaN;

		/// <summary>
		/// Диаметр внешнего кольца
		/// </summary>
		private double _outerRingDiameter = double.NaN;

		/// <summary>
		/// Диаметр резьбы
		/// </summary>
		private double _threadDiameter = double.NaN;

		/// <summary>
		/// Возвращает и задает значение высоты шляпки болта
		/// </summary>
		public double BoltHeadHeight
		{
			get => _boltHeadHeight;
			set
			{
				const double minValue = 2.0;
				const double maxValue = 4.0;
				SetValue(ref _boltHeadHeight, value, minValue, maxValue);
			}
		}

		/// <summary>
		/// Возвращает и задает значение длины болта
		/// </summary>
		public double BolBodytHeight
		{
			get => _bolBodytHeight;
			set
			{
				const double minValue = 10.0;
				const double maxValue = 20.0;
				SetValue(ref _bolBodytHeight, value, minValue, maxValue);
			}
		}

		/// <summary>
		/// Возвращает и задает значение диаметра шляпки болта
		/// </summary>
		public double HeadDiameter
		{
			get => _headDiameter;
			set
			{
				const double minValue = 10.0;
				const double maxValue = 15.0;
				SetValue(ref _headDiameter, value, minValue, maxValue);
			}
		}

		/// <summary>
		/// Возвращает и задает значение диаметра внутреннего кольца
		/// </summary>
		public double InnerRingDiameter
		{
			get => _innerRingDiameter;
			set
			{
				const double minValue = 4.0;
				var maxValue = 7.0;
				if (!double.IsNaN(OuterRingDiameter))
				{
					maxValue = OuterRingDiameter - Accuracy;
				}

				SetValue(ref _innerRingDiameter, value, minValue, maxValue);
			}
		}

		/// <summary>
		/// Возвращает и задает значение диаметра внешнего кольца
		/// </summary>
		public double OuterRingDiameter
		{
			get => _outerRingDiameter;
			set
			{
				var minValue = 5.0;
				const double maxValue = 8.0;
				if (!double.IsNaN(InnerRingDiameter))
				{
					minValue = InnerRingDiameter + Accuracy;
				}

				SetValue(ref _outerRingDiameter, value, minValue, maxValue);
			}
		}

		/// <summary>
		/// Возвращает и задает значение диаметра резьбы
		/// </summary>
		public double ThreadDiameter
		{
			get => _threadDiameter;
			set
			{
				const double minValue = 4.0;
				var maxValue = 7.0;
				if (!double.IsNaN(InnerRingDiameter))
				{
					maxValue = InnerRingDiameter - Accuracy;
				}

				SetValue(ref _threadDiameter, value, minValue, maxValue);
			}
		}

		/// <summary>
		/// Установить значения поля
		/// </summary>
		/// <param name="field">Поле для записи значения</param>
		/// <param name="value">Значение для записи в поле</param>
		/// <param name="minValue">Минимальное разрешенное значение</param>
		/// <param name="maxValue">Максимальное разрешенное значение</param>
		private void SetValue(ref double field, double value, double minValue, double maxValue)
		{
			if (!double.IsNaN(value))
			{
				Validator.Validate(value, minValue, maxValue);
			}

			field = value;
		}
	}
}
