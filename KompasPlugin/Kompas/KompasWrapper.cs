using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Kompas6API5;

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
			    var kompasType = Type.GetTypeFromProgID("KOMPAS.Application.5");
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
    }
}
