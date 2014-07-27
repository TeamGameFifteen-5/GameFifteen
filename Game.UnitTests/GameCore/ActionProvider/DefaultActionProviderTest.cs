namespace Game.UnitTests.GameCore.ActionProvider
{
	using Game.Common;
	using Game.Core.Actions;
	using Game.Core.Actions.ActionProviders;
	using Game.Core.Actions.ActionReceiver;
	using Game.UnitTests.GameCore.SampleGameEngine;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.Diagnostics.CodeAnalysis;
	using System.IO;
	using System.Linq;
	using System.Text;

	[TestClass]
	public class DefaultActionProviderTest
	{
		[TestMethod]
		[ExcludeFromCodeCoverage]
		public void CreateAction()
		{
			var defaultActionProvider = new DefaultActionProvider();
			var defaultActionReceiver = new DefaultActionReceiver(FakeGameEngine.Engine);
			IGameAction gameAction = defaultActionProvider.GetAction(ActionType.Get(DefaultActionTypes.Unmapped), defaultActionReceiver);

			using (var memoryStream = new MemoryStream(1000))
			using (var streamWriter = new StreamWriter(memoryStream))
			{
				Console.SetOut(streamWriter);

				gameAction.Execute();
				streamWriter.Flush();

				var result = Encoding.ASCII.GetString(memoryStream.ToArray())
					.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
					.Last();
				Assert.AreEqual("Illegal command!", result);
			}
		}
	}
}