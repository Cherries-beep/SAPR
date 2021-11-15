﻿using System;
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

			BossExtrusion(part, sketch, _detailParameters.BoltBodyHeight);
			CreateThread(part, plane);
		}

		/// <summary>
		/// Создание резьбы во внутренней части маленького кольца
		/// </summary>
		/// <param name="part">Интерфейс детали</param>
		private void CreateThread(ksPart part, ksEntity plane)
		{
			var sketch = GetPlaneXozSketch(part, out var sketchDefinition);

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

			CutEvolution(part, sketch, conicSpiral);
		}

		/// <summary>
		/// Создать голову болта
		/// </summary>
		private void CreateHead(ksPart part)
		{
			var plane = CreatePlaneOffsetXoy(part, _detailParameters.BoltBodyHeight);
			ksEntity sketch = part.NewEntity((int)Obj3dType.o3d_sketch);
			ksSketchDefinition sketchDefinition = sketch.GetDefinition();
			sketchDefinition.SetPlane(plane);
			sketch.Create();

			// Входим в режим редактирования эскиза
			ksDocument2D document2D = sketchDefinition.BeginEdit();
			document2D.ksCircle(0, 0, _detailParameters.HeadDiameter / 2, 1);
			sketchDefinition.EndEdit();

			BossExtrusion(part, sketch, _detailParameters.BoltHeadHeight);
			CreateHeadRounding(part, sketch);
			CreateHeadHole(part);
		}

		/// <summary>
		/// Создает отверстие для отвертки
		/// </summary>
		/// <param name="part"></param>
		private void CreateHeadHole(ksPart part)
		{
			var plane = CreatePlaneOffsetXoy(part, 
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
			var point1 = new Point(x, y);
			var point2 = new Point(radius * Math.Cos(angle), radius * Math.Sin(angle));
			var point3 = new Point(radius * Math.Cos(2 * angle), radius * Math.Sin(2 * angle));
			var point4 = new Point(radius * Math.Cos(3 * angle), radius * Math.Sin(3 * angle));
			var point5 = new Point(radius * Math.Cos(4 * angle), radius * Math.Sin(4 * angle));
			var point6 = new Point(radius * Math.Cos(5 * angle), radius * Math.Sin(5 * angle));
			document2D.ksLineSeg(point1.X, point1.Y, point2.X, point2.Y, 1);
			document2D.ksLineSeg(point2.X, point2.Y, point3.X, point3.Y, 1);
			document2D.ksLineSeg(point3.X, point3.Y, point4.X, point4.Y, 1);
			document2D.ksLineSeg(point4.X, point4.Y, point5.X, point5.Y, 1);
			document2D.ksLineSeg(point5.X, point5.Y, point6.X, point6.Y, 1);
			document2D.ksLineSeg(point6.X, point6.Y, point1.X, point1.Y, 1);
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
			var sketch = GetPlaneXozSketch(part, out var sketchDefinition);

			// Входим в режим редактирования эскиза
			ksDocument2D document2D = sketchDefinition.BeginEdit();
			var x = _detailParameters.HeadDiameter / 2;
			var y = -_detailParameters.BoltBodyHeight;
			var deltaY = -_detailParameters.BoltHeadHeight;
			var deltaX = _detailParameters.OuterRingDiameter / 2;
			document2D.ksLineSeg(x, y, x, y + deltaY, 1);
			document2D.ksLineSeg(x, y + deltaY, deltaX, y + deltaY, 1);
			document2D.ksArcBy3Points(x, y, x - 0.1 * x, y + deltaY / 2, deltaX, y + deltaY, 1);
			sketchDefinition.EndEdit();

			CutEvolution(part, sketch, head);
		}

		/// <summary>
		/// Выдавливание объекта
		/// </summary>
		/// <param name="part"></param>
		/// <param name="sketch"></param>
		/// <param name="height"></param>
		private void BossExtrusion(ksPart part, ksEntity sketch, double height)
		{
			ksEntity extrude = part.NewEntity((int)Obj3dType.o3d_bossExtrusion);
			ksBossExtrusionDefinition extrudeDefinition = extrude.GetDefinition();
			extrudeDefinition.directionType = (int)Direction_Type.dtNormal;
			extrudeDefinition.SetSketch(sketch);
			ksExtrusionParam extrudeParam = extrudeDefinition.ExtrusionParam();
			extrudeParam.depthNormal = height;
			extrude.Create();
		}

		/// <summary>
		/// Выдавливание вырезанием по траектории
		/// </summary>
		/// <param name="part"></param>
		/// <param name="sketch"></param>
		/// <param name="trajectory"></param>
		private void CutEvolution(ksPart part, ksEntity sketch, ksEntity trajectory)
		{
			ksEntity cinematicEvolition =
				(ksEntity)part.NewEntity((short)Obj3dType.o3d_cutEvolution);
			ksCutEvolutionDefinition cutEvolutionDefinition =
				(ksCutEvolutionDefinition)cinematicEvolition.GetDefinition();
			cutEvolutionDefinition.SetSketch(sketch);
			ksEntityCollection collection =
				(ksEntityCollection)cutEvolutionDefinition.PathPartArray();
			collection.Add(trajectory);
			cinematicEvolition.Create();
		}

		/// <summary>
		/// Создание плоскости относительно плоскости XOY на расстоянии <see cref="offsetValue"/> 
		/// </summary>
		/// <param name="part"></param>
		/// <param name="offsetValue"></param>
		/// <returns></returns>
		private ksEntity CreatePlaneOffsetXoy(ksPart part, double offsetValue)
		{
			ksEntity planeXoy = part.GetDefaultEntity((int)Obj3dType.o3d_planeXOY);
			ksEntity plane = part.NewEntity((int)Obj3dType.o3d_planeOffset);
			ksPlaneOffsetDefinition planeOffsetDefinition = plane.GetDefinition();
			planeOffsetDefinition.direction = true;
			planeOffsetDefinition.offset = offsetValue;
			planeOffsetDefinition.SetPlane(planeXoy);
			plane.Create();
			return plane;
		}

		/// <summary>
		/// Получить эскиз относительно плоскости XOZ
		/// </summary>
		/// <param name="part"></param>
		/// <returns></returns>
		private ksEntity GetPlaneXozSketch(ksPart part, out ksSketchDefinition sketchDefinition)
		{
			ksEntity plane = part.GetDefaultEntity((int)Obj3dType.o3d_planeXOZ);
			ksEntity sketch = part.NewEntity((int)Obj3dType.o3d_sketch);
			sketchDefinition = sketch.GetDefinition();
			sketchDefinition.SetPlane(plane);
			sketch.Create();
			return sketch;
		}
	}
}