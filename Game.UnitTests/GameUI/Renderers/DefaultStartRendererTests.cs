namespace Game.UnitTests.GameUI.Renderers
{
    using Game.UI.Renderers;
    using Game.UI.Windows.Console.IOProviders;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Diagnostics.CodeAnalysis;

    [TestClass]
    [ExcludeFromCodeCoverage]
    public class DefaultStartRendererTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateWithNull()
        {
            new DefaultStartRenderer<ConsoleIOProvider>().Render(null);
        }

        [TestMethod]
        public void StartRendererCorrectExecution()
        {
            new DefaultStartRenderer<ConsoleIOProvider>().Render(new ConsoleIOProvider());
        }
    }
}
