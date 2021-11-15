using System;
using Core;
using NUnit.Framework;

namespace TestCore
{
	/// <summary>
	/// Класс теста <see cref="Core.DetailParameters"/>
	/// </summary>
	[TestFixture]
	public class TestDetailParameters
	{
		/// <summary>
		/// Возвращает новый экземпляр класса <see cref="Core.DetailParameters"/>
		/// </summary>
		private DetailParameters DetailParameters => new DetailParameters();

		[Test(Description = "Проверка корректного возврата у свойства InnerRingDiameter")]
		public void TestInnerRingDiameter_CorrectGetInnerRingDiameter()
		{
			var detailParameters = DetailParameters;

			var expected = 4.0;

			detailParameters.InnerRingDiameter = expected;

			var actual = detailParameters.InnerRingDiameter;

			Assert.AreEqual(expected, actual, "Возвращенное значение не равно ожидаемому");
		}

		[Test(Description = "Проверка корректного присвоения значения свойству InnerRingDiameter")]
		public void TestInnerRingDiameter_CorrectSet()
		{
			var detailParameters = DetailParameters;

			var value = 4.0;

			Assert.DoesNotThrow(() => detailParameters.InnerRingDiameter = value,
				"Не удалось присвоить корректное значение");
		}

		[Test(Description = "Проверка присвоения значения меньше минимального свойству InnerRingDiameter")]
		public void TestInnerRingDiameter_ThrowExceptionSetBelowMin()
		{
			var detailParameters = DetailParameters;

			var value = 1.0;

			Assert.Throws<ArgumentException>(() => detailParameters.InnerRingDiameter = value,
				"Присвоилось значение не входящий в диапазон");
		}

		[Test(Description = "Проверка присвоения значения больше максимального свойству InnerRingDiameter")]
		public void TestInnerRingDiameter_ThrowExceptionSetAboveMin()
		{
			var detailParameters = DetailParameters;

			var value = 100.0;

			Assert.Throws<ArgumentException>(() => detailParameters.InnerRingDiameter = value,
				"Присвоилось значение не входящий в диапазон");
		}

		[Test(Description = "Проверка корректного присвоения значения свойству InnerRingDiameter при установленном значении OuterRingDiameter")]
		public void TestInnerRingDiameter_CorrectSetWithOuterRingDiameter()
		{
			var detailParameters = DetailParameters;

			var value = 4.0;
			var outerRingDiameterValue = 5.0;
			detailParameters.OuterRingDiameter = outerRingDiameterValue;

			Assert.DoesNotThrow(() => detailParameters.InnerRingDiameter = value,
				"Не удалось присвоить корректное значение");
		}

		[Test(Description = "Проверка присвоения значения свойству InnerRingDiameter большему или такому же, как при установленном значении OuterRingDiameter")]
		public void TestInnerRingDiameter_ThrowExceptionSetWithOuterRingDiameter()
		{
			var detailParameters = DetailParameters;

			var value = 5.0;
			var outerRingDiameterValue = 5.0;
			detailParameters.OuterRingDiameter = outerRingDiameterValue;

			Assert.Throws<ArgumentException>(() => detailParameters.InnerRingDiameter = value,
				"Присвоилось значение не входящий в диапазон");
		}

		[Test(Description = "Проверка корректного возврата у свойства OuterRingDiameter")]
		public void TestOuterRingDiameter_CorrectGet()
		{
			var detailParameters = DetailParameters;

			var expected = 5.0;

			detailParameters.OuterRingDiameter = expected;

			var actual = detailParameters.OuterRingDiameter;

			Assert.AreEqual(expected, actual, "Возвращенное значение не равно ожидаемому");
		}

		[Test(Description = "Проверка корректного присвоения значения свойству OuterRingDiameter")]
		public void TestOuterRingDiameter_CorrectSet()
		{
			var detailParameters = DetailParameters;

			var value = 5.0;

			Assert.DoesNotThrow(() => detailParameters.OuterRingDiameter = value,
				"Не удалось присвоить корректное значение");
		}

