namespace Game.Core
{
	using Game.Common.GameOverCheckers;
using Game.Common.Map;
using Game.Common.Map.Movement;
using Game.Common.Players;
using Game.Common.Stats;
using Game.Core.Actions.ActionProviders;
using Game.UI;

	public interface IGameEngineSettings
	{
		IUIEngine UIEngine { get; }

		IField Field { get; }

		IPlayer Player { get; }

		IHighScores HighScores { get; }

		IActionProvider ActionProvider { get; }

		IMovement Movement { get; }

		IGameOverChecker GameOverChecker { get; }
	}
}