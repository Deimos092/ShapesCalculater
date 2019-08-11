using System;
using System.Collections.Generic;
using System.Text;

namespace ShapesCalculater.Core.Interface
{
	public interface ITriangle
	{
		Double Aside { get; set; }

		Double Bside { get; set; }

		Double Cside { get; set; }

		Double Median { get; set; }

		///// <summary>
		///// Вычислить площадь фигуры
		///// </summary>
		///// <returns></returns>
		//void CalcArea(Double a = 0, Double b = 0, Double c = 0);

		//void CalcPerimeter(Double a = 0, Double b = 0, Double c = 0);
	}
}
