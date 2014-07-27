namespace Game.UnitTests.GameCommon.Utils
{
	using System;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System.Diagnostics.CodeAnalysis;
	using Game.Common.Utils;

	[TestClass]
	[ExcludeFromCodeCoverage]
	public class DefaultRandomGeneratorTest
	{
		[TestMethod]
		public void RandomGenerateNumbers()
		{
			var defaultRandomGenerator = DefaultRandomGenerator.Instance;
			defaultRandomGenerator.Next();
			defaultRandomGenerator.Next(int.MaxValue);
			defaultRandomGenerator.Next(int.MinValue, int.MaxValue);
			defaultRandomGenerator.NextDouble();
		}
	}
}
