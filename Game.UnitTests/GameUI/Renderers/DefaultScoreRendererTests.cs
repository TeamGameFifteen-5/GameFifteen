namespace Game.UnitTests.GameUI.Renderers
{
    using Game.Common.Stats;
    using Game.UI.Renderers;
    using Game.UI.Windows.Console.IOProviders;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Diagnostics.CodeAnalysis;

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
