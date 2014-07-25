namespace Game.Core
{
    using Game.Common;
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
		/// Event queue for all listeners interested in GameMovement events.
		/// </summary>
		event Action GameMovement;

		/// <summary>
		/// Event queue for all listeners interested in GameShowScore events.
		/// </summary>
		event Action GameShowScore;

		/// <summary>
		/// Event queue for all listeners interested in GameIllegalMove events.
		/// </summary>
		event Action GameIllegalMove;

		/// <summary>
		/// Event queue for all listeners interested in GameIllegalCommand events.
		/// </summary>
		event Action GameIllegalCommand;

		/// <summary>
		/// Event queue for all listeners interested in GameCustomEvent events.
		/// </summary>
		event CustomEventHandler GameCustomEvent;

		/// <summary>
		/// Starts the main cycle.
		/// </summary>
		void Start();

		/// <summary>
		/// Moves to the given direction.
		/// </summary>
		/// <param name="direction">The direction.</param>
		void Move(Direction direction);

		/// <summary>
		/// Shows the score.
		/// </summary>
		void ShowScore();

		/// <summary>
		/// Exits this object.
		/// </summary>
		void Exit();

		/// <summary>
		/// Restart game.
		/// </summary>
		void RestartGame();

		/// <summary>
		/// Illegal move.
		/// </summary>
		void IllegalMove();

		/// <summary>
		/// Illegal command.
		/// </summary>
		void IllegalCommand();

		void Invalidate();
	}
}