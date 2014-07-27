using Game.Common.Map;
using Game.Common.Map.Fillers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Game.UnitTests.GameCommon.Map.Fillers
{
	[TestClass]
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
			var originalPosition = field.Position.Clone();
			var defaultFieldFiller = new DefaultFieldFiller();
			defaultFieldFiller.Fill(field);
			Assert.AreNotEqual(originalPosition.X, field.Position.X);
			Assert.AreNotEqual(originalPosition.Y, field.Position.Y);
		}
	}
}