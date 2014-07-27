﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Game.UI.Renderers;
using Game.UI.Windows.Console.IOProviders;
using System.Diagnostics.CodeAnalysis;

namespace Game.UnitTests.GameUI.Renderers
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class DefaultStartRendererTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateWithNull1()
        {
            new DefaultStartRenderer<ConsoleIOProvider>().Render(null);
        }
    }
}