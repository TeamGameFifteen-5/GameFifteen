namespace Game.UnitTests.GameUI.Renderers
{
    using Game.UI.Renderers;
    using Game.UI.Windows.Console.IOProviders;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Diagnostics.CodeAnalysis;

    [TestClass]
    [ExcludeFromCodeCoverage]
    public class DefaultIllegalCommandRendererTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateWithNull()
        {
            new DefaultIllegalCommandRenderer<ConsoleIOProvider>().Render(null);
        }

        [TestMethod]
        public void IllegalCommandRendererCorrectExecution()
        {
            new DefaultIllegalCommandRenderer<ConsoleIOProvider>().Render(new ConsoleIOProvider());
        }
    }
}
