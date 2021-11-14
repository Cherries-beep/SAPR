using System;
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

			// Выдавливание
			ksEntity extrude = part.NewEntity((int)Obj3dType.o3d_bossExtrusion);
			ksBossExtrusionDefinition extrudeDefinition = extrude.GetDefinition();
			extrudeDefinition.directionType = (int)Direction_Type.dtNormal;
			extrudeDefinition.SetSketch(sketch);
			ksExtrusionParam extrudeParam = extrudeDefinition.ExtrusionParam();
			extrudeParam.depthNormal = _detailParameters.BoltBodytHeight;
			extrude.Create();

			CreateThread(part, plane);
		}

		/// <summary>
		/// Создание резьбы во внутренней части маленького кольца
		/// </summary>
		/// <param name="part">Интерфейс детали</param>
		private void CreateThread(ksPart part, ksEntity plane)
		{
			ksEntity planeXoz = part.NewEntity((short)Obj3dType.o3d_planeXOZ);
			ksEntity iSketch =
				(ksEntity)part.NewEntity((short)Obj3dType.o3d_sketch);
			ksSketchDefinition iDefinitionSketch =
				(ksSketchDefinition)iSketch.GetDefinition();
			iDefinitionSketch.SetPlane(planeXoz);
			iSketch.Create();
			ksDocument2D iDocument2D = (ksDocument2D)iDefinitionSketch.BeginEdit();
			var x = _detailParameters.InnerRingDiameter / 2;
			var y = 0;
			var delta = _detailParameters.InnerRingDiameter - _detailParameters.ThreadDiameter;
			iDocument2D.ksLineSeg(x, y, x - delta, y -  delta, 1);
			iDocument2D.ksLineSeg(x - delta, y - delta, x - delta, y + delta, 1);
			iDocument2D.ksLineSeg(x - delta, y + delta, x, y, 1);
			iDefinitionSketch.EndEdit();

			ksEntity conicSpiral =
				(ksEntity)part.NewEntity((short)Obj3dType.o3d_cylindricSpiral);
			ksCylindricSpiralDefinition iCylindricSpiralDefinition =
				(ksCylindricSpiralDefinition)conicSpiral.GetDefinition();
			iCylindricSpiralDefinition.diamType = 0;
			iCylindricSpiralDefinition.buildDir = true;
			iCylindricSpiralDefinition.diam = _detailParameters.ThreadDiameter;
			iCylindricSpiralDefinition.buildMode = 2;
			iCylindricSpiralDefinition.turn = 20;
			iCylindricSpiralDefinition.height = _detailParameters.BoltBodytHeight;
			iCylindricSpiralDefinition.SetPlane(plane);
			conicSpiral.SetAdvancedColor(0);
			conicSpiral.hidden = true;
			conicSpiral.Create();

			ksEntity cinematicEvolition =
				(ksEntity)part.NewEntity((short)Obj3dType.o3d_cutEvolution);
			ksCutEvolutionDefinition cutEvolutionDefinition =
				(ksCutEvolutionDefinition)cinematicEvolition.GetDefinition();
			cutEvolutionDefinition.SetSketch(iSketch);
			ksEntityCollection collection =
				(ksEntityCollection)cutEvolutionDefinition.PathPartArray();
			collection.Add(conicSpiral);
			cinematicEvolition.Create();
		}

		/// <summary>
		/// Создать голову болта
		/// </summary>
		private void CreateHead(ksPart part)
		{
			ksEntity planeXoy = part.GetDefaultEntity((int)Obj3dType.o3d_planeXOY);
			ksEntity plane = part.NewEntity((int)Obj3dType.o3d_planeOffset);
			ksPlaneOffsetDefinition planeOffsetDefinition = plane.GetDefinition();
			planeOffsetDefinition.direction = true;
			planeOffsetDefinition.offset = _detailParameters.BoltBodytHeight;
			planeOffsetDefinition.SetPlane(planeXoy);
			plane.Create();
			ksEntity sketch = part.NewEntity((int)Obj3dType.o3d_sketch);
			ksSketchDefinition sketchDefinition = sketch.GetDefinition();
			sketchDefinition.SetPlane(plane);
			sketch.Create();

			// Входим в режим редактирования эскиза
			ksDocument2D document2D = sketchDefinition.BeginEdit();
			document2D.ksCircle(0, 0, _detailParameters.HeadDiameter / 2, 1);
			sketchDefinition.EndEdit();

			// Выдавливание
			ksEntity extrude = part.NewEntity((int)Obj3dType.o3d_bossExtrusion);
			ksBossExtrusionDefinition extrudeDefinition = extrude.GetDefinition();
			extrudeDefinition.directionType = (int)Direction_Type.dtNormal;
			extrudeDefinition.SetSketch(sketch);
			ksExtrusionParam extrudeParam = extrudeDefinition.ExtrusionParam();
			extrudeParam.depthNormal = _detailParameters.BoltHeadHeight;
			extrude.Create();

			CreateHeadRounding(part, sketch);
			CreateHeadHole(part);
		}

		/// <summary>
		/// Создает отверстие для отвертки
		/// </summary>
		/// <param name="part"></param>
		private void CreateHeadHole(ksPart part)
		{
			ksEntity planeXoy = part.GetDefaultEntity((int)Obj3dType.o3d_planeXOY);
			ksEntity plane = part.NewEntity((int)Obj3dType.o3d_planeOffset);
			ksPlaneOffsetDefinition planeOffsetDefinition = plane.GetDefinition();
			planeOffsetDefinition.direction = true;
			planeOffsetDefinition.offset = _detailParameters.BoltBodytHeight + _detailParameters.BoltHeadHeight;
			planeOffsetDefinition.SetPlane(planeXoy);
			plane.Create();
			ksEntity sketch = part.NewEntity((int)Obj3dType.o3d_sketch);
			ksSketchDefinition sketchDefinition = sketch.GetDefinition();
			sketchDefinition.SetPlane(plane);
			sketch.Create();

			ksDocument2D document2D = sketchDefinition.BeginEdit();
			var radius = _detailParameters.InnerRingDiameter / 2;
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
			ksEntity plane = part.GetDefaultEntity((int)Obj3dType.o3d_planeXOZ);
			ksEntity sketch = part.NewEntity((int)Obj3dType.o3d_sketch);
			ksSketchDefinition sketchDefinition = sketch.GetDefinition();
			sketchDefinition.SetPlane(plane);
			sketch.Create();

			// Входим в режим редактирования эскиза
			ksDocument2D document2D = sketchDefinition.BeginEdit();
			var x = _detailParameters.HeadDiameter / 2;
			var y = -_detailParameters.BoltBodytHeight;
			var deltaY = -_detailParameters.BoltHeadHeight;
			var deltaX = _detailParameters.OuterRingDiameter / 2;
			var indexLine = document2D.ksLineSeg(x, y, x, y + deltaY, 1);
			document2D.ksLineSeg(x, y + deltaY, deltaX, y + deltaY, 1);
			document2D.ksArcBy3Points(x, y, x - 0.1 * x, y + deltaY / 2, deltaX, y + deltaY, 1);
			sketchDefinition.EndEdit();

			ksEntity cinematicEvolition =
				(ksEntity)part.NewEntity((short)Obj3dType.o3d_cutEvolution);
			ksCutEvolutionDefinition cutEvolutionDefinition =
				(ksCutEvolutionDefinition)cinematicEvolition.GetDefinition();
			cutEvolutionDefinition.SetSketch(sketch);
			ksEntityCollection collection =
				(ksEntityCollection)cutEvolutionDefinition.PathPartArray();
			collection.Add(head);
			cinematicEvolition.Create();
		}


	}
}