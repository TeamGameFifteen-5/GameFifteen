namespace Game.UnitTests.GameUI.Renderers
{
    using Game.Common.Map;
    using Game.UI.Renderers;
    using Game.UI.Windows.Console.IOProviders;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Diagnostics.CodeAnalysis;

    [TestClass]
    [ExcludeFromCodeCoverage]
    public class DefaultFieldRendererTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateWithNullOutputProvider()
        {
            new DefaultFieldRenderer<ConsoleIOProvider>().Render(null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateWithField()
        {
            new DefaultFieldRenderer<ConsoleIOProvider>().Render(new ConsoleIOProvider(), null);
        }

        [TestMethod]
        public void FieldRendererCorrectExecution()
        {
            new DefaultFieldRenderer<ConsoleIOProvider>().Render(new ConsoleIOProvider(), new Field());
        }
    }
}
