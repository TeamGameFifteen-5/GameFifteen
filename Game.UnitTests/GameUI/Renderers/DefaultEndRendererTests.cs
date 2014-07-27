namespace Game.UnitTests.GameUI.Renderers
{
	using Game.UI.Renderers;
	using Game.UI.Windows.Console.IOProviders;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Diagnostics.CodeAnalysis;

	[TestClass]
	[ExcludeFromCodeCoverage]
	public class DefaultEndRendererTests
	{
		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void CreateWithNull1()
		{
			new DefaultEndRenderer<ConsoleIOProvider>().Render(null, null);
		}

		//TODO: Add tests
	}
}