		[Test(Description = "Проверка присвоения значения меньше минимального свойству OuterRingDiameter")]
		public void TestOuterRingDiameter_ThrowExceptionSetBelowMin()
		{
			var detailParameters = DetailParameters;

			var value = 1.0;

			Assert.Throws<ArgumentException>(() => detailParameters.OuterRingDiameter = value,
				"Присвоилось значение не входящий в диапазон");
		}

		[Test(Description = "Проверка присвоения значения больше максимального свойству OuterRingDiameter")]
		public void TestOuterRingDiameter_ThrowExceptionSetAboveMin()
		{
			var detailParameters = DetailParameters;

			var value = 100.0;

			Assert.Throws<ArgumentException>(() => detailParameters.OuterRingDiameter = value,
				"Присвоилось значение не входящий в диапазон");
		}

		[Test(Description = "Проверка корректного присвоения значения свойству OuterRingDiameter при установленном значении InnerRingDiameter")]
		public void TestOuterRingDiameter_CorrectSetWithInnerRingDiameter()
		{
			var detailParameters = DetailParameters;

			var value = 6.0;
			var innerRingDiameterValue = 5.0;
			detailParameters.InnerRingDiameter = innerRingDiameterValue;

			Assert.DoesNotThrow(() => detailParameters.OuterRingDiameter = value,
				"Не удалось присвоить корректное значение");
		}

		[Test(Description = "Проверка присвоения значения свойству OuterRingDiameter меньше или такому же, как при установленном значении InnerRingDiameter")]
		public void TestOuterRingDiameter_ThrowExceptionSetWithInnerRingDiameter()
		{
			var detailParameters = DetailParameters;

			var value = 5.0;
			var innerRingDiameterValue = 5.0;
			detailParameters.InnerRingDiameter = innerRingDiameterValue;

			Assert.Throws<ArgumentException>(() => detailParameters.OuterRingDiameter = value,
				"Присвоилось значение не входящий в диапазон");
		}

		[Test(Description = "Проверка корректного возврата у свойства ThreadDiameter")]
		public void TestThreadDiameter_CorrectGet()
		{
			var detailParameters = DetailParameters;

			var expected = 4.0;

			detailParameters.ThreadDiameter = expected;

			var actual = detailParameters.ThreadDiameter;

			Assert.AreEqual(expected, actual, "Возвращенное значение не равно ожидаемому");
		}

		[Test(Description = "Проверка корректного присвоения значения свойству ThreadDiameter")]
		public void TestThreadDiameter_CorrectSet()
		{
			var detailParameters = DetailParameters;

			var value = 4.0;

			Assert.DoesNotThrow(() => detailParameters.ThreadDiameter = value,
				"Не удалось присвоить корректное значение");
		}

		[Test(Description = "Проверка присвоения значения меньше минимального свойству ThreadDiameter")]
		public void TestThreadDiameter_ThrowExceptionSetBelowMin()
		{
			var detailParameters = DetailParameters;

			var value = 1.0;

			Assert.Throws<ArgumentException>(() => detailParameters.ThreadDiameter = value,
				"Присвоилось значение не входящий в диапазон");
		}

		[Test(Description = "Проверка присвоения значения больше максимального свойству ThreadDiameter")]
		public void TestThreadDiameter_ThrowExceptionSetAboveMin()
		{
			var detailParameters = DetailParameters;

			var value = 100.0;

			Assert.Throws<ArgumentException>(() => detailParameters.ThreadDiameter = value,
				"Присвоилось значение не входящий в диапазон");
		}

		[Test(Description = "Проверка корректного присвоения значения свойству OuterRingDiameter при установленном значении InnerRingDiameter")]
		public void TestThreadDiameter_CorrectSetWithInnerRingDiameter()
		{
			var detailParameters = DetailParameters;

			var value = 5.9;
			var innerRingDiameterValue = 6.0;
			detailParameters.InnerRingDiameter = innerRingDiameterValue;

			Assert.DoesNotThrow(() => detailParameters.ThreadDiameter = value,
				"Не удалось присвоить корректное значение");
		}

