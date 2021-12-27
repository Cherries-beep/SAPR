using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Kompas6API5;
using Kompas6Constants3D;

namespace Kompas
{
	/// <summary>
	/// Класс для работы с Компас 3D
	/// </summary>
	public class KompasWrapper
    {
		/// <summary>
		/// Возвращает экземпляр Компас 3D
		/// </summary>
	    public KompasObject KompasObject { get; private set; }

		/// <summary>
		/// Запускает Компас 3D
		/// </summary>
	    public void RunKompas()
	    {
		    if (KompasObject == null)
		    {
			    var kompasType = Type.GetTypeFromProgID(
				    "KOMPAS.Application.5");
			    KompasObject = (KompasObject)Activator.CreateInstance(kompasType);
		    }

		    if (KompasObject != null)
		    {
			    var retry = true;
			    short tried = 0;
			    while (retry)
			    {
				    try
				    {
					    tried++;
					    KompasObject.Visible = true;
					    retry = false;
				    }
				    catch (COMException)
				    {
					    var kompasType = Type.GetTypeFromProgID("KOMPAS.Application.5");
					    KompasObject =
						    (KompasObject)Activator.CreateInstance(kompasType);

					    if (tried > 3)
					    {
						    retry = false;
					    }
				    }
			    }

			    KompasObject.ActivateControllerAPI();
		    }
        }

		/// <summary>
		/// Выдавливание объекта
		/// </summary>
		/// <param name="part"></param>
		/// <param name="sketch"></param>
		/// <param name="height"></param>
		public void BossExtrusion(ksPart part, ksEntity sketch, double height)
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
		public void CutTrajectoryEvolution(ksPart part, 
			ksEntity sketch, ksEntity trajectory)
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
		/// Выдавливание с вырезом
		/// </summary>
		/// <param name="part"></param>
		/// <param name="sketch"></param>
		public void CutEvolution(ksPart part, ksEntity sketch)
		{
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
		/// Создание плоскости относительно плоскости XOY на расстоянии <see cref="offsetValue"/> 
		/// </summary>
		/// <param name="part"></param>
		/// <param name="offsetValue"></param>
		/// <returns></returns>
		public ksEntity CreatePlaneOffsetXoy(ksPart part, double offsetValue)
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
		/// <param name="sketchDefinition"></param>
		/// <returns></returns>
		public ksEntity GetPlaneXozSketch(ksPart part,
			out ksSketchDefinition sketchDefinition)
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
