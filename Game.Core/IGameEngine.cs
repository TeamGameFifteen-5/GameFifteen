namespace Game.Core
{
	using Game.Common.GameOverCheckers;
	using Game.Common.Map;
	using Game.Common.Players;
	using Game.Common.Stats;
	using Game.UI.IOProviders;
	using System;

	/// <summary>
	/// Interface for Game Engine.
	/// </summary>
	public interface IGameEngine
	{
		/// <summary>
		/// Event queue for all listeners interested in GameStart events.
		/// </summary>
		event Action GameStart;

		/// <summary>
		/// Event queue for all listeners interested in GameEnd events.
		/// </summary>
		event Action GameEnd;

		/// <summary>
		/// Event queue for all listeners interested in GameExit events.
		/// </summary>
		event Action GameExit;

		/// <summary>
		/// Event queue for all listeners interested in GameCustomEvent events.
		/// </summary>
		event CustomEventHandler GameCustomEvent;

		/// <summary>
		/// Gets the input provider.
		/// </summary>
		/// <value>
		/// The input provider.
		/// </value>
		IInputProvider InputProvider { get; }

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
		IIntegerStats HighScores { get; }

		/// <summary>
		/// Gets the game over checker.
		/// </summary>
		/// <value>
		/// The game over checker.
		/// </value>
		IGameOverChecker GameOverChecker { get; }

		/// <summary>
		/// Starts the main cycle.
		/// </summary>
		void Start();

		/// <summary>
		/// Exits the main cycle.
		/// </summary>
		void Exit();
	}
}