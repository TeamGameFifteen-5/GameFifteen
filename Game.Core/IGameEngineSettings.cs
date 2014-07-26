namespace Game.Core
{
	using Game.Common.GameOverCheckers;
	using Game.Common.Map;
	using Game.Common.Map.Movement;
	using Game.Common.Players;
	using Game.Core.Actions.ActionProviders;
	using Game.UI;

	/// <summary>
	/// Interface for game engine settings.
	/// </summary>
	/// <typeparam name="TUIEngine">Type of the tui engine.</typeparam>
	/// <typeparam name="TStats">   Type of the stats.</typeparam>
	public interface IGameEngineSettings<TUIEngine, TStats>
		where TUIEngine : IUIEngine
	{
		/// <summary>
		/// Gets the engine.
		/// </summary>
		/// <value>
		/// The user interface engine.
		/// </value>
		TUIEngine UIEngine { get; }

		/// <summary>
		/// Gets the field.
		/// </summary>
		/// <value>
		/// The field.
		/// </value>
		IField Field { get; }

		/// <summary>
		/// Gets the player.
		/// </summary>
		/// <value>
		/// The player.
		/// </value>
		IPlayer Player { get; }

		/// <summary>
		/// Gets the high scores.
		/// </summary>
		/// <value>
		/// The high scores.
		/// </value>
		TStats HighScores { get; }

		/// <summary>
		/// Gets the action provider.
		/// </summary>
		/// <value>
		/// The action provider.
		/// </value>
		IActionProvider ActionProvider { get; }

		/// <summary>
		/// Gets the movement.
		/// </summary>
		/// <value>
		/// The movement.
		/// </value>
		IMovement Movement { get; }

		/// <summary>
		/// Gets the game over checker.
		/// </summary>
		/// <value>
		/// The game over checker.
		/// </value>
		IGameOverChecker GameOverChecker { get; }
	}
}