namespace Game.UI
{
	using Game.Common;
	using Game.UI.IOProviders;

	/// <summary>
	/// Interface for the UI Engine.
	/// </summary>
	public interface IUIEngine
	{
		/// <summary>
		/// Gets the difficulty.
		/// </summary>
		/// <value>
		/// The difficulty.
		/// </value>
		Difficulty Difficulty { get; }

		/// <summary>
		/// The input provider.
		/// </summary>
		/// <value>
		/// The input provider.
		/// </value>
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
		/// <param name="eventObject">The event object.</param>
		void OnGameCustomEvent(object eventObject);
	}
}