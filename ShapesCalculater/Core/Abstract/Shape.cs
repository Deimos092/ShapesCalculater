using System;
using System.Collections.Generic;
using System.Text;
using ShapesCalculater.Core.Interface;

namespace ShapesCalculater.Core.Abstract
{
	public abstract class Shape : IShapeFlat
	{
		public Int32 CountSides { get; set; } = 0;
		public Double Height { get; set; } = 0;
		public Double Perimeter { get; set; } = 0;
		public Double Area { get; set; } = 0;

		/// <summary>
		/// Вычислить площадь фигуры
		/// </summary>
		/// <returns></returns>
		public virtual void CalcArea(Double a = 0, Double b = 0, Double c = 0)
		{

		}

		public virtual void CalcPerimeter(Double a = 0, Double b = 0, Double c = 0)
		{

		}

		public override string ToString()
		{
			return base.ToString();
		}
	}
}
