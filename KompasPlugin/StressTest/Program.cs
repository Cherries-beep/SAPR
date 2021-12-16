using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Kompas;
using Microsoft.VisualBasic.Devices;

namespace StressTest
{
	class Program
	{
		static void Main(string[] args)
		{
			var fenceParameters = new DetailParameters();
			var builder = new DetailBuilder(fenceParameters);
			var stopWatch = new Stopwatch();
			stopWatch.Start();
			var streamWriter = new StreamWriter("log.txt", true);
			var count = 0;
			while (true)
			{
				builder.Build();
				var computerInfo = new ComputerInfo();
				var usedMemory = (computerInfo.TotalPhysicalMemory -
				                  computerInfo.AvailablePhysicalMemory) / Math.Pow(1024, 3);
				streamWriter.WriteLine(
					$"{++count}\t{stopWatch.Elapsed:hh\\:mm\\:ss}\t{usedMemory}");
				streamWriter.Flush();
			}
		}
	}
}
