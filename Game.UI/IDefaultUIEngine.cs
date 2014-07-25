namespace Game.UI
{
	/// <summary>
	/// Interface for the UI Engine.
	/// </summary>
	public interface IDefaultUIEngine : IUIEngine
	{
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
	}
}