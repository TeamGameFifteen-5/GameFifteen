namespace Game.UnitTests.GameUI.Renderers
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Game.UI.Renderers;
    using Game.UI.Windows.Console.IOProviders;
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
    }
}
