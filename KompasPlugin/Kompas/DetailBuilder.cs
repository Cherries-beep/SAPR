using System;
using System.Collections.Generic;
using Core;
using Kompas6API5;
using Kompas6Constants3D;
using KompasAPI7;

namespace Kompas
{
	/// <summary>
	/// Класс для создания болта с внутренней резьбой на Компас 3D
	/// </summary>
	public class DetailBuilder
	{
		/// <summary>
		/// Параметры детали
		/// </summary>
		private readonly DetailParameters _detailParameters;

		/// <summary>
		/// Экземпляр класса работы с Компас 3D
		/// </summary>
		private readonly KompasWrapper _kompasWrapper;

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="detailParameters"></param>
		public DetailBuilder(DetailParameters detailParameters)
		{
			_detailParameters = detailParameters;
			_kompasWrapper = new KompasWrapper();
		}

		/// <summary>
		/// Построить модель болта
		/// </summary>
		public void Build()
		{
			_kompasWrapper.RunKompas();
			ksDocument3D document3D = _kompasWrapper.KompasObject.Document3D();
			document3D.Create();
			ksPart part = document3D.GetPart((int)Part_Type.pTop_Part);

			CreateBody(part);
			CreateHead(part);
		}

		/// <summary>
		/// Создать тело болта
		/// </summary>
		private void CreateBody(ksPart part)
		{
			ksEntity plane = part.GetDefaultEntity((int)Obj3dType.o3d_planeXOY);
			ksEntity sketch = part.NewEntity((int)Obj3dType.o3d_sketch);
			ksSketchDefinition sketchDefinition = sketch.GetDefinition();
			sketchDefinition.SetPlane(plane);
			sketch.Create();

			// Входим в режим редактирования эскиза
			ksDocument2D document2D = sketchDefinition.BeginEdit();
			document2D.ksCircle(0, 0, _detailParameters.ThreadDiameter / 2, 1);
			document2D.ksCircle(0, 0, _detailParameters.OuterRingDiameter / 2, 1);
			sketchDefinition.EndEdit();

			_kompasWrapper.BossExtrusion(part, sketch, _detailParameters.BoltBodyHeight);
			CreateThread(part, plane);
		}

		/// <summary>
		/// Создание резьбы во внутренней части маленького кольца
		/// </summary>
		/// <param name="part">Интерфейс детали</param>
		private void CreateThread(ksPart part, ksEntity plane)
		{
			var sketch = _kompasWrapper.GetPlaneXozSketch(part, out var sketchDefinition);

			// Входим в режим редактирования эскиза
			ksDocument2D document2D = (ksDocument2D)sketchDefinition.BeginEdit();
			var x = _detailParameters.InnerRingDiameter / 2;
			var y = 0;
			var delta = _detailParameters.InnerRingDiameter - _detailParameters.ThreadDiameter;
			var point1 = new Point(x, y);
			var point2 = new Point(x - delta, y - delta);
			var point3 = new Point(x - delta, y + delta);
			document2D.ksLineSeg(point1.X, point1.Y, point2.X, point2.Y, 1);
			document2D.ksLineSeg(point2.X, point2.Y, point3.X, point3.Y, 1);
			document2D.ksLineSeg(point3.X, point3.Y, point1.X, point1.Y, 1);
			sketchDefinition.EndEdit();

			// Создание траектории для резьбы
			ksEntity conicSpiral =
				(ksEntity)part.NewEntity((short)Obj3dType.o3d_cylindricSpiral);
			ksCylindricSpiralDefinition cylindricalSpiralDefinition =
				(ksCylindricSpiralDefinition)conicSpiral.GetDefinition();
			cylindricalSpiralDefinition.diamType = 0;
			cylindricalSpiralDefinition.buildDir = true;
			cylindricalSpiralDefinition.diam = _detailParameters.ThreadDiameter * 0.5;
			cylindricalSpiralDefinition.buildMode = 2;
			cylindricalSpiralDefinition.turn = 20;
			cylindricalSpiralDefinition.height = _detailParameters.BoltBodyHeight;
			cylindricalSpiralDefinition.SetPlane(plane);
			conicSpiral.SetAdvancedColor(0);
			conicSpiral.hidden = true;
			conicSpiral.Create();

			_kompasWrapper.CutEvolution(part, sketch, conicSpiral);
		}

