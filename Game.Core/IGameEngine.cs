namespace Game.Core
{
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
		/// Starts the main cycle.
		/// </summary>
		void Start();

		/// <summary>
		/// Exits the main cycle.
		/// </summary>
		void Exit();
	}
}