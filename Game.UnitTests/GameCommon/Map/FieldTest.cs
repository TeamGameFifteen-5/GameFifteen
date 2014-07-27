namespace Game.UnitTests.GameCommon.Map
{
	using Game.Common.Map;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System.Collections;
	using System.Diagnostics.CodeAnalysis;

	[TestClass]
	[ExcludeFromCodeCoverage]
	public class FieldTest
	{
		[TestMethod]
		public void GetEnumerator()
		{
			IEnumerable field = new Field();
			Assert.IsNotNull(field.GetEnumerator());
		}
	}
}