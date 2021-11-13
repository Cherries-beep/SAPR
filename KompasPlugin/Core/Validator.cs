using System;

namespace Core
{
	/// <summary>
	/// Класс валидатор
	/// </summary>
	public static class Validator
	{
		/// <summary>
		/// Проверка значения на вхождение в диапазон
		/// </summary>
		/// <param name="value">Проверяемое значение</param>
		/// <param name="minValue">Минимальное значение</param>
		/// <param name="maxValue">Максимальное значение</param>
		/// <returns>True, если валидация пройдена, иначе False</returns>
		public static void Validate(double value, double minValue, double maxValue)
		{
			if (value < minValue || value > maxValue)
			{
				throw new ArgumentException($"Значение не входит в диапазон. Диапазон {minValue} — {maxValue}");
			}
		}
	}
}