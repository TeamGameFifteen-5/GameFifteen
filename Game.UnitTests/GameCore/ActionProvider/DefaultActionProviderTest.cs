namespace Game.UnitTests.GameCore.ActionProvider
{
	using Game.Common;
	using Game.Core.Actions;
	using Game.Core.Actions.ActionProviders;
	using Game.Core.Actions.ActionReceiver;
	using Game.UnitTests.GameCore.SampleGameEngine;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	using System.IO;

	[TestClass]
	public class DefaultActionProviderTest
	{
		[TestMethod]
		public void CreateAction()
		{
			var defaultActionProvider = new DefaultActionProvider();
			var defaultActionReceiver = new DefaultActionReceiver(FakeGameEngine.Engine);
			IGameAction gameAction = defaultActionProvider.GetAction(ActionType.Get(DefaultActionTypes.Unmapped), defaultActionReceiver);

			byte[] buffer = new byte[102400];
			using (var memoryStream = new MemoryStream(buffer))
			using (var streamWriter = new StreamWriter(memoryStream))
			{
				Console.SetOut(streamWriter);

				gameAction.Execute();

				memoryStream.Seek(0, SeekOrigin.Begin);
				using (var streamReader = new StreamReader(memoryStream))
				{
					var result = streamReader.ReadLine();
					Assert.AreEqual("Illegal command!", result);
				}
			}
		}
	}
}