		[Test(Description = "Проверка присвоения значения свойству ThreadDiameter меньшему или такому же, как при установленном значении InnerRingDiameter")]
		public void TestThreadDiameter_ThrowExceptionSetWithInnerRingDiameter()
		{
			var detailParameters = DetailParameters;

			var value = 4.0;
			var innerRingDiameterValue = 4.0;
			detailParameters.InnerRingDiameter = innerRingDiameterValue;

			Assert.Throws<ArgumentException>(() => detailParameters.ThreadDiameter = value,
				"Присвоилось значение не входящий в диапазон");
		}

		[Test(Description = "Проверка корректного возврата у свойства BoltHeadHeight")]
		public void TestBoltHeadHeight_CorrectGet()
		{
			var detailParameters = DetailParameters;

			var expected = 2.0;

			detailParameters.BoltHeadHeight = expected;

			var actual = detailParameters.BoltHeadHeight;

			Assert.AreEqual(expected, actual, "Возвращенное значение не равно ожидаемому");
		}

		[Test(Description = "Проверка корректного присвоения значения свойству BoltHeadHeight")]
		public void TestBoltHeadHeight_CorrectSet()
		{
			var detailParameters = DetailParameters;

			var value = 2.0;

			Assert.DoesNotThrow(() => detailParameters.BoltHeadHeight = value,
				"Не удалось присвоить корректное значение");
		}

		[Test(Description = "Проверка присвоения значения меньше минимального свойству BoltHeadHeight")]
		public void TestBoltHeadHeight_ThrowExceptionSet()
		{
			var detailParameters = DetailParameters;

			var value = 1.0;

			Assert.Throws<ArgumentException>(() => detailParameters.BoltHeadHeight = value,
				"Присвоилось значение не входящий в диапазон");
		}

		[Test(Description = "Проверка присвоения значения больше максимального свойству BoltHeadHeight")]
		public void TestBoltHeadHeight_ThrowExceptionSetAboveMin()
		{
			var detailParameters = DetailParameters;

			var value = 100.0;

			Assert.Throws<ArgumentException>(() => detailParameters.BoltHeadHeight = value,
				"Присвоилось значение не входящий в диапазон");
		}

		[Test(Description = "Проверка корректного возврата у свойства BoltHeight")]
		public void TestBoltHeight_CorrectGet()
		{
			var detailParameters = DetailParameters;

			var expected = 10.0;

			detailParameters.BoltBodyHeight = expected;

			var actual = detailParameters.BoltBodyHeight;

			Assert.AreEqual(expected, actual, "Возвращенное значение не равно ожидаемому");
		}

		[Test(Description = "Проверка корректного присвоения значения свойству BoltHeight")]
		public void TestBoltHeight_CorrectSet()
		{
			var detailParameters = DetailParameters;

			var value = 10.0;

			Assert.DoesNotThrow(() => detailParameters.BoltBodyHeight = value,
				"Не удалось присвоить корректное значение");
		}

		[Test(Description = "Проверка присвоения значения меньше минимального свойству BoltHeight")]
		public void TestBoltHeight_ThrowExceptionSetBelowMin()
		{
			var detailParameters = DetailParameters;

			var value = 1.0;

			Assert.Throws<ArgumentException>(() => detailParameters.BoltBodyHeight = value,
				"Присвоилось значение не входящий в диапазон");
		}

		[Test(Description = "Проверка присвоения значения больше максимального свойству BoltHeight")]
		public void TestBoltHeight_ThrowExceptionSetAboveMin()
		{
			var detailParameters = DetailParameters;

			var value = 100.0;

			Assert.Throws<ArgumentException>(() => detailParameters.BoltBodyHeight = value,
				"Присвоилось значение не входящий в диапазон");
		}

		[Test(Description = "Проверка корректного возврата у свойства HeadDiameter")]
		public void TestHeadDiameter_CorrectGet()
		{
			var detailParameters = DetailParameters;

			var expected = 10.0;

			detailParameters.HeadDiameter = expected;

			var actual = detailParameters.HeadDiameter;

			Assert.AreEqual(expected, actual, "Возвращенное значение не равно ожидаемому");
		}

		[Test(Description = "Проверка корректного присвоения значения свойству HeadDiameter")]
		public void TestHeadDiameter_CorrectSet()
		{
			var detailParameters = DetailParameters;

			var value = 10.0;

			Assert.DoesNotThrow(() => detailParameters.HeadDiameter = value,
				"Не удалось присвоить корректное значение");
		}

