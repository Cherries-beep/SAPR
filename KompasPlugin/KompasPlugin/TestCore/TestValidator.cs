using System;
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
		
        //TODO: RSDN (+)
		[TestCase(10, 
			TestName = "Проверка отправки корректного значения, входящего в диапазон")]
		[TestCase(MinValue,
			TestName = "Проверка отправки корректного значения," +
			           " равному минимальному значению")]
		[TestCase(MaxValue, 
			TestName = "Проверка отправки корректного значения," +
			           " равному максимальному значению")]
		public void TestValidate_CorrectValue(double value)
		{
			Assert.DoesNotThrow(() => Validator.Validate(value, MinValue, MaxValue),
				"Значение должно входить в указанный диапазон." +
				$" Значение — {value}; Диапазон — {MinValue} — {MaxValue}");
		}

		[TestCase(3, 
			TestName = "Проверка отправки значения меньшего минимального")]
		[TestCase(20,
			TestName = "Проверка отправки значения больше максимального")]
		public void TestValidate_BelowMinValue(double value)
		{
			Assert.Throws<ArgumentException>(() => Validator.Validate(value, MinValue, MaxValue),
				$"Значение не должно входить в указанный диапазон. Значение — {value}; Диапазон — {MinValue} — {MaxValue}");
		}

		[TestCase(TestName = "Проверка правильного считывания значения из строки")]
		public void TestGetValueFromString_CorrectValue()
		{
			const string value = "10.0";

			var expected = 10.0;

			var actual = double.NaN;

			Assert.DoesNotThrow(() => actual = Validator.GetValueFromString(value),
				"Значение не спарсилось");

			Assert.AreEqual(expected, actual, "При парсе получилось не то значение");
		}

		[TestCase("", TestName = "Проверка парса пустой строки")]
		[TestCase("qwewq123qw", TestName = "Проверка парса неправильной строки")]
		public void TestGetValueFromString_EmptyString(string value)
		{
			Assert.Throws<ArgumentException>(() => Validator.GetValueFromString(value),
				"Запарсилось пустая строка");
		}
	}
}
