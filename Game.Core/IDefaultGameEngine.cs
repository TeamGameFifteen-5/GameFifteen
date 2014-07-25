namespace Game.Core
{
	using Game.Common;
	using System;

	public interface IDefaultGameEngine : IGameEngine, IMoveable
	{
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
		/// Shows the score.
		/// </summary>
		void ShowScore();

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

		/// <summary>
		/// Invalidates the field.
		/// </summary>
		void FieldInvalidate();
	}
}