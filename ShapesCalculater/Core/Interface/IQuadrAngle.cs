using System;
using System.Collections.Generic;
using System.Text;

namespace ShapesCalculater.Core.Interface
{
	interface IQuadrAngle
	{
		Double SideA { get; set; }

		Double SideB { get; set; }

		Boolean IsTrapeze { get; set; }

		Double MidLine { get; set; }

		void CalcMidLine();
	}
}
