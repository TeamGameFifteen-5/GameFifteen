namespace Game.UnitTests.GameUI.Renderers
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Game.UI.Renderers;
    using Game.UI.Windows.Console.IOProviders;
    using System.Diagnostics.CodeAnalysis;
    using Game.Common.Stats;

    [TestClass]
    [ExcludeFromCodeCoverage]
    public class DefaultScoreRendererTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateWithNullOutputProvider()
        {
            new DefaultScoreRenderer<ConsoleIOProvider>().Render(null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateWithStats()
        {
            new DefaultScoreRenderer<ConsoleIOProvider>().Render(new ConsoleIOProvider(), null);
        }

        [TestMethod]
        public void ScoreRendererCorrectExecution()
        {
            new DefaultScoreRenderer<ConsoleIOProvider>().Render(new ConsoleIOProvider(), InFileScores.Instance);
        }
    }
}
