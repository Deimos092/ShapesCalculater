using System;
using System.Collections.Generic;
using System.Text;
using ShapesCalculater.Core.Abstract;
using ShapesCalculater.Core.Interface;

namespace ShapesCalculater.Shapes
{
	public class Triangle : Shape, ITriangle
	{
		private delegate void Init();
		private event Init InitializeEventHadler;

		public Triangle()
		{
			CountSides = 3;
		}
		public Triangle(int height)
		{
			Height = height;
			CountSides = 3;
		}

		/// <summary>
		/// Initialize all property of Triangle
		/// </summary>
		/// <param name="a">Side A</param>
		/// <param name="b">Side B</param>
		/// <param name="c">Side C</param>
		public Triangle(Double a, Double b, Double c)
		{
			Aside = a;
			Bside = b;
			Cside = c;
			Initialize();
			CheckRectangular();

		}

		public Double Aside { get; set; } = 0.0;
		public Double Bside { get; set; } = 0.0;
		public Double Cside { get; set; } = 0.0;

		/// <summary>
		/// Return Alpha angle of A Point
		/// </summary>
		public Double Alpha { get; private set; } = 0.0;

		/// <summary>
		/// Return Beta angle of B Point
		/// </summary>
		public Double Beta { get; private set; } = 0.0;

		/// <summary>
		/// Return Gamma angle of C Point
		/// </summary>
		public Double Gamma { get; private set; } = 0.0;

		//-----------------------------------------------
		public struct Point
		{
			public Double X, Y;
		}
		public Point Apoint { get; set; } = new Point();
		public Point Bpoint { get; set; } = new Point();
		public Point Cpoint { get; set; } = new Point();
		//-----------------------------------------------


		public Double Median { get; set; } = 0.0;

		public Boolean IsThisTriangle { get; private set; } = false;
		public Boolean IsThisRectangular { get; private set; } = false;

		/// <summary>
		/// Calculate Square of Triangle with Point's coordinates 
		/// </summary>
		/// <param name="a">Point A</param>
		/// <param name="b">Point B</param>
		/// <param name="c">Point C</param>
		/// <returns>Property Area</returns>
		public double CalcArea(Point a, Point b, Point c)
		{
			var SecondDeterminant = ((a.X - c.X) * (b.Y - c.Y) - (a.Y - c.Y) * (b.X - c.X));

			return Area = 1 / 2 * Math.Abs(SecondDeterminant);
		}

		/// <summary>
		/// Calculate Square of Triangle with custom values
		/// </summary>
		/// <param name="a">side A</param>
		/// <param name="b">side B</param>
		/// <param name="c">side C</param>
		/// <returns></returns>
		public override void CalcArea(double a = -1, double b = -1, double c = -1)
		{
			FixSides(ref a, ref b, ref c);
			Area = Math.Sqrt(Perimeter * (Perimeter - a) * (Perimeter - b) * (Perimeter - c));
		}

		/// <summary>
		/// Calculate Perimetr of Triangle with custom values
		/// </summary>
		/// <param name="a">side A</param>
		/// <param name="b">side B</param>
		/// <param name="c">side C</param>
		/// <returns></returns>
		public override void CalcPerimeter(double a = -1, double b = -1, double c = -1)
		{
			FixSides(ref a, ref b, ref c);
			Perimeter = (a + b + c) / 2;
		}

		/// <summary>
		/// Calculate Side by Coordinates Triangle ABC
		/// </summary>
		/// <param name="a">Point's of AC == Aside</param>
		/// <param name="b">Point's of AB == Bside</param>
		/// <param name="c">Point's of CB == Cside</param>
		public void CalcSideByPoint(Point a, Point b, Point c)
		{
			Aside = Math.Sqrt(Math.Pow(a.X - c.X, 2) + Math.Pow(a.Y - c.Y, 2));
			Bside = Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
			Cside = Math.Sqrt(Math.Pow(c.X - b.X, 2) + Math.Pow(c.Y - b.Y, 2));
		}

