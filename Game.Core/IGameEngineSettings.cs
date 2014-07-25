﻿namespace Game.Core
{
	using Game.Common.GameOverCheckers;
	using Game.Common.Map;
	using Game.Common.Map.Movement;
	using Game.Common.Players;
	using Game.Common.Stats;
	using Game.Core.Actions.ActionProviders;
	using Game.UI;

	public interface IGameEngineSettings<TUIEngine, TStats>
		where TUIEngine : IUIEngine
	{
		TUIEngine UIEngine { get; }

		IField Field { get; }

		IPlayer Player { get; }

		TStats HighScores { get; }

		IActionProvider ActionProvider { get; }

		IMovement Movement { get; }

		IGameOverChecker GameOverChecker { get; }
	}
}