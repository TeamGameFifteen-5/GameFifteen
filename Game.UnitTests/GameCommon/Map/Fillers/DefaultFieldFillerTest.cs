namespace Game.UnitTests.GameCommon.Map.Fillers
{
	using Game.Common;
	using Game.Common.Map;
	using Game.Common.Map.Fillers;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Diagnostics.CodeAnalysis;

	[TestClass]
	[ExcludeFromCodeCoverage]
	public class DefaultFieldFillerTest
	{
		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void FillWithNull()
		{
			var defaultFieldFiller = new DefaultFieldFiller();
			defaultFieldFiller.Fill(null);
		}

		[TestMethod]
		public void FillRepositioningOfFieldPosition()
		{
			var field = new Field();
			field.RandomizeField(Difficulty.Hard);

			field.Position = new Position(0, 0);
			var originalPosition = field.Position.Clone();
			var defaultFieldFiller = new DefaultFieldFiller();
			defaultFieldFiller.Fill(field);

			Assert.AreNotEqual(originalPosition.X, field.Position.X);
			Assert.AreNotEqual(originalPosition.Y, field.Position.Y);
		}
	}
}