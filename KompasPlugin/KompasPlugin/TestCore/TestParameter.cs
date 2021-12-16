using System;
using Core;
using NUnit.Framework;

namespace TestCore
{
	/// <summary>
	/// Класс тестирования <see cref="Parameter"/>
	/// </summary>
	[TestFixture]
	public class TestParameter
	{
		[TestCase(TestName = "Проверка корректного получения" +
		                     " значения свойства MinValue.")]
		public void TestMinValue_CorrectGetValue()
		{
			var value = 10.0;

			var expected = value;

			var parameter = new Parameter(15, value, 20);

			var actual = parameter.MinValue;

			Assert.AreEqual(expected, actual, "Вернулось некорректное значение.");
		}

		[TestCase(TestName = "Проверка корректного получения" +
							 " значения свойства MaxValue.")]
		public void TestMaxValue_CorrectGetValue()
		{
			var value = 10.0;

			var expected = value;

			var parameter = new Parameter(5, 1, value);

			var actual = parameter.MaxValue;

			Assert.AreEqual(expected, actual, "Вернулось некорректное значение.");
		}

		[TestCase(TestName = "Проверка корректного получения" +
							 " значения свойства Value.")]
		public void TestValue_CorrectGetValue()
		{
			var value = 10.0;

			var expected = value;

			var parameter = new Parameter(value, 1, 20);

			var actual = parameter.Value;

			Assert.AreEqual(expected, actual, "Вернулось некорректное значение.");
		}

		[TestCase(TestName = "Проверка корректной записи" +
							 " значения свойства Value.")]
		public void TestValue_CorrectSetValue()
		{
			var value = 10.0;

			var parameter = new Parameter(5, 1, 20);

			Assert.DoesNotThrow(() => parameter.Value = value,
				"Не удалось присвоить корректное значение.");
		}

		[TestCase(1, TestName = "Проверка записи" +
							 " значения свойства Value" +
							 " меньшему минимальному значению." +
							 "Должно выкинуть исключение.")]
		[TestCase(100, TestName = "Проверка записи" +
								" значения свойства Value" +
								" больше максимального значения." +
								"Должно выкинуть исключение.")]
		public void TestValue_IncorrectSetValue(double value)
		{
			var parameter = new Parameter(7, 5, 9);

			Assert.Throws<ArgumentException>(() => parameter.Value = value,
				"Не удалось присвоить корректное значение.");
		}
	}
}