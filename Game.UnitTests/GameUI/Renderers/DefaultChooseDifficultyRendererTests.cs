namespace Game.UnitTests.GameUI.Renderers
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Game.UI.Renderers;
    using Game.UI.Windows.Console.IOProviders;

    [TestClass]
    public class DefaultChooseDifficultyRendererTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateWithNull1()
        {
            new DefaultChooseDifficultyRenderer<ConsoleIOProvider>().Render(null);
        }
    }
}