		/// <summary>
		/// Создать голову болта
		/// </summary>
		private void CreateHead(ksPart part)
		{
			var plane = _kompasWrapper.CreatePlaneOffsetXoy(part, _detailParameters.BoltBodyHeight);
			ksEntity sketch = part.NewEntity((int)Obj3dType.o3d_sketch);
			ksSketchDefinition sketchDefinition = sketch.GetDefinition();
			sketchDefinition.SetPlane(plane);
			sketch.Create();

			// Входим в режим редактирования эскиза
			ksDocument2D document2D = sketchDefinition.BeginEdit();
			document2D.ksCircle(0, 0, _detailParameters.HeadDiameter / 2, 1);
			sketchDefinition.EndEdit();

			_kompasWrapper.BossExtrusion(part, sketch, _detailParameters.BoltHeadHeight);
			CreateHeadRounding(part, sketch);
			CreateHeadHole(part);
		}

		/// <summary>
		/// Создает отверстие для отвертки
		/// </summary>
		/// <param name="part"></param>
		private void CreateHeadHole(ksPart part)
		{
			var plane = _kompasWrapper.CreatePlaneOffsetXoy(part, 
				_detailParameters.BoltBodyHeight + _detailParameters.BoltHeadHeight);
			ksEntity sketch = part.NewEntity((int)Obj3dType.o3d_sketch);
			ksSketchDefinition sketchDefinition = sketch.GetDefinition();
			sketchDefinition.SetPlane(plane);
			sketch.Create();

			// Входим в режим редактирования эскиза
			ksDocument2D document2D = sketchDefinition.BeginEdit();
			var radius = _detailParameters.OuterRingDiameter / 2;
			var x = radius;
			var y = 0.0;
			var angle = 60 * Math.PI / 180;
			var points = new List<Point>();
			points.Add(new Point(x, y));
			for (var i = 1; i <= 5; i++)
			{
				points.Add(new Point(radius * Math.Cos(i * angle), radius * Math.Sin(i * angle)));
			}

			for (var i = 0; i < points.Count; i++)
			{
				var nextIndex = i + 1;
				if (i == points.Count - 1)
				{
					nextIndex = 0;
				}
                //TODO: rsdn
				document2D.ksLineSeg(points[i].X, points[i].Y, points[nextIndex].X, points[nextIndex].Y, 1);
			}

			sketchDefinition.EndEdit();

			// Выдавливание с вырезом
			ksEntity cutExtrusion =
				(ksEntity)part.NewEntity((short)Obj3dType.o3d_cutExtrusion);
			ksCutExtrusionDefinition extrusionDefinition =
				cutExtrusion.GetDefinition();
			ksExtrusionParam extrusionParam =
				(ksExtrusionParam)extrusionDefinition.ExtrusionParam();
			extrusionDefinition.SetSketch(sketch);
			extrusionParam.direction = (short)Direction_Type.dtNormal;
			extrusionParam.typeNormal = (short)End_Type.etBlind;
			extrusionParam.depthNormal = 1;
			cutExtrusion.Create();
		}

		/// <summary>
		/// Закругляет шапку болта
		/// </summary>
		/// <param name="part"></param>
		/// <param name="head"></param>
		private void CreateHeadRounding(ksPart part, ksEntity head)
		{
			var sketch = _kompasWrapper.GetPlaneXozSketch(part, out var sketchDefinition);

			// Входим в режим редактирования эскиза
			ksDocument2D document2D = sketchDefinition.BeginEdit();
			var x = _detailParameters.HeadDiameter / 2;
			var y = -_detailParameters.BoltBodyHeight;
			var deltaY = -_detailParameters.BoltHeadHeight;
			var deltaX = _detailParameters.OuterRingDiameter / 2;
			document2D.ksLineSeg(x, y, x, y + deltaY, 1);
			document2D.ksLineSeg(x, y + deltaY, deltaX, y + deltaY, 1);
			//TODO: rsdn
			document2D.ksArcBy3Points(x, y, x - 0.1 * x, y + deltaY / 2, deltaX, y + deltaY, 1);
			sketchDefinition.EndEdit();

			_kompasWrapper.CutEvolution(part, sketch, head);
		}
	}
}