		[Test(Description = "Проверка присвоения значения меньше минимального свойству HeadDiameter")]
		public void TestHeadDiameter_ThrowExceptionSetBelowMin()
		{
			var detailParameters = DetailParameters;

			var value = 1.0;

			Assert.Throws<ArgumentException>(() => detailParameters.HeadDiameter = value,
				"Присвоилось значение не входящий в диапазон");
		}

		[Test(Description = "Проверка присвоения значения больше максимального свойству HeadDiameter")]
		public void TestHeadDiameter_ThrowExceptionSetAboveMin()
		{
			var detailParameters = DetailParameters;

			var value = 100.0;

			Assert.Throws<ArgumentException>(() => detailParameters.HeadDiameter = value,
				"Присвоилось значение не входящий в диапазон");
		}

		[Test(Description = "Проверка корректного присвоения минимальных значений")]
		public void TestSetMinValue_CorrectSet()
		{
			var detailParameters = DetailParameters;

			Assert.DoesNotThrow(() => detailParameters.SetMinValue(),
				"Не удалось присвоить установить минимальные значения");
		}

		[Test(Description = "Проверка корректного присвоения значения свойству BoltBodyHeight через метод SetValue")]
		public void TestSetValue_CorrectSetBoltBodyHeight()
		{
			var detailParameters = DetailParameters;

			var value = 10.0;

			Assert.DoesNotThrow(() => detailParameters.SetValue(Parameters.BoltBodyHeight, value),
				"Не удалось присвоить корректное значение");
		}

		[Test(Description = "Проверка корректного присвоения значения свойству HeadDiameter через метод SetValue")]
		public void TestSetValue_CorrectSetHeadDiameter()
		{
			var detailParameters = DetailParameters;

			var value = 10.0;

			Assert.DoesNotThrow(() => detailParameters.SetValue(Parameters.HeadDiameter, value),
				"Не удалось присвоить корректное значение");
		}

		[Test(Description = "Проверка корректного присвоения значения свойству BoltHeadHeight через метод SetValue")]
		public void TestSetValue_CorrectSetBoltHeadHeight()
		{
			var detailParameters = DetailParameters;

			var value = 2.0;

			Assert.DoesNotThrow(() => detailParameters.SetValue(Parameters.BoltHeadHeight, value),
				"Не удалось присвоить корректное значение");
		}

		[Test(Description = "Проверка корректного присвоения значения свойству InnerRingDiameter через метод SetValue")]
		public void TestSetValue_CorrectSetInnerRingDiameter()
		{
			var detailParameters = DetailParameters;

			var value = 4.0;

			Assert.DoesNotThrow(() => detailParameters.SetValue(Parameters.InnerRingDiameter, value),
				"Не удалось присвоить корректное значение");
		}

		[Test(Description = "Проверка корректного присвоения значения свойству OuterRingDiameter через метод SetValue")]
		public void TestSetValue_CorrectSetOuterRingDiameter()
		{
			var detailParameters = DetailParameters;

			var value = 5.0;

			Assert.DoesNotThrow(() => detailParameters.SetValue(Parameters.OuterRingDiameter, value),
				"Не удалось присвоить корректное значение");
		}

		[Test(Description = "Проверка корректного присвоения значения свойству ThreadDiameter через метод SetValue")]
		public void TestSetValue_CorrectSetThreadDiameter()
		{
			var detailParameters = DetailParameters;

			var value = 3.0;

			Assert.DoesNotThrow(() => detailParameters.SetValue(Parameters.ThreadDiameter, value),
				"Не удалось присвоить корректное значение");
		}

		[Test(Description = "Проверка присвоения значения неизвестному элементу перечисления")]
		public void TestSetValue_UnkownEnumerate()
		{
			var detailParameters = DetailParameters;

			var value = 3.0;

			Assert.Throws<ArgumentOutOfRangeException>(() => detailParameters.SetValue((Parameters)15, value),
				"Нашелся такой элемент перечисления!");
		}
	}
}