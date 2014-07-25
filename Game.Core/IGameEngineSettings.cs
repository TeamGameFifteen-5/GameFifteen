namespace Game.Core
{
	using Game.Common;
	using Game.Common.GameOverCheckers;
	using Game.Common.Map;
	using Game.Common.Map.Movement;
	using Game.Common.Players;
	using Game.Core.Actions.ActionProviders;
	using Game.UI;

	public interface IGameEngineSettings<TUIEngine, TStats>
		where TUIEngine : IUIEngine
	{
		Difficulty Difficulty { get; }

		TUIEngine UIEngine { get; }

		IField Field { get; }

		IPlayer Player { get; }

		TStats HighScores { get; }

		IActionProvider ActionProvider { get; }

		IMovement Movement { get; }

		IGameOverChecker GameOverChecker { get; }
	}
}