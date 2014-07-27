﻿namespace Game.UnitTests.GameUI.Renderers
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Game.UI.Renderers;
    using Game.UI.Windows.Console.IOProviders;
    using System.Diagnostics.CodeAnalysis;
    using Game.Common.Map;

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
