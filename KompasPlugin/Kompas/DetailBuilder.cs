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
			CreateHead(part);
			CreateBody(part);
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
			document2D.ksCircle(0, 0, _detailParameters.InnerRingDiameter / 2, 1);
			document2D.ksCircle(0, 0, _detailParameters.OuterRingDiameter / 2, 1);
			sketchDefinition.EndEdit();

			// Выдавливание
			ksEntity extrude = part.NewEntity((int)Obj3dType.o3d_bossExtrusion);
			ksBossExtrusionDefinition extrudeDefinition = extrude.GetDefinition();
			extrudeDefinition.directionType = (int)Direction_Type.dtNormal;
			extrudeDefinition.SetSketch(sketch);
			ksExtrusionParam extrudeParam = extrudeDefinition.ExtrusionParam();
			extrudeParam.depthNormal = _detailParameters.BoltHeight + _detailParameters.BoltHeadHeight;
			extrude.Create();

			CreateThread(part);
		}

		/// <summary>
		/// Создание резьбы во внутренней части маленького кольца
		/// </summary>
		/// <param name="part">Интерфейс детали</param>
		private void CreateThread(ksPart part)
		{
			ksEntity plane =
				(ksEntity)part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY);
			ksEntity iSketch =
				(ksEntity)part.NewEntity((short)Obj3dType.o3d_sketch);
			ksSketchDefinition iDefinitionSketch =
				(ksSketchDefinition)iSketch.GetDefinition();
			iDefinitionSketch.SetPlane(plane);
			iSketch.Create();
			ksDocument2D iDocument2D = (ksDocument2D)iDefinitionSketch.BeginEdit();
			var X = _detailParameters.InnerRingDiameter / 2;
			var Y = 0;
			iDocument2D.ksLineSeg(X - 3, Y - 0.5, X + 2, Y, 1);
			iDocument2D.ksLineSeg(X - 3, Y + 0.5, X + 2, Y, 1);
			iDocument2D.ksLineSeg(X - 3, Y - 0.5, X - 3, Y + 0.5, 1);
			iDefinitionSketch.EndEdit();

			ksEntity conicSpiral =
				(ksEntity)part.NewEntity((short)Obj3dType.o3d_cylindricSpiral);
			ksCylindricSpiralDefinition iCylindricSpiralDefinition =
				(ksCylindricSpiralDefinition)conicSpiral.GetDefinition();
			iCylindricSpiralDefinition.diamType = 0;
			iCylindricSpiralDefinition.buildDir = true;
			iCylindricSpiralDefinition.diam = _detailParameters.InnerRingDiameter;
			iCylindricSpiralDefinition.buildMode = 2;
			iCylindricSpiralDefinition.turn = _detailParameters.BoltHeight / _detailParameters.ThreadDiameter;
			iCylindricSpiralDefinition.height = _detailParameters.BoltHeight + _detailParameters.BoltHeadHeight;

			ksEntityCollection entityCollectionPart =
				(ksEntityCollection)part.EntityCollection((short)Obj3dType.o3d_face);
			ksEntity planeXOY =
				(ksEntity)part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY);
			iCylindricSpiralDefinition.SetPlane(planeXOY);
			conicSpiral.SetAdvancedColor(0);
			conicSpiral.Create();

		}

		/// <summary>
		/// Создать голову болта
		/// </summary>
		private void CreateHead(ksPart part)
		{
			ksEntity plane = part.GetDefaultEntity((int)Obj3dType.o3d_planeXOY);
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
		}
	}
}