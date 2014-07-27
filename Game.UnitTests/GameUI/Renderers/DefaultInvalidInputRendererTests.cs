namespace Game.UnitTests.GameUI.Renderers
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Diagnostics.CodeAnalysis;
    using Game.UI.Renderers;
    using Game.UI.Windows.Console.IOProviders;

    [TestClass]
    [ExcludeFromCodeCoverage]
    public class DefaultInvalidInputRendererTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateWithNull1()
        {
            new DefaultInvalidInputRenderer<ConsoleIOProvider>().Render(null);
        }

        [TestMethod]
        public void InvalidInputRendererCorrectExecution()
        {
            new DefaultInvalidInputRenderer<ConsoleIOProvider>().Render(new ConsoleIOProvider());
        }
    }
}
