namespace Game.UnitTests.GameUI.Renderers
{
    using Game.UI.Renderers;
    using Game.UI.Windows.Console.IOProviders;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Diagnostics.CodeAnalysis;

    [TestClass]
    [ExcludeFromCodeCoverage]
    public class DefaultHelpDisplayRendererTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateWithNull()
        {
            new DefaultHelpDisplayRenderer<ConsoleIOProvider>().Render(null);
        }

        [TestMethod]
        public void HelpDisplayRendererCorrectExecution()
        {
            new DefaultHelpDisplayRenderer<ConsoleIOProvider>().Render(new ConsoleIOProvider());
        }
    }
}