		/// <summary>
		/// Return All Sides and All Values of Triangle
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{

			StringBuilder Sbuilder = new StringBuilder();
			Sbuilder.AppendLine($"Is this Triangle = {IsThisTriangle}");
			Sbuilder.AppendLine($"Is Rectangual = {IsThisRectangular}\n");

			Sbuilder.AppendLine($"A = {Aside,4:##0.#0} sm\tAlpha = {Alpha:#0.##}");
			Sbuilder.AppendLine($"B = {Bside,4:##0.#0} sm\tBeta  = {Beta:#0.##}");
			Sbuilder.AppendLine($"C = {Cside,4:##0.#0} sm\tGamma = {Gamma:#0.##}");

			Sbuilder.AppendLine($"Median = {Median,-4:##0.##0} sm");
			Sbuilder.AppendLine($"Perimeter = {Perimeter:# ##0.###} sq/sm\tArea = {Area:# ##0.###} sq/sm");

			return Sbuilder.ToString();

		}

		//--------------------------------------- PRIVATE METHODS ---------------------------------
		#region --------------------------------------- PRIVATE METHODS ---------------------------------
		private void Initialize()
		{
			try
			{
				if (CheckTriangle())
				{
					this.InitializeEventHadler += new Init(() => CountSides = 3);
					this.InitializeEventHadler += new Init(CalcPerimeter);
					this.InitializeEventHadler += new Init(GetMedian);
					this.InitializeEventHadler += new Init(CalcAngles);
					this.InitializeEventHadler += new Init(CalcArea);
					this.InitializeEventHadler?.Invoke();
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Error runtime Initialize Action!", ex.GetBaseException());
			}
		}
		private void FixSides(ref double a, ref double b, ref double c)
		{
			if (a == -1) a = Aside;
			if (b == -1) b = Bside;
			if (c == -1) c = Cside;
		}
		private bool CheckTriangle()
		{
			Double flag = Aside + Bside;
			Double flag2 = Aside - Bside;
			//-----------------------
			if (Cside < flag && Cside > flag2)
			{
				return IsThisTriangle = true;
			}
			else
			{
				return IsThisTriangle = false;
			}
		}
		private bool CheckRectangular()
		{
			if (Alpha == 90 || Beta == 90 || Gamma == 90)
				return IsThisRectangular = true;

			return IsThisRectangular = false;
		}
		private void CalcAngles()
		{
			try
			{
				//----------------- A = (B^2 + C^2 - A^2) / 2BC
				var Avalue = (Math.Pow(Aside, 2) + Math.Pow(Cside, 2) - Math.Pow(Bside, 2)) / (2 * Aside * Cside);
				Alpha = Math.Acos(Avalue) * 180 / Math.PI;

				//----------------- B = (A^2 + C^2 - B^2) / 2AC
				var Bvalue = (Math.Pow(Aside, 2) + Math.Pow(Bside, 2) - Math.Pow(Cside, 2)) / (2 * Aside * Bside);
				Beta = Math.Acos(Bvalue) * 180 / Math.PI;

				//----------------- C = (A^2 + B^2 - C^2) / 2AB
				var Cvalue = (Math.Pow(Bside, 2) + Math.Pow(Cside, 2) - Math.Pow(Aside, 2)) / (2 * Cside * Bside);
				Gamma = Math.Acos(Cvalue) * 180 / Math.PI;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message, ex);
			}
		}

		/// <summary>
		/// Calculate Areat by Heron's formula
		/// </summary>
		private void CalcArea()
		{
			try
			{
				Area = Math.Sqrt(Perimeter * (Perimeter - Aside) * (Perimeter - Bside) * (Perimeter - Cside));
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message, ex);
			}
		}
		private void CalcPerimeter()
		{
			Perimeter = (Aside + Bside + Cside) / 2;
		}
		private void GetMedian()
		{
			try
			{
				//----------- 1/2 * SQRT( 2B^2 + 2C^2 - A^2) 
				Median = 1.0 / 2.0 * (Math.Sqrt(2 * (Aside * Aside) + (2 * Bside * Bside) - (Cside * Cside)));
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message, ex);
			}
		}
		#endregion
	}
}
