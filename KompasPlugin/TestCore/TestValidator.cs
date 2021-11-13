﻿using System;
using Core;
using NUnit.Framework;

namespace TestCore
{
	/// <summary>
	/// Класс теста <see cref="Validator"/>
	/// </summary>
	[TestFixture]
	public class TestValidator
	{
		/// <summary>
		/// Минимальное значение
		/// </summary>
		private const double MinValue = 5.0;

		/// <summary>
		/// Максимальное значение
		/// </summary>
		private const double MaxValue = 15.0;

		[Test(Description = "Проверка отправки корректного значения, входящего в диапазон")]
		public void TestValidate_CorrectValue()
		{
			const double value = 10.0;

			Assert.DoesNotThrow(() => Validator.Validate(value, MinValue, MaxValue),
				$"Значение должно входить в указанный диапазон. Значение — {value}; Диапазон — {MinValue} — {MaxValue}");
		}

		[Test(Description = "Проверка отправки корректного значения, равному минимальному значению")]
		public void TestValidate_CorrectValueEqualMinValue()
		{
			const double value = MinValue;

			Assert.DoesNotThrow(() => Validator.Validate(value, MinValue, MaxValue),
				$"Значение должно входить в указанный диапазон. Значение — {value}; Диапазон — {MinValue} — {MaxValue}");
		}

		[Test(Description = "Проверка отправки корректного значения, равному максимальному значению")]
		public void TestValidate_CorrectValueEqualMaxValue()
		{
			const double value = MaxValue;

			Assert.DoesNotThrow(() => Validator.Validate(value, MinValue, MaxValue),
				$"Значение должно входить в указанный диапазон. Значение — {value}; Диапазон — {MinValue} — {MaxValue}");
		}

		[Test(Description = "Проверка отправки значения меньшего минимального")]
		public void TestValidate_BelowMinValue()
		{
			const double value = 3.0;

			Assert.Throws<ArgumentException>(() => Validator.Validate(value, MinValue, MaxValue),
				$"Значение не должно входить в указанный диапазон. Значение — {value}; Диапазон — {MinValue} — {MaxValue}");
		}

		[Test(Description = "Проверка отправки значения больше максимального")]
		public void TestValidate_AboveMaxValue()
		{
			const double value = 20.0;

			Assert.Throws<ArgumentException>(() => Validator.Validate(value, MinValue, MaxValue),
				$"Значение не должно входить в указанный диапазон. Значение — {value}; Диапазон — {MinValue} — {MaxValue}");
		}
	}
}
