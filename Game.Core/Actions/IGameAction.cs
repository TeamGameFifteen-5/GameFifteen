namespace Game.Core.Actions
{
	/// <summary>
	/// Interface for game action.
	/// </summary>
	public interface IGameAction
	{
		/// <summary>
		/// Executes the action.
		/// </summary>
		void Execute();

		/// <summary>
		/// Undo the action.
		/// </summary>
		void UnExecute();
	}
}