namespace Game.UnitTests.GameUI.Renderers
{
	using Game.UI.Renderers;
	using Game.UI.Windows.Console.IOProviders;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Diagnostics.CodeAnalysis;

	[TestClass]
	[ExcludeFromCodeCoverage]
	public class DefaultChooseDifficultyRendererTests
	{
		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void CreateWithNull()
		{
			new DefaultChooseDifficultyRenderer<ConsoleIOProvider>().Render(null);
		}

        [TestMethod]
        public void ChooseDificultyCorrectExecution()
        {
            new DefaultChooseDifficultyRenderer<ConsoleIOProvider>().Render(new ConsoleIOProvider());
        }
	}
}