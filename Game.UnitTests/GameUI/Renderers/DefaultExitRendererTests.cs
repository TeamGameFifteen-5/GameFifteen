namespace Game.UnitTests.GameUI.Renderers
{
    using Game.UI.Renderers;
    using Game.UI.Windows.Console.IOProviders;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Diagnostics.CodeAnalysis;

    [TestClass]
    [ExcludeFromCodeCoverage]
    public class DefaultExitRendererTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateWithNull()
        {
            new DefaultExitRenderer<ConsoleIOProvider>().Render(null);
        }

        [TestMethod]
        public void ExitRendererCorrectExecution()
        {
            new DefaultExitRenderer<ConsoleIOProvider>().Render(new ConsoleIOProvider());
        }
    }
}
