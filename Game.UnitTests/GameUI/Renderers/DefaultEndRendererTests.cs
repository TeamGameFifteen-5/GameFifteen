namespace Game.UnitTests.GameUI.Renderers
{
    using Game.Common.Players;
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
        public void CreateWithNullOutputProvider()
		{
			new DefaultEndRenderer<ConsoleIOProvider>().Render(null, null);
		}

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateWithPlayer()
        {
            new DefaultEndRenderer<ConsoleIOProvider>().Render(new ConsoleIOProvider(), null);
        }

        [TestMethod]
        public void IllegalMoveRendererCorrectExecution()
        {
            new DefaultEndRenderer<ConsoleIOProvider>().Render(new ConsoleIOProvider(), new Player());
        }
	}
}