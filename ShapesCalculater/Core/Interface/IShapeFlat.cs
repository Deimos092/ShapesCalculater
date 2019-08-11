using System;
using System.Collections.Generic;
using System.Text;

namespace ShapesCalculater.Core.Interface
{
	interface IShapeFlat
	{
		/// <summary>
		/// Площадь фигуры
		/// </summary>
		Double Area { get; set; }

		Double Perimeter { get; set; }

		Double Height { get; set; }

		Int32 CountSides { get; }

		/// <summary>
		/// Вычислить площадь фигуры
		/// </summary>
		/// <returns></returns>
		void CalcArea(Double a = 0, Double b = 0, Double c = 0);

		void CalcPerimeter(Double a = 0, Double b = 0, Double c = 0);
	}
}
