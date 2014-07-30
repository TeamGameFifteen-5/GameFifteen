namespace Game.UnitTests.GameUI.Renderers
{
    using Game.UI.Renderers;
    using Game.UI.Windows.Console.IOProviders;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Diagnostics.CodeAnalysis;

    [TestClass]
    [ExcludeFromCodeCoverage]
    public class DefaultIllegalMoveRendererTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateWithNull()
        {
            new DefaultIllegalMoveRenderer<ConsoleIOProvider>().Render(null);
        }

        [TestMethod]
        public void IllegalMoveRendererCorrectExecution()
        {
            new DefaultIllegalMoveRenderer<ConsoleIOProvider>().Render(new ConsoleIOProvider());
        }
    }
}
