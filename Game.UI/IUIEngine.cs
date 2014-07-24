using Game.UI.IOProviders;
using System;

namespace Game.UI
{
	/// <summary>
	/// Interface for the UI Engine.
	/// </summary>
	public interface IUIEngine
	{
		/// <summary>
		/// The input provider.
		/// </summary>
		IInputProvider InputProvider { get; }

		/// <summary>
		/// Executes the game start action.
		/// </summary>
		void OnGameStart();

		/// <summary>
		/// Executes the game end action.
		/// </summary>
		void OnGameEnd();

		/// <summary>
		/// Executes the game exit action.
		/// </summary>
		void OnGameExit();

		/// <summary>
		/// Executes the game movement action.
		/// </summary>
		void OnGameMovement();

		/// <summary>
		/// Executes the game illegal move action.
		/// </summary>
		void OnGameIllegalMove();

		/// <summary>
		/// Executes the game illegal command action.
		/// </summary>
		void OnGameIllegalCommand();

		/// <summary>
		/// Executes the game invalidate action.
		/// </summary>
		void OnGameCustomEvent(Object eventObject);
	}
}