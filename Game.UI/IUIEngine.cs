namespace Game.UI
{
    using System;
    using Game.UI.IOProviders;

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
		/// Executes the game invalidate action.
		/// </summary>
		void OnGameCustomEvent(object eventObject);
	}
}