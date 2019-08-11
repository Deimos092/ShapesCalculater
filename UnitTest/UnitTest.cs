using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Text;
using ShapesCalculater.Shapes;


namespace UnitTest
{
	[TestClass]
	public class UnitTest
	{
		public int Count { get => 1000; }

		[TestMethod]
		public void TriangleTest()
		{
			StringBuilder builder = new StringBuilder();
			Random rnd = new Random();

			double a, b, c;
			Triangle triangle;
			for (int i = 0; i < Count; i++)
			{
				a = rnd.NextDouble() * 100.0;
				b = rnd.NextDouble() * 100.0;
				c = rnd.NextDouble() * 100.0;

				triangle = new Triangle(a, b, c);
				builder.AppendLine($"{DateTime.Now.ToString("dd.MM.yyyy")} {DateTime.Now.ToLongTimeString()}");
				builder.AppendLine($"Is this Triangle : {triangle.IsThisTriangle}");
				builder.AppendLine(triangle.ToString());
				builder.AppendLine(new string('-', 30));
			}
			File.AppendAllTextAsync(Path.Combine(Directory.GetCurrentDirectory(), "TriangleTest.txt"), builder.ToString());
		}
	}
}
