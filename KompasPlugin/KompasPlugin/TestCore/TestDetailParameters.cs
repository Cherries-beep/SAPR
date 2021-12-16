using System;
using System.Collections.Generic;
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
		
		[TestCase(ParameterTypes.InnerRingDiameter, 4,
			TestName = "Проверка корректного возврата у свойства InnerRingDiameter")]
		[TestCase(ParameterTypes.OuterRingDiameter, 5,
			TestName = "Проверка корректного возврата у свойства OuterRingDiameter")]
		[TestCase(ParameterTypes.HeadDiameter, 10,
			TestName = "Проверка корректного возврата у свойства HeadDiameter")]
		[TestCase(ParameterTypes.ThreadDiameter, 3.7,
			TestName = "Проверка корректного возврата у свойства ThreadDiameter")]
		[TestCase(ParameterTypes.BoltHeadHeight, 2,
			TestName = "Проверка корректного возврата у свойства BoltHeadHeight")]
		[TestCase(ParameterTypes.BoltBodyHeight, 10,
			TestName = "Проверка корректного возврата у свойства InnerRingDiameter")]
		public void TestGetValue_CorrectGet(ParameterTypes parameterType, double expected)
		{
			var detailParameters = DetailParameters;
			
			var actual = detailParameters.GetValue(parameterType);

			Assert.AreEqual(expected, actual, "Возвращенное значение не равно ожидаемому");
		}
		
		[TestCase(ParameterTypes.InnerRingDiameter, 4,
			TestName = "Проверка корректного присвоения значения свойству InnerRingDiameter")]
		[TestCase(ParameterTypes.OuterRingDiameter, 5,
			TestName = "Проверка корректного присвоения значения свойству OuterRingDiameter")]
		[TestCase(ParameterTypes.HeadDiameter, 10,
			TestName = "Проверка корректного присвоения значения свойству HeadDiameter")]
		[TestCase(ParameterTypes.ThreadDiameter, 3.7,
			TestName = "Проверка корректного присвоения значения свойству ThreadDiameter")]
		[TestCase(ParameterTypes.BoltHeadHeight, 2,
			TestName = "Проверка корректного присвоения значения свойству BoltHeadHeight")]
		[TestCase(ParameterTypes.BoltBodyHeight, 10,
			TestName = "Проверка корректного присвоения значения свойству InnerRingDiameter")]
		public void TestInnerRingDiameter_CorrectSet(ParameterTypes parameterType,
			double value)
		{
			var detailParameters = DetailParameters;

			Assert.DoesNotThrow(() => detailParameters.SetValue(parameterType, value),
				"Не удалось присвоить корректное значение");
		}

		[TestCase(ParameterTypes.InnerRingDiameter, 1.0, 
			TestName = "Проверка присвоения значения меньше минимального свойству InnerRingDiameter")]
		[TestCase(ParameterTypes.InnerRingDiameter, 100.0, 
			TestName = "Проверка присвоения значения больше максимального свойству InnerRingDiameter")]
		[TestCase(ParameterTypes.OuterRingDiameter, 1.0, 
			TestName = "Проверка присвоения значения меньше минимального свойству OuterRingDiameter")]
		[TestCase(ParameterTypes.OuterRingDiameter, 100.0, 
			TestName = "Проверка присвоения значения больше максимального свойству OuterRingDiameter")]
		[TestCase(ParameterTypes.HeadDiameter, 1.0, 
			TestName = "Проверка присвоения значения меньше минимального свойству HeadDiameter")]
		[TestCase(ParameterTypes.HeadDiameter, 100.0, 
			TestName = "Проверка присвоения значения больше максимального свойству HeadDiameter")]
		[TestCase(ParameterTypes.ThreadDiameter, 1.0, 
			TestName = "Проверка присвоения значения меньше минимального свойству ThreadDiameter")]
		[TestCase(ParameterTypes.ThreadDiameter, 100.0, 
			TestName = "Проверка присвоения значения больше максимального свойству ThreadDiameter")]
		[TestCase(ParameterTypes.BoltHeadHeight, 1.0, 
			TestName = "Проверка присвоения значения меньше минимального свойству BoltHeadHeight")]
		[TestCase(ParameterTypes.BoltHeadHeight, 100.0, 
			TestName = "Проверка присвоения значения больше максимального свойству BoltHeadHeight")]
		[TestCase(ParameterTypes.BoltBodyHeight, 1.0, 
			TestName = "Проверка присвоения значения меньше минимального свойству BoltBodyHeight")]
		[TestCase(ParameterTypes.BoltBodyHeight, 100.0, 
			TestName = "Проверка присвоения значения больше максимального свойству BoltBodyHeight")]
		public void TestInnerRingDiameter_ThrowExceptionSet(ParameterTypes parameterType, double value)
		{
			var detailParameters = DetailParameters;

			Assert.Throws<ArgumentException>(() => detailParameters.SetValue(parameterType, value),
				"Присвоилось значение не входящий в диапазон");
		}

		[TestCase(ParameterTypes.ThreadDiameter, 
			ParameterTypes.InnerRingDiameter,
			4, 4,
			TestName = "Проверка присвоения значения свойству ThreadDiameter меньшему " +
			           "или такому же, как при установленном значении InnerRingDiameter")]
		[TestCase(ParameterTypes.OuterRingDiameter, 
			ParameterTypes.InnerRingDiameter,
			3, 4.9,
			TestName = "Проверка присвоения значения свойству OuterRingDiameter меньшему " +
			           "или такому же, как при установленном значении InnerRingDiameter")]
		[TestCase(ParameterTypes.InnerRingDiameter, 
			ParameterTypes.OuterRingDiameter,
			5, 5,
			TestName = "Проверка присвоения значения свойству InnerRingDiameter меньшему " +
					   "или такому же, как при установленном значении OuterRingDiameter")]
		public void TestThreadDiameter_ThrowExceptionSetWithInnerRingDiameter(
			ParameterTypes testingParameterType, ParameterTypes secondParameterType,
			double testingValue, double value)
		{
			var detailParameters = DetailParameters;
			
			detailParameters.SetValue(
				secondParameterType, value);

			Assert.Throws<ArgumentException>(() => detailParameters.SetValue(
					testingParameterType, testingValue),
				"Присвоилось значение не входящий в диапазон");
		}

		[TestCase(ParameterTypes.ThreadDiameter,
			ParameterTypes.InnerRingDiameter,
			4.7, 4.9,
			TestName = "Проверка корректного присвоения значения свойству ThreadDiameter" +
			           " при установленном значении InnerRingDiameter")]
		[TestCase(ParameterTypes.OuterRingDiameter,
			ParameterTypes.InnerRingDiameter,
			6, 4.9,
			TestName = "Проверка корректного присвоения значения свойству OuterRingDiameter" +
					   " при установленном значении InnerRingDiameter")]
		[TestCase(ParameterTypes.InnerRingDiameter,
			ParameterTypes.OuterRingDiameter,
			4, 5,
			TestName = "Проверка корректного присвоения значения свойству InnerRingDiameter" +
					   " при установленном значении OuterRingDiameter")]
		public void TestThreadDiameter_CorrectSetWithInnerRingDiameter(
			ParameterTypes testingParameterType, ParameterTypes secondParameterType,
			double testingValue, double value)
		{
			var detailParameters = DetailParameters;

			detailParameters.SetValue(
				secondParameterType, value);

			Assert.DoesNotThrow(() => detailParameters.SetValue(
					testingParameterType, testingValue),
				"Не удалось присвоить корректное значение");
		}

		[TestCase(TestName = "Проверка присвоения значения неизвестному элементу перечисления")]
		public void TestSetValue_UnkownEnumerate()
		{
			var detailParameters = DetailParameters;

			var value = 3.0;

			Assert.Throws<KeyNotFoundException>(() => detailParameters.SetValue((ParameterTypes)15, value),
				"Нашелся такой элемент перечисления!");
		}

		[TestCase(TestName = "Проверка корректного возврата у свойства ScrewdriverType")]
		public void TestScrewdriverType_CorrectGet()
		{
			var detailParameters = DetailParameters;

			var expected = ScrewdriverTypes.Cross;

			detailParameters.ScrewdriverType = expected;

			var actual = detailParameters.ScrewdriverType;

			Assert.AreEqual(expected, actual, "Возвращенное значение не равно ожидаемому");
		}

		[TestCase(TestName = "Проверка корректного присвоения значения свойству ScrewdriverType")]
		public void TestScrewdriverType_CorrectSet()
		{
			var detailParameters = DetailParameters;

			var value = ScrewdriverTypes.Cross;

			Assert.DoesNotThrow(() => detailParameters.ScrewdriverType = value,
				"Не удалось присвоить корректное значение");
		}

		[TestCase(TestName = "Проверка работы DependencyParameterChanged")]
		public void TestDependencyParameterChanged_InvokeCorrect()
		{
			var detailParameters = DetailParameters;

			var flag = false;

			detailParameters.DependencyParameterChanged += (sender, args) => flag = true;

			detailParameters.SetValue(ParameterTypes.OuterRingDiameter, 5.0);

			Assert.IsTrue(flag, $"Не сработало событие {nameof(detailParameters.DependencyParameterChanged)}");
		}
	}
}