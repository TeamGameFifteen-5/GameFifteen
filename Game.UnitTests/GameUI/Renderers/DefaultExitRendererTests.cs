namespace Game.UnitTests.GameUI.Renderers
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Game.UI.Renderers;
    using Game.UI.Windows.Console.IOProviders;

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
