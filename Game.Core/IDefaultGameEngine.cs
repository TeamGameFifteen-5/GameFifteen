namespace Game.Core
{
	using Game.Common;
	using Game.UI;
	using System;

	/// <summary>
	/// Interface for default game engine.
	/// </summary>
	/// <seealso cref="IGameEngine"/>
	/// <seealso cref="IMoveable"/>
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
		/// Gets the engine.
		/// </summary>
		/// <value>
		/// The user interface engine.
		/// </value>
		IDefaultUIEngine UIEngine { get; }

		/// <summary>
		/// Gets the moveable entity.
		/// </summary>
		/// <value>
		/// The moveable entity.
		/// </value>
		IMoveable MoveableEntity { get; }

		/// <summary>
		/// Shows the score.
		/// </summary>
		void ShowScore();

		/// <summary>
		/// Restart game.
		/// </summary>
		void StartGame();

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